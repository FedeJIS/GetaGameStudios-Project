using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
//This class contains all the behaviours and data to edit the Kart. 
public class KartEditor : MonoBehaviour
{
    public Material[] body_color;
    int body_index = 0;
    int wheels_index = 0;
    public Material[] wheels_color;
    public GameObject body;
    public GameObject[] wheels;

    string jsonFileName = "savedMaterials";
    private void Start() {
        ApplyMaterials();
        Load();
    }
   public void NextBody()
   {
       if(body_index < body_color.Length-1)
       {
           body_index++;
       }else body_index = 0;
       ApplyMaterials();
   }

   public void PrevBody()
   {
       if(body_index > 0)
       {
           body_index--;
       }else body_index = body_color.Length-1;
       ApplyMaterials();
   }


   public void NextWheel()
   {
       if(wheels_index < wheels_color.Length-1)
       {
           wheels_index++;
       }else wheels_index = 0;
       ApplyMaterials();
   }


   public void PrevWheel()
   {
       if(wheels_index > 0)
       {
           wheels_index--;
       }else wheels_index = wheels_color.Length-1;
       ApplyMaterials();
   }

//Applies the materials to the editing kart.
   void ApplyMaterials()
   {
       body.GetComponent<SkinnedMeshRenderer>().material = body_color[body_index];
       foreach (GameObject wheel in wheels)
       {
         wheel.GetComponent<MeshRenderer>().material = wheels_color[wheels_index];
       }
   }

//Saves and goes back to menu
   public void SaveAndExit()
   {
       EditorHelper save = new EditorHelper();
       save.body_mat = body.GetComponent<SkinnedMeshRenderer>().material;
       save.wheels_mat = wheels[0].GetComponent<MeshRenderer>().material;
       string g = JsonUtility.ToJson(save);
       string jsonFilePath = Application.dataPath + "/Karting/kart_mats.json";
       File.WriteAllText(jsonFilePath, g);
       SceneManager.LoadScene(0);
   }

//Loads the edition (INCOMPLETE)
   public void Load()
   {
        string jsonFilePath = Application.dataPath + "/Karting/kart_mats.json";
        EditorHelper eh = new EditorHelper();
        if(File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            eh = JsonUtility.FromJson<EditorHelper>(json);
        }
   }


}
