using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppArboreBinar.Coada.interfaces
{
    public interface ICoada<T> where T : IComparable<T>
    {

        Node<T> getHead();

        void pop();

        void push(T value);

        bool empty();

        T top();

        void afisare();
    }
}
