using System;
using System.IO;

namespace OkunanSatirSil
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            string[] satirlar = System.IO.File.ReadAllLines("Dosya Yolu");
            int len = satirlar.Length;
            Console.WriteLine("Kaçıncı satıra kadar silmek istiyorsunuz ? : ");

            i = Convert.ToInt32(Console.ReadLine());
            
            using(StreamWriter sw = new StreamWriter("Dosya Yolu"))
            {
                while(i< len)
                {
                    var yeni = satirlar[i];
                    sw.WriteLine(yeni);
                    i++;
                }

            }
        }
    }
}
