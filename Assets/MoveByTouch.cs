using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    Vector3 currentposition;
    Vector3 nextposition;
    Vector3 touchPosition;
    Vector3 startPosition;
    Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Ended)
            {
                startPosition = Camera.main.ScreenToWorldPoint(touch.position);
            }
            if (touch.phase == TouchPhase.Moved)
            {
                nextposition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition = nextposition - startPosition;
                touchPosition.z += touchPosition.y;
                touchPosition.y = 0f;
                transform.position = new Vector3(transform.position.x + touchPosition.x,transform.position.y,transform.position.z + touchPosition.z);
                startPosition = nextposition;
            }
        }
    }
}
