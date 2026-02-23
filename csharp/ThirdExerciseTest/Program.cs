using Xunit;
using Review; // This links to your main code
using System;
using System.Linq;

namespace ThirdExerciseTest
{
    // Tools used for testing:
    // - xUnit for the testing framework

    // Done so the contract is fulfilled
    public class NoOpShuffler : IShuffler
    {
        public void Shuffle<C>(IList<C> list) 
        {
            // do nothing so the deck stays in order
        }
    }
    public class DeckTests
    {
        [Fact]
        public void Draw_ShouldReturnFirstCardInDeck()
        {
            // 1. ARRANGE (Set up the test)
            var deck = new Deck();
            var fakeShuffler = new NoOpShuffler();
            deck.Shuffle(fakeShuffler); // Cards stay: Hearts Two, Hearts Three...

            // 2. ACT (Do the thing)
            var card = deck.Draw();

            // 3. ASSERT (Check if it's right)
            // Since we didn't shuffle, the first card should be Two of Hearts.
            Assert.Equal(Suit.Hearts, card.Suit);
            Assert.Equal(Rank.Two, card.Rank);
        }
    }
}