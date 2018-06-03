using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using System.Runtime.InteropServices;

namespace MapasGoogle
{
    public partial class Form1 : Form
    {
        [DllImport("C:\\Users\\Usuario\\Desktop\\Google\\Airport_DLL_BACKEND\\Debug\\Airport_DLL_BACKEND.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Creat_Airport(string name, double lat, double lon);
      

        [DllImport("C:\\Users\\Usuario\\Desktop\\Google\\Airport_DLL_BACKEND\\Debug\\Airport_DLL_BACKEND.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Read_Airport(StringBuilder buff, int pos);

        [DllImport("C:\\Users\\Usuario\\Desktop\\Google\\Airport_DLL_BACKEND\\Debug\\Airport_DLL_BACKEND.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Lenght_File();

        [DllImport("C:\\Users\\Usuario\\Desktop\\Google\\Airport_DLL_BACKEND\\Debug\\Airport_DLL_BACKEND.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Delete_Airport(string name);

        [DllImport("C:\\Users\\Usuario\\Desktop\\Google\\Airport_DLL_BACKEND\\Debug\\Airport_DLL_BACKEND.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Update_Airport(string name, string Nname, double lat, double lon);

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dt;

        int filaSeleccionada = 0;
        double LatInicial = 15.561373;
        double LngInicial = -88.0243623;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dt.Columns.Add(new DataColumn("Lat", typeof(double)));
            dt.Columns.Add(new DataColumn("Lng", typeof(double)));

            //dt.Rows.Add("Ubicacion1", LatInicial, LngInicial);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;

            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            //marcador
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.green);
            markerOverlay.Markers.Add(marker);

            //tooltip
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Ubicacion: \n Latitud: {0} \n Longitud: {1}", LatInicial, LngInicial);
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Char delimit = ';';
            for (int i = 0; i < Lenght_File(); i++)
            {
                StringBuilder st = new StringBuilder(1000);
                Read_Airport(st, (i + 1));
                String[] elements = st.ToString().Split(delimit);

                dt.Rows.Add(elements[0], elements[1], elements[2]);

            }

        }

        private void SeleccionarRegistro(object sender, DataGridViewCellEventArgs e)
        {
            filaSeleccionada = e.RowIndex;
            txtDescipcion.Text = dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString();
            txtLatitud.Text = dataGridView1.Rows[filaSeleccionada].Cells[1].Value.ToString();
            txtLongitud.Text = dataGridView1.Rows[filaSeleccionada].Cells[2].Value.ToString();
            marker.Position = new PointLatLng(Convert.ToDouble(txtLatitud.Text), Convert.ToDouble(txtLongitud.Text));
            gMapControl1.Position = marker.Position;
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

            txtLatitud.Text = lat.ToString();
            txtLongitud.Text = lng.ToString();
            txtDescipcion.Text = "";

            marker.Position = new PointLatLng(lat, lng);
            marker.ToolTipText = string.Format("Ubicacion: \n Latitud: {0} \n Longitud: {1}", lat, lng);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

                Creat_Airport(txtDescipcion.Text, Convert.ToDouble(txtLatitud.Text), Convert.ToDouble(txtLongitud.Text));
                dt.Rows.Add(txtDescipcion.Text, txtLatitud.Text, txtLongitud.Text);
                txtDescipcion.Text = "";
                txtLatitud.Text = "";
                txtLongitud.Text = "";


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarForm eForm = new EliminarForm();
            eForm.Show();
            /*
            Delete_Airport(txtDescipcion.Text);
            dataGridView1.Rows.RemoveAt(filaSeleccionada);
            txtDescipcion.Text = "";
            txtLatitud.Text = "";
            txtLongitud.Text = "";
            */  
        }

        private void btnPolygon_Click(object sender, EventArgs e)
        {
            

            GMapOverlay Poligono = new GMapOverlay("POligono");
            List<PointLatLng> puntos = new List<PointLatLng>();

            double lng, lat;
            for(int filas = 0; filas < dataGridView1.Rows.Count -1 ; filas++)
            {
                lat = Convert.ToDouble(dataGridView1.Rows[filas].Cells[1].Value);
                lng = Convert.ToDouble(dataGridView1.Rows[filas].Cells[2].Value);
                puntos.Add(new PointLatLng(lat, lng));

            }
            GMapPolygon poligonoPuntos = new GMapPolygon(puntos, "Poligono");
            Poligono.Polygons.Add(poligonoPuntos);
            gMapControl1.Overlays.Add(Poligono);

            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            GMapOverlay Ruta = new GMapOverlay("CapaRuta");
            List<PointLatLng> puntos = new List<PointLatLng>();

            double lng, lat;
            for (int filas = 0; filas < dataGridView1.Rows.Count; filas++)
            {
                lat = Convert.ToDouble(dataGridView1.Rows[filas].Cells[1].Value);
                lng = Convert.ToDouble(dataGridView1.Rows[filas].Cells[2].Value);
                puntos.Add(new PointLatLng(lat, lng));

            }
            GMapRoute PuntosRuta = new GMapRoute(puntos, "Ruta");
            Ruta.Routes.Add(PuntosRuta);
            gMapControl1.Overlays.Add(Ruta);

            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
        }

        private void POINTBUTTON_Click(object sender, EventArgs e)
        {
            
            //for (int filas = 0; filas < dataGridView1.Rows.Count; filas++)
            //{
            //    lat = Convert.ToDouble(dataGridView1.Rows[filas].Cells[1].Value);
            //    lng = Convert.ToDouble(dataGridView1.Rows[filas].Cells[2].Value);
            //    marker.Position = new PointLatLng(lat, lng);
            //    gMapControl1.Position = marker.Position;

            //}
        }

        private void DESTINO_BT_Click(object sender, EventArgs e)
        {
            UpdateForm uForm = new UpdateForm();
            uForm.Show();
            /*
            Update_Airport(txtDescipcion.Text, TxTupdate.Text, Convert.ToDouble(txtLatitud.Text), Convert.ToDouble(txtLongitud.Text));
            txtDescipcion.Text = "";
            txtLatitud.Text = "";
            txtLongitud.Text = "";
            TxTupdate.Text = "";
            */    
    }

        
    }
}
