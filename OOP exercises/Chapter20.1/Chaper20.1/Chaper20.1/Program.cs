using System;
using System.Linq;

namespace Chaper20._1
{
    public class Animal
    {
        private int age;
        private string name;
        private bool isMale;

        public Animal(int age, string name, bool isMale)
        {
            this.age = age;
            this.name = name;
            this.isMale = isMale;
        }
        public override string ToString()
        {
            return string.Format(", age: {0}, name: {1}, gender:{2}", this.age, this.name, (this.isMale ? "Male" : "Female"));
        }
        public virtual void MakeSound()
        {
            Console.WriteLine("Make sound.");
        }
    }

    public class Dog : Animal
    {
        public Dog(int age, string name, bool isMale)
            : base(age, name, isMale)
        { }
        public override string ToString()
        {
            return string.Concat("Dog",base.ToString());
        }

        public override void MakeSound()
        {
            Console.WriteLine("Woof");
        }
    }

    public class Frog : Animal
    {
        public Frog(int age, string name, bool isMale)
            : base(age, name, isMale)
        { }
        public override string ToString()
        {
            return string.Concat("Frog", base.ToString());
        }

        public override void MakeSound()
        {

            Console.WriteLine("Croak");
        }
    }

    public class Cat : Animal
    {
        public Cat(int age, string name, bool isMale)
            : base(age, name, isMale)
        { }
        public override string ToString()
        {
            return string.Concat("Cat", base.ToString());
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }
    }

    public class Kitten : Animal
    {
        public Kitten(int age, string name, bool isMale)
            : base(age, name, isMale)
        { }
        public override string ToString()
        {
            return string.Concat("Kitten", base.ToString());
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }
    }

    public class Tomcat : Animal
    {
        public Tomcat(int age, string name, bool isMale)
            : base(age, name, isMale)
        { }
        public override string ToString()
        {
            return string.Concat("Tomcat", base.ToString());
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Animal[] animals = new Animal[5];
            animals[0] = new Dog(5, "aaa", true);
            animals[1] = new Frog(6, "bbb", false);
            animals[2] = new Cat(4, "ccc", false);
            animals[3] = new Kitten(2, "ddd", true);
            animals[4] = new Tomcat(10, "eee", true);

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
                animal.MakeSound();
            }
        }
    }
}
