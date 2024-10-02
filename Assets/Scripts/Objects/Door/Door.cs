using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Variables publicas
    public AudioSource audioSource;
    public AudioClip openingSound, closingSound, lockedSound;

    // Variables privadas
    private bool isOpen = false;
    [SerializeField] private bool isLocked;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // funcion de interaccion
    public void Interaction()
    {
        if (!isLocked)
        {
            if (isOpen)
            {
                isOpen = false;
            }
            else
            {
                isOpen = true;
            }
            UpdateAnimation();
        }
        else
        {
            audioSource.clip = lockedSound;
            audioSource.Play();
        }
    }

    // funcion para reproducir el sonido
    public void PlaySound()
    {
        if (isOpen)
        {
            audioSource.clip = openingSound;
        }
        else
        {
            audioSource.clip = closingSound;
        }
        audioSource.Play();
    }

    // funcion para cambiar el estado Open de la puerta
    public void SetIsOpen(bool _state)
    {
        isOpen= _state;
        UpdateAnimation();
    }

    // funcion para cambiar el estado Locked de la puerta
    public void SetIsLocked(bool _state)
    {
        isLocked = _state;
    }

    public void UpdateAnimation()
    {
        animator.SetBool("isOpen", isOpen);
    }
}
