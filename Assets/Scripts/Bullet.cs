using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   // private float bulletSpeed = 40f;
   // private Rigidbody rb;

   [SerializeField] private ParticleSystem destroyEffect;


   
   void Start()
   {
       
   }
    
    void Update()
    {
      //  Destroy(this.gameObject,5f);
         
        
    }

    
    void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.CompareTag("Obstacle"))
       {
         Color otherColor = other.gameObject.GetComponent<Renderer>().material.color;

         if(this.GetComponent<Renderer>().sharedMaterial.color == otherColor)
         {
           ParticleSystem particle = Instantiate(destroyEffect,other.transform.position,Quaternion.identity);
           Destroy(particle,0.25f);
           Destroy(other.gameObject,0.25f);
         }

         else
         {
           other.gameObject.transform.localScale *= 1.5f;

         }
       }
        
        
      Destroy(this.gameObject,2f);
        
    }


   
}
