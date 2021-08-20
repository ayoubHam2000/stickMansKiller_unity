using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPosition : MonoBehaviour
{
    [SerializeField] Transform Target = null;
    [SerializeField] float SmoothSpeed = 1f;
    [SerializeField] Vector3 offset = Vector3.zero;

    private Vector3 newPos = Vector3.zero;
    private void Update()
    {
        if (Target)
        {
            newPos = Target.position + offset;
            Vector3 test = new Vector3(newPos.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards
                (transform.position, test, SmoothSpeed * Time.deltaTime);
        }
    }


    public void MouveInY(float posY)
    {
        if (Target)
        { 
        Vector3 test = new Vector3(transform.position.x, posY, transform.position.z);
        transform.position = Vector3.MoveTowards
        (transform.position, test, SmoothSpeed * Time.deltaTime);
        }
    }

}


// Update is called once per frame
/*
void Update()
{
    float PlayerPosX = ThePlayer.transform.position.x;
    float PlayerPosY = ThePlayer.transform.position.y;
    if (transform.position.x - PlayerPosX < distanceX)
    {
        Vector3 newPosX = new Vector3(PlayerPosX + distanceX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosX, Speed);
    }
    else if (transform.position.x - PlayerPosX > distanceX)
    {
        Vector3 newPosX = new Vector3(PlayerPosX + distanceX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosX, Speed);
    }
    if (transform.position.y - PlayerPosY < distanceY)
    {
        Vector3 newPosY = new Vector3(transform.position.x, PlayerPosY + distanceY, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosY, Speed);
    }

    else if (transform.position.y - PlayerPosY > distanceY)
    {
        Vector3 newPosY = new Vector3(transform.position.x, PlayerPosY + distanceY, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosY, Speed);
    }

}
*/
