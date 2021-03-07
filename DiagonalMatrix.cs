using System;

namespace Task_4
{
    public class DiagonalMatrix<T>
    {
        public int Size { get; }

        private readonly T[] _matrix;

        private void ThrowIfOutOfRange(int indexI, int indexJ)
        {
            if (indexI < 0 || indexI >= Size || indexJ < 0 || indexJ >= Size) throw new IndexOutOfRangeException();
        }

        public DiagonalMatrix(T[] array)
        {
            Size = array.Length;
            _matrix = array;
        }

        public DiagonalMatrix(int size)
        {
            if (size < 0) throw new ArgumentNullException();

            Size = size;
            _matrix = new T[size];
        }

        public T this[int i, int j]
        {
            get
            {
                ThrowIfOutOfRange(i, j);
                 return i == j  ? _matrix[i] : default;
            } 
            set
            {
                ThrowIfOutOfRange(i, j);
                if (i != j) return;
                if (!value.Equals(_matrix[i])) Changed?.Invoke(new ChangeElementEventArgs<T>(i, _matrix[i], value)); 
                _matrix[i] = value;
            }
        }

        public event ElementChanged Changed;

        public delegate void ElementChanged(ChangeElementEventArgs<T> args);

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is DiagonalMatrix<T> other)
            {
                if (Size != other.Size) return false;
                for (var i = 0; i < Size; i++)
                {
                    if (!this[i, i].Equals(other[i, i])) return false;
                }

                return true;
            }

            return false;
        }

        public override int GetHashCode() => _matrix.GetHashCode();

    }
}
