using System.Threading.Tasks;

namespace Problems.Advent._2018
{
    public class Dag11 : Problem
    {
        private const int input = 1955;

        public override Task ExecuteAsync()
        {
            int[,] cells = new int[300,300];
            for (int x = 1; x <= 300; x++)
            {
                for (int y = 1; y <= 300; y++)
                {
                    cells[x - 1, y - 1] = CalculateCellValue(x, y);
                }
            }

            int max = -1000;
            int xMax = -1;
            int yMax = -1;
            int aMax = -1;

            for (int x = 1; x <= 298; x++)
            {
                for (int y = 1; y <= 298; y++)
                {
                    for (int a = 1; x + a <= 301 && y + a <= 301; a++)
                    {
                        int block = 0;
                        for (int xx = x - 1; xx < x + a - 1; xx++)
                        {
                            for (int yy = y - 1; yy < y + a - 1; yy++)
                            {
                                block += cells[xx, yy];
                            }
                        }


                        if (block > max)
                        {
                            max = block;
                            xMax = x;
                            yMax = y;
                            aMax = a;
                        }
                    }
                }
            }

            Result = $"{xMax},{yMax},{aMax}";
            return Task.CompletedTask;
        }

        private int CalculateCellValue(int x, int y)
        {
            return ((((x + 10) * y) + input) * (x + 10) % 1000) / 100 - 5;
        }

        public override int Nummer => 201811;
    }
}
