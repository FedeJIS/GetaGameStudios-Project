using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGSNewKart : MonoBehaviour
{
    private Rigidbody myRb;
    //BASE STATS
    [SerializeField]
    private float kartCurrentSpeed;

    [SerializeField]
    private float kartMaxSpeed;
    
    [SerializeField]
    private float kartAcceleration;

    [SerializeField]
    private float kartBrakingSpeed;
    

    private void Awake() 
    {
        myRb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void MoveKart()
    {
         if (Input.GetKey(KeyCode.W))
                  myRb.velocity += transform.forward * kartAcceleration * Time.deltaTime;
         if (Input.GetKey(KeyCode.S))
                  myRb.velocity += (-transform.forward) * kartBrakingSpeed * Time.deltaTime;
         if (Input.GetKey(KeyCode.D))
                 transform.Rotate(0,1.5f,0);
         if (Input.GetKey(KeyCode.A))
                 transform.Rotate(0,1.5f,0);
    }
}
