using UnityEngine;

public class LeetCode744 : MonoBehaviour
{
    public char[] letter = new char[] {'e','e','e','e','e','e','n','n','n','n'};
    public char ch = 'e';

    private void Start()
    {
        var res = NextGreatestLetter(letter, ch);
        Debug.Log(res);
    }

    public char NextGreatestLetter(char[] letters, char target)
    {
        if (target >= letters[letters.Length - 1]) {
            return letters[0];
        }
        var res = BinarySearch(letters, target);
        if (letters[res] == target)
        {
            return letters[res + 1];
        }
        return letters[res];
    }

    public int BinarySearch(char[] letters, char target)
    {
        int left = 0, right = letters.Length - 1;
        while (left <= right)
        {
            int middle = (right - left) / 2 + left;
            if (letters[middle] > target)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }
        return left;
    }
}