using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotInfo : MonoBehaviour
{

    [SerializeField] public int damage = 100;
    [SerializeField] GameObject explosion = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* if (explosion)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }*/
        Destroy(gameObject);
    }

   
}
