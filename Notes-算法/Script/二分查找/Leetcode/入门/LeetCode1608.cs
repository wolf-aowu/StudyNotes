using UnityEngine;

public class LeetCode1608 : MonoBehaviour
{
    public int[] array = new int[] {0, 4, 3, 0, 4};

    private void Start()
    {
        var res = SpecialArray(array);
        Debug.Log(res);
    }

    public int SpecialArray(int[] nums)
    {
        var length = nums.Length;
        QuickRank(nums, 0, length - 1);

        for (int i = 0; i <= nums.Length; i++)
        {
            var res = BinarySearch(nums, i);
            if (length - res == i)
            {
                return i;
            }
        }
        return -1;
    }

    public int BinarySearch(int[] nums, int target)
    {
        int left = -1, right = nums.Length;
        while (left + 1 != right)
        {
            int middle = (right + left) / 2;
            if (nums[middle] >= target)
            {
                right = middle;
            }
            else
            {
                left = middle;
            }
        }
        return right;
    }

    public void QuickRank(int[] nums, int low, int high)
    {
        if (low >= high) return;
        int l = low, h = high;
        int pivot = nums[low];
        while (l < h)
        {
            while (nums[h] >= pivot && l < h)
            {
                h--;
            }
            if (l < h)
            {
                nums[l] = nums[h];
            }
            while (nums[l] <= pivot && l < h)
            {
                l++;
            }
            if (l < h)
            {
                nums[h] = nums[l];
            }
            if (l >= h)
            {
                nums[l] = pivot;
            }
        }
        QuickRank(nums, low, h - 1);
        QuickRank(nums, h + 1, high);
    }
}