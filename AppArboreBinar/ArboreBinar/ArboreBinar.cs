using AppArboreBinar.Coada.interfaces;
using AppArboreBinar.Coada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppArboreBinar.ArboreBinar.interfacecs;
using System.Windows.Forms;
using System.Web.Services.Description;
using System.Xml.Linq;
using AppArboreBinar.View.Panels;
using System.Web.UI.Design;
using System.Reflection.Context;
using System.Security.Cryptography;

namespace AppArboreBinar.ArboreBinar
{
    public class ArboreBinar<T> : IArbore<T> where T : PnlCard, IComparable<T>
    {

        private TreeNode<T> _root = null;

        public void setNode(TreeNode<T> node)
        {
            _root = node;   
        }

        public TreeNode<T> getNode() { return  _root; }

        public void add(T data, TreeNode<T> aux)
        {
            if (_root == null)
            {
                _root = new TreeNode<T>();

                _root.Left = null;
                _root.Right = null;
                _root.Data = data;
                //  Console.WriteLine(_root.Data);
            }
            else
            {
                TreeNode<T> nou = new TreeNode<T>();
                nou.Data = data;
                nou.Left = null;
                nou.Right = null;

                if (aux.Data.CompareTo(data) > 0)
                {
                    if (aux.Left == null)
                    {
                        aux.Left = nou;


                    }
                    else
                    {
                        add(data, aux.Left);
                    }
                }
                else
                {
                    if (aux.Right == null)
                    {
                        aux.Right = nou;
                    }
                    else
                    {
                        add(data, aux.Right);
                    }
                }

            }
        }

        public void afisare()
        {

            ICoada<TreeNode<T>> coada = new Coada<TreeNode<T>>();

            TreeNode<T> treeNode = _root;
            // Console.WriteLine(treeNode.Left.Left.Data);

            do
            {
                MessageBox.Show(treeNode.Data.btnNr.Text);

                if (treeNode.Left != null)
                {
                    coada.push(treeNode.Left);
                }

                if (treeNode.Right != null)
                {
                    coada.push(treeNode.Right);
                }

                treeNode = coada.top();

                coada.pop();

            } while (treeNode != null);

        }

        public void maximul(T maxi)
        {

            ICoada<TreeNode<T>> coada = new Coada<TreeNode<T>>();

            TreeNode<T> root = _root;

            do
            {
                if (root.Data.CompareTo(maxi) >= 1)
                {
                    maxi = root.Data;
                }

                if (root.Left != null)
                    coada.push(root.Left);

                if (root.Right != null)
                    coada.push(root.Right);

                root = coada.top();

                coada.pop();

            } while (root != null);


            Console.WriteLine("User-ul maxim este:\n" + maxi.ToString());
        }

        public void minimul(T mini)
        {

            ICoada<TreeNode<T>> coada = new Coada<TreeNode<T>>();

            TreeNode<T> root = _root;

            do
            {
                if (root.Data.CompareTo(mini) == -1)
                {
                    mini = root.Data;
                }

                if (root.Left != null)
                    coada.push(root.Left);

                if (root.Right != null)
                    coada.push(root.Right);

                root = coada.top();

                coada.pop();

            } while (root != null);


            Console.WriteLine("User-ul Minim este:\n" + mini.ToString());
        }

        public T getByPanel(TreeNode<T> node, T panel)
        {
            ICoada<TreeNode<T>> coada = new Coada<TreeNode<T>>();

            TreeNode<T> treeNode = _root;

            T data;

            do
            {

                if (treeNode.Left != null)
                {
                    coada.push(treeNode.Left);
                    if (treeNode.Left.Data.CompareTo(panel) == 0)
                    {
                        return treeNode.Data;
                    }
                }

                if (treeNode.Right != null)
                {
                    coada.push(treeNode.Right);
                    if (treeNode.Right.Data.CompareTo(panel) == 0)
                    {
                        return treeNode.Data;
                    }
                }

                treeNode = coada.top();

                coada.pop();

            } while (treeNode != null);

            return null;
        }

        public string getPartByPanel(T mainPanel)
        {

            ICoada<TreeNode<T>> coada = new Coada<TreeNode<T>>();

            TreeNode<T> treeNode = _root;

            T data;

            do
            {
                //Console.WriteLine(treeNode.Data);


                if (treeNode.Left != null)
                {
                    coada.push(treeNode.Left);
                    if (treeNode.Left.Data.CompareTo(mainPanel) == 0)
                    {
                        return "left";
                    }
                }

                if (treeNode.Right != null)
                {
                    coada.push(treeNode.Right);
                    if (treeNode.Right.Data.CompareTo(mainPanel) == 0)
                    {
                        return "right";
                    }
                }

                treeNode = coada.top();

                coada.pop();

            } while (treeNode != null);

            return null;
        }

        public TreeNode<T> find(TreeNode<T> current, T cautat)
        {
            if (current == null) return null;
            else if (current.Data.Equals(cautat))
            {
                return current;
            }

            var l = find(current.Left,cautat);
            if (l != null) return l;

            return find(current.Right,cautat);
        }

        public void setT(TreeNode<T> start,T luat, T pus)
        {

            TreeNode<T> card1 = find(_root, luat);
            TreeNode<T> card2 = find(_root, pus);

            T aux = card1.Data;
            card1.Data = card2.Data;
            card2.Data = aux;

            start = _root;
           // MessageBox.Show(start.Left.Data.btnNr.Text);

        }

