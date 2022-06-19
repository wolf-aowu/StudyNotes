using UnityEngine;

public class LeetCode852 : MonoBehaviour
{
    public int[] data = new int[] {0, 1, 0};

    private void Start()
    {
        var res = PeakIndexInMountainArray(data);
        Debug.Log(res);
    }

    public int PeakIndexInMountainArray(int[] arr)
    {
        int left = 1, right = arr.Length - 2;
        while (left <= right)
        {
            var middle = (right - left) / 2 + left;
            if (arr[middle] > arr[middle - 1] &&
                arr[middle] > arr[middle + 1])
            {
                return middle;
            }
            else if (arr[middle] < arr[middle + 1])
            {
                left = middle + 1;
            }
            else if (arr[middle] < arr[middle - 1])
            {
                right = middle - 1;
            }
        }
        return -1;
    }
}