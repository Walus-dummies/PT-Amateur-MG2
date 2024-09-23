using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // Variables publicas
    public GroundDetector groundDetector;
    public float dampTime;

    // Variablese privadas
    private PlayerMovement playerMovement;
    private Animator animator;

    private float animatorSpeed, dampSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        animatorSpeed = 0f;
        dampSpeed = 0f;
    }

    public void CheckSpeed()
    {
        animatorSpeed = Mathf.SmoothDamp(animatorSpeed, (playerMovement.GetCurrentSpeed() / playerMovement.runSpeed), ref dampSpeed, dampTime);
        if (groundDetector.GetIsGrounded())
        {
            animator.SetFloat("Speed", animatorSpeed);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }
}
