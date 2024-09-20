using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{
    public float decreaseInterval = 0.1f; // Time interval for decreasing size
    public float decreaseAmount = 0.01f;   // Amount to decrease every interval
    public float increaseAmount = 0.25f;  // Amount to increase when pressing space
    public float scaleSpeed = 2.0f;       // Speed at which the scale changes

    private Vector3 targetScale;          // The scale we're moving towards
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial target scale to the current scale of the object
        targetScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Smoothly move towards the target scale
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);

        // Decrease the size every 3 seconds
        timer += Time.deltaTime;
        if (timer >= decreaseInterval)
        {
            DecreaseSize();
            timer = 0f; // Reset the timer after decreasing size
        }

        // Enlarge the background when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseSize();
        }
    }

    // Function to decrease size
    void DecreaseSize()
    {
        targetScale -= new Vector3(decreaseAmount, decreaseAmount, 0);
        // Ensure the target scale doesn't become negative or too small
        targetScale = new Vector3(Mathf.Max(targetScale.x, 0.1f), Mathf.Max(targetScale.y, 0.1f), 1f);
    }

    // Function to increase size
    void IncreaseSize()
    {
        targetScale += new Vector3(increaseAmount, increaseAmount, 0);
    }
}