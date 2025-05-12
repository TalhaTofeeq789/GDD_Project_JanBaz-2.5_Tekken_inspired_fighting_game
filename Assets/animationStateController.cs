/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class animationStateController : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            animator.SetBool("isWalking", true);
        }
    }
}

*/

using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Initialize the Animator component
        isWalkingHash = Animator.StringToHash("isWalking"); // Cache the hash for "isWalking"
        isRunningHash = Animator.StringToHash("isRunning"); // Cache the hash for "isRunning"
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash); // Use the cached hash
        bool isRunning = animator.GetBool(isRunningHash); // Use the cached hash
        bool forwardPressed = Input.GetKey("w"); // Check if "w" is pressed
        bool runPressed = Input.GetKey(KeyCode.LeftShift); // Check if "Left Shift" is pressed

        // If the character is not walking and "w" is pressed, start walking
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        // If the character is walking and "w" is not pressed, stop walking
        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        // If the character is walking and "Left Shift" is pressed, start running
        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        // If the character is running and "Left Shift" is not pressed, stop running
        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}

 