using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace Video_Player
{
    internal class QNode
    {
        internal string data;
        internal QNode next; 
        public QNode(string d)
        {
            data = d;
            next = null;
        }
    }
    internal class Queue
    {
        QNode front;
        QNode rear;

        public Queue()
        {
            this.front = this.rear = null;
        }

        internal void Enqueue(string item)
        {
            QNode newNode = new QNode(item);
 
            if (this.rear == null)
            {
                this.front = this.rear = newNode;
            }
            else
            { 
                this.rear.next = newNode;
                this.rear = newNode;
            }
            Console.WriteLine("{0} inserted into Queue", item);
        }
        public QNode rethead()
        {
            return front;
        }
        internal void Dequeue()
        {  
            if (this.front == null)
            {
                Console.WriteLine("The Queue is empty");
                return;
            }  
            QNode temp = this.front;
            this.front = this.front.next;
  
            if (this.front == null)
            {
                this.rear = null;
            }

            Console.WriteLine("Item deleted is {0}", temp.data);
        }
        internal void Peek()
        {
            if (front == null)
            {
                Console.WriteLine("Stack Underflow.");
                return;
            }

            Console.WriteLine("{0} is on the front of Queue", this.front.data);
        }
    }
}
