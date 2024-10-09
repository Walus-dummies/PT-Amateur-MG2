using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    //Variables publicas
    public float timeToFinish;
    public UnityEvent OnPlayerDetected, AfterTime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnPlayerDetected.Invoke();

            GetComponent<Collider>().enabled = false;

            StartCoroutine(AfterTimeEvent());
        }
    }

    IEnumerator AfterTimeEvent ()
    {
        yield return new WaitForSeconds(timeToFinish);
        AfterTime.Invoke();
        gameObject.SetActive(false);
    }
}
