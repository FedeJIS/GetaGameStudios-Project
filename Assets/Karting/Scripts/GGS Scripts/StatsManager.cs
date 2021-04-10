using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents a Stat Manager to change the stats of the player.
namespace KartGame.KartSystems
{
    public class StatsManager : MonoBehaviour
    {
        //ATTRIBUTES
        private ArcadeKart myKart;
        
        [SerializeField]
        //Max speed to reach
        private float TopSpeed;
        
        [SerializeField]
        //How fast the Kart reaches Max Speed
        private float Acceleration;

        [SerializeField]
        //How fast the Kart stops
        private float Braking;
        
        [SerializeField]
        //Curve sensibility
        public float Steer;
        //METHODS
        void Awake()
        {
          myKart = GetComponent<ArcadeKart>();
        }

        void Start()
        {
            SetStats();
        }

        public void SetStats()
        {
            if(myKart != null)
            {
                myKart.baseStats.Acceleration = Acceleration;
                myKart.baseStats.TopSpeed = TopSpeed;
                myKart.baseStats.Braking = Braking;
                myKart.baseStats.Steer = Steer;
            }
        }
    }
}
