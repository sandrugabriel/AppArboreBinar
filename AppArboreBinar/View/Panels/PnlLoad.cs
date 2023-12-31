﻿using AppArboreBinar.ArboreBinar.interfacecs;
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
using System.Diagnostics;
using System.Management;
using System.Net.PeerToPeer.Collaboration;

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

        Button btndelete;
        BunifuElipse eliDelete;
        TextBox txtText;

        Button btnAddNode;
        BunifuElipse eliAdd;
        TextBox txtAdd;
        Button btnaddSave;
        BunifuElipse eliaddSave;

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

            btndelete = new Button();
            eliDelete = new BunifuElipse();
            txtText = new TextBox();

            btnAddNode = new Button();
            eliAdd = new BunifuElipse();
            txtAdd = new TextBox();
            btnaddSave = new Button();
            eliaddSave = new BunifuElipse();

            this.Controls.Add(this.lblTile);
            this.Controls.Add(this.pctDesign);
            this.Controls.Add(this.btnStergere);
            this.Controls.Add(this.btnDLR);
            this.Controls.Add(this.btnLDR);
            this.Controls.Add(this.btnLRD);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.btnAddNode);
            this.Controls.Add(this.btnaddSave);
            this.Controls.Add(this.txtAdd);

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
            this.btnStergere.Text = "Sterge nod";
            this.btnStergere.Size = new Size(250, 80);
            this.btnStergere.Location = new Point(1050, 750);
            this.btnStergere.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnStergere.FlatAppearance.BorderSize = 0;
            this.btnStergere.FlatStyle = FlatStyle.Flat;
            this.btnStergere.Click += new EventHandler(btnDelete_Click);
            elibtn.TargetControl = btnStergere;
            elibtn.ElipseRadius = 25;

            //btnDLR
            this.btnDLR.Text = "Afisare in preordine";
            this.btnDLR.Size = new Size(250, 80);
            this.btnDLR.Location = new Point(270, 750);
            this.btnDLR.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnDLR.FlatAppearance.BorderSize = 0;
            this.btnDLR.Click += new EventHandler(btnDLR_Click);
            this.btnDLR.FlatStyle = FlatStyle.Flat;
            elibtnDLR.TargetControl = btnDLR;
            elibtnDLR.ElipseRadius = 25;


            //btnLDR
            this.btnLDR.Text = "Afisare in inordine";
            this.btnLDR.Size = new Size(250, 80);
            this.btnLDR.Location = new Point(530, 750);
            this.btnLDR.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnLDR.FlatAppearance.BorderSize = 0;
            this.btnLDR.Click += new EventHandler(btnLDR_Click);
            this.btnLDR.FlatStyle = FlatStyle.Flat;
            elibtnLDR.TargetControl = btnLDR;
            elibtnLDR.ElipseRadius = 25;


            //btnLRD
            this.btnLRD.Text = "Afisare in postordine";
            this.btnLRD.Size = new Size(250, 80);
            this.btnLRD.Location = new Point(790, 750);
            this.btnLRD.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnLRD.FlatAppearance.BorderSize = 0;
            this.btnLRD.Click += new EventHandler(btnLRD_Click);
            this.btnLRD.FlatStyle = FlatStyle.Flat;
            elibtnLRD.TargetControl = btnLRD;
            elibtnLRD.ElipseRadius = 25;

            //txttext
            this.txtText.Location = new Point(1040,770);
            this.txtText.Size = new Size(150,50);
            this.txtText.Visible = false;

            //btndelete
            this.btndelete.Text = "Sterge";
            this.btndelete.Size = new Size(150, 50);
            this.btndelete.Location = new Point(1210, 765);
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.FlatStyle = FlatStyle.Flat;
            this.btndelete.Click += new EventHandler(btnStergere_Click);
            eliDelete.TargetControl = btndelete;
            eliDelete.ElipseRadius = 25;
            this.btndelete.Visible = false;

            //btnadd
            this.btnAddNode.Text = "Add Nod";
            this.btnAddNode.Size = new Size(250, 80);
            this.btnAddNode.Location = new Point(10, 750);
            this.btnAddNode.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnAddNode.FlatAppearance.BorderSize = 0;
            this.btnAddNode.FlatStyle = FlatStyle.Flat;
            this.btnAddNode.Click += new EventHandler(btnAdd_Click);
            eliAdd.TargetControl = btnAddNode;
            eliAdd.ElipseRadius = 25;

            //btnaddsave
            this.btnaddSave.Text = "Save";
            this.btnaddSave.Size = new Size(130, 50);
            this.btnaddSave.Location = new Point(130, 765);
            this.btnaddSave.BackColor = System.Drawing.Color.FromArgb(15, 20, 35);
            this.btnaddSave.FlatAppearance.BorderSize = 0;
            this.btnaddSave.FlatStyle = FlatStyle.Flat;
            this.btnaddSave.Click += new EventHandler(btnaddSave_Click);
            eliaddSave.TargetControl = btnaddSave;
            eliaddSave.ElipseRadius = 25;
            this.btnaddSave.Visible = false;

            //txtadd
            this.txtAdd.Location = new Point(20, 770);
            this.txtAdd.Size = new Size(100, 50);
            this.txtAdd.Visible = false;

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

        private void btnaddSave_Click(object sender, EventArgs e)
        {
            int nr;

            bool succes = int.TryParse(txtAdd.Text, out nr);

            if (succes)
            {

                this.btnaddSave.Visible = false;
                this.txtAdd.Visible = false;
                this.btnAddNode.Visible = true;

                StreamReader streamReader = new StreamReader(Application.StartupPath+ @"/data/arbori.txt");

                string t = "";
                string final = "";
                string nod = "";
                while((t = streamReader.ReadLine()) != null)
                {
                    if (!t.Split('|')[2].Equals(text))
                    {
                        final += t+"\n";
                    }
                    else
                    {
                        nod = t.Split('|')[0] + "|" + t.Split('|')[1] + "|";
                    }
                }

                nod += text + "," + nr.ToString();

                final += nod;

              //  MessageBox.Show(final);
                streamReader.Close();

                StreamWriter streamWriter = new StreamWriter(Application.StartupPath + @"/data/arbori.txt");

                streamWriter.Write(final);
                streamWriter.Close();

                string numere = text + "," + nr.ToString();

                this.form.removePnl("PnlLoad");
                //MessageBox.Show(nod);
                this.form.Controls.Add(new PnlLoad(form, numere));

            }
            else
            {
                MessageBox.Show("Nu a-ti introdus un numar!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.btnAddNode.Visible = false;
            this.btnaddSave.Visible = true;
            this.txtAdd.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.btndelete.Visible = true;
            this.txtText.Visible = true;
            this.btnStergere.Visible = false;
        }

        private void btnLRD_Click(object sender, EventArgs e)
        {
            this.removePnlLoad("PnlAfisare");
            List<PnlCard> cards = new List<PnlCard>();
            arbore.afisarePostordine(arbore.getNode(), ref cards);
            PnlAfisare pnlAfisare = new PnlAfisare(form, "Afisare in postordine:", cards);
            pnlAfisare.Location = new Point(260, 560);
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

            if (txtText.Text.Equals(primul))
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
               // MessageBox.Show(numere);
                final += figura + numere + "\n";

                streamReader.Close();

                // MessageBox.Show(final);

                StreamWriter streamWriter = new StreamWriter(Application.StartupPath + @"/data/arbori.txt");
                streamWriter.Write(final);

                streamWriter.Close();
                this.form.removePnl("PnlLoad");
                this.form.Controls.Add(new PnlLoad(form, numere));


            }
            else if (arbore.valid(arbore.getNode(), txtText.Text))
            {

                this.btndelete.Visible = false;
                this.txtText.Visible = false;
                this.btnStergere.Visible = true;

                arbore.stergeNod(arbore.getNode(), int.Parse(txtText.Text));

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

                    if (prop[i] != txtText.Text && i < prop.Length - 1)
                    {
                        numere += prop[i] + ",";
                        figura += prop[i] + ",";
                    }
                    if (i == prop.Length - 1 && prop[i] != txtText.Text)
                    {
                        figura += prop[i];
                        numere += prop[i];
                    }
                }

                final += figura + "\n";
                //MessageBox.Show(final);
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

        public void carduriDinamice()
        {
            //7,-1,9,18,31,2
            PnlCard mainCard = new PnlCard(form, numbers[0]);
            mainCard.Location = new Point(560, 150);
            mainCard.btnNr.DragEnter += all_DragEnter;
            mainCard.btnNr.DragDrop += all_DragDrop;

            allCards.Add(mainCard);
            arbore.add(mainCard, arbore.getNode());

            this.Controls.Add(mainCard);

            for (int i = 1; i < numbers.Count; i++)
            {

                //  MessageBox.Show(numbers[i].ToString());
                PnlCard card = new PnlCard(form, numbers[i]);
                card.btnNr.DragEnter += all_DragEnter;
                card.btnNr.DragDrop += all_DragDrop;
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
                        allCards[i].Location = new Point(card1.Location.X - 180, card1.Location.Y + 70);
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

        Button d;
        int ct = 0;

        private void all_DragEnter(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Move;
            if (sender is Button button && ct == 0)
            {
                d = button;
                ct++;
            }

            if (ct == 2) ct = 0;
        }

        public Button findByText(string text)
        {
            for (int i = 0; i < allCards.Count; i++)
            {
                if (allCards[i].btnNr.Text.Equals(text))
                    return allCards[i].btnNr;
            }

            return null;
        }

        public PnlCard findByButton(Button btn)
        {
            if (btn == null) return null;
            else
            {
                for (int i = 0; i < allCards.Count; i++)
                {
                    if (allCards[i].btnNr == btn) return allCards[i];
                }
            }

            return null;
        }

        private void all_DragDrop(object sender, DragEventArgs e)
        {

            string text = sender.ToString().Remove(0, 35);
            //  MessageBox.Show(text);

            Button btnDestinatie = findByText(text);
            PnlCard destinatie = findByButton(btnDestinatie);

            Button btnSursa = d;
            PnlCard sursa = findByButton(btnSursa);

            //  arbore.setT(arbore.getNode(),sursa,destinatie);

            string text1 = sursa.btnNr.Text;
            string text2 = destinatie.btnNr.Text;
            destinatie.btnNr.Text = text1;
            sursa.btnNr.Text = text2;

          //  MessageBox.Show(arbore.getNode().Left.Data.btnNr.Text);//18

            if (arbore.verificareArbore(arbore.getNode()) == true)
            {
                MessageBox.Show("Nodul s-a schimbat!","Succes",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Nu se potate schimba nod!!\nNu o sa mai fie arbore binar!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                string text3 = sursa.btnNr.Text;
                string text4 = destinatie.btnNr.Text;
                destinatie.btnNr.Text = text3;
                sursa.btnNr.Text = text4;
            }

            ct = 0;
        }


    }
}
