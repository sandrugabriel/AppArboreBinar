using AppArboreBinar.Coada.interfaces;
using AppArboreBinar.Coada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppArboreBinar.ArboreBinar.interfacecs;
using System.Windows.Forms;

namespace AppArboreBinar.ArboreBinar
{
    public class ArboreBinar<T> : IArbore<T> where T : Panel, IComparable<T>
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

        public void getByPanel(T mainPanel, string part, T panel)
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
                    if (treeNode.Left.Data.CompareTo(mainPanel) == 1)
                    {
                        panel = treeNode.Data;
                        part = "left";
                    }
                }

                if (treeNode.Right != null)
                {
                    coada.push(treeNode.Right);
                    if (treeNode.Right.Data.CompareTo(mainPanel) == 1)
                    {
                        panel = treeNode.Data;
                        part = "right";
                    }
                }

                treeNode = coada.top();

                coada.pop();

            } while (treeNode != null);


        }

    }
}
