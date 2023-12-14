using AppArboreBinar.ArboreBinar.interfacecs;
using AppArboreBinar.ArboreBinar;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using System.Xml.Linq;
using System.Runtime.Caching.Hosting;

namespace AppArboreBinar.View.Panels
{
    public class PnlLoad : Panel
    {

        Form1 form;

        Label lblTile;
        PictureBox pctDesign;

        IArbore<PnlCard> arbore;

        List<int> numbers;

        List<PnlCard> allCards;

        Button btnStergere;
        BunifuElipse elibtn;

        Button btnSave;
        BunifuElipse elibtnSave;

        BunifuTextBox txtStergere;

        string text;
        int id;
        string primul;
        public PnlLoad(Form1 form1, string text1)
        {

            this.form = form1;
            arbore = new ArboreBinar<PnlCard>();
            numbers = new List<int>();
            allCards = new List<PnlCard>();
            text = text1;
           // MessageBox.Show(text);

            this.Name = "PnlLoad";
            this.Size = new System.Drawing.Size(1420, 925);
            this.Location = new System.Drawing.Point(102, 44);
            this.BackColor = Color.FromArgb(15, 20, 54);
            this.Font = new System.Drawing.Font("Century Gothic", 13);
            this.ForeColor = Color.White;

            this.lblTile = new Label();
            this.pctDesign = new PictureBox();
            this.btnStergere = new Button();
            this.elibtn = new BunifuElipse();
            this.txtStergere = new BunifuTextBox();
            this.btnSave = new Button();
            this.elibtnSave = new BunifuElipse();

            this.Controls.Add(this.lblTile);
            this.Controls.Add(this.pctDesign);
            this.Controls.Add(this.btnStergere);
            this.Controls.Add(this.txtStergere);
            this.Controls.Add(this.btnSave);

            //lblTile
            this.lblTile.Location = new System.Drawing.Point(90, 64);
            this.lblTile.AutoSize = true;
            this.lblTile.Font = new System.Drawing.Font("Century Gothic", 20);
            this.lblTile.Text = "Arbore Binar";

            //pctDesign
            this.pctDesign.Location = new System.Drawing.Point(84, 105);
            this.pctDesign.Size = new System.Drawing.Size(319, 2);
            this.pctDesign.BackColor = System.Drawing.Color.White;

            //btnStergere
            this.btnStergere.Text = "Sterge un numar din arbore";
            this.btnStergere.Size = new Size(250,80);
            this.btnStergere.Location = new Point(530,750);
            this.btnStergere.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnStergere.FlatAppearance.BorderSize = 0;
            this.btnStergere.FlatStyle = FlatStyle.Flat;
            this.btnStergere.Click += new EventHandler(btnStergere_Click);

            elibtn.TargetControl = btnStergere;
            elibtn.ElipseRadius = 25;


            //btnStergere
            this.btnSave.Text = "Save";
            this.btnSave.Size = new Size(150, 80);
            this.btnSave.Location = new Point(780, 750);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnSave.Visible = false;

            elibtnSave.TargetControl = btnSave;
            elibtnSave.ElipseRadius = 25;

            //txtText
            this.txtStergere.Location = new System.Drawing.Point(300,760);
            this.txtStergere.Size = new System.Drawing.Size(460, 60);
            this.txtStergere.PlaceholderText = "Introduceti numarul pe care il doriti sters!";
            this.txtStergere.PlaceholderForeColor = Color.DimGray;
            this.txtStergere.Font = new System.Drawing.Font("Century Gothic", 13);
            this.txtStergere.Visible = false;
            this.txtStergere.ForeColor = Color.Black;

            int semn = 0;
            string[] prop = text.Split(',');
            primul = prop[0];
            foreach (string s in prop)
            {

                if (int.TryParse(s, out int rezult) == true)
                {
                    numbers.Add(int.Parse(s));

                }
                else
                {
                    semn = 1;
                }
            }

            carduriDinamice();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStergere.Text.Equals(primul))
            {
                arbore.stergerePrimul(arbore.getNode());

                StreamReader streamReader = new StreamReader(Application.StartupPath + @"/data/arbori.txt");

                string t = "";

                string final = "";

                string[] prop = text.Split(',');
                string figura = "";


                while ((t = streamReader.ReadLine()) != null)
                {
                    if (!t.Split('|')[2].Equals(text))
                    {
                        final += t + "\n";
                    }
                    else
                    {
                        figura += t.Split('|')[0] + "|" + t.Split('|')[1] + "|";
                    }
                }

                string numere = arbore.update(arbore.getNode());
                numere = numere.Remove(numere.Length - 1);
                MessageBox.Show(numere);
                final += figura + numere + "\n";

                streamReader.Close();

                // MessageBox.Show(final);

                StreamWriter streamWriter = new StreamWriter(Application.StartupPath + @"/data/arbori.txt");
                streamWriter.Write(final);

                streamWriter.Close();
                this.form.removePnl("PnlLoad");
                this.form.Controls.Add(new PnlLoad(form, numere));

                return;
            }
            else if (arbore.valid(arbore.getNode(), txtStergere.Text))
            {


                this.btnSave.Visible = false;
                this.txtStergere.Visible = false;
                this.btnStergere.Visible = true;

                TreeNode<PnlCard> sters = arbore.getNodeByText(txtStergere.Text);

                arbore.stergereNod(arbore.getNode(), sters);

                StreamReader streamReader = new StreamReader(Application.StartupPath + @"/data/arbori.txt");

                string t = "";

                string final = "";

                string[] prop = text.Split(',');
                string figura = "";


                while ((t = streamReader.ReadLine()) != null)
                {
                    if (!t.Split('|')[2].Equals(text))
                    {
                        final += t + "\n";
                    }
                    else
                    {
                        figura += t.Split('|')[0] + "|" + t.Split('|')[1] + "|";
                    }
                }

                string numere = "";

                for (int i = 0; i < prop.Length; i++)
                {

                    if (prop[i] != txtStergere.Text && i < prop.Length - 1)
                    {
                        numere += prop[i] + ",";
                        figura += prop[i] + ",";
                    }
                    if (i == prop.Length - 1 && prop[i] != txtStergere.Text)
                    {
                        figura += prop[i];
                        numere += prop[i];
                    }
                }

                final += figura + "\n";

                streamReader.Close();

                // MessageBox.Show(final);

                StreamWriter streamWriter = new StreamWriter(Application.StartupPath + @"/data/arbori.txt");
                streamWriter.Write(final);

                streamWriter.Close();
                this.form.removePnl("PnlLoad");
                this.form.Controls.Add(new PnlLoad(form, numere));

            }
            else
            {
                MessageBox.Show("Numarul nu a fost gasit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnStergere_Click(object sender, EventArgs e)
        {

          //  TreeNode<PnlCard> succ = arbore.succesorulPrimulNod(arbore.getNode());


            this.txtStergere.Visible = true;
            this.btnStergere.Visible = false;
            this.btnSave.Visible = true;

        }

        public void carduriDinamice()
        {
            //7,-1,9,18,31,2
            PnlCard mainCard = new PnlCard(form, numbers[0]);
            mainCard.Location = new Point(560, 310);

            allCards.Add(mainCard);
            arbore.add(mainCard, arbore.getNode());

            this.Controls.Add(mainCard);

            for (int i = 1; i < numbers.Count; i++)
            {

                //  MessageBox.Show(numbers[i].ToString());
                PnlCard card = new PnlCard(form, numbers[i]);

                arbore.add(card, arbore.getNode());
                allCards.Add(card);
            }

            // MessageBox.Show(arbore.getNode().Left.Right.Data.btnNr.Text);

            for (int i = 0; i < allCards.Count; i++)
            {
                // MessageBox.Show(allCards[i].btnNr.Text);

                string part = arbore.getPartByPanel(allCards[i]);
                PnlCard card1 = arbore.getByPanel(arbore.getNode(), allCards[i]);

                //         MessageBox.Show(card1.btnNr.Text);
                if (card1 != null)
                {
                    if (part == "left")
                        allCards[i].Location = new Point(card1.Location.X -180, card1.Location.Y + 70);
                    if (part == "right")
                        allCards[i].Location = new Point(card1.Location.X + 180, card1.Location.Y + 70);

                    this.Controls.Add(allCards[i]);
                }

            }
/*
            arbore.stergereNod(arbore.getNode(), arbore.getNode().Right);

            MessageBox.Show(arbore.getNode().Right.Data.btnNr.Text);
            //arbore.afisare();
*/
        }

    }
}
