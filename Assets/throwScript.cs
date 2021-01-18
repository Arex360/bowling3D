using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwScript : MonoBehaviour
{
   public Transform target;
   public Rigidbody ball;
   public float throwSpeed;

   public GameObject mainCam;
   public GameObject throwCam;
 
   Vector3 direction;
   public bool isthrown;
   private void Start() {
       isthrown = false;
      
   }
   private void FixedUpdate() {
       direction = (target.position - ball.position).normalized;
       if(Input.GetMouseButtonDown(0)&& !isthrown){
           ball.useGravity = true;
           
           ball.AddForce(direction * throwSpeed * Time.fixedDeltaTime,ForceMode.Impulse);
           isthrown = true;
       }
       if(isthrown){
           mainCam.SetActive(false);
           throwCam.SetActive(true);
       }else{
           mainCam.SetActive(true);
           throwCam.SetActive(false);
       }
   }
   
 }

