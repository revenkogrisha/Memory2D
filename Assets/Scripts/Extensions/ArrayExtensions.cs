using System;

public static class ArrayExtensions
{
    public static void ShuffleArray(this Array array)
    {
        int[] newArray = array.Clone() as int[];

        for (int i = 0; i < newArray.Length; i++)
        {
            int temp = newArray[i];
            int random = UnityEngine.Random.Range(0, newArray.Length);

            newArray[i] = newArray[random];
            newArray[random] = temp;
        }

        Array.Copy(newArray, array, array.Length);
    }
}
