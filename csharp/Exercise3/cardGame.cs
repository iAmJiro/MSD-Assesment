using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Domain
{
    public enum Suit
    {
        // Define the suits of a standard deck of cards
        Hearts, Diamonds, Clubs, Spades
    }
    public enum Rank
    {
        // Define the ranks of a standard deck of cards
        // In some card games, Ace can be the highest number, in my card game; it would be the lowest
        Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
        Jack = 11, Queen = 12, King = 13, Ace = 1
    }
    // Set the Card record to as it will never change
    public record Card(Suit Suit, Rank Rank)
    {
        // This record represents a single playing card with a suit and rank
    }
}