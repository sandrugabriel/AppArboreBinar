namespace AppArboreBinar.View.Mockups
{
    partial class MockupCard
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
            this.btnNr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNr
            // 
            this.btnNr.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNr.FlatAppearance.BorderSize = 0;
            this.btnNr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNr.Location = new System.Drawing.Point(0, 0);
            this.btnNr.Name = "btnNr";
            this.btnNr.Size = new System.Drawing.Size(146, 63);
            this.btnNr.TabIndex = 0;
            this.btnNr.Text = "button1";
            this.btnNr.UseVisualStyleBackColor = false;
            // 
            // MockupCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(146, 63);
            this.Controls.Add(this.btnNr);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MockupCard";
            this.Text = "MockupCard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNr;
    }
}