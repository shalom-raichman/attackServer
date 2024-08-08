using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attackServer
{
    internal class Node<T>
    {
        private T _value;
        private Node<T> _next;


        public Node(T value)
        {
            this.setValue(value); ;
            this.setNext(null);
        }

        public Node(T value, Node<T> next)
        {
            this.setValue(value); ;
            this.setNext(next);
        }

        public void setValue(T value)
        {
            this._value = value;
        }

        public void setNext(Node<T> next)
        {
            this._next = next;
        }

        public T getValue()
        {
            return this._value;
        }

        public Node<T> getNext()
        {
            return this._next;
        }

        public override string ToString()
        {
            // un ari
            // bi nari
            // tri nari
            // a + b > 5 ? true : false
            string hasNext = this.getNext() != null ? "has" : "no";
            return $"Value is {this.getValue()}, {hasNext} Next";
        }

    }
}
