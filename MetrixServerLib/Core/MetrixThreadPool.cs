using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetrixServerLib.Core
{
    /// <summary>
    /// 程序主进程
    /// </summary>
    public class MetrixThreadPool
    {
        protected readonly Stack<Thread> m_pool = new Stack<Thread>();

        public MetrixThreadPool()
        {

        }

        public int GetSize()
        {
            return this.m_pool.Count;
        }

        public Thread Peek()
        {
            return this.m_pool.Peek();
        }

        public Thread Pop()
        {
            return this.m_pool.Pop();
        }

        public Thread ElementAt(int index)
        {
            return this.m_pool.ElementAt(index);
        }

        public void Push(Thread t)
        {
            this.m_pool.Push(t);
        }
    }
}
