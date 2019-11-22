using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public GameObject explosionEffect;
    public GameObject explosionZone;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<IDamagable>() != null)
        {
            DoDamage(collision.gameObject);
        }
        else
        {
            Explosion();
        }
    }

    private void DoDamage(GameObject target)
    {

    }
    private void Explosion()
    {
        GameObject temp = Instantiate(explosionEffect);
        GameObject eTemp = Instantiate(explosionZone);
        eTemp.transform.position = transform.position;
        temp.transform.position = transform.position;
        eTemp.GetComponent<ExplosionZone>().damage = damage;

        Destroy(temp, 1.0f);
        Destroy(eTemp, 0.2f);
        Destroy(gameObject);
        
    }


}
