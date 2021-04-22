using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    public delegate void ControllsInput(Vector2 position);
    public static ControllsInput PlayerInput;

    private bool isFirstTouch = true;

    private Vector2 firstTouch;

    private void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (isFirstTouch)
            {
                firstTouch = touch.position;
                isFirstTouch = false;
            }

            //Calculating finger movement
            var currentTouch = touch.position;
            var returnVector = currentTouch - firstTouch;

            
            //Returning zero vector if finger is up
            if (touch.phase == TouchPhase.Ended)
            {
                returnVector = Vector3.zero;
                isFirstTouch = true;
            }

            PlayerInput(returnVector);
        }
    }
}
