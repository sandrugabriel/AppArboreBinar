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

        string text;
        int id;
        public PnlLoad(Form1 form1, string text1)
        {

            this.form = form1;
            arbore = new ArboreBinar<PnlCard>();
            numbers = new List<int>();
            allCards = new List<PnlCard>();
            text = text1;

            this.Name = "PnlGenerareArbore";
            this.Size = new System.Drawing.Size(1420, 925);
            this.Location = new System.Drawing.Point(102, 44);
            this.BackColor = Color.FromArgb(15, 20, 54);
            this.Font = new System.Drawing.Font("Century Gothic", 13);
            this.ForeColor = Color.White;

            this.lblTile = new Label();
            this.pctDesign = new PictureBox();

            this.Controls.Add(this.lblTile);
            this.Controls.Add(this.pctDesign);

            //lblTile
            this.lblTile.Location = new System.Drawing.Point(90, 64);
            this.lblTile.AutoSize = true;
            this.lblTile.Font = new System.Drawing.Font("Century Gothic", 20);
            this.lblTile.Text = "Arbore Binar";

            //pctDesign
            this.pctDesign.Location = new System.Drawing.Point(84, 105);
            this.pctDesign.Size = new System.Drawing.Size(319, 2);
            this.pctDesign.BackColor = System.Drawing.Color.White;


            int semn = 0;
            string[] prop = text.Split(',');

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
            StreamReader streamReader = new StreamReader(Application.StartupPath + @"/data/arbori.txt");

            string t = "";

            string final = "";

            while ((t = streamReader.ReadLine()) != null)
            {
                if (int.Parse(t.Split('|')[0]) != id)
                    final += t + "\n";
            }

            streamReader.Close();

            //  MessageBox.Show(final);
            final += id.ToString() + "|" + text.Split('|')[1] + "|" + arbore.update(arbore.getNode());

            //final += arbor.update(arbor.getNode(), id);

            StreamWriter streamWriter = new StreamWriter(Application.StartupPath + @"/data/arbori.txt");
            streamWriter.Write(final);

            streamWriter.Close();


            this.form.removePnl("PnlHome");
            this.form.removePnl("PnlSlide");
            this.form.removePnl("PnlAdd");
            this.form.removePnl("PnlLoad");
            this.form.removePnl("PnlDelete");
            this.form.Controls.Add(new PnlSlide(form));
            this.form.Controls.Add(new PnlLoad(form, text));
            MessageBox.Show("Figura s-a salvat in fisier!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        allCards[i].Location = new Point(card1.Location.X - 200, card1.Location.Y + 80);
                    if (part == "right")
                        allCards[i].Location = new Point(card1.Location.X + 180, card1.Location.Y + 80);

                    this.Controls.Add(allCards[i]);
                }

            }


        }

    }
}
