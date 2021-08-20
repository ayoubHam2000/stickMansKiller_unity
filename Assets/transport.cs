using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transport : MonoBehaviour
{
    public Transform topOFTheRock = null;
    public float timeOfTransporting = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("yes");
        GameObject theEnemey = collision.gameObject;
        if (theEnemey.GetComponent<enemy>())
        {
            Debug.Log("transport");
            StartCoroutine(transportEnemies(theEnemey));
        }
        else Debug.Log("no transport");
    }

    private IEnumerator transportEnemies(GameObject theEnemy)
    {
        Debug.Log("transport");
        yield return new WaitForSeconds(timeOfTransporting);
        Vector3 enemyPos = theEnemy.transform.localScale;
        theEnemy.transform.localScale = new Vector3(-enemyPos.x, enemyPos.y, enemyPos.z);
        theEnemy.transform.position = topOFTheRock.position;
    }
}
