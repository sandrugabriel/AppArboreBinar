using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppArboreBinar.View.Panels
{
    public class PnlSlide : Panel
    {

        private System.Windows.Forms.PictureBox pctDesign;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.PictureBox pctHome;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox pctAdd;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.PictureBox pctDelete;
        private System.Windows.Forms.PictureBox pctMenu;

        Form1 form;
        private Timer timer;

        User user;

        public PnlSlide(Form1 form1)
        {
            this.form = form1;

            // PnlSideBar
            this.Size = new System.Drawing.Size(105, 925);
            this.Font = new System.Drawing.Font("Comfortaa", 13.8F, System.Drawing.FontStyle.Regular);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PnlSlide";
            this.MaximumSize = new System.Drawing.Size(230, 925);
            this.MinimumSize = new System.Drawing.Size(105, 925);
            this.Location = new System.Drawing.Point(0, 44);
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 39);
            //this.Dock = DockStyle.Left;

            this.pctAdd = new System.Windows.Forms.PictureBox();
            this.pctDelete = new System.Windows.Forms.PictureBox();
            this.pctHome = new System.Windows.Forms.PictureBox();
            this.pctDesign = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblMenu = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pctMenu = new System.Windows.Forms.PictureBox();
            this.timer = new Timer();

            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Interval = 5;

            this.btnAdd.Controls.Add(this.pctAdd);
            this.btnDelete.Controls.Add(this.pctDelete);
            this.btnHome.Controls.Add(this.pctHome);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pctMenu);

            // pctAdd
            this.pctAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctAdd.Image = Image.FromFile(Application.StartupPath + @"/images/add.png");
            this.pctAdd.Location = new System.Drawing.Point(24, 2);
            this.pctAdd.Name = "pctAdd";
            this.pctAdd.Size = new System.Drawing.Size(54, 54);
            this.pctAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctAdd.Click += new EventHandler(btnAdd_Click);

            // 
            // pctDelete
            this.pctDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctDelete.Image = Image.FromFile(Application.StartupPath + @"/images/delete.png");
            this.pctDelete.Location = new System.Drawing.Point(24, 2);
            this.pctDelete.Name = "pctDelete";
            this.pctDelete.Size = new System.Drawing.Size(54, 54);
            this.pctDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctDelete.Click += new EventHandler(btnDelete_Click);

            // 
            // pctHome
            this.pctHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctHome.Image = Image.FromFile(Application.StartupPath + @"/images/home.png");
            this.pctHome.Location = new System.Drawing.Point(24, 2);
            this.pctHome.Name = "pctHome";
            this.pctHome.Size = new System.Drawing.Size(54, 54);
            this.pctHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctHome.Click += new EventHandler(btnHome_Click);

            // pctDesign
            this.pctDesign.BackColor = System.Drawing.Color.White;
            this.pctDesign.Location = new System.Drawing.Point(106, 78);
            this.pctDesign.Name = "pctDesign";
            this.pctDesign.Size = new System.Drawing.Size(347, 1);

            // btnHome
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHome.Location = new System.Drawing.Point(0, 227);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(600, 60);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "              Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Click += new EventHandler(btnHome_Click);

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular);
            this.btnAdd.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(0, 227 + 79 + 79);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(600, 60);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "              Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Click += new EventHandler(btnAdd_Click);

            // lblMenu
            this.lblMenu.AutoSize = true;
            this.lblMenu.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular);
            this.lblMenu.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMenu.Location = new System.Drawing.Point(100, 37);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(112, 40);
            this.lblMenu.TabIndex = 1;
            this.lblMenu.Text = "Menu";

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(0, 227 + 79);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(600, 60);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "              Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Click += new EventHandler(btnDelete_Click);

            // pctMenu
            this.pctMenu.BackColor = System.Drawing.Color.Transparent;
            this.pctMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMenu.Image = Image.FromFile(Application.StartupPath + @"/images/menu.png");
            this.pctMenu.Location = new System.Drawing.Point(24, 36);
            this.pctMenu.Name = "pctMenu";
            this.pctMenu.Size = new System.Drawing.Size(54, 54);
            this.pctMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctMenu.Click += new EventHandler(pctMenu_Click);

        }

        bool sidebar = false;
        private void timer_Tick(object sender, EventArgs e)
        {

            if (sidebar)
            {
                this.Width -= 10;
                if (this.Width == this.MinimumSize.Width)
                {
                    sidebar = false;
                    timer.Stop();

                }

            }
            else
            {
                this.Width += 10;
                if (this.Width == this.MaximumSize.Width)
                {
                    sidebar = true;
                    timer.Stop();

                }
            }


        }

        private void pctMenu_Click(object sender, EventArgs e)
        {
            this.timer.Start();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.form.removePnl("PnlHome");
            this.form.removePnl("PnlSlide");
            this.form.removePnl("PnlAdd");
            this.form.removePnl("PnlLoad");
            this.form.removePnl("PnlDelete");
            this.form.Controls.Add(new PnlSlide(form));
            this.form.Controls.Add(new PnlHome(form));

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            this.form.removePnl("PnlHome");
            this.form.removePnl("PnlSlide");
            this.form.removePnl("PnlAdd");
            this.form.removePnl("PnlLoad");
            this.form.removePnl("PnlDelete");
            this.form.Controls.Add(new PnlSlide(form));
         //   this.form.Controls.Add(new PnlAdd(form, user));

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            this.form.removePnl("PnlHome");
            this.form.removePnl("PnlSlide");
            this.form.removePnl("PnlAdd");
            this.form.removePnl("PnlLoad");
            this.form.removePnl("PnlDelete");
            this.form.Controls.Add(new PnlSlide(form));
         //   this.form.Controls.Add(new PnlDelete(form, user));

        }


    }
}
