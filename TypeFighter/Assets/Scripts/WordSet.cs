using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordSet", menuName = "ScriptableObjects/WordSet", order = 1)]
public class WordSet : ScriptableObject
{
    public List<Word> _words;

    public bool HasWord(string potentialWord)
    {
        foreach (Word word in _words)
        {
            if (word.Matches(potentialWord))
            {
                return true;
            }
        }

        return false;
    }
}
