using UnityEngine;

public class LeetCode374 : MonoBehaviour
{
    public int num = 10;
    public int pick = 6;

    private void Start()
    {
        var res = GuessNumber(num);
        Debug.Log($"res: {res}");
    }

    public int GuessNumber(int n)
    {
        return BinarySearch(n);
    }

    public int BinarySearch(int num)
    {
        int left = 1, right = num;
        while (left <= right)
        {
            var middle = (right - left) / 2 + left;
            var guessRes = guess(middle);
            if (guessRes == 0)
            {
                return middle;
            }
            else if (guessRes == -1)
            {
                right = middle - 1;
            }
            else if (guessRes == 1)
            {
                left = middle + 1;
            }
        }
        return -1;
    }

    public int guess(int guessNum)
    {
        if (guessNum < pick)
        {
            return 1;
        }
        else if (guessNum > pick)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}