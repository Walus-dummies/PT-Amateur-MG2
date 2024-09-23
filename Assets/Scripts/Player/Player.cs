using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables publicas
    public PlayerMovement playerMovement;
    public CameraMovement cameraMovement;
    public Interactor interactor;
    public PlayerAnimations animations;
    
    // Variables privadas


    // Singleton
    public static Player Instance { get; private set; }

    private void Awake()
    {
        // Verificacion de Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        Application.targetFrameRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cameraMovement.Rotation();
        interactor.Interaction();
    }

    private void FixedUpdate()
    {
        playerMovement.Movement();
        animations.CheckSpeed();
    }
}
