using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppArboreBinar.View.Panels
{
    public class PnlAfisare : Panel
    {
        Form1 form;

        Label label1;

        List<PnlCard> cards;

        public PnlAfisare(Form1 form1, string text, List<PnlCard> list1)
        {
            this.form = form1;
            this.cards = list1;

            // MockupAfisare
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(950, 145);
            this.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PnlAfisare";

            this.label1 = new Label();

            this.Controls.Add(this.label1);

            // label1
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = text;

            generareCards();
        }

        public void generareCards()
        {

            this.Controls.Clear();

            this.Controls.Add(this.label1);

            int x = 50, y = 50;

            foreach(PnlCard pnlCard in cards)
            {
                PnlCard pnlCard1 = new PnlCard(form,int.Parse(pnlCard.btnNr.Text));
                pnlCard1.Location = new System.Drawing.Point(x,y);
                this.Controls.Add(pnlCard1);

                x += 200;

            }

        }

    }
}
