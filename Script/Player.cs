using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variable
    public float movementSpeed;
    public GameObject camera;
    public GameObject PlayerObj;

    public GameObject bulletSpawnPoint;
    public float waitTime;
    public GameObject bullet;
    private Transform bulletSpawned;
    public float points;
    public float maxHealth;
    public float health;
    //Methods
    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {


        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;
        
        if(playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            PlayerObj.transform.rotation = Quaternion.Slerp(PlayerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }
        //Player Movement
        if(Input.GetKey(KeyCode.W))
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.A))
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.D))
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.S))
        transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);



        //Shootinng
        if(Input.GetKey(KeyCode.K))
        {
            Shoot();
        }
        if(health <= 0)
    {
        Die();
    }
    
    }

    void Shoot()
    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
    }

    public void Die()
    {   
        print("Dead");
    }


}
