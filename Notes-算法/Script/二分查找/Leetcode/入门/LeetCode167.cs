using UnityEngine;

public class LeetCode167 : MonoBehaviour
{
    public int[] nums = new int[] {2, 7, 11, 15};
    public int num = 9;

    private void Start()
    {
        var res = TwoSum(nums, num);
        Debug.Log($"{res[0]},{res[1]}");
    }

    // 二分查找法
    public int[] TwoSum(int[] numbers, int target)
    {
        for (int i = 0; i < numbers.Length; ++i)
        {
            int left = i + 1, right = numbers.Length - 1;
            while (left <= right)
            {
                int mid = (right - left) / 2 + left;
                if (numbers[mid] == target - numbers[i])
                {
                    return new int[] {i + 1, mid + 1};
                }
                else if (numbers[mid] > target - numbers[i])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
        }
        return new int[] {-1, -1};
    }

    // 双指针方法
    // public int[] TwoSum(int[] numbers, int target)
    // {
    //     int left = 0, right = numbers.Length - 1;
    //     while (left < right)
    //     {
    //         int res = numbers[left] + numbers[right];
    //         if (res == target)
    //         {
    //             return new int[] {left + 1, right + 1};
    //         }
    //         else if (res > target)
    //         {
    //             right -= 1;
    //         }
    //         else
    //         {
    //             left += 1;
    //         }
    //     }
    //     return new int[] {-1, -1};
    // }
}