using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public class SquareMatrix : Matrix
    {
        public SquareMatrix(int size, long? modulus = null) : base(size, size, modulus)
        {
        }

        public static SquareMatrix Identity(int size, long? modulus)
        {
            var result = new SquareMatrix(size, modulus);
            for (int i = 0; i < size; i++)
            {
                result[i, i] = 1;
            }

            return result;
        }

        public SquareMatrix PowerMod(long e)
        {
            if (e == 0)
            {
                return Identity(NumberOfColumns, Modulus);
            }
            SquareMatrix result = null;
            SquareMatrix currentPower = this;
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
                        result = (SquareMatrix)result.Times(currentPower);
                    }
                }

                currentPower = (SquareMatrix) currentPower.Times(currentPower);
                e /= 2;
            }

            return result;
        }

    }
}
