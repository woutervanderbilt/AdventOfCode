using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class LllBase
    {
        private IList<double[]> baseVectors;
        private IList<double[]> gramSchmidt;
        private bool algortihmExecuted;
        private int dimension;
        private int numberOfVectors;

        public LllBase(IList<long[]> baseVectors)
        {
            if (baseVectors.Select(v => v.Length).Distinct().Count() != 1)
            {
                throw new ArgumentException("Niet alle vectors even groot", nameof(baseVectors));
            }
            this.baseVectors = new List<double[]>();
            foreach (var baseVector in baseVectors)
            {
                this.baseVectors.Add(baseVector.Select(c => (double)c).ToArray());
            }

            dimension = baseVectors[0].Length;
            numberOfVectors = baseVectors.Count;
        }

        public IList<long[]> ReducedBase()
        {
            if (!algortihmExecuted)
            {
                Execute();
            }

            return baseVectors.Select(b => b.Select(d => (long)Math.Round(d)).ToArray()).ToList();
        }

        private void Execute()
        {
            ComputeGramSchmidt();
            int k = 1;
            while (k < baseVectors.Count)
            {
                for (int j = k - 1; j >= 0; j--)
                {
                    var mukj = GramSchmidtCoefficient(k, j);
                    if (Math.Abs(mukj) > .5)
                    {
                        baseVectors[k] = Minus(baseVectors[k], ScalarMultiply(Math.Round(mukj), baseVectors[j]));
                        ComputeGramSchmidt();
                    }
                }

                var mukkMinusOne = GramSchmidtCoefficient(k, k - 1);
                if (InnerProduct(gramSchmidt[k], gramSchmidt[k]) >= (.95 - mukkMinusOne * mukkMinusOne) *
                    InnerProduct(gramSchmidt[k - 1], gramSchmidt[k - 1]))
                {
                    k++;
                }
                else
                {
                    var bk = baseVectors[k];
                    baseVectors[k] = baseVectors[k - 1];
                    baseVectors[k - 1] = bk;
                    ComputeGramSchmidt();
                    k = Math.Max(k - 1, 1);
                }
            }
        }

        private double[] ScalarMultiply(double s, double[] v)
        {
            return v.Select(c => s * c).ToArray();
        }

        private double InnerProduct(double[] a, double[] b)
        {
            double res = 0;
            for (int i = 0; i < a.Length; i++)
            {
                res += a[i] * b[i];
            }

            return res;
        }

        private double[] Projection(double[] u, double[] v)
        {
            var factor = InnerProduct(u, v) / InnerProduct(u, u);
            return ScalarMultiply(factor, u);
        }

        private double[] Minus(double[] l, double[] r)
        {
            double[] res = new double[dimension];
            for (int i = 0; i < dimension; i++)
            {
                res[i] = l[i] - r[i];
            }

            return res;
        }


        private void ComputeGramSchmidt()
        {
            gramSchmidt = new List<double[]>();
            for (int i = 0; i < numberOfVectors; i++)
            {
                var res = baseVectors[i];
                for (int j = 0; j < i; j++)
                {
                    res = Minus(res, Projection(gramSchmidt[j], baseVectors[i]));
                }
                gramSchmidt.Add(res);
            }
        }

        private double GramSchmidtCoefficient(int i, int j)
        {
            return InnerProduct(baseVectors[i], gramSchmidt[j]) / InnerProduct(gramSchmidt[j], gramSchmidt[j]);
        }
    }
}
