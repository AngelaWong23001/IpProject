using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineDemo : MonoBehaviour
{
    // Start is called before the first frame update
    public int demoInt = 0;
    public int[] intArray;
    private float pauseTime;

    public bool taskTwoBool;

    void Start()
    {
        StartCoroutine(DemoCoroutine());
        StartCoroutine(TaskOne());
        StartCoroutine(TaskTwo());
    }

    IEnumerator DemoCoroutine()
    {
        yield return OtherCoroutine();

        Debug.Log("Coroutine starting");
        yield return new WaitForSeconds(3f);
        //Using WaitForSeconds() causes the coroutine to wait for a set number of seconds. 


        while(true)
        {
            Debug.Log("Coroutine running");
            yield return new WaitForEndOfFrame();
            //Using WaitForEndOfFrame() causes the coroutine to wait until the frame ends.

        }
    }
    IEnumerator OtherCoroutine()
        {
            while(demoInt == 0)
            {
                Debug.Log("second coroutine running");
                yield return new WaitForEndOfFrame(); 
                //Using WaitForEndOfFrame() causes the coroutine to wait until the frame ends.

            }
        }
//Task 1:
//Create a public array of ints and set the values in the Inpector window
//Using a coroutine, loop through and print all elements in the array with a variable pause in between.
//You can use the Start() function to start the coroutine.
     IEnumerator TaskOne()
    {
        for(int i = 0; i < intArray.Length; ++i)
        {
         Debug.Log(intArray[i]);
         yield return new WaitForSeconds(pauseTime);
         //Using WaitForSeconds() causes the coroutine to wait for a set number of seconds. 

        }
    }
 //Task 2:
//Create a bool, and a new coroutine.
//Start the coroutine and have it wait until the bool is true before printing a message.
//The bool can be set to true through input or some other event (e.g. collision, trigger, etc.)

    IEnumerator TaskTwo()
    {
        while(!taskTwoBool)
        {
            yield return new WaitForEndOfFrame();
            //Using WaitForEndOfFrame() causes the coroutine to wait until the frame ends.

        }
        Debug.Log("bool is now true");
    }
}
