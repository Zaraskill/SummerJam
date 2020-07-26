using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Shuffle
{
    #region int
    public static int[] DoShuffle(int[] toShuffle)
    {
        List<int> shuffleList = new List<int>();

        for (int i = 0; i < toShuffle.Length; i++)
        {
            shuffleList.Add(toShuffle[i]);

            int pos = Random.Range(0, shuffleList.Count);
            int tmp = shuffleList[pos];
            shuffleList[pos] = shuffleList[shuffleList.Count - 1];
            shuffleList[shuffleList.Count - 1] = tmp;

        }

        for (int i = 0; i < shuffleList.Count; i++)
        {
            toShuffle[i] = shuffleList[i];
        }

        return toShuffle;
    }
    public static List<int> DoShuffle(List<int> toShuffle)
    {
        List<int> shuffleList = new List<int>();

        for (int i = 0; i < toShuffle.Count; i++)
        {
            shuffleList.Add(toShuffle[i]);

            int pos = Random.Range(0, shuffleList.Count);
            int tmp = shuffleList[pos];
            shuffleList[pos] = shuffleList[shuffleList.Count - 1];
            shuffleList[shuffleList.Count - 1] = tmp;

        }

        for (int i = 0; i < shuffleList.Count; i++)
        {
            toShuffle[i] = shuffleList[i];
        }

        return toShuffle;
    }
    #endregion
    #region float
    public static float[] DoShuffle(float[] toShuffle)
    {
        List<float> shuffleList = new List<float>();

        for (int i = 0; i < toShuffle.Length; i++)
        {
            shuffleList.Add(toShuffle[i]);

            int pos = Random.Range(0, shuffleList.Count);
            float tmp = shuffleList[pos];
            shuffleList[pos] = shuffleList[shuffleList.Count - 1];
            shuffleList[shuffleList.Count - 1] = tmp;

        }

        for (int i = 0; i < shuffleList.Count; i++)
        {
            toShuffle[i] = shuffleList[i];
        }

        return toShuffle;
    }
    public static List<float> DoShuffle(List<float> toShuffle)
    {
        List<float> shuffleList = new List<float>();

        for (int i = 0; i < toShuffle.Count; i++)
        {
            shuffleList.Add(toShuffle[i]);

            int pos = Random.Range(0, shuffleList.Count);
            float tmp = shuffleList[pos];
            shuffleList[pos] = shuffleList[shuffleList.Count - 1];
            shuffleList[shuffleList.Count - 1] = tmp;

        }

        for (int i = 0; i < shuffleList.Count; i++)
        {
            toShuffle[i] = shuffleList[i];
        }

        return toShuffle;
    }
    #endregion
    #region string
    public static string[] DoShuffle(string[] toShuffle)
    {
        List<string> shuffleList = new List<string>();

        for (int i = 0; i < toShuffle.Length; i++)
        {
            shuffleList.Add(toShuffle[i]);

            int pos = Random.Range(0, shuffleList.Count);
            string tmp = shuffleList[pos];
            shuffleList[pos] = shuffleList[shuffleList.Count - 1];
            shuffleList[shuffleList.Count - 1] = tmp;

        }

        for (int i = 0; i < shuffleList.Count; i++)
        {
            toShuffle[i] = shuffleList[i];
        }

        return toShuffle;
    }
    public static List<string> DoShuffle(List<string> toShuffle)
    {
        List<string> shuffleList = new List<string>();

        for (int i = 0; i < toShuffle.Count; i++)
        {
            shuffleList.Add(toShuffle[i]);

            int pos = Random.Range(0, shuffleList.Count);
            string tmp = shuffleList[pos];
            shuffleList[pos] = shuffleList[shuffleList.Count - 1];
            shuffleList[shuffleList.Count - 1] = tmp;

        }

        for (int i = 0; i < shuffleList.Count; i++)
        {
            toShuffle[i] = shuffleList[i];
        }

        return toShuffle;
    }
    #endregion
    #region char
    public static char[] DoShuffle(char[] toShuffle)
    {
        List<char> shuffleList = new List<char>();

        for (int i = 0; i < toShuffle.Length; i++)
        {
            shuffleList.Add(toShuffle[i]);

            int pos = Random.Range(0, shuffleList.Count);
            char tmp = shuffleList[pos];
            shuffleList[pos] = shuffleList[shuffleList.Count - 1];
            shuffleList[shuffleList.Count - 1] = tmp;

        }

        for (int i = 0; i < shuffleList.Count; i++)
        {
            toShuffle[i] = shuffleList[i];
        }

        return toShuffle;
    }
    public static List<char> DoShuffle(List<char> toShuffle)
    {
        List<char> shuffleList = new List<char>();

        for (int i = 0; i < toShuffle.Count; i++)
        {
            shuffleList.Add(toShuffle[i]);

            int pos = Random.Range(0, shuffleList.Count);
            char tmp = shuffleList[pos];
            shuffleList[pos] = shuffleList[shuffleList.Count - 1];
            shuffleList[shuffleList.Count - 1] = tmp;

        }

        for (int i = 0; i < shuffleList.Count; i++)
        {
            toShuffle[i] = shuffleList[i];
        }

        return toShuffle;
    }
    #endregion

    #region char
    public static GameObject[] DoShuffle(GameObject[] toShuffle)
    {
        List<GameObject> shuffleList = new List<GameObject>();

        for (int i = 0; i < toShuffle.Length; i++)
        {
            shuffleList.Add(toShuffle[i]);

            int pos = Random.Range(0, shuffleList.Count);
            GameObject tmp = shuffleList[pos];
            shuffleList[pos] = shuffleList[shuffleList.Count - 1];
            shuffleList[shuffleList.Count - 1] = tmp;

        }

        for (int i = 0; i < shuffleList.Count; i++)
        {
            toShuffle[i] = shuffleList[i];
        }

        return toShuffle;
    }
    public static List<GameObject> DoShuffle(List<GameObject> toShuffle)
    {
        List<GameObject> shuffleList = new List<GameObject>();

        for (int i = 0; i < toShuffle.Count; i++)
        {
            shuffleList.Add(toShuffle[i]);

            int pos = Random.Range(0, shuffleList.Count);
            GameObject tmp = shuffleList[pos];
            shuffleList[pos] = shuffleList[shuffleList.Count - 1];
            shuffleList[shuffleList.Count - 1] = tmp;

        }

        for (int i = 0; i < shuffleList.Count; i++)
        {
            toShuffle[i] = shuffleList[i];
        }

        return toShuffle;
    }
    #endregion
}
