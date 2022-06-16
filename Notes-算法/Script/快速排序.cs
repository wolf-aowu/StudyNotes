using UnityEngine;

public class 快速排序 : MonoBehaviour
{
    public int[] data = {20, 190, 10, 50, 60, 70, 50, 80, 40};

    void Start()
    {
        Debug.Log("----------快速排序前----------");
        Debug.Log(ArrayToString(data));
        QuickRank(data, 0, data.Length - 1);
        Debug.Log("----------快速排序后----------");
        Debug.Log(ArrayToString(data));
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
}