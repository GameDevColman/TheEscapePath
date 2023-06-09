﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth_KillBehaviour : MonoBehaviour
{

	// Use this for initialization
    public KillStil _Enemy;             //? killstill Scripte;
    public Transform KillPosition;      //? the transfom The player must be present in it;
    public float time;                  //? the Coroutine Time;
    public Animator anim;  

    public KillStil Enemy
    {
        get { return _Enemy; }
        set { _Enemy = value; }
    }
    
	void Start () {
        //! Subscribe and register this behaviour as  behaviour.
       anim=this.GetComponent<Animator>();
	}
           
	// Update is called once per frame
	void Update () {
        // if (Input.GetKeyDown(KeyCode.E) && Enemy != null)
        // {
        //     this.transform.position = KillPosition.position;
        //     this.transform.rotation = KillPosition.rotation;

        //     //! checking  if the position and rotation of the player is change it;
        //     if(this.transform.position == KillPosition.position && this.transform.rotation == KillPosition.rotation)
        //     {
        //         //! playe animation Kill

        //         anim.SetTrigger("Kill");
        //         Debug.Log("Should Animate");
        //         _Enemy.SetParent();

        //         //! start the coroutine 
        //         StartCoroutine(EndKillStealth());
        //     }
        // }
	}

    
    IEnumerator EndKillStealth()
    {
        //write 4 seconds
        yield return new WaitForSeconds(time);
        anim.ResetTrigger("Kill");

        //! set the enemy  and the kill position equle null
        _Enemy = null;
        KillPosition=null;
        
    }
}
