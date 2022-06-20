using UnityEngine;

public class LeetCode69 : MonoBehaviour
{
    public int number = 6;

    private void Start()
    {
        var res = MySqrt(number);
        Debug.Log(res);
    }

    public int MySqrt(int x)
    {
        if (x == 0) return 0;
        if (x == 1) return 1;
        return BinarySearch(x);
    }

    public int BinarySearch(long target)
    {
        long left = 2, right = target / 2;
        while (left <= right)
        {
            long middle = (right - left) / 2 + left;
            if (middle * middle == target)
            {
                return (int) middle;
            }
            else if (middle * middle < target)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }
        return (int) right;
    }
}