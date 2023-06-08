using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfParts {get; private set;}
    public string dialogText {get; private set;}
    public GameObject spaceShip;

    public UnityEvent<PlayerInventory> OnPartCollected;
    public UnityEvent<PlayerInventory> OnDialogShow;

    void Start() 
    {
        Time.timeScale = 1;
        Guard.OnGuardHasSpottedPlayer += PlayerSpotted;
    }

    void Update() {
        if (NumberOfParts == 5) {
            spaceShip.SetActive(true);
        } else {
            spaceShip.SetActive(false);
        }
    }

    void PlayerSpotted()
    {
        DialogShow("Youv'e been spotted! Press enter to play again");
        Time.timeScale = 0;
    }

    public void PartCollected()
    {
        NumberOfParts++;
        if (NumberOfParts == 5) {
            DialogShow("Now you can go back home!");
        }
        OnPartCollected.Invoke(this);
    }

    public void DialogShow(string newText)
    {
         dialogText = newText;
         OnDialogShow.Invoke(this);
    }

    public void GoHome()
    {
        DialogShow("Travel safe :)");
    }
}
