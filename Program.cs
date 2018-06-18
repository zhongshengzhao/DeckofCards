using System;
using ConsoleApplicationDeckofCards.Objects;

namespace ConsoleApplicationDeckofCards
{
    class Program
    {
        private static void Main(string[] args)
        {
            var deck = new Deck<Card>();
            if (!deck.IsDackValid) throw new Exception("Not a valid deck."); //Not necessary here, but we can use this properity to verify deck

            deck.Shuffle();

            var caller = new Caller<Card>(deck, "test1");
            int i = 0;

            try
            {
                while (true)
                {
                    var card = caller.CallOneCard();
                    i++;
                }

                return;
            }
            catch (Exception e)
            {
            }
            finally
            {
                Console.WriteLine("Totally {0} cards have been called.", i);
            }
        }
    }
   
}
