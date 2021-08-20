using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation2 : MonoBehaviour
{
    public Vector3 Dist = Vector3.zero;

    private void Update()
    {
        makerotation();
    }

    private void makerotation()
    {
        //Vector2 JoystickPos = new Vector2(shotControler.Horizontal, shotControler.Vertical);
        Dist = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (Dist.x != 0)
        {
            // rotation and felpt
            float angleOnDeg = Mathf.Atan(Dist.y / Dist.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0f, 0f, angleOnDeg);
        }
    }
}
