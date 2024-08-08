using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attackServer
{
    internal class Queue1<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _count;

        public Queue1()
        {
            this.setHead(null);
            this.setTail(null);
            this.setCount(0);
        }

        // (3, newNode)
        // (4, null)

        public void Enqueue(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (this.getTail() != null)
            {
                Node<T> tail = this.getTail();
                tail.setNext(newNode);
            }
            if (this.getHead() == null)
            {
                this.setHead(newNode);

            }
            this.setTail(newNode);
            this.setCount(this.getCount() + 1);
        }

        public T Dequeue()
        {
            if (this.isEmpty()) throw new Exception("Queue is empty, can't Dequeue");
            T value = this.getHead().getValue();
            this.setHead(this.getHead().getNext());
            if (this.getHead() == null)
            {
                this.setTail(null);
            }
            this.setCount(this.getCount() - 1);
            return value;
        }


        private bool isEmpty()
        {
            return this.getHead() == null;
        }

        public void setHead(Node<T> head)
        {
            this._head = head;
        }

        public void setTail(Node<T> tail)
        {
            this._tail = tail;
        }

        public void setCount(int count)
        {
            this._count = count;
        }

        public Node<T> getHead()
        {
            return this._head;
        }

        public Node<T> getTail()
        {
            return this._tail;
        }

        public int getCount()
        {
            return this._count;
        }

    }
}
