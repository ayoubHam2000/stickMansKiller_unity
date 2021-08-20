using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{

    [SerializeField] GameObject[] enemies = null;
    [SerializeField] int[] numberOfEnemies = null;
    // Start is called before the first frame update

    private int i = 0;
    void Start()
    {
        StartCoroutine(startwave());
    }

    private IEnumerator startwave()
    {
        while (true)
        {
            if (i != numberOfEnemies.Length)
            { 
                Vector3 ThePos = new Vector3(0f, Random.Range(0, 1), 0);
                Instantiate(enemies[i], transform.position + ThePos, Quaternion.identity);
                numberOfEnemies[i]--;
                if (numberOfEnemies[i] == 0)
                {
                    i++;
                }
            }
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
