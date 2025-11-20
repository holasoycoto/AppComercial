namespace AppComercial.Windows
{
    partial class FrmPrincipal
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
            btnMarcas = new Button();
            btnProductos = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnMarcas
            // 
            btnMarcas.Location = new Point(45, 39);
            btnMarcas.Name = "btnMarcas";
            btnMarcas.Size = new Size(94, 54);
            btnMarcas.TabIndex = 0;
            btnMarcas.Text = "Marcas";
            btnMarcas.UseVisualStyleBackColor = true;
            btnMarcas.Click += btnMarcas_Click;
            // 
            // btnProductos
            // 
            btnProductos.Location = new Point(179, 39);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(94, 54);
            btnProductos.TabIndex = 0;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(696, 382);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 45);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnProductos);
            Controls.Add(btnMarcas);
            Name = "FrmPrincipal";
            Text = "FrmPrincipal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnMarcas;
        private Button btnProductos;
        private Button btnSalir;
    }
}