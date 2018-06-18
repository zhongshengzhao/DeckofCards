using ConsoleApplicationDeckofCards.Interfaces;

namespace ConsoleApplicationDeckofCards.Objects
{
    public class Caller<T> where T : ICard, new()
    {
        private readonly Deck<T> _deck;
        private readonly string _callerName;

        public string CallerName
        {
            get { return _callerName; }
        }

        public bool IsDeckValid
        {
            get { return _deck.IsDackValid; }
        }

        public Caller(Deck<T> deck, string callerName)
        {
            _deck = deck;
            _callerName = callerName;
        }

        public T CallOneCard()
        {
            return _deck.DealOneCard();
        }
    }
}
