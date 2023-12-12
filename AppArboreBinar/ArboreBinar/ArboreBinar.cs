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

namespace AppArboreBinar.ArboreBinar
{
    public class ArboreBinar<T> : IArbore<T> where T : PnlCard, IComparable<T>
    {

        private TreeNode<T> _root = null;

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
                Console.WriteLine(treeNode.Data);

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
            ICoada<TreeNode<T>> coada = new Coada<TreeNode<T>>();

            TreeNode<T> treeNode = current;

            T data;

            do
            {

                if (treeNode.Left != null)
                {
                    coada.push(treeNode.Left);

                }

                if (treeNode.Right != null)
                {
                    coada.push(treeNode.Right);
                }

                if (treeNode.Data.CompareTo(cautat) == 0)
                {
                    return treeNode;
                }

                treeNode = coada.top();

                coada.pop();

            } while (treeNode != null);

            return null;
        }

        public void setT(TreeNode<T> tree, T luat, T pus)
        {

            TreeNode<T> card1 = find(tree, luat);
            TreeNode<T> card2 = find(tree, pus);

            T aux = card1.Data;
            card1.Data = card2.Data;
            card2.Data = aux;

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

    }
}
