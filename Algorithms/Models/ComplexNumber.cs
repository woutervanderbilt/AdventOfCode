using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models;

public struct ComplexNumber
{
    public static readonly ComplexNumber I = new ComplexNumber(0, 1);

    public ComplexNumber(Rational realPart, Rational imaginaryPart)
    {
        RealPart = realPart;
        ImaginaryPart = imaginaryPart;
    }

    public Rational RealPart { get; }
    public Rational ImaginaryPart { get; }

    public static ComplexNumber operator +(ComplexNumber l, ComplexNumber r) => new ComplexNumber(l.RealPart + r.RealPart, l.ImaginaryPart + r.ImaginaryPart);

    public static ComplexNumber operator -(ComplexNumber l, ComplexNumber r) => new ComplexNumber(l.RealPart - r.RealPart, l.ImaginaryPart - r.ImaginaryPart);

    public static ComplexNumber operator *(ComplexNumber l, ComplexNumber r) => new ComplexNumber(l.RealPart * r.RealPart - l.ImaginaryPart * r.ImaginaryPart, l.RealPart * r.ImaginaryPart + l.ImaginaryPart * r.RealPart);

    public static ComplexNumber operator /(ComplexNumber l, ComplexNumber r)
    {
        return l * r.Inverse();
    }

    public static ComplexNumber operator -(ComplexNumber c)
    {
        return new ComplexNumber(-c.RealPart, c.ImaginaryPart);
    }

    public static implicit operator ComplexNumber(Rational r)
    {
        return new ComplexNumber(r, 0);
    }
    public ComplexNumber Inverse() => new ComplexNumber(RealPart/ (RealPart * RealPart + ImaginaryPart * ImaginaryPart), -ImaginaryPart/ (RealPart * RealPart + ImaginaryPart * ImaginaryPart));
    public ComplexNumber Conjugate() => new ComplexNumber(RealPart, -ImaginaryPart);

    public ComplexNumber ToThePower(int e)
    {
        var power = this;
        var result = new ComplexNumber(1,0);
        while (e > 0)
        {
            if (e % 2 == 1)
            {
                result = result * power;
            }

            power = power * power;
            e /= 2;
        }

        return result;
    }

    public override string ToString() => $"{RealPart} + {ImaginaryPart}i";
}