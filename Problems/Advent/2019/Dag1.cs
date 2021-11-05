using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2019
{
    public class Dag1 : Problem
    {
        public override Task ExecuteAsync()
        {
            IList<int> input = new List<int>
            {
                74819, 111192, 104476, 53965, 89875, 147914, 120203, 73658, 80054, 75468, 88811, 73140, 90128, 51639,
                70417, 102818, 106523, 77151, 118711, 146183, 143477, 89008, 67987, 94512, 98199, 118483, 91978, 53595,
                144819, 130211, 103326, 113805, 50204, 138909, 113345, 142697, 121281, 128132, 98383, 127929, 88562,
                135418, 65123, 94330, 107136, 85822, 86208, 93398, 110176, 143538, 98851, 56280, 84734, 52873, 51898,
                66332, 91624, 75662, 125892, 137867, 114748, 124360, 81075, 140638, 77417, 86881, 50250, 131326, 88877,
                141095, 147701, 103934, 101008, 140186, 117845, 149923, 138631, 93188, 74299, 89504, 75185, 72688,
                53057, 50200, 124950, 110233, 114558, 94047, 112376, 122374, 115571, 136289, 115146, 80924, 140787,
                125638, 99960, 61024, 138366, 127943
            };
            Result = input.Sum(TotalRequiredFuel).ToString();
            return Task.CompletedTask;

            int TotalRequiredFuel(int f)
            {
                int total = 0;
                var r = RequiredFuel(f);
                while (r > 0)
                {
                    total += r;
                    r = RequiredFuel(r);
                }

                return total;
            }

            int RequiredFuel(int f)
            {
                return f / 3 - 2;
            }
        }

        public override int Nummer => 201901;
    }
}
