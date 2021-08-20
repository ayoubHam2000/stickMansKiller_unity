using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotation : MonoBehaviour
{
    [Range(0f, 1f)][SerializeField] float smooth = 1f;
    [SerializeField] float repaireRotation = 0f;

    private Vector3 Distance;
    private Camera myCam;


    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Distance = myCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (Distance.x != 0)
        {
            float newAngle = Mathf.Atan(Distance.y / Distance.x) * Mathf.Rad2Deg * smooth + repaireRotation;
            transform.eulerAngles = new Vector3(0f, 0f, newAngle);
        }
    }
}
