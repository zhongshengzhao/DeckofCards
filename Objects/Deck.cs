using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplicationDeckofCards.Interfaces;
using ConsoleApplicationDeckofCards.Constants;

namespace ConsoleApplicationDeckofCards.Objects
{
    /// <summary>
    /// Generic class encapsulate the Shuffling operation that is specific to 
    /// any custom type in which the interface ICard is implemented
    /// </summary>
    public class Deck<T>
        where T : ICard, new()
    {
        private readonly int _totalItems;
        private int _currentItem;
        private int[] _repository = new int[] { };

        public Deck()
            : this(DeckConst.DefaultPokerNumber)
        {
        }

        public Deck(int totalItems)
        {
            this._totalItems = totalItems;
        }

        public int CurrentItem
        {
            get { return _currentItem; }
        }

        public int TotalCards
        {
            get { return _totalItems; }
        }

        public bool IsDackValid
        {
            get { return TotalCards > 0 && CurrentItem < TotalCards; }
        }

        /// <summary>
        /// Object Ids in the deck are randomly permuted
        /// </summary>
        public void Shuffle()
        {
            _repository = Enumerable.Range(0, _totalItems).ToArray();
            _currentItem = 0;

            var rnd = new Random();

            for (int i = (_totalItems - 1); i > 0; i--)
            {
                int rndPick = rnd.Next(i + 1);

                if (rndPick < i)
                {
                    //exchange _repository[i] and _repository[rndPick],
                    _repository[i] += _repository[rndPick];
                    _repository[rndPick] = _repository[i] - _repository[rndPick];
                    _repository[i] = _repository[i] - _repository[rndPick];

                    //or we can use the following approach to exchange:
                    //var tmp = _repository[rndPick];
                    //_repository[rndPick] = _repository[i];
                    //_repository[i] = tmp;
                }
            }
        }

        /// <summary>
        /// Return one obj from the deck to the caller
        /// </summary>
        /// <returns></returns>
        public T DealOneCard()
        {
            if (_currentItem >= _totalItems)
            {
                throw new Exception("Request can not be processed because there is no card available.");
            }

            var t = createItem(_repository[_currentItem]);
            _currentItem++;

            return t;
        }

        private T createItem(int id)
        {
            T t = new T();
            t.Init(id);

            return t;
        }
    }
}
