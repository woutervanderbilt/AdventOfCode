using System.Threading.Tasks;

namespace Problems.Advent;

public class Dag19 : Problem
{
    private const int input = 3014603;

    public override Task ExecuteAsync()
    {
        Elf previous = null;
        Elf first = null;
        for (int i = 1; i <= input; i++)
        {
            var elf = new Elf(i);
            elf.LeftNeighbour = previous;
            if (previous != null)
            {
                previous.RightNeighbour = elf;
            }

            if (first == null)
            {
                first = elf;
            }
            previous = elf;
        }


        previous.RightNeighbour = first;
        first.LeftNeighbour = previous;
        Elf currentElf = first;
        while (currentElf.LeftNeighbour != currentElf)
        {
            var skippedElf = currentElf.RightNeighbour;
            currentElf.RightNeighbour = skippedElf.RightNeighbour;
            currentElf.RightNeighbour.LeftNeighbour = currentElf;
            currentElf = currentElf.RightNeighbour;
        }

        Result = currentElf.Number.ToString();
        return Task.CompletedTask;
    }

    private class Elf
    {
        public Elf(int number)
        {
            Number = number;
        }

        public int Number { get; }
        public Elf LeftNeighbour { get; set; }
        public Elf RightNeighbour { get; set; }
    }

    public override int Nummer => 201619;
}