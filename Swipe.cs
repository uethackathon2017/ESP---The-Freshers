using UnityEngine;
using System.Collections;

public class Swipe : MonoBehaviour
{
    public static Swipe instance;

    public float minSwipeDistY;

    public float minSwipeDistX;

    public int status;

    private Vector2 startPos;

    void Awake()
    {
        if (instance == null) instance = this;
        status = 0;
    }

    void Update()
    {

        if (Input.touchCount > 0)

        {

            Touch touch = Input.touches[0];



            switch (touch.phase)

            {

                case TouchPhase.Began:

                    startPos = touch.position;

                    break;



                case TouchPhase.Ended:

                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistVertical > minSwipeDistY && swipeDistVertical > swipeDistHorizontal)

                    {

                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        if (swipeValue > 0)//up swipe
                            status = 3;


                        else if (swipeValue < 0)//down swipe
                            status = 4;

                        
                    }else

                    if (swipeDistHorizontal > minSwipeDistX && swipeDistHorizontal > swipeDistVertical)

                    {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0)//right swipe
                            status = 1;


                        else if (swipeValue < 0)//left swipe
                            status = 2;


                    }
                    break;
            }
        }
    }
}
