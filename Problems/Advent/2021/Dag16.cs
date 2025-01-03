﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2021;

internal class Dag16 : Problem
{
    private const string input = @"420D610055D273AF1630010092019207300B278BE5932551E703E608400C335003900AF0402905009923003880856201E95C00B60198D400B50034400E20101DC00E10024C00F1003C400B000212697140249D049F0F8952A8C6009780272D5D074B5741F3F37730056C0149658965E9AED7CA8401A5CC45BB801F0999FFFEEE0D67050C010C0036278A62D4D737F359993398027800BECFD8467E3109945C1008210C9C442690A6F719C48A351006E9359C1C5003E739087E80F27EC29A0030322BD2553983D272C67508E5C0804639D4BD004C401B8B918E3600021D1061D47A30053801C89EF2C4CCFF39204C53C212DABED04C015983A9766200ACE7F95C80D802B2F3499E5A700267838803029FC56203A009CE134C773A2D3005A77F4EDC6B401600043A35C56840200F4668A71580043D92D5A02535BAF7F9A89CF97C9F59A4F02C400C249A8CF1A49331004CDA00ACA46517E8732E8D2DB90F3005E92362194EF5E630CA5E5EEAD1803E200CC228E70700010A89D0BE3A08033146164177005A5AEEB1DA463BDC667600189C9F53A6FF6D6677954B27745CA00BCAE53A6EEDC60074C920001B93CFB05140289E8FA4812E071EE447218CBE1AA149008DBA00A497F9486262325FE521898BC9669B382015365715953C5FC01AA8002111721D4221007E13C448BA600B4F77F694CE6C01393519CE474D46009D802C00085C578A71E4001098F518639CC301802B400E7CDDF4B525C8E9CA2188032600E44B8F1094C0198CB16A29180351EA1DC3091F47A5CA0054C4234BDBC2F338A77B84F201232C01700042A0DC7A8A0200CC578B10A65A000601048B24B25C56995A30056C013927D927C91AB43005D127FDC610EF55273F76C96641002A4F0F8C01CCC579A8D68E52587F982996F537D600";
    public override Task ExecuteAsync()
    {
        var testinput = "A0016C880162017C3686B18A3D4780";
        var binaryInputBuilder = new StringBuilder();
        foreach (var c in input)
        {
            binaryInputBuilder.Append(Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'));
        }

        var binaryInput = binaryInputBuilder.ToString();

        var packet = new Packet(binaryInput);

        Result = $"{packet.VersionSum()} {packet.Value()}";


        return Task.CompletedTask;
    }


    private class Packet
    {
        public Packet(string binary)
        {
            var version = binary.Substring(0, 3);
            Version = Convert.ToInt32(version, 2);
            var type = binary.Substring(3, 3);
            Type = Convert.ToInt32(type, 2);
            if (Type == 4)
            {
                var value = new StringBuilder();
                int i = 6;
                while (i + 5 < binary.Length)
                {
                    var substring = binary.Substring(i, 5);
                    value.Append(substring.Substring(1));
                    if (substring.StartsWith("0"))
                    {
                        break;
                    }
                    i += 5;
                }

                LiteralValue = Convert.ToInt64(value.ToString(), 2);
                Remaining = binary.Substring(i + 5);
                Length = i + 5;
            }
            else
            {
                LengthType = binary[6];
                if (LengthType == '0')
                {
                    SubPacketLength = Convert.ToInt32(binary.Substring(7, 15), 2);
                    int totalSubPacketLength = 0;
                    while (totalSubPacketLength < SubPacketLength)
                    {
                        var subPacket = new Packet(binary.Substring(22 + totalSubPacketLength));
                        totalSubPacketLength += subPacket.Length;
                        SubPackets.Add(subPacket);
                    }

                    Length = 22 + SubPacketLength;
                    Remaining = binary.Substring(Length);

                }
                else
                {
                    SubPacketCount = Convert.ToInt32(binary.Substring(7, 11), 2);
                    var totalSubPacketLength = 0;
                    for (int i = 0; i < SubPacketCount; i++)
                    {
                        var subPacket = new Packet(binary.Substring(18 + totalSubPacketLength));
                        totalSubPacketLength += subPacket.Length;
                        SubPackets.Add(subPacket);
                    }

                    Length = 18 + totalSubPacketLength;
                    Remaining = binary.Substring(Length);
                }
            }
        }

        public long VersionSum()
        {
            return Version + SubPackets.Sum(s => s.VersionSum());
        }

        public int Version { get; set; }
        public int Type { get; set; }
        public char LengthType { get; set; }

        public long LiteralValue { get; set; }
        public int SubPacketLength { get; set; }
        public int SubPacketCount { get; set; }
        public string Remaining { get; set; }
        public int Length { get; set; }

        public IList<Packet> SubPackets { get; set; } = new List<Packet>();

        public long Value()
        {
            return Type switch
            {
                0 => SubPackets.Sum(s => s.Value()),
                1 => SubPackets.Aggregate(1l, (a, b) => a * b.Value()),
                2 => SubPackets.Select(s => s.Value()).Min(),
                3 => SubPackets.Select(s => s.Value()).Max(),
                4 => LiteralValue,
                5 => SubPackets[0].Value() > SubPackets[1].Value() ? 1 : 0,
                6 => SubPackets[0].Value() < SubPackets[1].Value() ? 1 : 0,
                7 => SubPackets[0].Value() == SubPackets[1].Value() ? 1 : 0,
                _ => throw new Exception()
            };
        }
    }

    public override int Nummer => 202116;
}