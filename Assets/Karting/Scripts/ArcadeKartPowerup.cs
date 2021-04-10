using KartGame.KartSystems;
using UnityEngine;
using UnityEngine.Events;

public class ArcadeKartPowerup : MonoBehaviour {

    public ArcadeKart.StatPowerup boostStats = new ArcadeKart.StatPowerup
    {
        MaxTime = 5
    };
    AudioSource myAudioSrc;
    public bool isCoolingDown { get; private set; }
    public float lastActivatedTimestamp { get; private set; }
    public float cooldown = 5f;
    public bool disableGameObjectWhenActivated;
    public UnityEvent onPowerupActivated;
    public UnityEvent onPowerupFinishCooldown;

    public bool rotate = false;

    private void Awake()
    {
        lastActivatedTimestamp = -9999f;
        myAudioSrc = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (isCoolingDown) { 

            if (Time.time - lastActivatedTimestamp > cooldown) {
                //finished cooldown!
                isCoolingDown = false;
                onPowerupFinishCooldown.Invoke();
            }

        }
        if(rotate) transform.Rotate(new Vector3(0,5,0));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isCoolingDown) return;

        var rb = other.attachedRigidbody;
        if (rb) {

            var kart = rb.GetComponent<ArcadeKart>();

            if (kart)
            { 
                lastActivatedTimestamp = Time.time;
                kart.AddPowerup(this.boostStats);
                onPowerupActivated.Invoke();
                isCoolingDown = true;
                myAudioSrc.Play();
                if (disableGameObjectWhenActivated)
                {
                    Destroy(this.gameObject,myAudioSrc.clip.length);
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
    }

}
