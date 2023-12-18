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
using System.Linq.Expressions;

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

        Button btnDLR;
        BunifuElipse elibtnDLR;

        Button btnLDR;
        BunifuElipse elibtnLDR;

        Button btnLRD;
        BunifuElipse elibtnLRD;

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
            this.btnDLR = new Button();
            this.elibtnDLR = new BunifuElipse();

            this.btnLDR = new Button();
            this.elibtnLDR = new BunifuElipse();
            this.btnLRD = new Button();
            this.elibtnLRD = new BunifuElipse();

            this.Controls.Add(this.lblTile);
            this.Controls.Add(this.pctDesign);
            this.Controls.Add(this.btnStergere);
            this.Controls.Add(this.btnDLR);
            this.Controls.Add(this.btnLDR);
            this.Controls.Add(this.btnLRD);

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
            this.btnStergere.Text = "Sterge primul nod";
            this.btnStergere.Size = new Size(250,80);
            this.btnStergere.Location = new Point(1050,750);
            this.btnStergere.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnStergere.FlatAppearance.BorderSize = 0;
            this.btnStergere.FlatStyle = FlatStyle.Flat;
            this.btnStergere.Click += new EventHandler(btnStergere_Click);
            elibtn.TargetControl = btnStergere;
            elibtn.ElipseRadius = 25;

            //btnDLR
            this.btnDLR.Text = "Afisare in preordine";
            this.btnDLR.Size = new Size(250, 80);
            this.btnDLR.Location = new Point(150, 750);
            this.btnDLR.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnDLR.FlatAppearance.BorderSize = 0;
            this.btnDLR.Click += new EventHandler(btnDLR_Click);
            this.btnDLR.FlatStyle = FlatStyle.Flat;
            elibtnDLR.TargetControl = btnDLR;
            elibtnDLR.ElipseRadius = 25;


            //btnLDR
            this.btnLDR.Text = "Afisare in inordine";
            this.btnLDR.Size = new Size(250, 80);
            this.btnLDR.Location = new Point(450, 750);
            this.btnLDR.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnLDR.FlatAppearance.BorderSize = 0;
            this.btnLDR.Click += new EventHandler(btnLDR_Click);
            this.btnLDR.FlatStyle = FlatStyle.Flat;
            elibtnLDR.TargetControl = btnLDR;
            elibtnLDR.ElipseRadius = 25;


            //btnLRD
            this.btnLRD.Text = "Afisare in postordine";
            this.btnLRD.Size = new Size(250, 80);
            this.btnLRD.Location = new Point(750, 750);
            this.btnLRD.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnLRD.FlatAppearance.BorderSize = 0;
            this.btnLRD.Click += new EventHandler(btnLRD_Click);
            this.btnLRD.FlatStyle = FlatStyle.Flat;
            elibtnLRD.TargetControl = btnLRD;
            elibtnLRD.ElipseRadius = 25;

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

        private void btnLRD_Click(object sender, EventArgs e)
        {
            this.removePnlLoad("PnlAfisare");
            List<PnlCard> cards = new List<PnlCard>();
            arbore.afisarePostordine(arbore.getNode(),ref cards);
            PnlAfisare pnlAfisare = new PnlAfisare(form,"Afisare in postordine:",cards);
            pnlAfisare.Location = new Point(260,560);
            this.Controls.Add(pnlAfisare);

        }
        public void removePnlLoad(string pnl)
        {

            Control control = null;

            foreach (Control c in this.Controls)
            {

                if (c.Name.Equals(pnl))
                {
                    control = c;
                }

            }

            this.Controls.Remove(control);

        }

        private void btnLDR_Click(object sender, EventArgs e)
        {

            this.removePnlLoad("PnlAfisare");
            List<PnlCard> cards = new List<PnlCard>();
            arbore.afisareiInordine(arbore.getNode(), ref cards);
            PnlAfisare pnlAfisare = new PnlAfisare(form, "Afisare in inordine:", cards);
            pnlAfisare.Location = new Point(260, 560);
            this.Controls.Add(pnlAfisare);

        }

        private void btnDLR_Click(object sender, EventArgs e)
        {
            this.removePnlLoad("PnlAfisare");
            List<PnlCard> cards = new List<PnlCard>();
            arbore.afisarePreordine(arbore.getNode(), ref cards);
            PnlAfisare pnlAfisare = new PnlAfisare(form, "Afisare in preordine:", cards);
            pnlAfisare.Location = new Point(260, 560);
            this.Controls.Add(pnlAfisare);

        }


        private void btnStergere_Click(object sender, EventArgs e)
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


        }

        public void carduriDinamice()
        {
            //7,-1,9,18,31,2
            PnlCard mainCard = new PnlCard(form, numbers[0]);
            mainCard.Location = new Point(560, 150);

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
