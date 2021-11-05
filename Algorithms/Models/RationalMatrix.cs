using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public class RationalMatrix
    {
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        private Rational[,] values;

        public RationalMatrix(int numberOfRows, int numberOfColumns)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            values = new Rational[numberOfRows, numberOfColumns];
            for (int r = 0; r < NumberOfRows; r++)
            {
                for (int c = 0; c < NumberOfColumns; c++)
                {
                    values[r, c] = Rational.Zero;
                }
            }
        }

        public Rational this[int row, int column]
        {
            get => values[row, column];
            set => values[row, column] = value;
        }

        public RationalMatrix Times(RationalMatrix right)
        {
            if (NumberOfColumns != right.NumberOfRows)
            {
                throw new ArgumentException("Dimensies matchen niet");
            }

            var result = InitializeMatrix(NumberOfRows, right.NumberOfColumns);
            Parallel.For(0, NumberOfRows, r =>
            {
                for (int c = 0; c < right.NumberOfColumns; c++)
                {
                    Rational newValue = 0;

                    for (int i = 0; i < NumberOfColumns; i++)
                    {
                        newValue += this[r, i] * right[i, c];
                    }

                    result[r, c] = newValue;
                }
            });
            return result;
        }

        private static RationalMatrix InitializeMatrix(int numberOfRows, int numberOfColumns)
        {
            if (numberOfRows == numberOfColumns)
            {
                return new SquareRationalMatrix(numberOfRows);
            }

            return new RationalMatrix(numberOfRows, numberOfColumns);
        }

        public static RationalMatrix operator +(RationalMatrix a, RationalMatrix b)
        {
            if (a.NumberOfColumns != b.NumberOfColumns || a.NumberOfColumns != b.NumberOfColumns)
            {
                throw new ArgumentException("Dimensies matchen niet");
            }

            var result = InitializeMatrix(a.NumberOfRows, a.NumberOfColumns);
            for (int i = 0; i < a.NumberOfRows; i++)
            {
                for (int j = 0; j < a.NumberOfColumns; j++)
                {
                    var sum = a[i, j] + b[i, j];
                    result[i, j] = sum;
                }
            }

            return result;
        }

        public static RationalMatrix operator -(RationalMatrix a, RationalMatrix b)
        {
            if (a.NumberOfColumns != b.NumberOfColumns || a.NumberOfRows != b.NumberOfRows)
            {
                throw new ArgumentException("Dimensies matchen niet");
            }

            var result = InitializeMatrix(a.NumberOfRows, a.NumberOfColumns);
            for (int i = 0; i < a.NumberOfRows; i++)
            {
                for (int j = 0; j < a.NumberOfColumns; j++)
                {
                    var diff = a[i, j] - b[i, j];
                    result[i, j] = diff;
                }
            }

            return result;
        }
    }

    public class SquareRationalMatrix : RationalMatrix
    {
        public SquareRationalMatrix(int size) : base(size, size)
        {
        }

        public static SquareRationalMatrix Identity(int size)
        {
            var result = new SquareRationalMatrix(size);
            for (int i = 0; i < size; i++)
            {
                result[i, i] = 1;
            }

            return result;
        }

        public SquareRationalMatrix Inverse()
        {
            IList<IList<Rational>> oldMatrix = new List<IList<Rational>>();
            IList<IList<Rational>> newMatrix = new List<IList<Rational>>();
            for (int r = 0; r < NumberOfColumns; r++)
            {
                IList<Rational> oldRow = new List<Rational>();
                IList<Rational> newRow = new List<Rational>();
                for (int c = 0; c < NumberOfColumns; c++)
                {
                    newRow.Add(c == r ? 1 : 0);
                    oldRow.Add(this[r, c]);
                }

                oldMatrix.Add(oldRow);
                newMatrix.Add(newRow);
            }

            for (int i = 0; i < NumberOfColumns; i++)
            {
                int j = i;
                while (oldMatrix[i][i].Numerator == 0)
                {
                    j++;
                }

                if (j != i)
                {
                    MoveRow(j, i);
                }

                ScalarMultiplyRow(i, 1 / oldMatrix[i][i]);

                for (int k = i + 1; k < NumberOfColumns; k++)
                {
                    if (oldMatrix[k][i].Numerator != 0)
                    {
                        AddNthRowKTimesToMthRow(i, k, -oldMatrix[k][i]);
                    }
                }
            }


            for (int i = NumberOfColumns - 1; i >= 0; i--)
            {
                for (int k = i - 1; k >= 0; k--)
                {
                    if (oldMatrix[k][i].Numerator != 0)
                    {
                        AddNthRowKTimesToMthRow(i, k, -oldMatrix[k][i]);
                    }
                }
            }





            var result = new SquareRationalMatrix(NumberOfColumns);
            for (int r = 0; r < NumberOfColumns; r++)
            {
                for (int c = 0; c < NumberOfColumns; c++)
                {
                    result[r, c] = newMatrix[r][c];
                }
            }

            return result;

            void MoveRow(int from, int to)
            {
                var oldRowToMove = oldMatrix[from];
                oldMatrix.Insert(to, oldRowToMove);
                oldMatrix.RemoveAt(from + (to <= from ? 1 : 0));

                var newRoTowMove = newMatrix[from];
                newMatrix.Insert(to, newRoTowMove);
                newMatrix.RemoveAt(from + (to <= from ? 1 : 0));
            }

            void AddNthRowKTimesToMthRow(int n, int m, Rational k)
            {
                var oldNthRow = oldMatrix[n];
                var oldMthRow = oldMatrix[m];
                var newNthRow = newMatrix[n];
                var newMthRow = newMatrix[m];
                for (int i = 0; i < NumberOfColumns; i++)
                {
                    oldMthRow[i] += k * oldNthRow[i];
                    newMthRow[i] += k * newNthRow[i];
                }
            }

            void ScalarMultiplyRow(int n, Rational k)
            {
                var oldRow = oldMatrix[n];
                var newRow = newMatrix[n];
                for (int c = 0; c < NumberOfColumns; c++)
                {
                    oldRow[c] *= k;
                    newRow[c] *= k;
                }
            }

        }

        public SquareRationalMatrix ToThePower(long e)
        {
            if (e == 0)
            {
                return Identity(NumberOfColumns);
            }

            SquareRationalMatrix result = null;
            SquareRationalMatrix currentPower = this;
            while (e > 0)
            {
                if (e % 2 == 1)
                {
                    if (result == null)
                    {
                        result = currentPower;
                    }
                    else
                    {
                        result = (SquareRationalMatrix) result.Times(currentPower);
                    }
                }

                currentPower = (SquareRationalMatrix) currentPower.Times(currentPower);
                e /= 2;
            }

            return result;
        }
    }
}
