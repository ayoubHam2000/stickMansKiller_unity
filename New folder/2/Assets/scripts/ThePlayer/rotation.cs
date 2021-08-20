using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

    [SerializeField] float repaireRotation = 0f;
    [SerializeField] float retationSmouth = 1f;

    private MainFlept TheFlept = null;
 
    void Start () {
        repaireRotation += transform.eulerAngles.z;
        TheFlept = FindObjectOfType<player>().GetComponent<MainFlept>();
    }



    private void Update()
    {
        makerotation();
    }

    private void makerotation()
    {
        //Vector2 JoystickPos = new Vector2(shotControler.Horizontal, shotControler.Vertical);
        Vector3 Dist = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (Dist.x != 0)
        {
            // rotation and felpt
            float angleOnDeg = Mathf.Atan(Dist.y / Dist.x) * Mathf.Rad2Deg + repaireRotation;
            if (Dist.x < 0) TheFlept.Flept(true);
            else TheFlept.Flept(false);
            transform.eulerAngles = new Vector3(0f, 0f, angleOnDeg * retationSmouth);
        }
    }

    
}


/*
 * old script
 private void makerotation()
    {
        if (isWalking == true)
        {
            Vector3 Distance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angleOnDeg = Mathf.Atan2(Distance.y, Distance.x) * Mathf.Rad2Deg + repaireRotation;
            transform.eulerAngles = new Vector3(0f, 0f, angleOnDeg * retationSmouth);

        }

    }
 *
 * 
 * 
 private void FindTarget()
    {
        if (isWalking == false)
        {
            int Length = FindObjectsOfType<enemy>().Length;
            if (Length != 0)
            {
                Vector3 Distance = FindObjectsOfType<enemy>()[0].gameObject.transform.position - transform.position;
                float angleOnDeg = Mathf.Atan2(Distance.y, Distance.x) * Mathf.Rad2Deg + repaireRotation;
                transform.eulerAngles = new Vector3(0f, 0f, angleOnDeg * retationSmouth);
            }
            else
            {
                transform.eulerAngles = Vector3.zero;
            }

        }
    }


 * */
