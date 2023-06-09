using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public AudioClip boomSound;

    private void OnTriggerEnter(Collider collider) 
    {
        PlayerInventory playerInventory = collider.GetComponent<PlayerInventory>();

        if (collider.gameObject.tag == "Player" && playerInventory != null)
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<Renderer>().enabled = false;
            AudioSource.PlayClipAtPoint(boomSound, transform.position);
            playerInventory.GoHome();
        }
    }
}
