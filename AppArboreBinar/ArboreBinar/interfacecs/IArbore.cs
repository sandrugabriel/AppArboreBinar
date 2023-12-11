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

        void getByPanel(T mainPanel, string part, T panel);
    }
}
