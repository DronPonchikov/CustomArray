using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomArray
{
    public  class CustomArray<T> : IEnumerable<T>
    {
        private readonly T [] my_array;
        private int _length;
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
                
                return _length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(_length));
                }

                _length = value;
            }
        }

        /// <summary>
        /// Should return array 
        /// </summary>
        public T[] Array
        {
            get
            {
                
                return my_array;
            
            }
            
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
            my_array = new T [length];
           

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

            if (list.Count()==0)
            {
                throw new ArgumentException(nameof(list), "Your list have no params");
            }
            First = first;
            Length = list.Count();
            my_array = list.ToArray();            

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
                throw new ArgumentNullException(nameof(list), "Your list is null");
            }

            if ( list.Count()==0)
            {
                throw new ArgumentException( "Your list has no params",nameof(list));
            }

            Length = list.Length;
            First = first;
            my_array=list;
            
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
                if (item > Last || item < First)
                {
                    throw new ArgumentException( "Index is null",nameof(item),);
                }
                if (First < 0)
                {
                   return  Array[First + Length];
                }
                else
                {
                    return Array[item];
                }

                
            }
            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException(nameof(value), "Index is null");
                }
                if (item > Last || item < First )
                {
                    throw new ArgumentException("SystemOutOfBoundsOfArray",(nameof(value));
                }
                if (First<0)
                {
                    Array[First + Length] = value;
                }
                else
                {
                    Array[item] = value;
                }
                
               
            }
        }

        public IEnumerator<T> GetEnumerator()
        { 
            foreach (var item in my_array)
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
