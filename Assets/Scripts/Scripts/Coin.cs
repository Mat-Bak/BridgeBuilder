using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Coin : MonoBehaviour
{
    private bool coinUp = false;
    private float coinPosition;
    public float minPos;
    public float maxPos;

    // Animation coin (Position and rotation)

    void Update()
    {
        coinPosition = transform.position.y;
        transform.Rotate(new Vector3(0, 100f, 0) * Time.unscaledDeltaTime);
        if(coinPosition <= (maxPos+0.2) && coinPosition>= (minPos-0.2))
        {
            if (coinUp == false)
            {
                transform.position -= new Vector3(0, 0.001f, 0);
                if(coinPosition <= minPos)
                {
                    coinUp = true;
                }
            }
            else
            {
                transform.position += new Vector3(0, 0.001f, 0);
                if (coinPosition >= maxPos)
                {
                    coinUp = false;
                }
            }

        }

    }
}
