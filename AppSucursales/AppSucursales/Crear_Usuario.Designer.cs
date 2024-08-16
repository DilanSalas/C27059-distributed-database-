namespace AppSucursales
{
    partial class Crear_Usuario
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
            panel2 = new Panel();
            panel3 = new Panel();
            txtContraseña = new TextBox();
            txtCedula = new TextBox();
            cbRol = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtTotal = new TextBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            panel1 = new Panel();
            label5 = new Label();
            label7 = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.BackgroundImage = Properties.Resources.WhatsApp_Image_2024_06_14_at_11_23_57_PM;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(4, 121);
            panel2.Name = "panel2";
            panel2.Size = new Size(793, 328);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Controls.Add(txtContraseña);
            panel3.Controls.Add(txtCedula);
            panel3.Controls.Add(cbRol);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(txtTotal);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(228, 328);
            panel3.TabIndex = 11;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(82, 121);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(141, 23);
            txtContraseña.TabIndex = 13;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(60, 73);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(163, 23);
            txtCedula.TabIndex = 12;
            // 
            // cbRol
            // 
            cbRol.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbRol.FormattingEnabled = true;
            cbRol.Items.AddRange(new object[] { "1", "2" });
            cbRol.Location = new Point(82, 161);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(143, 23);
            cbRol.TabIndex = 11;
            cbRol.Text = "Seleccione Rol:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(9, 25);
            label1.Name = "label1";
            label1.Size = new Size(214, 20);
            label1.TabIndex = 0;
            label1.Text = "Creación de Usuarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(9, 76);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 0;
            label2.Text = "Cedula:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(353, 73);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(141, 23);
            txtTotal.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Black;
            label3.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(9, 124);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 1;
            label3.Text = "Contreseña:";
            label3.Click += label3_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(9, 273);
            button1.Name = "button1";
            button1.Size = new Size(76, 33);
            button1.TabIndex = 9;
            button1.Text = "Ingresar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(124, 273);
            button2.Name = "button2";
            button2.Size = new Size(76, 33);
            button2.TabIndex = 10;
            button2.Text = "Salir";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Black;
            label4.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(36, 164);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 2;
            label4.Text = "Rol:";
            label4.Click += label4_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label7);
            panel1.ForeColor = Color.CornflowerBlue;
            panel1.Location = new Point(5, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(792, 114);
            panel1.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(300, 36);
            label5.Name = "label5";
            label5.Size = new Size(193, 30);
            label5.TabIndex = 5;
            label5.Text = "ByCiclo Shop";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("SimSun", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(314, 66);
            label7.Name = "label7";
            label7.Size = new Size(159, 13);
            label7.TabIndex = 4;
            label7.Text = "Venta de bicicletas";
            // 
            // Crear_Usuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Crear_Usuario";
            Text = "Crear_Usuario";
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private TextBox txtProducto;
        private Label label2;
        private TextBox txtTotal;
        private Label label3;
        private Button button1;
        private Button button2;
        private Label label4;
        private Panel panel1;
        private Label label5;
        private Label label7;
        private ComboBox cbRol;
        private TextBox txtContraseña;
        private TextBox txtCedula;
    }
}