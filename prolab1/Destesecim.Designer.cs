namespace prolab1
{
    partial class Destesecim
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
            this.buttonTas = new System.Windows.Forms.Button();
            this.buttonKagit = new System.Windows.Forms.Button();
            this.buttonMakas = new System.Windows.Forms.Button();
            this.labelBilgilendirme = new System.Windows.Forms.Label();
            this.buttonBasla = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTas
            // 
            this.buttonTas.Location = new System.Drawing.Point(272, 178);
            this.buttonTas.Name = "buttonTas";
            this.buttonTas.Size = new System.Drawing.Size(130, 166);
            this.buttonTas.TabIndex = 0;
            this.buttonTas.Text = "TAŞ";
            this.buttonTas.UseVisualStyleBackColor = true;
            this.buttonTas.Click += new System.EventHandler(this.buttonTas_Click);
            // 
            // buttonKagit
            // 
            this.buttonKagit.Location = new System.Drawing.Point(432, 178);
            this.buttonKagit.Name = "buttonKagit";
            this.buttonKagit.Size = new System.Drawing.Size(130, 166);
            this.buttonKagit.TabIndex = 1;
            this.buttonKagit.Text = "KAĞIT";
            this.buttonKagit.UseVisualStyleBackColor = true;
            this.buttonKagit.Click += new System.EventHandler(this.buttonKagit_Click);
            // 
            // buttonMakas
            // 
            this.buttonMakas.Location = new System.Drawing.Point(596, 178);
            this.buttonMakas.Name = "buttonMakas";
            this.buttonMakas.Size = new System.Drawing.Size(130, 166);
            this.buttonMakas.TabIndex = 2;
            this.buttonMakas.Text = "MAKAS";
            this.buttonMakas.UseVisualStyleBackColor = true;
            this.buttonMakas.Click += new System.EventHandler(this.buttonMakas_Click);
            // 
            // labelBilgilendirme
            // 
            this.labelBilgilendirme.AutoSize = true;
            this.labelBilgilendirme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBilgilendirme.Location = new System.Drawing.Point(428, 135);
            this.labelBilgilendirme.Name = "labelBilgilendirme";
            this.labelBilgilendirme.Size = new System.Drawing.Size(144, 20);
            this.labelBilgilendirme.TabIndex = 3;
            this.labelBilgilendirme.Text = "5 Adet Kart Seçiniz";
            // 
            // buttonBasla
            // 
            this.buttonBasla.Enabled = false;
            this.buttonBasla.Location = new System.Drawing.Point(272, 366);
            this.buttonBasla.Name = "buttonBasla";
            this.buttonBasla.Size = new System.Drawing.Size(454, 42);
            this.buttonBasla.TabIndex = 4;
            this.buttonBasla.Text = "SAVAŞA BAŞLA";
            this.buttonBasla.UseVisualStyleBackColor = true;
            this.buttonBasla.Click += new System.EventHandler(this.buttonBasla_Click);
            // 
            // Destesecim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 615);
            this.Controls.Add(this.buttonBasla);
            this.Controls.Add(this.labelBilgilendirme);
            this.Controls.Add(this.buttonMakas);
            this.Controls.Add(this.buttonKagit);
            this.Controls.Add(this.buttonTas);
            this.Name = "Destesecim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Destesecim";
            this.Load += new System.EventHandler(this.Destesecim_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTas;
        private System.Windows.Forms.Button buttonKagit;
        private System.Windows.Forms.Button buttonMakas;
        private System.Windows.Forms.Label labelBilgilendirme;
        private System.Windows.Forms.Button buttonBasla;
    }
}