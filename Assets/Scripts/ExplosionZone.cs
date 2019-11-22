using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionZone : MonoBehaviour
{
    public int damage;
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null)
        {
            Vector3 ExplosionDirection = transform.position - other.transform.position;

            other.GetComponent<Rigidbody>().AddForce(-ExplosionDirection * 50);

            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IDamagable>() != null)
        {
            other.GetComponent<IDamagable>().TakeDamage(damage);
        }
    }
}
