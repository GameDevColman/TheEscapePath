using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipPart : MonoBehaviour
{
    public AudioClip boomSound;

    private void OnTriggerEnter(Collider collider) {
        PlayerInventory playerInventory = collider.GetComponent<PlayerInventory>();

        if (collider.gameObject.tag == "Player" && playerInventory != null)
        {
            AudioSource.PlayClipAtPoint(boomSound, transform.position);
            Destroy(gameObject);
        }
    }
}
