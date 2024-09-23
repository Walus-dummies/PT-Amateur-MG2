using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed, runSpeed, jumpForce;
    public bool canMove;
    public GroundDetector groundDetector;

    // Variables privadas;
    private Vector3 movementVector, verticalForce;
    private float speed, currentSpeed;
    private bool isGrounded;
    private CharacterController characterController;

    // Start function
    private void Start()
    {
        // Inicializacion de variables
        characterController = GetComponent<CharacterController>();
        speed = walkSpeed;
        currentSpeed = 0f;
        verticalForce = Vector3.zero;
        movementVector = Vector3.zero;
    }

    public void Movement()
    {
        // Si nos podemos mover
        if (canMove)
        {
            Walk();
            Run();
            Jump();
        }

        // Gravedad y check ground
        Gravity();
        CheckGround();
    }

    // Funcion para caminar
    public void Walk()
    {
        // Conseguimos los inputs
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");

        // Normalizamos el vector de movimiento
        movementVector = movementVector.normalized;

        // Nos movemos en direccion a la camara
        movementVector = transform.TransformDirection(movementVector);

        // Guardamos la velocidad actual con suavizado
        currentSpeed = Mathf.Lerp(currentSpeed, movementVector.magnitude * speed, 10f * Time.deltaTime);

        // Nos movemos
        characterController.Move(movementVector * currentSpeed * Time.deltaTime);
    }

    // Funcion para correr
    public void Run()
    {
        // Si presionamos el boton para correr modificamos la velocidad
        if (Input.GetAxis("Run") > 0f)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }

    // Funcion para saltar
    void Jump()
    {
        // Si estamos tocando el suelo
        if (isGrounded && Input.GetAxis("Jump") > 0f)
        {
            verticalForce = new Vector3(0f, jumpForce, 0f);
            isGrounded = false;
        }
    }

    // Funcion de gravedad
    public void Gravity()
    {
        if (!isGrounded)
        {
            // Aumentamos la aceleracion de la gravedad
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        else
        {
            verticalForce = new Vector3(0f, -2f, 0f);
        }

        // Aplicamos la fuerza vertical
        characterController.Move(verticalForce * Time.deltaTime);
    }

    // Funcion para ver si estamos tocando el suelo
    void CheckGround()
    {
        isGrounded = groundDetector.GetIsGrounded();
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
