using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor_Test : MonoBehaviour {

    public bool lockCursor = true;

    public float zoomSpeed = 1;
    public float targetOrtho;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 20.0f;

    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
    }

    void Update()
    {

        // pressing esc toggles between hide/show
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lockCursor = !lockCursor;
        }

        //Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        //Cursor.visible = lockCursor ? Cursor.visible = true : Cursor.visible = false;
        Cursor.visible = !lockCursor;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            targetOrtho -= scroll * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }

        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
    }


}
