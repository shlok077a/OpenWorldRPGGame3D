using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursors : MonoBehaviour
{
    public GameObject cursor;
    public Sprite mainCursor;
    public Sprite cameraCursor;
    public Image cursorImage;
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        cursor.transform.position = Input.mousePosition;

        if (Input.GetMouseButton(1))
        {
            cursorImage.sprite = cameraCursor;
        }
        if (Input.GetMouseButtonUp(1))
        {
            cursorImage.sprite = mainCursor;
        }
    }
}
