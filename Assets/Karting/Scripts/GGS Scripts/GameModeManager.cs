using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class contains all the behaviours and data to represent a Countdown Gamemode.
public class GameModeManager : MonoBehaviour
{

    public TextMeshProUGUI txt_Timer;
    [SerializeField]
    private int startTime = 60;
    private float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = startTime;
        txt_Timer = GameObject.FindGameObjectWithTag("Text_Time").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       Countdown();
    }

    //This method represents a counter.
    private void Countdown()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                SetWinState(false);
        }
        txt_Timer.text = "TIME: "+ Mathf.RoundToInt(timeRemaining);
    }

    //Adds given time to counter
    public void AddTime(float time)
    {
        timeRemaining+=time;
    }

    //Sets the win state. If player has lost: Lose scene is loaded. Else Win scene is loaded.
    public void SetWinState(bool flag)
    {
        if(flag == false)
        {
          SceneManager.LoadScene(2);
        }
        else SceneManager.LoadScene(3);

    }
}
