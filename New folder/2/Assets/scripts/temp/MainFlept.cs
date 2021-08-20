using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFlept : MonoBehaviour
{

    public bool isFlept = false;
    public void Flept(bool flept)
    {
        if (isFlept != flept)
        {
            if (flept == true)
            {
                transform.localScale = new Vector2(-1f, 1f);
                isFlept = true;
            }
            else
            {
                transform.localScale = new Vector2(1f, 1f);
                isFlept = false;
            }
        }
    }
}
