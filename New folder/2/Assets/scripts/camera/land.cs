using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class land : MonoBehaviour
{
    private Vector3 startpos = Vector3.zero;
    private float length  = 0;
    public GameObject cam;
    public float parallaxEffectOnX = 0;
    public float parallaxEffectOnY = 0;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        float tempX = cam.transform.position.x * (1 - parallaxEffectOnX);
        float distX = cam.transform.position.x * parallaxEffectOnX;
        float distY = cam.transform.position.y * parallaxEffectOnY;
       

        transform.position = new Vector3(startpos.x + distX, distY, transform.position.z);
        if (tempX > startpos.x + length) { startpos.x += length; }
        else if (tempX < startpos.x - length) { startpos.x -= length; } 

    }
}
