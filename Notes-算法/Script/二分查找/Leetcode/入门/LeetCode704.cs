using UnityEngine;

public class LeetCode704 : MonoBehaviour
{
    public int[] data = new int[] {-1, 0, 3, 5, 9, 12};
    public int targetNum = 9; //结果应为 4

    private void Start()
    {
        var result = Search(data, targetNum);
        Debug.Log(result);
    }

    public int Search(int[] nums, int target) {
        if (nums[nums.Length - 1] < target) {
            return -1;
        }
        else if (nums[0] > target) {
            return -1;
        }
        else {
            var result = BinarySearch(nums, target);
            if (nums[result] != target) {
                return -1;
            }
            else {
                return result;
            }
        }
    }

    public int BinarySearch(int[] nums, int target) {
        int left = -1, right = nums.Length;
        while (left + 1 != right) {
            int middle = (left + right) / 2;
            if (nums[middle] < target) {
                left = middle;
            }
            else {
                right = middle;
            }
        }

        return left;
    }

    //public int Search(int[] nums, int target) {
    //    int left = 0, right = nums.Length - 1;
    //    while (left <= right) {
    //        int mid = (right - left) / 2 + left;
    //        int num = nums[mid];
    //        if (num == target) {
    //            return mid;
    //        }
    //        else if (num > target) {
    //            right = mid - 1;
    //        }
    //        else {
    //            left = mid + 1;
    //        }
    //    }
    //    return -1;
    //}
}