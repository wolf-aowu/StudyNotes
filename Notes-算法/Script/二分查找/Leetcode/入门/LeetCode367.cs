using UnityEngine;

public class LeetCode367 : MonoBehaviour
{
    public int number = 16;

    private void Start()
    {
        var res = IsPerfectSquare(number);
        Debug.Log(res);
    }

    public bool IsPerfectSquare(int num)
    {
        if (num == 1 || num == 4) return true;
        if (num < 4) return false;
        long left = 2, right = num / 2;
        while (left <= right)
        {
            long middle = (right - left) / 2 + left;
            long res = middle * middle;
            if (res == num) return true;
            if (res > num)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }
        return false;
    }
}