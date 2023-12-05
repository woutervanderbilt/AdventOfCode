using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2018;

public class Dag9 : Problem
{
    const int numberOfElves = 464;
    private const int highestMarble = 7091800;

    public override Task ExecuteAsync()
    {
        long[] scores = new long[numberOfElves];
        Marble marble = new Marble();
        marble.LeftNeighbour = marble;
        marble.RightNeighbour = marble;
        Marble currentMarble = marble;
        for (int i = 1; i <= highestMarble; i++)
        {
            if (i % 23 == 0)
            {
                for (int l = 1; l <= 7; l++)
                {
                    currentMarble = currentMarble.LeftNeighbour;
                }

                scores[i % numberOfElves] += i + currentMarble.Value;
                currentMarble.LeftNeighbour.RightNeighbour = currentMarble.RightNeighbour;
                currentMarble.RightNeighbour.LeftNeighbour = currentMarble.LeftNeighbour;
                currentMarble = currentMarble.RightNeighbour;
            }
            else
            {
                Marble newMarble = new Marble {Value = i};
                newMarble.LeftNeighbour = currentMarble.RightNeighbour;
                newMarble.RightNeighbour = currentMarble.RightNeighbour.RightNeighbour;
                newMarble.LeftNeighbour.RightNeighbour = newMarble;
                newMarble.RightNeighbour.LeftNeighbour = newMarble;
                currentMarble = newMarble;
            }
        }

        Result = scores.Max().ToString();
        return Task.CompletedTask;
    }

    public override int Nummer => 201809;

    private class Marble
    {
        public Marble LeftNeighbour { get; set; }
        public Marble RightNeighbour { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"{LeftNeighbour.Value} - {Value} - {RightNeighbour.Value}";
        }
    }
}