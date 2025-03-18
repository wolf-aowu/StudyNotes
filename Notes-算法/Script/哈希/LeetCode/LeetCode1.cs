using System.Collections.Generic;
using UnityEngine;

public class LeetCode1 : MonoBehaviour {
    public int[] numbers = new int[] { 2, 7, 11, 15 };
    public int targetNum = 9;

    public void Start() {
        var res = TwoSum(numbers, targetNum);
        Debug.Log($"{res[0]}, {res[1]}");
    }

    /// <summary>
    /// 暴力枚举法
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum(int[] nums, int target) {
        int n = nums.Length;
        for (int i = 0; i < n - 1; i++) {
            for (int j = i + 1; j < n; j++) {
                if (nums[i] + nums[j] == target) {
                    return new int[] { i, j };
                }
            }
        }
        return null;
    }

    ///// <summary>
    ///// 哈希表，C# 中由于字典没有根据 value 找 key 的方法，所以效率还不如暴力高
    ///// </summary>
    ///// <param name="nums"></param>
    ///// <param name="target"></param>
    ///// <returns></returns>
    //public static int[] TwoSum(int[] nums, int target) {
    //    Dictionary<int, int> hashtable = new Dictionary<int, int>();
    //    for (int i = 0; i < nums.Length; i++) {
    //        if (hashtable.ContainsValue(target - nums[i])) {
    //            foreach (KeyValuePair<int, int> pair in hashtable) {
    //                if (pair.Value == target - nums[i]) {
    //                    return new int[] { pair.Key, i };
    //                }
    //            }
    //        }
    //        hashtable.Add(i, nums[i]);
    //    }
    //    return null;
    //}

    ///// <summary>
    ///// 哈希表，使用了两个字典，速度只有略微的提升，需要的内存变大了，没有暴力效率高
    ///// </summary>
    ///// <param name="nums"></param>
    ///// <param name="target"></param>
    ///// <returns></returns>
    //public static int[] TwoSum(int[] nums, int target) {
    //    Dictionary<int, int> hashtableForValue = new Dictionary<int, int>();
    //    Dictionary<int, int> hashtableForKey = new Dictionary<int, int>();

    //    for (int i = 0; i < nums.Length; i++) {
    //        if (hashtableForValue.ContainsValue(target - nums[i])) {
    //            return new int[] { hashtableForKey[target - nums[i]], i };
    //        }
    //        hashtableForValue[i] = nums[i];
    //        hashtableForKey[nums[i]] = i;
    //    }
    //    return null;
    //}
}