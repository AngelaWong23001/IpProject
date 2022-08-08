using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    public string currentState;
    public string nextState;
    public bool demoBool;

    // Start is called before the first frame update
    void Start()
    {
        currentState = "Open";
        nextState = currentState;
        SwitchState();
    }

    // Update is called once per frame
    void Update()
    {
        if(demoBool)
        {
            nextState = "Open";
        }
        else
        {
            nextState = "Close";
        }


        //If the current state does not match next state, update current state.
        if(currentState != nextState)
        {
            currentState = nextState;
        }
    }
        void SwitchState()
        {
            StartCoroutine(currentState);
        }
        IEnumerator Open()
        {
            // Transition in
            Debug.Log("door is opening");

            // State Behaviour
            while(currentState == "Open")
            {
                Debug.Log("Door is Open");
                yield return new WaitForEndOfFrame();
                //Using WaitForEndOfFrame() causes the coroutine to wait until the frame ends.

            }
            SwitchState();
        }
        IEnumerator Close()
        {
            Debug.Log("Door is closing");

            while(currentState == "Close")
            {
                Debug.Log("Door is closed");
                yield return new WaitForEndOfFrame();
                //Using WaitForEndOfFrame() causes the coroutine to wait until the frame ends.

            }
            SwitchState();
        }
}
