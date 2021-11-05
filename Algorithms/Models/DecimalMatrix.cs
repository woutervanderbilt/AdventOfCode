using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public class DecimalMatrix
    {
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        private decimal[,] values;
        public DecimalMatrix(int numberOfRows, int numberOfColumns)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            values = new decimal[numberOfRows, numberOfColumns];
        }

        public decimal this[int row, int column]
        {
            get => values[row, column];
            set => values[row, column] = value;
        }

        public DecimalMatrix Times(DecimalMatrix right)
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
                    decimal newValue = 0;
                   
                        for (int i = 0; i < NumberOfColumns; i++)
                        {
                            newValue += this[r, i] * right[i, c];
                        }

                    result[r, c] = newValue;
                }
            });
            return result;
        }

        private static DecimalMatrix InitializeMatrix(int numberOfRows, int numberOfColumns)
        {
            if (numberOfRows == numberOfColumns)
            {
                return new SquareDecimalMatrix(numberOfRows);
            }
            return new DecimalMatrix(numberOfRows, numberOfColumns);
        }

        public static DecimalMatrix operator +(DecimalMatrix a, DecimalMatrix b)
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

        public static DecimalMatrix operator -(DecimalMatrix a, DecimalMatrix b)
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
}
