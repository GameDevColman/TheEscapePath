using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogUI : MonoBehaviour
{
    private TextMeshProUGUI dialogText;

    void Start()
    {
      dialogText = GetComponent<TextMeshProUGUI>();
      Invoke("HideText", 7);
    }

    void HideText()
    {
      dialogText.text = "";
    }
}
