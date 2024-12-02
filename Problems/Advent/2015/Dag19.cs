using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Problems.Advent._2015;

internal class Dag19 : Problem
{
    private const string input = @"Al => ThF
Al => ThRnFAr
B => BCa
B => TiB
B => TiRnFAr
Ca => CaCa
Ca => PB
Ca => PRnFAr
Ca => SiRnFYFAr
Ca => SiRnMgAr
Ca => SiTh
F => CaF
F => PMg
F => SiAl
H => CRnAlAr
H => CRnFYFYFAr
H => CRnFYMgAr
H => CRnMgYFAr
H => HCa
H => NRnFYFAr
H => NRnMgAr
H => NTh
H => OB
H => ORnFAr
Mg => BF
Mg => TiMg
N => CRnFAr
N => HSi
O => CRnFYFAr
O => CRnMgAr
O => HP
O => NRnFAr
O => OTi
P => CaP
P => PTi
P => SiRnFAr
Si => CaSi
Th => ThCa
Ti => BP
Ti => TiTi
e => HF
e => NAl
e => OMg";

    private const string input2 = @"e => H
e => O
H => HO
H => OH
O => HH";

    const string medicine = @"ORnPBPMgArCaCaCaSiThCaCaSiThCaCaPBSiRnFArRnFArCaCaSiThCaCaSiThCaCaCaCaCaCaSiRnFYFArSiRnMgArCaSiRnPTiTiBFYPBFArSiRnCaSiRnTiRnFArSiAlArPTiBPTiRnCaSiAlArCaPTiTiBPMgYFArPTiRnFArSiRnCaCaFArRnCaFArCaSiRnSiRnMgArFYCaSiRnMgArCaCaSiThPRnFArPBCaSiRnMgArCaCaSiThCaSiRnTiMgArFArSiThSiThCaCaSiRnMgArCaCaSiRnFArTiBPTiRnCaSiAlArCaPTiRnFArPBPBCaCaSiThCaPBSiThPRnFArSiThCaSiThCaSiThCaPTiBSiRnFYFArCaCaPRnFArPBCaCaPBSiRnTiRnFArCaPRnFArSiRnCaCaCaSiThCaRnCaFArYCaSiRnFArBCaCaCaSiThFArPBFArCaSiRnFArRnCaCaCaFArSiRnFArTiRnPMgArF";
    private const string medicine2 = @"HOHOHO";

    public override Task ExecuteAsync()
    {
        HashSet<string> results = new HashSet<string>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var words = line.Split(' ');
            int length = words[0].Length;
            for (int i = 0; i <= medicine.Length - length; i++)
            {
                var s = medicine.Substring(i, length);
                if (s == words[0])
                {
                    results.Add(medicine.Remove(i, length).Insert(i, words[2]));
                }
            }
        }

        Result = results.Count.ToString();

        HashSet<string> molecules = new HashSet<string>();
        molecules.Add("e");
        int steps = 0;

        HashSet<string> newMedicines = new HashSet<string> { "e" };
        while (!molecules.Contains(medicine))
        {
            var nextNewMedicines = new HashSet<string>();
            foreach (var newMedicine in newMedicines)
            {
                foreach (var line in Input.Split(Environment.NewLine))
                {
                    var words = line.Split(' ');
                    int length = words[0].Length;
                    for (int i = 0; i <= newMedicine.Length - length; i++)
                    {
                        var s = newMedicine.Substring(i, length);
                        if (s == words[0])
                        {
                            var nextMedicine = newMedicine.Remove(i, length).Insert(i, words[2]);
                            var nml = nextMedicine.Length;
                            int n = 15;
                            if (nextMedicine.Length <= medicine.Length && (nml < n || nextMedicine.Substring(0, nml - n + 1) == medicine.Substring(0, nml - n + 1)))
                            {
                                if (!molecules.Contains(nextMedicine))
                                {
                                    molecules.Add(nextMedicine);
                                    nextNewMedicines.Add(nextMedicine);
                                }
                            }
                        }
                    }
                }
            }

            newMedicines = nextNewMedicines;

            steps++;
            Console.WriteLine($"{steps}: {newMedicines.Count}");
        }

        Result = steps.ToString();
        return Task.CompletedTask;
    }

    public override int Nummer => 201519;
}