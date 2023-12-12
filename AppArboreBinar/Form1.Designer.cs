using Bunifu.Framework.UI;

namespace AppArboreBinar
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
            this.components = new System.ComponentModel.Container();
            Bunifu.UI.WinForms.BunifuFormCaptionButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuFormCaptionButton.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Bunifu.UI.WinForms.BunifuFormCaptionButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuFormCaptionButton.BorderEdges();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnlBarTile = new System.Windows.Forms.Panel();
            this.mini = new Bunifu.UI.WinForms.BunifuFormCaptionButton();
            this.close = new Bunifu.UI.WinForms.BunifuFormCaptionButton();
            this.pnlBarTile.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnlBarTile
            // 
            this.pnlBarTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(26)))), ((int)(((byte)(75)))));
            this.pnlBarTile.Controls.Add(this.mini);
            this.pnlBarTile.Controls.Add(this.close);
            this.pnlBarTile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarTile.Location = new System.Drawing.Point(0, 0);
            this.pnlBarTile.Name = "pnlBarTile";
            this.pnlBarTile.Size = new System.Drawing.Size(1522, 44);
            this.pnlBarTile.TabIndex = 15;
            // 
            // mini
            // 
            this.mini.AllowAnimations = true;
            this.mini.AllowBorderColorChanges = true;
            this.mini.AllowDefaults = true;
            this.mini.AllowMouseEffects = true;
            this.mini.AnimationSpeed = 200;
            this.mini.AutoSizeCaptions = true;
            this.mini.BackColor = System.Drawing.Color.Transparent;
            this.mini.BackgroundColor = System.Drawing.Color.Transparent;
            this.mini.BackHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(31)))), ((int)(((byte)(65)))));
            this.mini.BackPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(31)))), ((int)(((byte)(75)))));
            this.mini.BorderColor = System.Drawing.Color.Transparent;
            this.mini.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(31)))), ((int)(((byte)(75)))));
            this.mini.BorderPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(31)))), ((int)(((byte)(65)))));
            this.mini.BorderRadius = 1;
            this.mini.BorderStyle = Bunifu.UI.WinForms.BunifuFormCaptionButton.BorderStyles.Dot;
            this.mini.BorderThickness = 1;
            this.mini.CaptionType = Bunifu.UI.WinForms.BunifuFormCaptionButton.CaptionTypes.Minimize;
            this.mini.ColorContrastOnClick = 30;
            this.mini.ColorContrastOnHover = 30;
            this.mini.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.mini.CustomizableEdges = borderEdges1;
            this.mini.DefaultBorderColor = System.Drawing.Color.Transparent;
            this.mini.DefaultColor = System.Drawing.Color.Transparent;
            this.mini.DialogResult = System.Windows.Forms.DialogResult.None;
            this.mini.IconColor = System.Drawing.Color.White;
            this.mini.IconHoverColor = System.Drawing.Color.White;
            this.mini.IconPressedColor = System.Drawing.Color.White;
            this.mini.Image = ((System.Drawing.Image)(resources.GetObject("mini.Image")));
            this.mini.ImageMargin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.mini.ImageSize = new System.Drawing.Size(25, 25);
            this.mini.Location = new System.Drawing.Point(1629, 0);
            this.mini.Name = "mini";
            this.mini.ShowBorders = true;
            this.mini.Size = new System.Drawing.Size(73, 42);
            this.mini.TabIndex = 1;
            this.mini.Click += new System.EventHandler(this.mini_Click);
            // 
            // close
            // 
            this.close.AllowAnimations = true;
            this.close.AllowBorderColorChanges = true;
            this.close.AllowDefaults = true;
            this.close.AllowMouseEffects = true;
            this.close.AnimationSpeed = 200;
            this.close.AutoSizeCaptions = true;
            this.close.BackColor = System.Drawing.Color.Transparent;
            this.close.BackgroundColor = System.Drawing.Color.Transparent;
            this.close.BackHoverColor = System.Drawing.Color.Red;
            this.close.BackPressedColor = System.Drawing.Color.Red;
            this.close.BorderColor = System.Drawing.Color.Transparent;
            this.close.BorderHoverColor = System.Drawing.Color.Transparent;
            this.close.BorderPressedColor = System.Drawing.Color.Red;
            this.close.BorderRadius = 0;
            this.close.BorderStyle = Bunifu.UI.WinForms.BunifuFormCaptionButton.BorderStyles.Dot;
            this.close.BorderThickness = 0;
            this.close.CaptionType = Bunifu.UI.WinForms.BunifuFormCaptionButton.CaptionTypes.Close;
            this.close.ColorContrastOnClick = 30;
            this.close.ColorContrastOnHover = 30;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.close.CustomizableEdges = borderEdges2;
            this.close.DefaultBorderColor = System.Drawing.Color.Transparent;
            this.close.DefaultColor = System.Drawing.Color.Transparent;
            this.close.DialogResult = System.Windows.Forms.DialogResult.None;
            this.close.ForeColor = System.Drawing.Color.White;
            this.close.IconColor = System.Drawing.Color.White;
            this.close.IconHoverColor = System.Drawing.Color.White;
            this.close.IconPressedColor = System.Drawing.Color.White;
            this.close.Image = ((System.Drawing.Image)(resources.GetObject("close.Image")));
            this.close.ImageMargin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.close.ImageSize = new System.Drawing.Size(30, 30);
            this.close.Location = new System.Drawing.Point(1449, 0);
            this.close.Name = "close";
            this.close.ShowBorders = true;
            this.close.Size = new System.Drawing.Size(73, 42);
            this.close.TabIndex = 0;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1522, 905);
            this.Controls.Add(this.pnlBarTile);
            this.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnlBarTile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BunifuElipse bunifuElipse1;
        public System.Windows.Forms.Panel pnlBarTile;
        private Bunifu.UI.WinForms.BunifuFormCaptionButton mini;
        private Bunifu.UI.WinForms.BunifuFormCaptionButton close;
    }
}

