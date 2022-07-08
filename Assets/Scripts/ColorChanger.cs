using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    public MeshRenderer myRenderer;
    public Color myColor ;
    private Color startColor;

    public float changeDuration;

    private float currentDuration;

    public Color[] colorArray;

    private int colorIndex;

    // Start is called before the first frame update
    void Start()
    {
        startColor = myRenderer.material.color;

    }

    // Update is called once per frame
    void Update()
    {
        if(currentDuration < changeDuration)
        {
         //   myRenderer.material.color = myColor;       ( color wheel can Change in inspector)
         float changePercentage = currentDuration / changeDuration;
         Color newColor = Color.Lerp(startColor, colorArray[colorIndex], changePercentage);
         myRenderer.material.color = newColor;

         currentDuration += Time.deltaTime;

        }
        else
        {
            //Reset the timer
            currentDuration = 0f;
            //Change Index of colors from array
            ++colorIndex;
            //If Index color from array is more than or equal to color array 
            //last index go back to index 0 Loop color in unity
            if(colorIndex >= colorArray.Length)
            {
                colorIndex = 0;
            }

            startColor = myRenderer.material.color;
        }
    }
}
