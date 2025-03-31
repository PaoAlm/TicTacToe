namespace juegogato
{
    partial class tie
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
            this.btn_continuetie = new System.Windows.Forms.Button();
            this.lblWinner = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_continuetie
            // 
            this.btn_continuetie.BackColor = System.Drawing.Color.IndianRed;
            this.btn_continuetie.FlatAppearance.BorderSize = 0;
            this.btn_continuetie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_continuetie.Font = new System.Drawing.Font("8_bit_1_6", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_continuetie.ForeColor = System.Drawing.Color.White;
            this.btn_continuetie.Location = new System.Drawing.Point(185, 259);
            this.btn_continuetie.Name = "btn_continuetie";
            this.btn_continuetie.Size = new System.Drawing.Size(115, 39);
            this.btn_continuetie.TabIndex = 27;
            this.btn_continuetie.Text = "continue";
            this.btn_continuetie.UseVisualStyleBackColor = false;
            this.btn_continuetie.Click += new System.EventHandler(this.btn_continuetie_Click);
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.BackColor = System.Drawing.Color.White;
            this.lblWinner.Font = new System.Drawing.Font("8-bit HUD", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblWinner.Location = new System.Drawing.Point(121, 40);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(233, 31);
            this.lblWinner.TabIndex = 22;
            this.lblWinner.Text = "It\'s a tie!!!";
            this.lblWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::juegogato.Properties.Resources.tie;
            this.pictureBox4.Location = new System.Drawing.Point(136, 92);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(206, 144);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 23;
            this.pictureBox4.TabStop = false;
            // 
            // tie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(483, 327);
            this.Controls.Add(this.btn_continuetie);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lblWinner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "tie";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tie";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_continuetie;
        private System.Windows.Forms.Label lblWinner;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}