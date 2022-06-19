using UnityEngine;

public class LeetCode35 : MonoBehaviour
{
    public int[] data = new int[] {1, 3, 5, 6};
    public int targetNum = 7; //结果应为 4

    private void Start()
    {
        var res = SearchInsert(data, targetNum);
        Debug.Log(res);
    }

    public int SearchInsert(int[] nums, int target)
    {
        if (nums[0] > target) return 0;
        if (nums[nums.Length - 1] < target) return nums.Length;
        int left = -1, right = nums.Length;
        while (left + 1 != right)
        {
            int middle = (left + right) / 2;
            if (nums[middle] == target)
            {
                return middle;
            }
            else if (nums[middle] > target)
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
}