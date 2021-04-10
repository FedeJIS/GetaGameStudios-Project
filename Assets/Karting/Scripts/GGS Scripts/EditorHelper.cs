using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class contains the information thats is going to be saved in the json file resulting of the Kart Edition.
[System.Serializable]
public class EditorHelper{
    public Material body_mat;
    public Material wheels_mat;

    public void ApplyMats(GameObject body, GameObject[] wheels)
    {
         body.GetComponent<SkinnedMeshRenderer>().material = body_mat;
         foreach (GameObject wheel in wheels)
         {
             wheel.GetComponent<MeshRenderer>().material = wheels_mat;
         }
    }
}
