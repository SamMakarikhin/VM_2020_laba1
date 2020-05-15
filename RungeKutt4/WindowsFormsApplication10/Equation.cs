using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication10
{
    class Equation
    {
        private double[] Ffunction(double[] v, double[] coefs)
        {
            double[] res = new double[2];
            res[0] = v[0] - Math.Pow(v[0], 3) * Math.Pow(3, -1) - v[1];
            res[1] = coefs[1] * (v[0] + coefs[0]);
            return res;
        }

        private DataCalc RungeIterration(double oldarg, double[] oldval, double h, double[] coefs)
        {
            int n = oldval.Length;
            DataCalc res = new DataCalc(n);
            res.SetVal(Runge4(oldval, h, coefs));
            res.SetArg(oldarg + h);
            return res;
        }

        public List<DataCalc> RungeMethod(double xl, double xr, double[] u0, double h, double[] coefs, int Nmax)
        {
            int n = u0.Length;
            List<DataCalc> traj = new List<DataCalc>();
            DataCalc start = new DataCalc(n);
            DataCalc temp;
            start.SetArg(xl);
            start.SetVal(u0);
            traj.Add(start);
            int sumIter = 0;
            while (sumIter < Nmax)
            {
                temp = new DataCalc(n);
                temp = RungeIterration(traj.Last().GetArg(), traj.Last().GetVal(), h, coefs);
                traj.Add(temp);
                sumIter++;
            }
            return traj;
        }

        private double[] Runge4(double[] val, double h, double[] coefs)
        {
            int n = val.Length;
            double[] res = new double[n];
            double[] temp = new double[n];
            double[] k1 = new double[n];
            double[] k2 = new double[n];
            double[] k3 = new double[n];
            double[] k4 = new double[n];
            k1 = Ffunction(val, coefs);
            temp = GetTemp(val, k1, 0.5 * h);
            k2 = Ffunction(temp, coefs);
            temp = GetTemp(val, k2, 0.5 * h);
            k3 = Ffunction(temp, coefs);
            temp = GetTemp(val, k3, h);
            k4 = Ffunction(temp, coefs);
            for (int i = 0; i < n; i++)
            {
                res[i] = val[i] + (h * (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i])) / 6;
            }
            return res;
        }

        private double[] GetTemp(double[] val, double[] k, double h)
        {
            int n = val.Length;
            double[] res = new double[n];
            for (int i = 0; i < n; i++)
            {
                res[i] = val[i] + h * k[i];
            }
            return res;
        }
    }
}
