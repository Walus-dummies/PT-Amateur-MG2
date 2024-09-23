using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    // Variables publicas
    public UnityEvent onInteract;

    // Funcion de interaccion
    public void Interact()
    {
        // Activamos el evento
        onInteract.Invoke();
    }
}
