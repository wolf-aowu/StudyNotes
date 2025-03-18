using UnityEngine;

public class LeetCode74 : MonoBehaviour {
    public int[][] numbers = new int[3][] { new int[] { 1, 3, 5, 7 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 60 } };
    public int targetNum = 3;

    public void Start() {
        var res = SearchMatrix(numbers, targetNum);
        Debug.Log(res);
    }

    public bool SearchMatrix(int[][] matrix, int target) {
        if (target < matrix[0][0]) return false;
        if (target > matrix[matrix.Length - 1][matrix[0].Length - 1]) return false;

        int startRow = -1, endRow = matrix.Length;
        while (startRow + 1 != endRow) {
            int middleRow = (startRow + endRow) / 2;
            int res = BinarySearch(matrix[middleRow], target);
            if (res == -1) return false;
            if (res == -2) {
                endRow = middleRow;
            }
            else if (res == -3) {
                startRow = middleRow;
            }
            else {
                return true;
            }
        }
        return false;
    }

    public int BinarySearch(int[] nums, int target) {
        if (target < nums[0]) return -2;
        if (target > nums[nums.Length - 1]) return -3;

        int left = -1, right = nums.Length;
        while (left + 1 != right) {
            int middle = (left + right) / 2;
            if (nums[middle] == target) return middle;
            else if (nums[middle] > target) {
                right = middle;
            }
            else {
                left = middle;
            }
        }
        return -1;
    }
}
