using System;


namespace ProgrammingFinals
{
    class Person
    {
        string name;
        string pronoun;
        string message;

        public Person(string name, string pronoun, string message)
        {
            this.name = name;
            this.pronoun = pronoun;
            this.message = message;
        }

        public void speak()
        {
            Console.WriteLine(message);
        }

        public String getName()
        {
            return name;
        }

        public String getPronoun()
        {
            return pronoun;
        }
    }
}