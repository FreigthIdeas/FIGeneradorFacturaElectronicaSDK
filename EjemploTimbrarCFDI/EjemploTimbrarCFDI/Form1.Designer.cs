namespace EjemploTimbrarCFDI
{
    partial class Form1
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
            this.btnTimbrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstErrores = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbQR = new System.Windows.Forms.PictureBox();
            this.cbQR = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUUID = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCancelar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbQR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTimbrar
            // 
            this.btnTimbrar.Location = new System.Drawing.Point(12, 12);
            this.btnTimbrar.Name = "btnTimbrar";
            this.btnTimbrar.Size = new System.Drawing.Size(75, 23);
            this.btnTimbrar.TabIndex = 0;
            this.btnTimbrar.Text = "Timbrar";
            this.btnTimbrar.UseVisualStyleBackColor = true;
            this.btnTimbrar.Click += new System.EventHandler(this.btnTimbrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Errores:";
            // 
            // lstErrores
            // 
            this.lstErrores.FormattingEnabled = true;
            this.lstErrores.Location = new System.Drawing.Point(12, 67);
            this.lstErrores.Name = "lstErrores";
            this.lstErrores.Size = new System.Drawing.Size(395, 121);
            this.lstErrores.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resultado";
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(12, 207);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(395, 193);
            this.txtResultado.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "QRCode";
            // 
            // pbQR
            // 
            this.pbQR.Location = new System.Drawing.Point(15, 429);
            this.pbQR.Name = "pbQR";
            this.pbQR.Size = new System.Drawing.Size(148, 148);
            this.pbQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbQR.TabIndex = 6;
            this.pbQR.TabStop = false;
            // 
            // cbQR
            // 
            this.cbQR.AutoSize = true;
            this.cbQR.Location = new System.Drawing.Point(67, 403);
            this.cbQR.Name = "cbQR";
            this.cbQR.Size = new System.Drawing.Size(95, 17);
            this.cbQR.TabIndex = 7;
            this.cbQR.Text = "Crear QRCode";
            this.cbQR.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "UUID";
            // 
            // txtUUID
            // 
            this.txtUUID.Location = new System.Drawing.Point(185, 446);
            this.txtUUID.Name = "txtUUID";
            this.txtUUID.ReadOnly = true;
            this.txtUUID.Size = new System.Drawing.Size(222, 20);
            this.txtUUID.TabIndex = 9;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(309, 473);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar Timbre";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblCancelar
            // 
            this.lblCancelar.AutoSize = true;
            this.lblCancelar.Location = new System.Drawing.Point(182, 508);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(0, 13);
            this.lblCancelar.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 581);
            this.Controls.Add(this.lblCancelar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtUUID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbQR);
            this.Controls.Add(this.pbQR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstErrores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTimbrar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTimbrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstErrores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbQR;
        private System.Windows.Forms.CheckBox cbQR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUUID;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCancelar;
    }
}

