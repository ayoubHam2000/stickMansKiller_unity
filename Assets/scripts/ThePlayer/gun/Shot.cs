using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float fireRate = 0.3f;
    public float fireDamage = 40f;
    public float fireSpeed = 12f;
    public float nextFire = 1f;
    public AudioClip fireSound = null;
    public float fireSoundVolum = 1f;
    public GameObject firePrefab = null;
    public Transform gunEnd = null;
    public GameObject fireMazzle = null;

    // Start is called before the first frame update
    void Start()
    {
        firePrefab.GetComponent<HitShot>().damage = fireDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && nextFire < Time.time)
        {
            nextFire = Time.time + fireRate;
            GameObject TheShot = Instantiate(firePrefab, gunEnd.position, transform.rotation);
            Vector2 Direction = (gunEnd.position - transform.position) * fireSpeed;
            TheShot.GetComponent<Rigidbody2D>().velocity = new Vector2(Direction.x, Direction.y);
            if (fireSound) AudioSource.PlayClipAtPoint(fireSound, Camera.main.transform.position, fireSoundVolum);
            if (fireMazzle) Instantiate(fireMazzle, gunEnd.position, Quaternion.identity);
        }
    }
}
