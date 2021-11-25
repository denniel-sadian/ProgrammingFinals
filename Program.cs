using System;
using System.Collections.Generic;

namespace ProgrammingFinals
{
    class Program
    {
        static void printIntro(int rounds)
        {
            Console.WriteLine("Let's play... Sing-no Toh!\n");
            Console.WriteLine("You are to be presented with song titles,");
            Console.WriteLine("and then you have to guess who sang those songs.");
            Console.WriteLine("You have " + rounds + " rounds. Good Luck!!!\n");
        }

        static void printSingers(List<Singer> singers)
        {
            Console.WriteLine("\nSingers to choose from:");
            foreach (Singer s in singers)
            {
                Console.WriteLine("\t- " + s.getName());
            }
            Console.WriteLine();
        }

        static bool match(string answer, string correct)
        {
            // Do not accept an answer that's 3 letters below
            if (answer.Length < 4) return false;
            answer = answer.Replace(" ", "").Trim().ToLower();
            correct = correct.Replace(" ", "").Trim().ToLower();
            return correct.Contains(answer);
        }

        static void pauseForAWhile()
        {
            System.Threading.Thread.Sleep(2500);
        }

        static void pauseForAWhile(int sec)
        {
            System.Threading.Thread.Sleep(sec * 1000);
        }

        static void Main(string[] args)
        {
            // Add singers
            List<Singer> singers = new List<Singer>{
                new Singer(
                    "Lady Gaga", "She",
                    "Put your paws up!",
                    new string[] { "Bad Romance", "Plastic Doll", "Just Dance" }),
                new Singer(
                    "Taylor Swift", "She",
                    "I'm your lover!",
                    new string[] { "Lover", "Look What You Made Me Do", "Love Story" }),
                new Singer(
                    "Halsey", "She",
                    "You're so good!",
                    new string[] { "Be Kind", "Castle", "Without Me" }),
                new Singer(
                    "Katy Pery", "She",
                    "Yasss!",
                    new string[] { "Dark Horse", "The One That Got Away", "California Gurls" }),
                new Singer(
                    "Ariana Grande", "She",
                    "Yuh yuh!!!!",
                    new string[] { "34+35", "Thank U, Next", "Positions" }),
                new Singer(
                    "Post Malone", "He",
                    "That one's amazing!",
                    new string[] { "Circles", "Sunflower", "Goodbyes" }),
                new Singer(
                    "Bruno Mars", "He",
                    "Yeah!!! You got it!",
                    new string[] { "Talking to the Moon", "That's What I like", "The Lazy Song" }),
                new Singer(
                    "Freddie Mercury", "He",
                    "You're so good, I'm a fan!",
                    new string[] { "Radio Ga Ga", "Another One Bites the Dust", "Bohemian Rhapsody" }),
                new Singer(
                    "Ed Sheeran", "He",
                    "Nice one!",
                    new string[] { "Perfect", "Bad Habits", "Shape of You" }),
                new Singer(
                    "Elton John", "He",
                    "You amaze me!",
                    new string[] { "Don't Go Breaking My Heart", "I'm Still Standing", "Candle In the Wind" })
            };
            List<int> pickedIndexes = new List<int>();
            int score = 0;

            bool done = false;
            while (!done)
            {
                while (pickedIndexes.Count < singers.Count)
                {
                    // Print intros
                    Console.Clear();
                    printIntro(singers.Count);
                    printSingers(singers);

                    // Randomly choose a singer
                    int i;
                    do i = new Random().Next(0, singers.Count);
                    while (pickedIndexes.Contains(i));
                    Singer singer = singers[i];
                    pickedIndexes.Add(i);

                    // Ask who the singer is
                    Console.WriteLine($"Song #{pickedIndexes.Count}: {singer.sing()}\n");
                    Console.Write("Who's the singer? : ");
                    string answer = Console.ReadLine();
                    if (match(answer, singer.getName()))
                    {
                        score++;
                        Console.WriteLine($"That's right! {singer.getPronoun()}'s {singer.getName()}!");
                        singer.speak();
                    }
                    else Console.WriteLine($"That's incorrect. {singer.getPronoun()}'s {singer.getName()}!");
                    Console.WriteLine("\n\n");
                    pauseForAWhile();
                }

                // Print score
                int percent = score * 100 / singers.Count;
                Console.WriteLine($"Your score is: {score} out of {singers.Count} == {percent}% !\n");
                pauseForAWhile(1);

                // Ask for another game
                Console.Write("Would you like to try again? (Y|N): ");
                if (Console.ReadLine().Trim().ToUpper() != "Y") done = true;
                else
                {
                    score = 0;
                    pickedIndexes = new List<int>();
                }
            }
        }
    }
}
