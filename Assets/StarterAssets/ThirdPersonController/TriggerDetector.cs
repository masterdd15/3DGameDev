using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{

    //In here, we can detect if the player is interacting with a speed boost

    //We need to communicate with the gamemanager
    GameManager mainManager;


    private void Awake()
    {
        mainManager = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.tag == "SpeedUp")
        {
            mainManager.isFast = true;
            mainManager.isSlow = false;
        }
        else if(other.tag == "SlowDown")
        {
            mainManager.isFast = false;
            mainManager.isSlow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        mainManager.StopChange();
    }
}
