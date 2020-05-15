using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication10
{
    class DataCalc
    {
        private double argx;
        private double[] val;

        public DataCalc(int n)
        {
            argx = 0;
            val = new double[n];
        }

        public double GetArg()
        {
            return argx;
        }

        public double[] GetVal()
        {
            return val;
        }

        public void SetArg(double x)
        {
            argx = x;
        }

        public void SetVal(double[] x)
        {
            int n = x.Length;
            for (int i = 0; i < n; i++)
            {
                val[i] = x[i];
            }
        }
    }
}
