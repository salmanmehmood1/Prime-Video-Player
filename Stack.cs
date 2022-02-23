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
    internal class Node
    {
        internal string data;
        internal Node next;

        public Node(string stk)
        {
            data = stk;
            next = null;
        }
    }

    internal class Stack
    {
        Node top;
        public Stack()
        {
            this.top = null;
        }
        internal void push(string value)
        {
            Node newNode = new Node(value);
            if (top == null)
            {
                newNode.next = null;
            }
            else
            {
                newNode.next = top;
            }
        }
        internal void Pop()
        {
            if (top == null)
            {
                return;
            }
            top = top.next;
        }
        public Node rethead()
        {
            return top;
        }

        internal void Peek()
        {
            if (top == null)
            {
                return;
            }

        }
    }
}
