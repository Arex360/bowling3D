using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageSystem : MonoBehaviour
{
      public float velocity;
     public float expectedForce;

     
    public float radius;
    public float force;

    private Rigidbody ball;
    void Start()
    {
        ball = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
       if(other.transform.CompareTag("Respawn")){
           Collider[] colliders = Physics.OverlapSphere(ball.position, radius);
           foreach(Collider hit in colliders){
           Rigidbody temp = hit.GetComponent<Rigidbody>();
           temp.AddExplosionForce(ball.velocity.magnitude * force,ball.position,radius);
           print(hit.name);
       }
    }
   }
}
