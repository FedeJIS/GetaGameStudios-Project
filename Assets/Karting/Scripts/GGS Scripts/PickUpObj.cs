using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PickUpObj : MonoBehaviour, IPickUp
{

   protected GameModeManager myManager;
   protected AudioSource myAudioSrc;
   protected BoxCollider myCollider;
   public GameObject myParticles;

   protected void Start() {
        myManager = GameObject.FindObjectOfType<GameModeManager>();
        myAudioSrc = GetComponent<AudioSource>();
        myCollider = GetComponent<BoxCollider>();
   }

   virtual public void DoAction()
   {
       if(myManager != null){
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            myCollider.enabled = false;
            myAudioSrc.Play();
            Instantiate(myParticles,transform.position,transform.rotation);
            Destroy(this.gameObject,myAudioSrc.clip.length);
       }
   }

    void IPickUp.PickedUp()
    {
        DoAction();
    }

}
