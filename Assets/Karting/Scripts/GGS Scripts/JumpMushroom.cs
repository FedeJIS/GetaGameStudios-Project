using System.Collections;
using System.Collections.Generic;
using KartGame.KartSystems;
using UnityEngine;
//This class represents a pickup object that forces the player to jump.
public class JumpMushroom : PickUpObj, IPickUp
{

    ArcadeKart myKart;
    private void Awake() {
        myKart = GameObject.FindGameObjectWithTag("Player").GetComponent<ArcadeKart>();
    }

    override public void DoAction()
    {
        if(myManager != null){
            myKart.ForceJump();
            base.DoAction();
       }
    }
}
