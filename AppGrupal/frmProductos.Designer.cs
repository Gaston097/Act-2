namespace AppGrupal
{
    partial class frmProductos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblListarProductos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pboMenu = new System.Windows.Forms.PictureBox();
            this.lblSalir = new System.Windows.Forms.Label();
            this.lblNuevo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblListarProductos
            // 
            this.lblListarProductos.AutoSize = true;
            this.lblListarProductos.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListarProductos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblListarProductos.Location = new System.Drawing.Point(159, 124);
            this.lblListarProductos.Name = "lblListarProductos";
            this.lblListarProductos.Size = new System.Drawing.Size(226, 34);
            this.lblListarProductos.TabIndex = 1;
            this.lblListarProductos.Text = "Listar Productos";
            this.lblListarProductos.Click += new System.EventHandler(this.lblListarProductos_Click);
            this.lblListarProductos.MouseLeave += new System.EventHandler(this.lblListarProductos_MouseLeave);
            this.lblListarProductos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblListarProductos_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumPurple;
            this.panel1.Controls.Add(this.pboMenu);
            this.panel1.Controls.Add(this.lblSalir);
            this.panel1.Controls.Add(this.lblNuevo);
            this.panel1.Controls.Add(this.lblListarProductos);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(37, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 369);
            this.panel1.TabIndex = 2;
            // 
            // pboMenu
            // 
            this.pboMenu.Location = new System.Drawing.Point(236, 27);
            this.pboMenu.Name = "pboMenu";
            this.pboMenu.Size = new System.Drawing.Size(79, 76);
            this.pboMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboMenu.TabIndex = 4;
            this.pboMenu.TabStop = false;
            // 
            // lblSalir
            // 
            this.lblSalir.AutoSize = true;
            this.lblSalir.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSalir.Location = new System.Drawing.Point(145, 238);
            this.lblSalir.MaximumSize = new System.Drawing.Size(256, 34);
            this.lblSalir.MinimumSize = new System.Drawing.Size(256, 34);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(256, 34);
            this.lblSalir.TabIndex = 3;
            this.lblSalir.Text = "Salir del Programa";
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            this.lblSalir.MouseLeave += new System.EventHandler(this.lblSalir_MouseLeave);
            this.lblSalir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSalir_MouseMove);
            // 
            // lblNuevo
            // 
            this.lblNuevo.AutoSize = true;
            this.lblNuevo.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNuevo.Location = new System.Drawing.Point(159, 179);
            this.lblNuevo.Name = "lblNuevo";
            this.lblNuevo.Size = new System.Drawing.Size(223, 34);
            this.lblNuevo.TabIndex = 2;
            this.lblNuevo.Text = "Nuevo Producto";
            this.lblNuevo.Click += new System.EventHandler(this.lblNuevo_Click);
            this.lblNuevo.MouseLeave += new System.EventHandler(this.lblNuevo_MouseLeave);
            this.lblNuevo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblNuevo_MouseMove);
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(615, 427);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(635, 470);
            this.MinimumSize = new System.Drawing.Size(635, 470);
            this.Name = "frmProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Productos";
            this.Load += new System.EventHandler(this.frmProductos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblListarProductos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNuevo;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.PictureBox pboMenu;
    }
}

