using System;
using System.Collections.Generic;
using System.Threading;

namespace PangyaAPI.Utilities.Log
{
    public class list_fifo_asyc<T> where T : class
    {
        private readonly LinkedList<T> m_deque = new LinkedList<T>();
        private readonly object cs = new object();
        private readonly AutoResetEvent cv = new AutoResetEvent(false);
         
        public void destroy()
        {
            this.m_deque.Clear();
        }

        public virtual void push(T item) => push_back(item);

        public void push_front(T item)
        {
            lock (cs)
            {
                m_deque.AddFirst(item);
                cv.Set();
            }
        }

        public void push_back(T item)
        {
            lock (cs)
            {
                m_deque.AddLast(item);
                cv.Set();
            }
        } 

        public T get(int millisecondsTimeout = 1000) => getFirst(millisecondsTimeout);

        public T getFirst(int millisecondsTimeout = 1000)
        {
            T item = null;
            var wait = true;

            while (wait)
            {
                lock (cs)
                {
                    if (m_deque.Count > 0)
                    {
                        item = m_deque.First.Value;
                        m_deque.RemoveFirst();
                        wait = false;
                        return item;
                    }
                }
                if (!cv.WaitOne(millisecondsTimeout))
                    return null;
            }

            return item;
        }
         
    }
}
