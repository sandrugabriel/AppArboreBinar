using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppArboreBinar.View.Panels
{
    public class PnlHome : Panel
    {

        Form1 form;

        Label lblTile;
        PictureBox pct;

        Button btnAdd;
        BunifuElipse eliThis;
        BunifuElipse eliPnl;
        BunifuTextBox txtText;
        Panel pnlAdd;
        Button btnSave;
        
        public PnlHome(Form1 form1)
        {
            form = form1;

            this.Size = new System.Drawing.Size(1420, 925);
            this.Location = new System.Drawing.Point(102, 44);
            this.BackColor = Color.FromArgb(15, 20, 54);
            this.Name = "PnlHome";
            //  this.Dock = DockStyle.Fill;

            this.lblTile = new Label();
            this.pct = new PictureBox();
            this.pnlAdd = new Panel();
            this.txtText = new BunifuTextBox();
            this.btnSave = new Button();

            // lblTile
            this.lblTile.AutoSize = true;
            this.lblTile.Font = new System.Drawing.Font("Century Gothic", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTile.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTile.Location = new System.Drawing.Point(60, 42);
            this.lblTile.Name = "lblTile";
            this.lblTile.Size = new System.Drawing.Size(243, 36);
            this.lblTile.TabIndex = 1;
            this.lblTile.Text = "Toate Schemele";

            // pct
            this.pct.BackColor = System.Drawing.SystemColors.Control;
            this.pct.Location = new System.Drawing.Point(51, 77);
            this.pct.Name = "pct";
            this.pct.Size = new System.Drawing.Size(265, 2);
            this.pct.TabIndex = 2;
            this.pct.TabStop = false;

            this.btnAdd = new Button();
            this.eliThis = new BunifuElipse();
            this.eliPnl = new BunifuElipse();

            eliThis.TargetControl = this.btnAdd;
            eliThis.ElipseRadius = 25;

            eliPnl.TargetControl = this.pnlAdd;
            eliPnl.ElipseRadius = 25;

            this.Controls.Add(this.btnAdd);

            this.btnAdd.Size = new Size(250, 103);
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Location = new Point(160,200);
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Text = "Add";
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Click += new EventHandler(btnAdd_Click);


            this.Controls.Add(this.pnlAdd);

            this.pnlAdd.Size = new Size(250, 103);
            this.pnlAdd.Location = new Point(160, 200);
            this.pnlAdd.Text = "Add";
            this.pnlAdd.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.pnlAdd.ForeColor = System.Drawing.Color.White;

            //txtText
            this.txtText.Location = new System.Drawing.Point(5,5);
            this.txtText.Size = new System.Drawing.Size(240, 51);
            this.txtText.PlaceholderText = "Introduceti numere cu \",\" intre ele";
            this.txtText.Font = new System.Drawing.Font("Century Gothic", 10);
            this.txtText.ForeColor = Color.Black;

            this.pnlAdd.Controls.Add(btnSave);

            this.btnSave.Size = new Size(100, 50);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Location = new Point(70, 50);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Text = "Add";
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 10);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Click += new EventHandler(btnSave_Click);

            createCard(3);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int semn = 0;
            string[] prop = txtText.Text.Split(',');

            foreach (string s in prop)
            {

                if (int.TryParse(s, out int rezult) != true)
                {
                    semn = 1;
                }
            }

            if (semn == 1)
            {
                MessageBox.Show("Nu a-ti introdus bine numerele!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Random rnd = new Random();
                int a = rnd.Next(100, 10000);
                string t = a.ToString() + "|" + "figura" + a.ToString() + "|" + txtText.Text + "\n";
                File.AppendAllText(Application.StartupPath + @"/data/arbori.txt", t);

                this.form.removePnl("PnlHome");
                this.form.Controls.Add(new PnlHome(form));
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            this.btnAdd.Visible = false;
            this.pnlAdd.Visible = true;

        }

        public void createCard(int nr)
        {

            StreamReader streamReader = new StreamReader(Application.StartupPath + @"/data/arbori.txt");

            this.Controls.Clear();

            this.Controls.Add(pct);
            this.Controls.Add(lblTile);
            this.Controls.Add(btnAdd);
            this.Controls.Add(pnlAdd);
            this.pnlAdd.Controls.Add(txtText);
            this.pnlAdd.Controls.Add(btnSave);

            List<string> list = new List<string>();
            string text = "";

            while ((text = streamReader.ReadLine()) != null)
            {
                    list.Add(text.Split('|')[1].ToString());
            }

            int x = 450, y = 200, ct = 0;

            foreach (string items in list)
            {
                ct++;
                Button btnCard = new Button();
                BunifuElipse eiBtn;

                eiBtn = new BunifuElipse();

                eiBtn.TargetControl = btnCard;
                eiBtn.ElipseRadius = 25;

                // btnCard
                btnCard.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
                btnCard.FlatAppearance.BorderSize = 0;
                btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnCard.ForeColor = System.Drawing.SystemColors.Control;
                btnCard.Location = new System.Drawing.Point(x, y);
                btnCard.Name = "btnCard";
                btnCard.Size = new System.Drawing.Size(250, 103);
                btnCard.Text = items;
                btnCard.Click += new EventHandler(btnCard_Click);

                this.Controls.Add(btnCard);

                x += 300;

                if (ct % nr == 0)
                {
                    x = 160;
                    y += 150;
                }

                if (y > this.Height)
                {
                    this.AutoScroll = true;
                }




                streamReader.Close();

            }

        }

        public void btnCard_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            string final = "";

            StreamReader streamReader = new StreamReader(Application.StartupPath + @"/data/arbori.txt");

            string text = "";

            while ((text = streamReader.ReadLine()) != null)
            {
                if (text.Split('|')[1].ToString() == btn.Text)
                    final = text.Split('|')[2].ToString();
            }
            streamReader.Close();
            this.form.removePnl("PnlHome");
            this.form.Controls.Add(new PnlLoad(form,final));
            //this.form.removePnl("PnlGenerareArbore");
           // this.form.Controls.Add(new PnlSlideTileBar(form, user));
           // this.form.Controls.Add(new PnlLoad(form, user, final));
            //  MessageBox.Show(final);

        }



    }
}
