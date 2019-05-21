using System.Collections;


public static class Utility{

	public static T[] ShuffleArray<T>(T[] array,int seed)
    {
        System.Random prng = new System.Random(seed);

        for(int i=0;i<array.Length-1;i++)
        {
            int radomIndex = prng.Next(i, array.Length);
            T tempItem = array[radomIndex];
            array[radomIndex] = array[i];
            array[i] = tempItem;
        }
        return array;
    }
}
