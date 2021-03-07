using System;
using Task_4;

public static class DiagonalMatrixHelper
{
    public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> a, DiagonalMatrix<T> b, Func<T, T, T> addMethod)
    {
        if (addMethod == null) throw new ArgumentNullException();
        if (b == null) b = new DiagonalMatrix<T>(a.Size);

        if (a.Size < b.Size)
        {
            (a, b) = (b, a);
        }

        var data = new T[a.Size];
        for (var i = 0; i < b.Size; i++)
        {
            data[i] = addMethod(a[i, i], b[i, i]);
        }

        for (var i = b.Size; i < a.Size; i++)
        {
            data[i] = a[i, i];
        }

        return new DiagonalMatrix<T>(data);
    }
}