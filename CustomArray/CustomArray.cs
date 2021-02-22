using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomArray
{
    public class CustomArray<T> : IEnumerable<T>
    {
        private readonly T [] array;
        /// <summary>
        /// Should return first index of array
        /// </summary>
        public int First 
        { 
            get;
            private set;
        }

        /// <summary>
        /// Should return last index of array
        /// </summary>
        public int Last
        {
            get => (Length + First) - 1;
            
        }

        /// <summary>
        /// Should return length of array
        /// <exception cref="ArgumentException">Thrown when value was smaller than 0</exception>
        /// </summary>
        public int Length 
        {
            get
            {
                if (Length < 0)
                {
                    throw new ArgumentException();
                }
                return Length;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                Length = value;
            }
        }

        /// <summary>
        /// Should return array 
        /// </summary>
        public T[] Array
        {
            get=> array;
            //private set;
        }


        /// <summary>
        /// Constructor with first index and length
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="length">Length</param>         
        public CustomArray(int first, int length)
        {
            First = first;
            Length = length;
            array = new T [Length];
            //Array = array;

        }


        /// <summary>
        /// Constructor with first index and collection  
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Collection</param>
        ///  <exception cref="NullReferenceException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when count is smaller than 0</exception>
        public CustomArray(int first, IEnumerable<T> list)
        {
            if (list==null)
            {
                throw new NullReferenceException();
            }

            if (first== 0 && list.Count()<0)
            {
                throw new ArgumentException();
            }
            First = first;
            Length = list.Count();
            array = list.ToArray();
            //Array = array;

        }

        /// <summary>
        /// Constructor with first index and params
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Params</param>
        ///  <exception cref="ArgumentNullException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when list without elements </exception>
        public CustomArray(int first, params T[] list)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }

            if (list.Length==0)
            {
                throw new ArgumentException();
            }

            Length = list.Length;
            First = first;
            array=list.ToArray();
            //Array = array;
        }

        /// <summary>
        /// Indexer with get and set  
        /// </summary>
        /// <param name="item">Int index</param>        
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when index out of array range</exception> 
        /// <exception cref="ArgumentNullException">Thrown in set  when value passed in indexer is null</exception>
        public T this[int item]
        {
            get
            {
                if (item > Last || item< First)
                {
                    throw new ArgumentException();
                }

                return Array[item];
            }
            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException();
                }
                if (item > Last || item < First)
                {
                    throw new ArgumentException();
                }

                Array[item] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        { 
            foreach (var item in Array)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return  GetEnumerator();
        }
    }
}
