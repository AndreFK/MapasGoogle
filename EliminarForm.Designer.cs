namespace MapasGoogle
{
    partial class EliminarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ID_lbl = new System.Windows.Forms.Label();
            this.ID_eliminarBX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Eliminar_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ID_lbl
            // 
            this.ID_lbl.AutoSize = true;
            this.ID_lbl.Location = new System.Drawing.Point(71, 55);
            this.ID_lbl.Name = "ID_lbl";
            this.ID_lbl.Size = new System.Drawing.Size(24, 13);
            this.ID_lbl.TabIndex = 0;
            this.ID_lbl.Text = "ID: ";
            this.ID_lbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // ID_eliminarBX
            // 
            this.ID_eliminarBX.Location = new System.Drawing.Point(101, 52);
            this.ID_eliminarBX.Name = "ID_eliminarBX";
            this.ID_eliminarBX.Size = new System.Drawing.Size(125, 20);
            this.ID_eliminarBX.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese ID del aeropuerto a eliminar";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Eliminar_btn
            // 
            this.Eliminar_btn.Location = new System.Drawing.Point(120, 94);
            this.Eliminar_btn.Name = "Eliminar_btn";
            this.Eliminar_btn.Size = new System.Drawing.Size(75, 23);
            this.Eliminar_btn.TabIndex = 3;
            this.Eliminar_btn.Text = "Eliminar";
            this.Eliminar_btn.UseVisualStyleBackColor = true;
            this.Eliminar_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // EliminarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 143);
            this.Controls.Add(this.Eliminar_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ID_eliminarBX);
            this.Controls.Add(this.ID_lbl);
            this.Name = "EliminarForm";
            this.Text = "Eliminar Aeropuerto";
            this.Load += new System.EventHandler(this.EliminarForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ID_lbl;
        private System.Windows.Forms.TextBox ID_eliminarBX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Eliminar_btn;
    }
}