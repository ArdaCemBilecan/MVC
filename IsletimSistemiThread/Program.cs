using System;
using System.Threading;

namespace IsletimSistemiThread
{
    class Program
    {
        static int sayi = 100;
    

        static void Main(string[] args)
        {
            Deger deger = new Deger();
            deger._ortak = 100;
            deger.flag = false;
            Producer pro = new Producer(deger);
            Consumer cons = new Consumer(deger);
            Thread t1 = new Thread(pro.Arttir);
            Thread t2 = new Thread(cons.azalt);
            Thread t3 = new Thread(pro.Arttir);
            Thread t4 = new Thread(cons.azalt);
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            Console.ReadLine();


        }


    static void producer()
        {
            for (int i = 0; i < 10; i++)
            {
               
                    sayi = sayi + 1;
                    Console.WriteLine("PRODUCER: " + sayi);
                   
                
            }
        }

        static void consumer()
        {
            for (int i = 0; i < 10; i++)
            {

                    sayi = sayi - 1;
                    Console.WriteLine("CONSUMER: " + sayi);
         


            }
        }

    }

    class Producer
    {
        private Deger Pdeger;
        public Producer(Deger d)
        {
            Pdeger = d;
        }

        public void Arttir()
        {
            if (Pdeger.flag == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    Pdeger._ortak++;
                    Console.WriteLine("PRODUCER: " + Pdeger._ortak);

                }
                Pdeger.flag = true;
                Console.WriteLine("FLAG DURUMU : "+Pdeger.flag);
            }
            
            Console.WriteLine("ARTTIR SON");
        }
    }


    class Consumer
    {
        Deger Cdeger;
        public Consumer(Deger d)
        {
            Cdeger = d;
            
        }

        public void azalt()
        {
            Console.WriteLine("CDEGER Flag: "+Cdeger.flag);
            if(Cdeger.flag == true)
            {
                Console.WriteLine("AZALT IF ICINDE");
                for (int i = 0; i <5; i++)
                {
                    Cdeger._ortak--;
                    Console.WriteLine("CONSUMER: " + Cdeger._ortak);

                }
                Cdeger.flag = false;
            }
            Console.WriteLine("AZALT SON");
        }
    }

    class Deger
    {
        public int _ortak;
        // eğer false ise arttır çalışacak
        // true ise azalt çalışacak
        public bool flag;
    }

}
