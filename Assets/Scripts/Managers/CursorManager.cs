using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    // Varibles Publicas
    public bool startCursorState;
    void Start()
    {
        SetCursorState(startCursorState);
    }

    //Función para cambiar el estado del cursor
    public void SetCursorState(bool _state)

    {
        if (_state)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false ;
        }

    }
}
