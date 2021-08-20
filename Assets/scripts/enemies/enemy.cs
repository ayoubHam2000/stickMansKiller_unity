using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform target = null;
    public float Health = 100;
    public List<AudioClip> DeathSounds = null;
    public float DeathSoundVoulum = 1f;
    public Animator animator = null;
    public bool Died = false;

    private TheWave remouveEnemy;

    private void Start()
    {
        remouveEnemy = FindObjectOfType<TheWave>();
    }

    public void GetDamage(float Damage)
    {
        Health -= Damage;
        if (Health < 0 && Died == false)
        {
            Died = true;
            Die();
        }
    }

    private void Die()
    {
        int randomSoundDeath = Random.Range(0, DeathSounds.Count);
        animator.SetBool("death", true);
        if (DeathSounds.Count > 0) AudioSource.PlayClipAtPoint(DeathSounds[randomSoundDeath], Camera.main.transform.position, DeathSoundVoulum);
        remouveEnemy.ennemiesStill--;
        Destroy(gameObject, 3f);
       
    }

    
}
