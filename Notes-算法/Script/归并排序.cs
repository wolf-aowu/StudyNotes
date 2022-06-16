using UnityEngine;

public class 归并排序 : MonoBehaviour
{
    public int[] data = {20, 190, 10, 50, 60, 70, 50, 80, 40};

    void Start()
    {
        Debug.Log("----------归并排序前----------");
        Debug.Log(ArrayToString(data));
        MergeRank(data, 0, data.Length - 1);
        Debug.Log("----------归并排序后----------");
        Debug.Log(ArrayToString(data));
    }

    /// <summary>
    /// 快速排序是不稳定排序
    /// </summary>
    private void MergeRank(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeRank(array, left, middle);
            MergeRank(array, middle + 1, right);
            Merge(array, left, right, middle + 1);
        }
    }

    private void Merge(int[] array, int left, int right, int middle)
    {
        int[] temp = new int[array.Length];
        int i = left, j = middle, k = left;
        while (i < middle && j <= right)
        {
            if (array[i] < array[j])
            {
                temp[k++] = array[i++];
            }
            else
            {
                temp[k++] = array[j++];
            }
        }
        while (i < middle)
        {
            temp[k++] = array[i++];
        }
        while (j <= right)
        {
            temp[k++] = array[j++];
        }
        i = left;
        k = left;
        while (k <= right)
        {
            array[i++] = temp[k++];
        }
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