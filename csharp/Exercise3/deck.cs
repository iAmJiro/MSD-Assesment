using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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
    // Could also be done with a lambda, I just prefer it this way
    public int RemainingCards 
    {
        get 
        {
            return _cards.Count;
        }
    }
    public void Shuffle(IShuffler shuffler)
    {
        // I'm not too sure if it will ever be null; but I will add a safety check just in case
        if (shuffler == null) throw new ArgumentNullException(nameof(shuffler));
        // Shuffles deck using the shuffler from cardGame.cs
        shuffler.Shuffle(_cards);
    }
}   