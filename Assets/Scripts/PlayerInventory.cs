using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfParts {get; private set;}

    public UnityEvent<PlayerInventory> OnPartCollected;

    public void PartCollected()
    {
        NumberOfParts++;
        OnPartCollected.Invoke(this);
    }
}
