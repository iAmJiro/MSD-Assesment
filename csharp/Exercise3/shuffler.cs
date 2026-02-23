using System;
using System.Collections.Generic;

namespace CardGame.Infrastructure
{
    // A little bit of research on the Fisher-Yates shuffle algorithm, 
    // it is a simple and efficient way to shuffle a list of items. 
    // It works by iterating through the list from the last item to the first, and for each item, 
    // it randomly selects another item from the remaining unshuffled portion of the list and swaps them. 
    // his ensures that each item has an equal probability of being in any position in the shuffled list.
    public class Shuffle : IShuffler
    {
        private static readonly Random _random = new Random();
        public void Shuffle<C>(IList<C> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = _random.Next(0, i + 1); // + 1 as maxint would be 52, meaning it will only show 51 cards
                C temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }   
}