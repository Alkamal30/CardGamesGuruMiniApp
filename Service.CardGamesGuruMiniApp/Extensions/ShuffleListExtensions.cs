namespace Services.CardGamesGuruMiniApp.Extensions;

public static class ShuffleListExtensions 
{
    private static Random _random = new Random();

    public static void Shuffle<T>(this IList<T> list) 
    {
        int length = list.Count;

        while(length > 1) 
        {
            int swapElementIndex = _random.Next(length--);
            (list[length], list[swapElementIndex]) = (list[swapElementIndex], list[length]);
        }
    }
}
