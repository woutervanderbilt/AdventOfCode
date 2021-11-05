using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent
{
    public class Dag02 : Problem
    {
        private const string input =
            @"DLRRRRLRLDRRRURRURULRLLULUURRRDDLDULDULLUUDLURLURLLDLUUUDUUUULDRDUUDUDDRRLRDDDUDLDLLRUURDRULUULRLRDULULLRLRLRLDRLUULDLDDDDRRLRUUUDDRURRULLLRURLUURULLRLUDDLDRUULDRURULRRRLLLRDLULDRRDDUDLURURLDULDRDRLDDUURRDUDDRDUURDULDUURDUDRDRULDUDUULRRULUUURDUURUDLDURDLRLURUUDRRDLRUDRULRURLDLLDLLRRDRDRLRRRULDRRLDUURLUUDLUUDDLLRULRDUUDURURLUURDRRRUDLRDULRRRLDRDULRUUDDDLRDUULDRLLDRULUULULRDRUUUULULLRLLLRUURUULRRLDDDRULRRRUDURUR
RULRUUUDLLUDURDRDDLLRLLUDRUDDRLRRDLDLDRDULDLULURDLUDDDUULURLDRUUURURLLRRDDDUUDRLRLLDLDRDDDRDUDLRDRDLLLDDLDUDDRUDUUDLLLLLDULRLURRRLLURUUULUDRLRLRLURRDRLLLRLLULRLLLDDLRLRDLUUUUUDULULDDULLUDUURDLRUDLRUDLRLLRLDLULRLDUDRURURDLRULDLULULDLLDLDLDLLLUDUDDLRLRRDULLUDRDDLLLDUURDULUDURLLLDRUDDDLRLULDLDRRDDDRDULDDUDRDDULLULRRLRUULRDUDURUDULUDUDURLDRDUUDDRRLRURDRRLRDDDDRUDLUDLDDLRDLUUDLRRURDDLURDLRDLLRDRDLDLDUUUURULUULDDDDLDULUURRRULUDLLLDRULDRURL
RRRLRDLLDUURDRRRLURDUULUDURDRRUUDURURRLDLLDRDLRRURDDUDDURLRUUDDULULRUUDRLUUDDLLDDDLRRRDLLLLLLRRURDULDLURRURRDDLDDDUDURRDURRRLUDRRULLRULDRLULRULDDRLLRDLRDUURULURLUURLRRULDULULUULDUDLRLDRDDRRRUUULULDUURLRLLURRLURDUUDDDRUULDLLLDRUURLRRLLDDUDRDLDDDULDRDDDUDRRLLLULURDUDLLUUURRLDULURURDDLUDLLRLDRULULURDLDRLURDLRRDRRUULLULDLURRDDUDRDDDLDUDLDRRUDRULDLDULRLLRRRRDDRLUURRRRDDLLRUURRLRURULDDULRLULRURRUULDUUDURDRRLRLUDRULDRUULUUDRDURDURRLULDDDULDDLRDURRUUUUUDDRRDLRDULUUDDL
DRRLLRRLULDDULRDDLRLDRURDDUDULURRDLUUULURRRLLRLULURLLRLLDLLUDDLLRDRURRDLDDURRURDRDDUDDDLLRLDLDLDDDDRRRRUDUDLRDUDDURLLRURRDUDLRLLUDDRLDUUDDLLLUDRRRLLDDULUDDRLLUDDULLDDLRLDLRURRLUDDLULULDLUURDLLUDUDRRRRDULUDLRRLRUDDUUDRRLLRUUDRRLDDLRRRUDRRDRRDDUDLULLURRUURLLLDRDDLUDDDUDDRURURDLRUULLRDRUUDRDUDRLULLDURUUULDDLDRDRUDRUDUULDDRLRDRRDRRRRLRLRUULDDUUDDLLLLRRRDUDLRDLDUDDUURLUDURLDRRRDRUDUDRLDLRLDRDDLUDRURLRDRDLDUDDDLRLULLUULURLDDDULDUDDDLDRLDLURULLUDLLDRULDLLLDUL
LDULURUULLUDLDDRLLDURRULRLURLLURLRRLRDLDDRUURULLRUURUURRUDDDLRRLDDLULDURLLRDURDLLLURLDRULLURLRLDRDRULURDULDLLDUULLLDUDULDURLUDRULRUUUUUUDUUDDDLLURDLDLRLRDLULRDRULUUDRLULLURLRLDURDRRDUDDDURLLUUDRRURUDLDUDRLRLDRLLLLDLLLURRUDDURLDDRULLRRRRDUULDLUDLDRDUUURLDLLLDLRLRRLDDULLRURRRULDLURLURRRRULUURLLUULRURDURURLRRDULLDULLUDURDUDRLUULULDRRDLLDRDRRULLLDDDRDUDLRDLRDDURRLDUDLLRUDRRRUDRURURRRRDRDDRULRRLLDDRRRLDLULRLRRRUDUDULRDLUDRULRRRRLUULRULRLLRLLURDLUURDULRLDLRLURDUURUULUUDRLLUDRULULULLLLRLDLLLDDDLUULUDLLLDDULRDRULURDLLRRDRLUDRD";

        public override Task ExecuteAsync()
        {
            string values = "123456789ABCD";
            IDictionary<int, Button> buttons = new Dictionary<int, Button>();
            for (int i = 0; i <= 12; i++)
            {
                buttons[i] = new Button(values[i]);
            }

                var button = buttons[0];
                button.SetNeighbour('R', buttons[0]);
                button.SetNeighbour('D', buttons[2]);
                button.SetNeighbour('L', buttons[0]);
                button.SetNeighbour('U', buttons[0]);

                button = buttons[1];
                button.SetNeighbour('R', buttons[2]);
                button.SetNeighbour('D', buttons[5]);
                button.SetNeighbour('L', buttons[1]);
                button.SetNeighbour('U', buttons[1]);

                button = buttons[2];
                button.SetNeighbour('R', buttons[3]);
                button.SetNeighbour('D', buttons[6]);
                button.SetNeighbour('L', buttons[1]);
                button.SetNeighbour('U', buttons[0]);

                button = buttons[3];
                button.SetNeighbour('R', buttons[3]);
                button.SetNeighbour('D', buttons[7]);
                button.SetNeighbour('L', buttons[2]);
                button.SetNeighbour('U', buttons[3]);

                button = buttons[4];
                button.SetNeighbour('R', buttons[5]);
                button.SetNeighbour('D', buttons[4]);
                button.SetNeighbour('L', buttons[4]);
                button.SetNeighbour('U', buttons[4]);

                button = buttons[5];
                button.SetNeighbour('R', buttons[6]);
                button.SetNeighbour('D', buttons[9]);
                button.SetNeighbour('L', buttons[4]);
                button.SetNeighbour('U', buttons[1]);

                button = buttons[6];
                button.SetNeighbour('R', buttons[7]);
                button.SetNeighbour('D', buttons[10]);
                button.SetNeighbour('L', buttons[5]);
                button.SetNeighbour('U', buttons[2]);

                button = buttons[7];
                button.SetNeighbour('R', buttons[8]);
                button.SetNeighbour('D', buttons[11]);
                button.SetNeighbour('L', buttons[6]);
                button.SetNeighbour('U', buttons[3]);

                button = buttons[8];
                button.SetNeighbour('R', buttons[8]);
                button.SetNeighbour('D', buttons[8]);
                button.SetNeighbour('L', buttons[6]);
                button.SetNeighbour('U', buttons[8]);

                button = buttons[9];
                button.SetNeighbour('R', buttons[10]);
                button.SetNeighbour('D', buttons[9]);
                button.SetNeighbour('L', buttons[9]);
                button.SetNeighbour('U', buttons[5]);

                button = buttons[10];
                button.SetNeighbour('R', buttons[11]);
                button.SetNeighbour('D', buttons[12]);
                button.SetNeighbour('L', buttons[9]);
                button.SetNeighbour('U', buttons[6]);

                button = buttons[11];
                button.SetNeighbour('R', buttons[11]);
                button.SetNeighbour('D', buttons[11]);
                button.SetNeighbour('L', buttons[10]);
                button.SetNeighbour('U', buttons[7]);

                button = buttons[12];
                button.SetNeighbour('R', buttons[12]);
                button.SetNeighbour('D', buttons[12]);
                button.SetNeighbour('L', buttons[12]);
                button.SetNeighbour('U', buttons[10]);

            var currentButton = buttons[4];
            Result = string.Empty;
            foreach (var line in input.Split(Environment.NewLine))
            {
                foreach (var instruction in line)
                {
                    currentButton = currentButton.Neighbour(instruction);
                    Console.Write(currentButton.Value);
                }

                Result += currentButton.Value;
            }
            
            return Task.CompletedTask;
        }

        public override int Nummer => 201602;

        private class Button
        {
            public Button(char value)
            {
                Value = value;
            }

            private IDictionary<char, Button> neighbours = new Dictionary<char, Button>();

            public char Value { get; }

            public Button Neighbour(char direction)
            {
                return neighbours[direction];
            }

            public void SetNeighbour(char direction, Button button)
            {
                neighbours[direction] = button;
            }
        }
    }
}
