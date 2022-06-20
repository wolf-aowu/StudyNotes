using System;
using UnityEngine;

public class LeetCode1385 : MonoBehaviour
{
    public int[] array1 = new int[] {2,1,100,3};
    public int[] array2 = new int[] {-5,-2,10,-3,7};
    public int dNum = 6;

    private void Start()
    {
        var res = FindTheDistanceValue(array1, array2, dNum);
        Debug.Log(res);
    }

    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
    {
        var arr2Length = arr2.Length;
        int count = 0;
        QuickRank(arr2, 0, arr2Length - 1);
        for (int i = 0; i < arr1.Length; i++)
        {
            var index = BinarySearch(arr2, arr1[i]);
            if (index < arr2Length && index >= 0 && arr1[i] == arr2[index])
            {
                if (d == 0)
                {
                    count++;
                }
                continue;
            }
            int d1 = -1, d2 = -1;
            if (index - 1 >= 0)
            {
                d1 = Math.Abs(arr1[i] - arr2[index - 1]);
            }
            if (index <= arr2Length - 1)
            {
                d2 = Math.Abs(arr1[i] - arr2[index]);
            }
            var res1 = d1 == -1 || d1 > d;
            var res2 = d2 == -1 || d2 > d;
            Debug.Log($"{d1}{d2}");
            if (res1 & res2)
            {
                count++;
            }
        }
        return count;
    }

    public int BinarySearch(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;
        while (left <= right)
        {
            int middle = (right - left) / 2 + left;
            if (nums[middle] == target)
            {
                return middle;
            }
            else if (nums[middle] > target)
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

    private void QuickRank(int[] array, int low, int high)
    {
        if (low >= high) return;
        int pivot = array[low];
        int l = low, h = high;
        while (l < h)
        {
            while (array[h] >= pivot && l < h)
            {
                h--;
            }
            if (l < h)
            {
                array[l] = array[h];
            }
            while (array[l] <= pivot && l < h)
            {
                l++;
            }
            if (l < h)
            {
                array[h] = array[l];
            }
            if (l >= h)
            {
                array[l] = pivot;
            }
        }
        QuickRank(array, low, h - 1);
        QuickRank(array, h + 1, high);
    }
}