using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroes
{
    internal class Villain
    {
        private string v1;
        private string v2;

        public Villain(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        internal void PrintGreeting()
        {
            
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Person a = new Person("William", "Bill");
            Person b = new Person("Robert", "Bobby");
            Person c = new Person("Lexi", "Alexis");

            SuperHero e = new SuperHero("Wade Turner", "Super Strength", "Mr.Incredible");
            SuperHero f =  new SuperHero("Bruce Wayne", "Super Intelligent", "Batman");

            Villain g = new Villain("Joker", "Batman");
            Villain h = new Villain("Doc-oc", "Spiderman");

            a.PrintGreeting();
            b.PrintGreeting();
            c.PrintGreeting();
            Console.WriteLine();
            e.PrintGreeting();
            f.PrintGreeting();
            Console.WriteLine();
            g.PrintGreeting();
            h.PrintGreeting();

            Console.ReadLine();

        }

        //Person Class
        public class Person
        {
            public string Name { get; set; }
            public string NickName { get; set; }

            //Person Constructor
            public Person(string initialName, string initialNickName)
            {
                Name = initialName;
                NickName = initialNickName;
            }

            public virtual void PrintGreeting()
            {
                Console.WriteLine("Hi, my name is {0} you can call me {1}", Name, NickName);
            }
        }

        //SuperHero Class
        public class SuperHero : Person
        {
            public string RealName { get; set; }
            public string SuperPower { get; set; }

            //SuperHeroes Constructor
            public SuperHero(string initialRealName, string initialSuperPower, string name) : base(name, null)
            {
                RealName = initialRealName;
                SuperPower = initialSuperPower;
            }

            public override void PrintGreeting()
            {
                Console.WriteLine(" I am {0}. When I am {1}, my super power is {2}!", RealName, Name, SuperPower);
            }
        }
    }
}
