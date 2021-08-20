using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        GetComponent<LineRenderer>().SetPosition(1, new Vector3(newPos.x, newPos.y, 0f));
    }
}
