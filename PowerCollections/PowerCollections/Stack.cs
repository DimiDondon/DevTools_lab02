using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
    public class Stack<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public int Capacity { get; }
        T[] n;
        public Stack(int nsize = 5)
        {
            if (nsize < 0) throw new InvalidOperationException("Емкость стека не должна быть отрицательной");
            Capacity = nsize;
            n = new T[Capacity];
        }
        public bool IsEmpty => Count == 0;
        public void Push(T a)
        {
            if (Count == Capacity) throw new InvalidOperationException("Превышен размер стека");
            else
            {
                n[Count] = a;
                Count++;
            }
        }
        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст");
            else
            {
                Count--;
                return n[Count];
            }
        }
        public T Top()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст");
            else
            {
                return n[Count - 1];
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            int nSize = Count - 1;
            for (int i = nSize; i >= 0; i--)
            {
                yield return n[i];
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
