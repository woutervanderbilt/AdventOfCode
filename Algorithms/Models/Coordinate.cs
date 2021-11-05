using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public struct Coordinate : IComparable<Coordinate>
    {
        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }

        public override string ToString()
        {
            return $"{Row},{Column}";
        }


        public int CompareTo(Coordinate other)
        {
            var rowComparison = Row.CompareTo(other.Row);
            if (rowComparison != 0) return rowComparison;
            return Column.CompareTo(other.Column);
        }

        public static bool operator <(Coordinate left, Coordinate right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Coordinate left, Coordinate right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Coordinate left, Coordinate right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Coordinate left, Coordinate right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
