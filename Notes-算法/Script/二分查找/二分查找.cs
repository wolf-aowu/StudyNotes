using UnityEngine;

public class 二分查找 : MonoBehaviour
{
    public delegate bool BinarySearchDelegate(int[] array, int middle);
    public int target = 10;

    // 二分查找必须是有序的数组
    public int[] data = {20, 190, 10, 50, 60, 70, 50, 80, 40};

    void Start()
    {
        QuickRank(data, 0, data.Length - 1);
        Debug.Log("----------快速排序后----------");
        Debug.Log(ArrayToString(data));
        Debug.Log("----------二分查找结果----------");
        if (data[0] > target)
        {
            Debug.Log("Not found, too low.");
        }
        else if (data[data.Length - 1] < target)
        {
            Debug.Log("Not found, too higher.");
        }
        else
        {
            var result = BinarySearch(data, SearchCondition, false);
            if (data[result] == target)
            {
                Debug.Log(result);
            }
            else
            {
                Debug.Log("Not found.");
            }
        }
    }

    /// <summary>
    /// 快速排序是不稳定排序
    /// </summary>
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

    private string ArrayToString(int[] array)
    {
        string arrayToString = "";
        foreach (var d in array)
        {
            arrayToString += d + " ";
        }
        return arrayToString;
    }

    private int BinarySearch(int[] array, BinarySearchDelegate condition, bool isLeft)
    {
        int left = -1, right = array.Length;
        while (left + 1 != right)
        {
            int middle = (left + right) / 2;
            var result = condition.Invoke(array, middle);
            if (result)
            {
                left = middle;
            }
            else
            {
                right = middle;
            }
        }

        return isLeft ? left : right;
    }

    private bool SearchCondition(int[] array, int middle)
    {
        if (array[middle] < target)
        {
            return true;
        }
        return false;
    }
}