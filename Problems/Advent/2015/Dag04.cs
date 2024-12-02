using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2015;

internal class Dag04 : Problem
{
    private const string input = @"yzbqklnj";
    public override Task ExecuteAsync()
    {
        int n = 0;
        var provider = new MD5CryptoServiceProvider();
        string hash = string.Empty;
        while (!hash.StartsWith("000000"))
        {
            n++;
            hash = ByteArrayToString(provider.ComputeHash(ASCIIEncoding.ASCII.GetBytes($"{input}{n}")));
        }

        Result = n.ToString();
        return Task.CompletedTask;
    }

    public static string ByteArrayToString(byte[] ba)
    {
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte b in ba)
            hex.AppendFormat("{0:x2}", b);
        return hex.ToString();
    }

    public override int Nummer => 201504;
}