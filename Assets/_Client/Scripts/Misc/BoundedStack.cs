using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YohohoTest
{
    public class BoundedStack<T>
    {

        private string _name;
        private Stack<T> _stack;
        private int _maxCapacity;  
        
        public Stack<T> Stack => _stack;

        public int MaxCapacity => _maxCapacity;
        public int Count => _stack.Count;

        public int AvailableSlots
        {
            get { return MaxCapacity - Count; }
        }

        public BoundedStack(string name,int maxCapacity)
        {
            _stack = new Stack<T>();
            _name = name;
            _maxCapacity = maxCapacity;
        }

        public void Push(T value)
        {
            if (AvailableSlots > 0)
            {               
                _stack.Push(value);
            }            
        }

        public T Pop() 
        {
            return _stack.Pop();
        }

        public T[] GetReversedArray()
        {
            var finalArray = new T[MaxCapacity];
            var stackArray =  _stack.ToArray();

            for(var i = 0; i < stackArray.Length; i++)
            {               
                var stackItem = stackArray[stackArray.Length - (i+1)];
                finalArray[i] = stackItem;               
            }

            return finalArray;
        }

    }   
}
