using UnityEngine;

public class LeetCode1351 : MonoBehaviour {
    public int[][] array = new int[][] { new int[] { 4, 3, 2, -1 }, new int[] { 3, 2, 1, -1 }, new int[] { 1, 1, -1, -2 }, new int[] { -1, -1, -2, -3 } };

    public void Start() {
        var res = CountNegatives(array);
        Debug.Log(res);
    }

    public int CountNegatives(int[][] grid) {
        int lastIndex = grid[0].Length - 1;
        int colum = grid[0].Length;
        int count = 0;
        for (int i = 0; i < grid.Length; i++) {
            lastIndex = BinarySearch(grid[i], lastIndex + 1);
            count += colum - lastIndex;
        }
        return count;
    }

    public int BinarySearch(int[] nums, int right) {
        if (nums[0] < 0) {
            return 0;
        }
        if (nums[nums.Length - 1] >= 0) {
            return nums.Length;
        }

        int left = -1;
        while (left + 1 != right) {
            int middle = (left + right) / 2;
            if (nums[middle] >= 0) {
                left = middle;
            }
            else {
                right = middle;
            }
        }
        return right;
    }
}
