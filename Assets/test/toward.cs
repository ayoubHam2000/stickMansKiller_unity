using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toward : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = speed * Time.deltaTime;
        transform.position += new Vector3(newPos, 0f, 0f);
    }
}
