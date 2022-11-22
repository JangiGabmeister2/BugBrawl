using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeText : MonoBehaviour
{
    public Text text;

    public string[] letters;
    int i = 0;

    public void NewText()
    {
        i++;

        ChangeName();
    }

    public void ChangeName()
    {
        if (i >= 26)
        {
            i = 0;
        }

        EventSystem.current.currentSelectedGameObject.name = letters[i];
        text.text = EventSystem.current.currentSelectedGameObject.name;
    }
}
