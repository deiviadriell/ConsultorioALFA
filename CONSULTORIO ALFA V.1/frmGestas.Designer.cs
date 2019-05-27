namespace CONSULTORIO_ALFA_V._1
{
    partial class frmGestas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudAbortos = new System.Windows.Forms.NumericUpDown();
            this.lblAbortos = new System.Windows.Forms.Label();
            this.nudCesareas = new System.Windows.Forms.NumericUpDown();
            this.nudPartos = new System.Windows.Forms.NumericUpDown();
            this.lblCesareas = new System.Windows.Forms.Label();
            this.nudEmbarazos = new System.Windows.Forms.NumericUpDown();
            this.lblPartos = new System.Windows.Forms.Label();
            this.lblEmbarazos = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAbortos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCesareas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPartos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmbarazos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPaciente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtCedula);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 109);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Paciente";
            // 
            // txtPaciente
            // 
            this.txtPaciente.BackColor = System.Drawing.Color.White;
            this.txtPaciente.Location = new System.Drawing.Point(19, 79);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(362, 20);
            this.txtPaciente.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Paciente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(186, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Más opciones de busqueda";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(126, 34);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(59, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCedula
            // 
            this.txtCedula.BackColor = System.Drawing.Color.White;
            this.txtCedula.Location = new System.Drawing.Point(20, 37);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(100, 20);
            this.txtCedula.TabIndex = 1;
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cédula";
            // 
            // nudAbortos
            // 
            this.nudAbortos.Location = new System.Drawing.Point(197, 140);
            this.nudAbortos.Name = "nudAbortos";
            this.nudAbortos.Size = new System.Drawing.Size(37, 20);
            this.nudAbortos.TabIndex = 20;
            this.nudAbortos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudAbortos_KeyPress);
            // 
            // lblAbortos
            // 
            this.lblAbortos.AutoSize = true;
            this.lblAbortos.Location = new System.Drawing.Point(194, 124);
            this.lblAbortos.Name = "lblAbortos";
            this.lblAbortos.Size = new System.Drawing.Size(43, 13);
            this.lblAbortos.TabIndex = 16;
            this.lblAbortos.Text = "Abortos";
            // 
            // nudCesareas
            // 
            this.nudCesareas.Location = new System.Drawing.Point(141, 140);
            this.nudCesareas.Name = "nudCesareas";
            this.nudCesareas.Size = new System.Drawing.Size(48, 20);
            this.nudCesareas.TabIndex = 19;
            this.nudCesareas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudCesareas_KeyPress);
            // 
            // nudPartos
            // 
            this.nudPartos.Location = new System.Drawing.Point(97, 140);
            this.nudPartos.Name = "nudPartos";
            this.nudPartos.Size = new System.Drawing.Size(38, 20);
            this.nudPartos.TabIndex = 18;
            this.nudPartos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudPartos_KeyPress);
            // 
            // lblCesareas
            // 
            this.lblCesareas.AutoSize = true;
            this.lblCesareas.Location = new System.Drawing.Point(137, 124);
            this.lblCesareas.Name = "lblCesareas";
            this.lblCesareas.Size = new System.Drawing.Size(51, 13);
            this.lblCesareas.TabIndex = 15;
            this.lblCesareas.Text = "Cesareas";
            // 
            // nudEmbarazos
            // 
            this.nudEmbarazos.Location = new System.Drawing.Point(32, 140);
            this.nudEmbarazos.Name = "nudEmbarazos";
            this.nudEmbarazos.Size = new System.Drawing.Size(56, 20);
            this.nudEmbarazos.TabIndex = 17;
            this.nudEmbarazos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudEmbarazos_KeyPress);
            // 
            // lblPartos
            // 
            this.lblPartos.AutoSize = true;
            this.lblPartos.Location = new System.Drawing.Point(94, 124);
            this.lblPartos.Name = "lblPartos";
            this.lblPartos.Size = new System.Drawing.Size(37, 13);
            this.lblPartos.TabIndex = 14;
            this.lblPartos.Text = "Partos";
            // 
            // lblEmbarazos
            // 
            this.lblEmbarazos.AutoSize = true;
            this.lblEmbarazos.Location = new System.Drawing.Point(29, 124);
            this.lblEmbarazos.Name = "lblEmbarazos";
            this.lblEmbarazos.Size = new System.Drawing.Size(59, 13);
            this.lblEmbarazos.TabIndex = 13;
            this.lblEmbarazos.Text = "Embarazos";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(343, 166);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(59, 23);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(278, 166);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(59, 23);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmGestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 201);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.nudAbortos);
            this.Controls.Add(this.lblAbortos);
            this.Controls.Add(this.nudCesareas);
            this.Controls.Add(this.nudPartos);
            this.Controls.Add(this.lblCesareas);
            this.Controls.Add(this.nudEmbarazos);
            this.Controls.Add(this.lblPartos);
            this.Controls.Add(this.lblEmbarazos);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGestas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestas";
            this.Load += new System.EventHandler(this.frmGestas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAbortos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCesareas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPartos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmbarazos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudAbortos;
        private System.Windows.Forms.Label lblAbortos;
        private System.Windows.Forms.NumericUpDown nudCesareas;
        private System.Windows.Forms.NumericUpDown nudPartos;
        private System.Windows.Forms.Label lblCesareas;
        private System.Windows.Forms.NumericUpDown nudEmbarazos;
        private System.Windows.Forms.Label lblPartos;
        private System.Windows.Forms.Label lblEmbarazos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
    }
}