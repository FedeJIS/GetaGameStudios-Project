using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents the StartingLine, if player reaches it he wins.
public class StartingLine : MonoBehaviour
{
     private GameModeManager myManager;

     private void OnTriggerEnter(Collider other)
    {
       myManager.SetWinState(true);
    }

    private void Start() {
        myManager = GameObject.FindObjectOfType<GameModeManager>();
    }
}
