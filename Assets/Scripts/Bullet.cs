using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public GameObject explosionEffect;
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
        temp.transform.position = transform.position;

        Destroy(temp, 1.0f);
        Destroy(gameObject);
        
    }


}
