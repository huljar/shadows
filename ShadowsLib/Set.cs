using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {

    public class Set<T> : ICollection<T>, IEnumerable<T>, IList<T> {

        private List<T> items;

        public Set() { }

        public Set(int capacity) {
            items = new List<T>(capacity);
        }

        public Set(IEnumerable<T> items) {
            this.items = new List<T>();
            foreach(T item in items) {
                Add(item);
            }
        }

        public Set(params T[] items) {
            this.items = new List<T>(items.Length);
            foreach(T item in items) {
                Add(item);
            }
        }

        public void Add(T item) {
            if(!Contains(item)) {
                items.Add(item);
            }
        }

        public void Clear() {
            items.Clear();
        }

        public bool Contains(T item) {
            return items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item) {
            return items.Remove(item);
        }

        public int Count {
            get { return items.Count; }
        }

        public bool IsReadOnly {
            get { return false; }
        }

        public IEnumerator<T> GetEnumerator() {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return items.GetEnumerator();
        }

        public int IndexOf(T item) {
            return items.IndexOf(item);
        }

        public void Insert(int index, T item) {
            if(!Contains(item)) {
                items.Insert(index, item);
            }
        }

        public void RemoveAt(int index) {
            items.RemoveAt(index);
        }

        public T this[int index] {
            get { return items[index]; }
            set { items[index] = value; }
        }
    }
}
