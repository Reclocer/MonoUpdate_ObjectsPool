using System.Collections.Generic;

namespace Corebin.Core.ObjectsPool.ObjectsQueue
{
    public sealed class ObjectsPoolQueue<T> 
    {
        public  Queue<T>[] Pools => _pools;
        private Queue<T>[] _pools;
        
        private int _objectsCount = 64;

        #region Constructors
        public ObjectsPoolQueue()
        {
            _pools = new Queue<T>[2];

            for (int i = 0; i < _pools.Length; i++)
            {
                _pools[i] = new Queue<T>(_objectsCount);
            }
        }

        public ObjectsPoolQueue(int objectsCount)
        {
            _pools = new Queue<T>[2];

            for (int i = 0; i < _pools.Length; i++)
            {
                _pools[i] = new Queue<T>(objectsCount);
            }

            _objectsCount = objectsCount;
        }

        public ObjectsPoolQueue(int poolsCount, int objectsCount)
        {
            _pools = new Queue<T>[poolsCount]; 
            
            for(int i = 0; i < _pools.Length; i++)
            {
                _pools[i] = new Queue<T>(objectsCount);
            }

            _objectsCount = objectsCount;
        }
        #endregion Constructors

        #region Methods
        public void Enqueue(T @object)
        {
            _pools[0].Enqueue(@object);
        }

        public void Enqueue(T @object, int order)
        {
            if(order >= _pools.Length)
            {
                EnqueueLast(@object);
            }
            else if (order <= 0)
            {
                Enqueue(@object);
            }
            else
            {
                _pools[order].Enqueue(@object);
            }  
        }

        public void EnqueueLast(T @object)
        {
            int n = _pools.Length;
            _pools[n].Enqueue(@object);
        }

        public T Peek()
        {
            for (int i = 0; i < _pools.Length; i++)
            {
                T @object = _pools[i].Peek();

                if (@object != null)
                {
                    return @object;
                }
            }

            return default;
        }

        public T Dequeue()
        {
            return NDequeue(0);
        }

        private T NDequeue(int i)
        {
            if (_pools[i].Count != 0)
            {
                T @object = _pools[i].Dequeue();

                int j = i + 1;

                if (j <= _pools.Length)
                {
                    _pools[j].Enqueue(@object);
                    return @object;
                }

                _pools[i].Enqueue(@object);
                return @object;
            }
            else if (_pools[i + 1] != null)
            {
                NDequeue(i + 1);
            }

            return default;
        }
        #endregion Methods
    }
}
