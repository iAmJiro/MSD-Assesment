using Xunit;
using CardGame.Domain; // Updated address
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirdExercise
{
    public class NoOpShuffler : IShuffler
    {
        public void Shuffle<C>(IList<C> list) 
        {
            // stays in order
        }
    }

    public class DeckTests
    {
        [Fact]
        public void Draw_ShouldReturnFirstCardInDeck()
        {
            var deck = new Deck();
            var fakeShuffler = new NoOpShuffler();
            deck.Shuffle(fakeShuffler); 

            var card = deck.Draw();

            // These will now work because 'using CardGame.Domain' finds Suit and Rank
            Assert.Equal(Suit.Hearts, card.Suit);
            Assert.Equal(Rank.Ace, card.Rank);
        }

        [Fact]
        public void Draw_ShouldRemoveCardFromDeck_ReducingCount()
        {
            var deck = new Deck();
            int initialCount = deck.RemainingCards; 

            deck.Draw();

            Assert.Equal(initialCount - 1, deck.RemainingCards);
        }
        [Fact]
        public void Draw_ShouldThrowException_WhenDeckIsEmpty()
        {
            var deck = new Deck();
            
            // Empty the deck by drawing all 52 cards
            for (int i = 0; i < 52; i++)
            {
                deck.Draw();
            }

            var exception = Assert.Throws<InvalidOperationException>(() => deck.Draw());
            Assert.Equal("No cards left in the deck.", exception.Message);
        }
    }
}