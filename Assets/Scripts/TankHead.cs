using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHead : MonoBehaviour
{
    //Manual Reference 
    public GameObject tankBody;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    public TankStats tankStats;
    public float turnSpeed = 15;
    PlayerNumber mySpot;

    //Controls
    public string fireButton;

    //Values
    [Range(0,10000)]
    public float chargeRate = 1000;
    public float fireAmmount;

    private float previousX;
    private float previousY;

    private void Start()
    {
        
        tankStats = GetComponentInParent<TankStats>();
        mySpot = GetComponentInParent<PlayerController>().mySpot;
        if (mySpot == PlayerNumber.player1)
        {
            fireButton = "Fire1";
        }
        if(mySpot == PlayerNumber.player2)
        {
            fireButton = "Fire2";
        }
    }
    private void Update()
    {
        
        if (Input.GetButton(fireButton))
        {
            ChargeBullet();
        }
        if(Input.GetButtonUp(fireButton))
        {
            FireBullet();
        }
        TurnHead();
        
    }


    private void TurnHead()
    {
        if (mySpot == PlayerNumber.player1)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(mouseRay, out hit);
            Vector3 location = hit.point;
            float angle = Mathf.Atan2(location.x - transform.position.x, location.z - transform.position.z);
            angle = Mathf.Rad2Deg * angle;
            Quaternion targetRotation = Quaternion.Euler(tankBody.transform.eulerAngles.x, angle, tankBody.transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(tankBody.transform.eulerAngles.x, transform.eulerAngles.y, tankBody.transform.eulerAngles.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        }
        if(mySpot == PlayerNumber.player2)
        {
            float angle = Mathf.Atan2(GetComponentInParent<PlayerController>().inputManager.Player2Facing.x, GetComponentInParent<PlayerController>().inputManager.Player2Facing.y);
            angle = Mathf.Rad2Deg * angle;
            Quaternion targetRotation = Quaternion.Euler(tankBody.transform.eulerAngles.x, angle, tankBody.transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(tankBody.transform.eulerAngles.x,transform.eulerAngles.y, tankBody.transform.eulerAngles.z);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

    }

    //Fires bullet and stuff
    private void FireBullet()
    {
        GameObject temp = Instantiate(bullet);
        temp.GetComponent<Bullet>().myBody = GetComponentInParent<Collider>();
        temp.transform.position = bulletSpawnPoint.transform.position;
        temp.GetComponent<Bullet>().damage = tankStats.damage;
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * fireAmmount);
        fireAmmount = 0;
    }

    private void ChargeBullet()
    {
        
        float maxPower = 3000;
        if(fireAmmount < maxPower)
        {
            fireAmmount += chargeRate * Time.deltaTime;
        }
        
    }

    
}