        public string update(TreeNode<T> node)
        {
            ICoada<TreeNode<T>> coada = new Coada<TreeNode<T>>();
            string t = "";
            TreeNode<T> treeNode = _root;

            T data;

            do
            {
                t += treeNode.Data.btnNr.Text + ",";

                if (treeNode.Left != null)
                {
                    coada.push(treeNode.Left);
                }

                if (treeNode.Right != null)
                {
                    coada.push(treeNode.Right);
                }

                treeNode = coada.top();

                coada.pop();

            } while (treeNode != null);

            return t;

        }

        public TreeNode<T> stergeNod(TreeNode<T> start, int val)
        {
            if (start == null)
                return start;

            if (val < int.Parse(start.Data.btnNr.Text))
            {

                start.Left = stergeNod(start.Left, val);
            }

            else if (val > int.Parse(start.Data.btnNr.Text))
            {

                start.Right = stergeNod(start.Right, val);
            }

            else
            {

                if (start.Right == null)
                    return start.Left;

                else if (start.Left == null)
                    return start.Right;


                TreeNode<T> succesor;
                if (start.Right != null)
                    succesor = start.Right;

                else 
                    succesor = start.Left;

                start.Data = succesor.Data;
                start.Right = stergeNod(start.Right, int.Parse(succesor.Data.btnNr.Text));
            }
            return start;
        }

        public TreeNode<T> minim(TreeNode<T> nod)
        {
            while (nod.Left != null)
                nod = nod.Left;
            return nod;
        }

        public TreeNode<T> succesorulPrimulNod(TreeNode<T> start)
        {

            var current = start.Right;
            while(current != null&& current.Left!=null) { 
            
                   current = current.Left;
             }

            return current;

           
        }

        public void stergerePrimul(TreeNode<T> start)
        {

            TreeNode<T> prim = succesorulPrimulNod(start);
            TreeNode<T> prim1 = succesorulPrimulNod(start);


           // MessageBox.Show(prim.Data.btnNr.Text);

            TreeNode<T> right = start.Right;
            while(right.Left != null)
            {
                if(right.Left.Data.CompareTo(prim.Data) == 0) {

                    right.Left = prim.Right;
               //     MessageBox.Show(right.Left.Data.btnNr.Text);
                    break;
                }

                right = right.Left;
            }
          //  MessageBox.Show("Primul1 : "+prim1.Data.btnNr.Text);

            prim1.Left = start.Left;
            prim1.Right = start.Right;

            start.Data = prim1.Data;
            start = prim1;

          //  MessageBox.Show(start.Data.btnNr.Text);

        //   MessageBox.Show(update(start));

        }

        public bool valid(TreeNode<T> node, string text)
        {

            ICoada<TreeNode<T>> coada = new Coada<TreeNode<T>>();

            TreeNode<T> treeNode = _root;

            do
            {
                if (treeNode.Data.btnNr.Text.Equals(text))
                {
                    return true;
                }

                if (treeNode.Left != null)
                {
                    coada.push(treeNode.Left);
                }

                if (treeNode.Right != null)
                {
                    coada.push(treeNode.Right);
                }

                treeNode = coada.top();

                coada.pop();

            } while (treeNode != null);

            return false;
        }

        public TreeNode<T> getNodeByText(string text)
        {
            ICoada<TreeNode<T>> coada = new Coada<TreeNode<T>>();

            TreeNode<T> treeNode = _root;

            do
            {
                if (treeNode.Data.btnNr.Text.Equals(text))
                {
                    return treeNode;
                }

                if (treeNode.Left != null)
                {
                    coada.push(treeNode.Left);
                }

                if (treeNode.Right != null)
                {
                    coada.push(treeNode.Right);
                }

                treeNode = coada.top();

                coada.pop();

            } while (treeNode != null);

            return null;

        }

        public void afisarePreordine(TreeNode<T> start, ref List<PnlCard> nrs)
        {

            if (start != null)
            {
                nrs.Add(start.Data);
                //Console.WriteLine(start.Data);

                afisarePreordine(start.Left,ref nrs);
                afisarePreordine(start.Right,ref nrs);
            }



        }

        public void afisareiInordine(TreeNode<T> start, ref List<PnlCard> cards)
        {
            if (start != null)
            {
                afisareiInordine(start.Left,ref cards);
                cards.Add(start.Data);

                //Console.WriteLine(start.Data);
                afisareiInordine(start.Right, ref cards);
            }
        }

        public void afisarePostordine(TreeNode<T> start, ref List<PnlCard> cards)
        {
            if (start != null)
            {
                afisarePostordine(start.Left, ref cards);
                afisarePostordine(start.Right, ref cards);
                cards.Add(start.Data);

                //Console.WriteLine(start.Data);
            }
        }

        public bool verificareArbore(TreeNode<T> node)
        {
           if(node == null)
            {
                return true;
            }

            if (node.Left != null && int.Parse(node.Data.btnNr.Text) < int.Parse(node.Left.Data.btnNr.Text))
                return false;

            if (node.Right != null && int.Parse(node.Data.btnNr.Text) > int.Parse(node.Right.Data.btnNr.Text))
                return false;

            return verificareArbore(node.Left) && verificareArbore(node.Right);
        }
    }
}
