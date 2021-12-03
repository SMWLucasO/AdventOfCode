using System;

namespace AdventOfCode.Common.Types
{
    public class IndexableInteger
    {

        public int this[int index]
        {
            get
            {
                if (index >= sizeof(int))
                    throw new InvalidOperationException("Index may not exceed amount of bits available.");

                // move bit to check to the beginning and AND it with 1.
                return (_number >> index) & 1;
            }

            set
            {
                if (value != 0 && value != 1)
                    throw new InvalidOperationException("Value may only be 0 or 1.");
                
                _number = (1 << index) | value;
            }
        }
        
        private int _number;

        public IndexableInteger(int number)
            => _number = number;

    }
}