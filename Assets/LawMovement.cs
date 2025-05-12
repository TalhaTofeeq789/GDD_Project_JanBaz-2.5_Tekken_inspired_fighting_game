using UnityEngine;

public class LawMovement : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int onGuardHash;
    int leftPunchHash;
    int rightPunchHash;
    int leftKickHash;
    int rightKickHash;
    int throwFireballHash;

    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        onGuardHash = Animator.StringToHash("onGuard");
        leftPunchHash = Animator.StringToHash("leftPunch");
        rightPunchHash = Animator.StringToHash("rightPunch");
        leftKickHash = Animator.StringToHash("leftKick");
        rightKickHash = Animator.StringToHash("rightKick");
        throwFireballHash = Animator.StringToHash("throwFireball");
    }

    void Update()
    {
        HandleMovement();
        HandleActions();
    }

    void HandleMovement()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool rightArrowPressed = Input.GetKey(KeyCode.RightArrow);
        bool leftArrowPressed = Input.GetKey(KeyCode.LeftArrow);
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift);

        if (!isWalking && (rightArrowPressed || leftArrowPressed))
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !(rightArrowPressed || leftArrowPressed))
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (rightArrowPressed || leftArrowPressed) && shiftPressed)
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!(rightArrowPressed || leftArrowPressed) || !shiftPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    void HandleActions()
    {
        ///
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool(onGuardHash, true);
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            animator.SetBool(onGuardHash, false);
        }
        ///
        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.SetBool(leftPunchHash, true);
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            animator.SetBool(leftPunchHash, false);
        }
        ///
        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetBool(rightPunchHash, true);
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            animator.SetBool(rightPunchHash, false);
        }
        ///
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetBool(leftKickHash, true);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            animator.SetBool(leftKickHash, false);
        }
        ///
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool(rightKickHash, true);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            animator.SetBool(rightKickHash, false);
        }
        ///
        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetBool(throwFireballHash, true);
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            animator.SetBool(throwFireballHash, false);
        }
        
    }
}
