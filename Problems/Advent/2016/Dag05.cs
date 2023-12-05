using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent;

public class Dag05 : Problem
{
    private const string input = @"wtnhxymk";

    public override Task ExecuteAsync()
    {
        string s = input;
        Result = "........";
        var provider = new MD5CryptoServiceProvider();
        int i = 0;
        while (true)
        {
            var hash = provider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(s+i));
            var hexhash = ByteArrayToString(hash);
            if (hexhash.StartsWith("00000"))
            {
                if (int.TryParse(hexhash[5].ToString(), out var position) && position < 8)
                {
                    if (Result[position] == '.')
                    {
                        Console.WriteLine($"{i} {hexhash}");
                        StringBuilder sb = new StringBuilder(Result);
                        sb[position] = hexhash[6]; ;
                        Result = sb.ToString();
                        if (!Result.Contains('.'))
                        {
                            break;
                        }
                    }
                }
            }

            i++;
        }

        return Task.CompletedTask;
    }


    public static string ByteArrayToString(byte[] ba)
    {
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte b in ba)
            hex.AppendFormat("{0:x2}", b);
        return hex.ToString();
    }

    public override int Nummer => 201605;
}