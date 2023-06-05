using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PartsCollection : MonoBehaviour
{
    private TextMeshProUGUI partsCollected;

    void Start()
    {
        partsCollected = GetComponent<TextMeshProUGUI>();
        Debug.Log(partsCollected);
    }

    public void UpdatePartsText(PlayerInventory playerInventory)
    {
        partsCollected.text = playerInventory.NumberOfParts.ToString();
    }
}
