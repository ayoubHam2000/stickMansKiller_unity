using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHit : MonoBehaviour
{
    public float DamageLevel = 1f;
    public enemy Theenemy = null;
    public void GetDamage(float theDamage)
    {
        float realDamage = DamageLevel * theDamage;
        Theenemy.GetDamage(realDamage);
    }
}
