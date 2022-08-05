using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Word", menuName = "ScriptableObjects/Word", order = 1)]
public class Word : ScriptableObject
{
    public string _word;

    public bool Matches(string word)
    {
        return word.Contains(_word);
    }
}
