using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public class Matrix
    {
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        public long? Modulus { get; }
        private readonly long[,] values;
        public Matrix(int numberOfRows, int numberOfColumns, long? modulus = null)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            Modulus = modulus;
            values = new long[numberOfRows, numberOfColumns];
        }

        public long this[int row, int column]
        {
            get => values[row, column];
            set => values[row, column] = value % Modulus ?? value;
        }

        public Matrix Times(Matrix right)
        {
            if (NumberOfColumns != right.NumberOfRows)
            {
                throw new ArgumentException("Dimensies matchen niet");
            }

            if (Modulus.HasValue && right.Modulus.HasValue && Modulus != right.Modulus)
            {
                throw new ArgumentException("Moduli matchen niet");
            }

            long? modulus = Modulus ?? right.Modulus;
            var result = InitializeMatrix(NumberOfRows, right.NumberOfColumns, modulus);
            Parallel.For(0, NumberOfRows, r =>
            {
                for (int c = 0; c < right.NumberOfColumns; c++)
                {
                    long newValue = 0;
                    if (!modulus.HasValue)
                    {
                        for (int i = 0; i < NumberOfColumns; i++)
                        {
                            newValue += this[r, i] * right[i, c];
                        }
                    }
                    else
                    {
                        for (int i = 0; i < NumberOfColumns; i++)
                        {
                            var addedValue = (this[r, i] * right[i, c]) % modulus.Value;
                            newValue = (newValue + addedValue) % modulus.Value;
                        }
                    }

                    result[r, c] = newValue;
                }
            });
            return result;
        }

        private static Matrix InitializeMatrix(int numberOfRows, int numberOfColumns, long? modulus)
        {
            if (numberOfRows == numberOfColumns)
            {
                return new SquareMatrix(numberOfRows, modulus);
            }
            return new Matrix(numberOfRows, numberOfColumns);
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.NumberOfColumns != b.NumberOfColumns || a.NumberOfColumns != b.NumberOfColumns)
            {
                throw new ArgumentException("Dimensies matchen niet");
            }

            var result = InitializeMatrix(a.NumberOfRows, a.NumberOfColumns, a.Modulus);
            for (int i = 0; i < a.NumberOfRows; i++)
            {
                for (int j = 0; j < a.NumberOfColumns; j++)
                {
                    var sum = a[i, j] + b[i, j];
                    if (a.Modulus.HasValue)
                    {
                        sum %= a.Modulus.Value;
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.NumberOfColumns != b.NumberOfColumns || a.NumberOfRows != b.NumberOfRows || a.Modulus != b.Modulus)
            {
                throw new ArgumentException("Dimensies matchen niet");
            }

            var result = InitializeMatrix(a.NumberOfRows, a.NumberOfColumns, a.Modulus);
            for (int i = 0; i < a.NumberOfRows; i++)
            {
                for (int j = 0; j < a.NumberOfColumns; j++)
                {
                    var diff = a[i, j] - b[i, j];
                    if (a.Modulus.HasValue)
                    {
                        diff = diff % a.Modulus.Value;
                        if (diff < 0)
                        {
                            diff = diff + a.Modulus.Value;
                        }
                    }

                    result[i, j] = diff;
                }
            }

            return result;
        }
    }
}
