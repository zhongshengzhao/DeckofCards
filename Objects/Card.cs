using System;
using System.Collections.Generic;
using ConsoleApplicationDeckofCards.Interfaces;
using ConsoleApplicationDeckofCards.Constants;

namespace ConsoleApplicationDeckofCards.Objects
{
    public class Card : ICard
    {
        private int? _cardId = null;
        private bool? _isValidCard = null;

        public string CardName { get; private set; }

        public int? CardId
        {
            get { return _cardId; }
        }

        public bool IsValidCard
        {
            get
            {
                if (_isValidCard == null)
                {
                    _isValidCard = _cardId.HasValue && (_cardId > -1 && _cardId < DeckConst.DefaultPokerNumber);
                }
                return _isValidCard.Value;
            }
        }

        public void Init(int id)
        {
            if (_cardId == null)
            {
                _cardId = id;
                CardName = GetCardName(_cardId.Value);
            }
        }

        private string GetCardName(int id)
        {
            if (!IsValidCard)
            {
                throw new Exception("Not a valid card.");
            }

            int cardTypeId = id / 13;
            int cardIndexId = (id - cardTypeId * 13) % 13;

            var cardType = GetCardTypeName(cardTypeId);
            var cardIndexName = GetCardIndexName(cardIndexId);

            _isValidCard = cardType != "" && cardIndexName != "";

            return !_isValidCard.Value ? "" : (cardType + " " + cardIndexName);
        }

        private static string GetCardIndexName(int id)
        {
            var cardIndexMapping = new Dictionary<int, string>
            {
                {DeckConst.Cards.Ace, "A"},
                {DeckConst.Cards.Two, "2"},
                {DeckConst.Cards.Three, "3"},
                {DeckConst.Cards.Four, "4"},
                {DeckConst.Cards.Five, "5"},
                {DeckConst.Cards.Six, "6"},
                {DeckConst.Cards.Seven, "7"},
                {DeckConst.Cards.Eight, "8"},
                {DeckConst.Cards.Nine, "9"},
                {DeckConst.Cards.Ten, "10"},
                {DeckConst.Cards.Jack, "J"},
                {DeckConst.Cards.Queen, "Q"},
                {DeckConst.Cards.King, "K"}
            };

            return (cardIndexMapping.ContainsKey(id)) ? cardIndexMapping[id] : "";
        }

        private static string GetCardTypeName(int id)
        {
            var cardTypeMapping = new Dictionary<int, string>
            {
                {DeckConst.CardType.Diamonds, "Diamond"},
                {DeckConst.CardType.Clubs, "Club"},
                {DeckConst.CardType.Hearts, "Heart"},
                {DeckConst.CardType.Spades, "Spade"}
            };

            return (cardTypeMapping.ContainsKey(id)) ? cardTypeMapping[id] : "";
        }
    }
}
