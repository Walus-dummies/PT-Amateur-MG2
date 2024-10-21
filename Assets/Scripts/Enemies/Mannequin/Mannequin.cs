using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mannequin : MonoBehaviour
{
    // Variables publicas
    public NavigationComponent navigation;
    public GazeDetector detector;
    public AudioSource audioSource;

    public float timeToStop, timeToMove;

    // Variables privadas
    private bool canMove = false;

    // Update is called once per frame
    void Update()
    {
        CanMove();
        FollowPlayer();
    }

    void CanMove()
    {
        if (!detector.IsRendered())
        {
            if(!canMove)
            StartCoroutine(StartMovementCoroutine(timeToMove));
        }
        else
        {
            if(canMove)
            StartCoroutine(StopMovementCoroutine(timeToStop));
        }
    }

    void FollowPlayer()
    {
        if (canMove)
        {
            navigation.NavigationState(true);
            navigation.MoveToPosition(Player.Instance.transform.position);
            audioSource.volume = 1.0f;
        }
        else
        {
            navigation.NavigationState(false);
            audioSource.volume = 0f;
        }
    }

    IEnumerator StopMovementCoroutine(float _time)
    {
        yield return new WaitForSeconds(_time);
        canMove = false;
    }

    IEnumerator StartMovementCoroutine(float _time)
    {
        yield return new WaitForSeconds(_time);
        if (!detector.IsRendered())
        {
            canMove = true;
        }
    }
}
