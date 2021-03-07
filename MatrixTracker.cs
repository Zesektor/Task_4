using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task_4
{
    public class MatrixTracker<T>
    {
        private Stack<ChangeElementEventArgs<T>> History { get; set; } = new Stack<ChangeElementEventArgs<T>>();

        private readonly DiagonalMatrix<T> _trackedMatrix;

        public MatrixTracker(DiagonalMatrix<T> matrix)
        {
            matrix.Changed += args => History.Push(args);
            _trackedMatrix = matrix;
        }

        public void Undo()
        {
           if (!History.Any()) return;
           var lastChange = History.Pop();
           _trackedMatrix[lastChange.Index, lastChange.Index] = lastChange.OldValue;
           History.Pop();
        }
    }
}
