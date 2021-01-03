using System;

namespace OperatorOverLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            KarmasikSayi k1 = new KarmasikSayi(-5, -6);
            KarmasikSayi k2 = new KarmasikSayi(4, 7);
            KarmasikSayi t = k1 + k2;
            Console.WriteLine("k1 + k2 = "+t.Gercek +" "+ t.Sanal);
            Console.WriteLine("**************************");
            KarmasikSayi a = new KarmasikSayi(5, 5.5);
            KarmasikSayi b = new KarmasikSayi(5, 5.5);
            var z = a + b;
            Console.WriteLine("a+b= "+z.Gercek +" "+ z.Sanal);

            var toplam = 10 + new KarmasikSayi(10, 1.5);
            Console.WriteLine("Toplam = "+toplam.Gercek+" "+toplam.Sanal);

            var toplam2 =  new KarmasikSayi(10, 1.5) + 6;
            Console.WriteLine("Toplam2 = " + toplam2.Gercek + " " + toplam2.Sanal);

             


        }
    }
}
