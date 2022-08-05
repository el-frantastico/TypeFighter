using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Serialization;

public class TypingController : MonoBehaviour
{
    private Coroutine _waitForKeyCoroutine;
    [SerializeField] private int _stringBuilderSize = 5;
    [SerializeField] private WordSet _wordSet;

    private readonly StringBuilder _stringBuilder = new StringBuilder();
    
    private void Start()
    {
        _waitForKeyCoroutine = StartCoroutine(WaitForKey());
    }

    private void OnDestroy()
    {
        StopCoroutine(_waitForKeyCoroutine);
    }

    private void OnKeyPress(string keyName)
    {
        if (keyName.Length == 1 && Char.IsLetter(keyName[0]))
        {
            _stringBuilder.Append(keyName[0]);
            
            if (_stringBuilder.Length > _stringBuilderSize)
            {
                _stringBuilder.Remove(0, 1);
            }

            if (_wordSet.HasWord(_stringBuilder.ToString()))
            {
                Debug.Log("FOUND WORD: " + _stringBuilder.ToString());
                _stringBuilder.Clear();
            }
        }
    }
    
    private IEnumerator WaitForKey()
    {
        while (true)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame)
            {
                InputSystem.onAnyButtonPress.CallOnce(button => OnKeyPress(button.name));
            }
            yield return null;
        }
    }
}
