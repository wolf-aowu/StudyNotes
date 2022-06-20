using System;
using UnityEngine;

public class LeetCode34 : MonoBehaviour
{
    public delegate bool DigitalProcess(int[] nums, int index, int target);

    public int[] numbers = new int[] {5, 7, 7, 8, 8, 10};
    public int targetNum = 8;

    private void Start()
    {
        var res = SearchRange(numbers, targetNum);
        Debug.Log($"{res[0]}{res[1]}");
    }

    public int[] SearchRange(int[] nums, int target)
    {
        QuickRank(nums, 0, nums.Length - 1);
        int[] res = new int[] {-1, -1};
        var startRes = BinaryRank(nums, target, TargetStartProcess, false);
        if (startRes == -1 || startRes == nums.Length || nums[startRes] != target)
        {
            return res;
        }
        var endRes = BinaryRank(nums, target, TargetEndProcess, true);
        res[0] = startRes;
        res[1] = endRes;
        return res;
    }

    public int BinaryRank(int[] nums, int target, DigitalProcess digitalProcess, bool returnLeftOrRight)
    {
        int left = -1, right = nums.Length;
        while (left + 1 != right)
        {
            int middle = (right + left) / 2;
            if (digitalProcess(nums, middle, target))
            {
                left = middle;
            }
            else
            {
                right = middle;
            }
        }
        return returnLeftOrRight ? left : right;
    }

    public bool TargetStartProcess(int[] nums, int index, int target)
    {
        return nums[index] < target;
    }

    public bool TargetEndProcess(int[] nums, int index, int target)
    {
        return nums[index] <= target;
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