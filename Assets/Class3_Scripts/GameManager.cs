using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    // This is private, so that we can show an error if its not set up yet
    private static GameManager staticInstance;

    //We need variables to store the player's current state
    public bool isFast;
    public bool isSlow;

    private float fastMoveSpeed = 32;
    private float fastSprintSpeed = 44;

    private float slowMoveSpeed = 3;
    private float slowSprintSpeed = 4;

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
        //Debug.Log("" + myController.MoveSpeed);

        if(isFast)
        {
            myController.MoveSpeed = fastMoveSpeed;
            myController.SprintSpeed = fastSprintSpeed;
        }
        else if(isSlow)
        {
            Debug.Log("CHANGING SPEED");
            myController.MoveSpeed = slowMoveSpeed;
            myController.SprintSpeed = slowSprintSpeed;
        }
    }

    public void StopChange()
    {
        if(isFast)
        {
            StartCoroutine("TempSpeedUp");
        }
        else if(isSlow)
        {
            StartCoroutine("TempSlowDown");
        }

        isFast = false;
        isSlow = false;
    }

    IEnumerator TempSpeedUp()
    {
        myController.MoveSpeed = fastMoveSpeed;
        myController.SprintSpeed = fastSprintSpeed;
        yield return new WaitForSeconds(2f);
        myController.MoveSpeed = 8;
        myController.SprintSpeed = 12;

    }

    IEnumerator TempSlowDown()
    {
        
myController.MoveSpeed = slowMoveSpeed;
        myController.SprintSpeed = slowSprintSpeed;
        yield return new WaitForSeconds(2f);
        myController.MoveSpeed = 8;
        myController.SprintSpeed = 12;

    }

}
