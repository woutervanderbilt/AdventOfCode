using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public class SquareDecimalMatrix : DecimalMatrix
    {
        public SquareDecimalMatrix(int size) : base(size, size)
        {
        }

        public static SquareDecimalMatrix Identity(int size)
        {
            var result = new SquareDecimalMatrix(size);
            for (int i = 0; i < size; i++)
            {
                result[i, i] = 1;
            }

            return result;
        }

        public SquareDecimalMatrix Inverse()
        {
            IList<IList<decimal>> oldMatrix = new List<IList<decimal>>();
            IList<IList<decimal>> newMatrix = new List<IList<decimal>>();
            for (int r = 0; r < NumberOfColumns; r++)
            {
                IList<decimal> oldRow = new List<decimal>();
                IList<decimal> newRow = new List<decimal>();
                for (int c = 0; c < NumberOfColumns; c++)
                {
                    newRow.Add(c==r ? 1 : 0);
                    oldRow.Add(this[r,c]);
                }
                oldMatrix.Add(oldRow);
                newMatrix.Add(newRow);
            }

            for (int i = 0; i < NumberOfColumns; i++)
            {
                int j = i;
                while (oldMatrix[i][i] == 0)
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
                    if (oldMatrix[k][i] != 0)
                    {
                        AddNthRowKTimesToMthRow(i, k, -oldMatrix[k][i]);
                    }
                }
            }


            for (int i = NumberOfColumns - 1; i >= 0; i--)
            {
                for (int k = i - 1; k >= 0; k--)
                {
                    if (oldMatrix[k][i] != 0)
                    {
                        AddNthRowKTimesToMthRow(i, k, -oldMatrix[k][i]);
                    }
                }
            }





            var result = new SquareDecimalMatrix(NumberOfColumns);
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

            void AddNthRowKTimesToMthRow(int n, int m, decimal k)
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

            void ScalarMultiplyRow(int n, decimal k)
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

        public SquareDecimalMatrix ToThePower(long e)
        {
            if (e == 0)
            {
                return Identity(NumberOfColumns);
            }
            SquareDecimalMatrix result = null;
            SquareDecimalMatrix currentPower = this;
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
                        result = (SquareDecimalMatrix)result.Times(currentPower);
                    }
                }

                currentPower = (SquareDecimalMatrix)currentPower.Times(currentPower);
                e /= 2;
            }

            return result;
        }
    }
}
