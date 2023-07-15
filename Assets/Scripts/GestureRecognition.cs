using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureRecognition : MonoBehaviour
{
    private bool isDrawing = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }

        if (isDrawing)
        {
            print("Sto disegnando");
        } else {
            print("Non sto disegnando");
        }
    }

    private void StartDrawing()
    {
        isDrawing = true;
        // Esegui azioni all'inizio del disegno
    }

    private void StopDrawing()
    {
        isDrawing = false;
        // Esegui azioni alla fine del disegno
    }
}
