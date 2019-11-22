using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStats : MonoBehaviour, IDamagable
{
    public int health;
    public int damage;


    private void Update()
    {
        if(health <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        
        gameObject.SetActive(false);
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
