using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouveinx : MonoBehaviour
{
    [SerializeField] float distanceX = 10f;
    [SerializeField] float speed = 1f;

    private Vector2 newPosX;
    private int time = -1;

    // Start is called before the first frame update

    private void Start()
    {
        newPosX = new Vector2(transform.position.x + distanceX, transform.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, newPosX, speed * Time.deltaTime);
        if (transform.position.x == newPosX.x)
        {
            newPosX = new Vector2(transform.position.x + 2*distanceX*time, transform.position.y);
            time *= -1;
        }
    }
    
}
