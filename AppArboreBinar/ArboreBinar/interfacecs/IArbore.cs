using AppArboreBinar.Coada.interfaces;
using AppArboreBinar.Coada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppArboreBinar.ArboreBinar.interfacecs
{
    public interface IArbore<T> where T : IComparable<T>
    {
        TreeNode<T> getNode();

        void add(T data, TreeNode<T> aux);

        void afisare();

        void maximul(T maxi);

        void minimul(T mini);

        string getPartByPanel(T mainPanel);

        T getByPanel(TreeNode<T> node, T mainPanel);

        void setT(TreeNode<T> tree, T luat, T pus);

        string update(TreeNode<T> node);

        void stergereNod(TreeNode<T> tree, TreeNode<T> nodeSters);

        bool valid(TreeNode<T> node, string text);

        TreeNode<T> getNodeByText(string text);

        TreeNode<T> succesorulPrimulNod(TreeNode<T> treeNode);

        void stergerePrimul(TreeNode<T> start);


    }
}
