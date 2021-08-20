using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRotation : MonoBehaviour
{
    [SerializeField] Transform Target = null;
    [SerializeField] bool isRandom = false;
    [SerializeField] float[] TheRange = null;
    [SerializeField] float rotationSmooth = 1;
    [Header("flept")]
    [SerializeField] bool isFlept = false;
    [SerializeField] GameObject theFlepObject = null;

    private bool fleptState = false;
    void Update()
    {
        if (Target)
        {
            Rotation();
        }
    }

    private void Rotation()
    {
        Vector3 Distance = Target.position - transform.position;
        if (Distance.x < 0 && isFlept == true)
        {
            Flept(true);
        }
        else if (Distance.x != 0 && isFlept == true)
        {
            Flept(false);
        }
        if (Distance.x != 0)
        {
            float angleOnDeg = Mathf.Atan(Distance.y / Distance.x) * Mathf.Rad2Deg;
            if (isRandom == true)
            {
                angleOnDeg += Random.Range(TheRange[0], TheRange[1]);
            }
            transform.eulerAngles = new Vector3(0f, 0f, angleOnDeg * rotationSmooth);
        }
    }

    private void Flept(bool flept)
    {
        if (fleptState != flept)
        {
            if (flept == true)
            {
                theFlepObject.transform.localScale = new Vector2(-1f, 1f);
                fleptState = true;
            }
            else
            {
                theFlepObject.transform.localScale = new Vector2(1f, 1f);
                fleptState = false;
            }
        }
    }
}
