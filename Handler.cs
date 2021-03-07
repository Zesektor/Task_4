using System;

namespace Task_4
{
    public class ChangeElementEventArgs<T> : EventArgs
    {
        public int Index { get; set; }
        public T OldValue { get; set; }
        public T NewValue { get; set; }

        /// <param name="index">index of matrixArray</param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public ChangeElementEventArgs(int index, T oldValue, T newValue)
        {
            Index = index;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
