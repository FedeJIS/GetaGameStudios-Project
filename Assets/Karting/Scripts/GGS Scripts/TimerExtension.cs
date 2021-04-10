using System.Collections;
using System.Collections.Generic;
using KartGame.KartSystems;
using UnityEngine;

//This class represents a pickup object that adds time to the counter.
public class TimerExtension : PickUpObj, IPickUp
{
    [SerializeField]
    private int timeToAdd = 1;
    void IPickUp.PickedUp()
    {
        DoAction();
    }

    override public void DoAction()
    {
        if(myManager != null){
            myManager.AddTime(timeToAdd);
            base.DoAction();
       }
    }
    private void FixedUpdate() {
        transform.Rotate(new Vector3(0,5,0));
    }


}
