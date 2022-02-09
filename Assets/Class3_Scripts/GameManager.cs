using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    // This is private, so that we can show an error if its not set up yet
    private static GameManager staticInstance;

    //We need variables to store the player's current state
    private bool isFast;
    private bool isSlow;

    //We also need the third person controller
    public ThirdPersonController myController;

    public static GameManager Instance
    {
        get
        {
            // If the static instance isn't set yet, throw an error
            if (staticInstance is null)
            {
                Debug.LogError("Game Manager is NULL");
            }

            return staticInstance;
        }
    }

    private void Awake()
    {
        // Set the static instance to this instance
        staticInstance = this;

    }

    private void Start()
    {
        //Set the myController variable to the player's controller
        myController = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
    }

    private void Update()
    {
        Debug.Log("" + myController.MoveSpeed);
    }
}
