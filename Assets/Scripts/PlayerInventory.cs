using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public static event System.Action OnGameWon;

    public int NumberOfParts {get; private set;}
    public string dialogText {get; private set;}
    public GameObject spaceShip;
    public AudioClip spottedSound;

    public UnityEvent<PlayerInventory> OnPartCollected;
    public UnityEvent<PlayerInventory> OnDialogShow;

    private bool isLost = false;

    void Start() 
    {
        Time.timeScale = 1;
        Guard.OnGuardHasSpottedPlayer += PlayerSpotted;
    }

    void Update() {
        if (NumberOfParts == 5 && !isLost) {
            spaceShip.SetActive(true);
        }
    }

    void PlayerSpotted()
    {
        isLost = true;
        DialogShow("Youv'e been spotted! Press enter to play again");
        AudioSource.PlayClipAtPoint(spottedSound, transform.position);
        Time.timeScale = 0;
        Guard.OnGuardHasSpottedPlayer -= PlayerSpotted;
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
        DialogShow("Travel safe! Press enter to play again");
        if (OnGameWon != null) {
			OnGameWon ();
		}
        Time.timeScale = 0;
    }
}
