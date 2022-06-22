using UnityEngine;

public class LeetCode278 : MonoBehaviour
{
    public int version = 5;
    public int bad = 4;

    private void Start()
    {
        var res = FirstBadVersion(version);
        Debug.Log(res);
    }

    public int FirstBadVersion(int n)
    {
        int left = 1, right = n;
        while (left <= right)
        {
            int middle = (right - left) / 2 + left;
            if (IsBadVersion(middle))
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }
        return left;
    }

    public bool IsBadVersion(int n)
    {
        return n >= bad;
    }
}