using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Variables publicas
    public float rotationSpeed, minRotation, maxRotation;
    public bool canRotate;

    // Variables privadas
    private float xRotation, yRotation;

    // Funcion para rotar la camara
    public void Rotation()
    {
        // Si podemos rotar
        if (canRotate)
        {
            // Conseguimos la rotacion del mouse
            xRotation += Input.GetAxis("Mouse X") * rotationSpeed;
            yRotation += Input.GetAxis("Mouse Y") * rotationSpeed;

            // Agregamos el limite de rotacion en Y
            yRotation = Mathf.Clamp(yRotation, minRotation, maxRotation);

            // Rotamos el objeto y la camara
            transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
            Camera.main.transform.localRotation = Quaternion.Euler(-yRotation, 0f, 0f);
        }
    }
}
