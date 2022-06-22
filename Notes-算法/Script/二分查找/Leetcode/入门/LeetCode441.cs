using UnityEngine;

public class LeetCode441 : MonoBehaviour
{
    public int number = 8;

    private void Start()
    {
        var res = ArrangeCoins(number);
        Debug.Log(res);
    }

    public int ArrangeCoins(int n)
    {
        long left = 1, right = n;
        while (left <= right)
        {
            long middle = (right - left) / 2 + left;
            long res = (1 + middle) * middle / 2;
            if (res == n)
            {
                return (int) middle;
            }
            else if (res < n)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }
        return (int) (left - 1);
    }
}