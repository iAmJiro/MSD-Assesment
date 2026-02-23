using CardGame.Domain;

var deck = new Deck();
var shuffler = new Shuffling();

Console.WriteLine("Shuffling...");
// Simulates time to shuffle
Thread.Sleep(5000);
deck.Shuffle(shuffler);

// Draws card
var myCard = deck.Draw();
Console.WriteLine($"you drew the {myCard.Rank} of {myCard.Suit}.");
Console.WriteLine($"Cards remaining: {deck.RemainingCards}");

/*
If the function is to just keep drawing cards,
Comment the logging above and use the logging below

while(true)
{
    Thread.Sleep(500);
    if (deck.RemainingCards > 0)
    {
        Console.WriteLine("Drawing another card...");
        Thread.Sleep(1000);
        var anotherCard = deck.Draw();
        Console.WriteLine($"you drew the {anotherCard.Rank} of {anotherCard.Suit}.");
        Console.WriteLine($"Cards remaining: {deck.RemainingCards}");
    }
}

*/