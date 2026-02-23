using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using CardGame.Domain;
namespace CardGame.Domain
{
    private readonly List<Card> _cards = new List<Card>();
    public Deck()
    {
        // This will fill the deck with all 52 cards, gets a suit first and then fill it with all ranks, it will then grab next suit after it's done
        foreach (Suit s in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                _cards.Add(new Card(s, r));
            }
        }
    }
}   