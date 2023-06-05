using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfParts {get; private set;}
    public string dialogText {get; private set;}

    public UnityEvent<PlayerInventory> OnPartCollected;
    public UnityEvent<PlayerInventory> OnDialogShow;

    public void PartCollected()
    {
        NumberOfParts++;
        OnPartCollected.Invoke(this);
    }

    public void DialogShow(string newText)
    {
         dialogText = newText;
         OnDialogShow.Invoke(this);
    }
}
