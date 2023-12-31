﻿using AppArboreBinar.Coada.interfaces;
using AppArboreBinar.Coada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppArboreBinar.View.Panels;

namespace AppArboreBinar.ArboreBinar.interfacecs
{
    public interface IArbore<T> where T : IComparable<T>
    {
        TreeNode<T> getNode();

        void setNode(TreeNode<T> node);

        void add(T data, TreeNode<T> aux);

        void afisare();

        void maximul(T maxi);

        void minimul(T mini);

        string getPartByPanel(T mainPanel);

        T getByPanel(TreeNode<T> node, T mainPanel);

        void setT(TreeNode<T> start,T luat, T pus);

        string update(TreeNode<T> node);

        TreeNode<T> stergeNod(TreeNode<T> start, int val);

        bool valid(TreeNode<T> node, string text);

        TreeNode<T> getNodeByText(string text);

        TreeNode<T> succesorulPrimulNod(TreeNode<T> treeNode);

        void stergerePrimul(TreeNode<T> start);

        void afisarePreordine(TreeNode<T> start,ref List<PnlCard> cards);

        void afisareiInordine(TreeNode<T> start, ref List<PnlCard> cards);

        void afisarePostordine(TreeNode<T> start, ref List<PnlCard> cards);

        bool verificareArbore(TreeNode<T> start);

    }
}
