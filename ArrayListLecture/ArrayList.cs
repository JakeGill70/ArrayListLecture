using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListLecture
{
    class ArrayList : IArrayList
    {
        private string[] stuff;
        private int currentCount;
        List<String> mything;

        public ArrayList() {
            stuff = new string[4];
            currentCount = 0;
        }

        public string this[int index] { get => stuff[index] ; set => Insert(index, value); }

        public int Count => currentCount;

        public bool IsReadOnly => false;

        public void Add(string item)
        {
            if (currentCount >= stuff.Length)
            {
                string[] biggerStuff = new string[stuff.Length * 2];
                CopyTo(biggerStuff, 0);
                stuff = biggerStuff;
            }
            Insert(currentCount++, item);
        }

        public void Resize(int newSize)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            Array.Clear(stuff);
        }

        public bool Contains(string item)
        {
            return stuff.Contains(item);
        }

        public void CopyTo(string[] array, int startingIndex)
        {
            if (startingIndex > this.Count) 
            {
                throw new ArgumentOutOfRangeException("You done goofed!");
            }
            stuff.CopyTo(array, startingIndex);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return stuff.GetEnumerator() as IEnumerator<string>;
        }

        public int IndexOf(string item)
        {
            for (int i = 0; i < stuff.Length; i++)
            {
                if (stuff[i] == item) 
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, string item)
        {
            if (index < 0 || index > this.Count) {
                index = Math.Abs(index) % this.Count;
            }
            stuff[index] = item;
        }

        public bool Remove(string item)
        {
            if (Contains(item)) 
            { 
                int index = IndexOf(item);
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < Count-1)
            {
                this[index] = default(string);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return stuff.GetEnumerator();
        }
    }
}
