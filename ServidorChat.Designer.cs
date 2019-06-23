namespace ServidorChatArquivo
{
    partial class ServidorChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServidorChat));
            this.btnAtender = new System.Windows.Forms.Button();
            this.lblEnderecoIP = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnRetornar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAtender
            // 
            this.btnAtender.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtender.Location = new System.Drawing.Point(345, 77);
            this.btnAtender.Name = "btnAtender";
            this.btnAtender.Size = new System.Drawing.Size(197, 32);
            this.btnAtender.TabIndex = 0;
            this.btnAtender.Text = "Iniciar Atendimento";
            this.btnAtender.UseVisualStyleBackColor = true;
            this.btnAtender.Click += new System.EventHandler(this.BtnAtender_Click);
            // 
            // lblEnderecoIP
            // 
            this.lblEnderecoIP.AutoSize = true;
            this.lblEnderecoIP.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnderecoIP.Location = new System.Drawing.Point(12, 77);
            this.lblEnderecoIP.Name = "lblEnderecoIP";
            this.lblEnderecoIP.Size = new System.Drawing.Size(111, 19);
            this.lblEnderecoIP.TabIndex = 1;
            this.lblEnderecoIP.Text = "Endereço IP: ";
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Location = new System.Drawing.Point(129, 77);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(192, 27);
            this.txtIP.TabIndex = 2;
            // 
            // rtbLog
            // 
            this.rtbLog.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.Location = new System.Drawing.Point(15, 128);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(527, 284);
            this.rtbLog.TabIndex = 3;
            this.rtbLog.Text = "";
            // 
            // btnRetornar
            // 
            this.btnRetornar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetornar.Location = new System.Drawing.Point(483, 437);
            this.btnRetornar.Name = "btnRetornar";
            this.btnRetornar.Size = new System.Drawing.Size(106, 30);
            this.btnRetornar.TabIndex = 4;
            this.btnRetornar.Text = "Retornar";
            this.btnRetornar.UseVisualStyleBackColor = true;
            this.btnRetornar.Click += new System.EventHandler(this.BtnRetornar_Click);
            // 
            // ServidorChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 483);
            this.Controls.Add(this.btnRetornar);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.lblEnderecoIP);
            this.Controls.Add(this.btnAtender);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ServidorChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servidor - Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtender;
        private System.Windows.Forms.Label lblEnderecoIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnRetornar;
    }
}