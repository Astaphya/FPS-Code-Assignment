using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private float shootRange = 100f;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpeed = 40f;
    private Vector3 destination;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    public void Shoot()
    {
        RaycastHit hit;


        if(Physics.Raycast(cam.transform.position ,cam.transform.forward , out hit , shootRange))
        {
            Debug.Log(hit.transform.name);
            destination = hit.point;
        }

        else{
            destination = cam.transform.forward + bulletSpawnPoint.position;
        }

        GameObject bullet =  Instantiate(bulletPrefab,bulletSpawnPoint.position,Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = (destination - bulletSpawnPoint.position).normalized * bulletSpeed;

        
    }
}
