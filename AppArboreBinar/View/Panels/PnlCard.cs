using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace AppArboreBinar.View.Panels
{
    public class PnlCard : Panel, IComparable<PnlCard>
    {

       public Button btnNr;
        BunifuElipse eliThis;
        Form1 form;

        public PnlCard(Form1 form1, int Data)
        {

            this.form = form1;

            this.Name = "PnlCard";
            this.Size = new System.Drawing.Size(146, 63);
            this.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.MouseDown += this_MouseDown;

            this.btnNr = new Button();
            this.eliThis = new BunifuElipse();

            eliThis.TargetControl = this;
            eliThis.ElipseRadius = 25;

            this.Controls.Add(this.btnNr);

            this.btnNr.AllowDrop = true;
            this.btnNr.Dock = DockStyle.Fill;
            this.btnNr.FlatAppearance.BorderSize = 0;
            this.btnNr.FlatStyle = FlatStyle.Flat;
            this.btnNr.Text = Data.ToString();
            this.btnNr.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnNr.ForeColor = System.Drawing.Color.White;
            this.btnNr.Tag = this;

            this.btnNr.MouseDown += this_MouseDown;

        }

        int IComparable<PnlCard>.CompareTo(PnlCard other)
        {
            if (int.Parse(this.btnNr.Text) > int.Parse(other.btnNr.Text))
            {
                return 1;

            }
            else if (int.Parse(this.btnNr.Text) < int.Parse(other.btnNr.Text))
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private void this_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            this.DoDragDrop(button, DragDropEffects.Move);

        }

    }
}
