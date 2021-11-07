using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealizationQueue
{
    class MyQueue<TValue> : IEnumerable<TValue>
    {
        private Item<TValue> head;
        private Item<TValue> tail;

        public bool IsEmpry()
        {
            return head == null;
        }

        public void PutValue(TValue value)
        {
            if (IsEmpry())
            {
                head = new Item<TValue> { Value = value, NextItem = null };
                tail = head;
            }
            else
            {
                var item = new Item<TValue> { Value = value, NextItem = null };
                tail.NextItem = item;
                tail = item;
            }
        }

        public TValue PeekValue()
        {
            if (IsEmpry())
                throw new Exception("Queue is empty.");
            else
            {
                return head.Value;
            }
        }

        public void RemoveValue()
        {
            if (IsEmpry())
                throw new Exception("Queue is empty.");
            else
            {
                var result = head.Value;
                head = head.NextItem;
                if (IsEmpry())
                    tail = null;
            }
        }

        public void Print()
        {
            if (IsEmpry())
                throw new Exception("Queue is empty.");
            foreach (var e in this)
                Console.WriteLine(e);
        }

        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
        {
            Item<TValue> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
