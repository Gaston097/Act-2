namespace AppGrupal
{
    partial class frmModificarProductos
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
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblObservaciones.Location = new System.Drawing.Point(14, 169);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(141, 25);
            this.lblObservaciones.TabIndex = 8;
            this.lblObservaciones.Text = "Observaciones";
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPrecioVenta.Location = new System.Drawing.Point(14, 132);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(124, 25);
            this.lblPrecioVenta.TabIndex = 7;
            this.lblPrecioVenta.Text = "Precio Venta";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.Location = new System.Drawing.Point(14, 96);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(116, 25);
            this.lblDescripcion.TabIndex = 6;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.Location = new System.Drawing.Point(14, 60);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(77, 25);
            this.lblCodigo.TabIndex = 5;
            this.lblCodigo.Text = "Codigo";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtObservaciones.Location = new System.Drawing.Point(19, 197);
            this.txtObservaciones.MaxLength = 255;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(567, 117);
            this.txtObservaciones.TabIndex = 12;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecioVenta.Location = new System.Drawing.Point(145, 132);
            this.txtPrecioVenta.MaxLength = 13;
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(114, 25);
            this.txtPrecioVenta.TabIndex = 11;
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVenta_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescripcion.Location = new System.Drawing.Point(144, 96);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(441, 25);
            this.txtDescripcion.TabIndex = 10;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(144, 60);
            this.txtCodigo.MaxLength = 20;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(441, 25);
            this.txtCodigo.TabIndex = 9;
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(466, 330);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(119, 40);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(222, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(157, 40);
            this.lblTitulo.TabIndex = 14;
            this.lblTitulo.Text = "Productos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmModificarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 386);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblCodigo);
            this.Name = "frmModificarProductos";
            this.Text = "frmModificarProductos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label lblTitulo;
    }
}