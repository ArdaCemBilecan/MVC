using System;
using System.Collections.Generic;
using System.Text;

namespace OperatorOverLoading
{
    class KarmasikSayi
    {
        private double mGercek;
        private double mSanal;
        public double Gercek
        {
            get { return mGercek; }
            set { mGercek = value; }
        }
        public double Sanal
        {
            get { return mSanal; }
            set { mSanal = value; }
        }
        public KarmasikSayi(double x, double y)
        {
            mGercek = x;
            mSanal = y;
        }
        public KarmasikSayi()
        {
            mGercek = 0;
            mSanal = 0;
        }


        public KarmasikSayi(KarmasikSayi k)
        {
            mGercek = k.mGercek;
            mSanal = k.mSanal;
        }
        public void Yaz()
        {
            if (mSanal > 0)
                Console.WriteLine("{0}+{1}i",
                mGercek,
                mSanal);
            else
                Console.WriteLine("{0}-{1}i",
                mGercek,
                -mSanal);
        }

        public static KarmasikSayi operator +(KarmasikSayi a,KarmasikSayi b)
        {
            double gt = a.Gercek + b.Gercek;
            double st = a.Sanal + b.Sanal;
            return new KarmasikSayi(gt, st);
        }

        public static KarmasikSayi operator +(KarmasikSayi a, double b)
        {
            double st = a.Sanal + b;
            return new KarmasikSayi(a.Gercek, st);
        }

        public static KarmasikSayi operator +(double b, KarmasikSayi a)
        {
            double gt = a.Gercek + b;
            double st = a.Sanal;
            return new KarmasikSayi(gt, st);
        }



    }
}
