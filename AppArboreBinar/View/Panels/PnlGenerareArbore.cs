using AppArboreBinar.ArboreBinar;
using AppArboreBinar.ArboreBinar.interfacecs;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppArboreBinar.View.Panels
{
    public class PnlGenerareArbore : Panel
    {
        Form1 form;

        Label lblTile;
        PictureBox pctDesign;
        BunifuTextBox txtText;
        Button btnGen;
        BunifuElipse eliBtn;

        IArbore<PnlCard> arbore;

        List<int> numbers;

        List<PnlCard> allCards;
        public PnlGenerareArbore(Form1 form1)
        {

            this.form = form1;
            arbore = new ArboreBinar<PnlCard>();
            numbers = new List<int>();
            allCards = new List<PnlCard>();

            this.Name = "PnlGenerareArbore";
            this.Size = new System.Drawing.Size(1522, 905);
            this.Font = new System.Drawing.Font("Century Gothic", 13);

            this.lblTile = new Label();
            this.pctDesign = new PictureBox();
            this.txtText = new BunifuTextBox();
            this.btnGen = new Button();
            this.eliBtn = new BunifuElipse();

            this.Controls.Add(this.lblTile);
            this.Controls.Add(this.pctDesign);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.btnGen);

            //lblTile
            this.lblTile.Location = new System.Drawing.Point(90, 64);
            this.lblTile.AutoSize = true;
            this.lblTile.Font = new System.Drawing.Font("Century Gothic", 20);
            this.lblTile.Text = "Generare Arbore";

            //pctDesign
            this.pctDesign.Location = new System.Drawing.Point(84, 105);
            this.pctDesign.Size = new System.Drawing.Size(319, 2);
            this.pctDesign.BackColor = System.Drawing.Color.Black;

            //txtText
            this.txtText.Location = new System.Drawing.Point(129, 163);
            this.txtText.Size = new System.Drawing.Size(608, 51);
            this.txtText.PlaceholderText = "Introduceti numere cu \",\" intre ele";
            this.txtText.Font = new System.Drawing.Font("Century Gothic", 14);

            //btnGen
            this.btnGen.Location = new System.Drawing.Point(786, 150);
            this.btnGen.Size = new System.Drawing.Size(225, 76);
            this.btnGen.FlatAppearance.BorderSize = 0;
            this.btnGen.FlatStyle = FlatStyle.Flat;
            this.btnGen.BackColor = SystemColors.ActiveCaption;
            this.btnGen.Text = "Generare Arbore";
            this.btnGen.Click += new EventHandler(btnGen_Click);

            this.eliBtn.TargetControl = this.btnGen;
            this.eliBtn.ElipseRadius = 25;

            
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            numbers.Clear();

            string[] prop = txtText.Text.Split(',');

            foreach (string s in prop)
            {

                if (int.TryParse(s, out int rezult) == true)
                {
                    numbers.Add(int.Parse(s));
                    
                }
                else
                {
                    MessageBox.Show("Nu a-ti introdus bine numerele!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /*  foreach (int nr in numbers) {

                  MessageBox.Show(nr.ToString());
              }*/
            carduriDinamice();
        }

        public void carduriDinamice()
        {
            //7,-1,9,18,31
            PnlCard mainCard = new PnlCard(form, numbers[0]);
            mainCard.Location = new Point( 688, 310);

            allCards.Add(mainCard);
            arbore.add(mainCard, arbore.getNode());

            this.Controls.Add(mainCard);

            for(int i=1; i<numbers.Count; i++) {

                PnlCard card = new PnlCard(form, numbers[i]);
            
                arbore.add(card,arbore.getNode());
                allCards.Add(card);
            }

            for(int i=0;i<allCards.Count;i++)
            {
                if (i > 0)
                {
                    string part = "";
                    PnlCard card1 = null;

                    arbore.getByPanel(allCards[i], part, card1);

                    MessageBox.Show(part);
                    if (card1 != null)
                    {

                        allCards[i].Location = new Point(card1.Location.X, card1.Location.Y + 80);
                        this.Controls.Add(allCards[i]);
                    }

                }
               
            }


        }
    }
}
