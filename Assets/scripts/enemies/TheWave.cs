using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWave : MonoBehaviour
{
    public Transform theTarget = null;
    public GameObject enemy = null;
    public int numberOfWaves = 0;
    public int numberOfenemies = 0;
    public float[] timeBetweenEnemies = null;
    public float[] timeBetweenWaves = null;
    public AudioClip WinSound = null;
    public int ennemiesStill;

    private float RandomTime;
    private bool wavesHasEnd = false;
    

    private void Start()
    {
        ennemiesStill = numberOfWaves * numberOfenemies;
        StartCoroutine(StartTheWave());
        wavesHasEnd = true;
    }

    private void Update()
    {
        if (wavesHasEnd == true)
        {
            if (ennemiesStill == 0)
            {
                StartCoroutine(Win());
            }
        }
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(1f);
        if (WinSound) AudioSource.PlayClipAtPoint(WinSound, Camera.main.transform.position, 1f);
        yield return new WaitForSeconds(2f);
        FindObjectOfType<ManageScenes>().MissionScene();
    }

    private IEnumerator StartTheWave()
    {
        for (int i = numberOfWaves; i > 0; i--)
        {
            RandomTime = Random.Range(timeBetweenWaves[0], timeBetweenWaves[1]);
            yield return new WaitForSeconds(RandomTime);
            yield return StartCoroutine(StartEnemies(numberOfenemies));
        }
    }

    private IEnumerator StartEnemies(int theNumberOfenemies)
    {
        for (int i = theNumberOfenemies; i > 0; i--)
        {
            RandomTime = Random.Range(timeBetweenEnemies[0], timeBetweenEnemies[1]);
            GameObject theEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            theEnemy.GetComponent<enemy>().target = theTarget;
            yield return new WaitForSeconds(RandomTime);
        }
    }
}
