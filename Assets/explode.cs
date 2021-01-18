using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    [SerializeField,Header("Debugger")] private float velocity;
   
    [SerializeField] private float expectedForce;
    [Space]
    public float force;
    public float radius;

    private Rigidbody rigidbody;
    [SerializeField]private bool goldenShot;

    [Space, Header("Restart")]
    public Transform orientation;
    public throwScript controller;
    public GameObject pins;
    [Space]

    public GameObject pinsParent;
    private bool sucHit;

    void Start()
    {
        goldenShot = false;
        rigidbody = this.GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rigidbody.velocity.magnitude;
        expectedForce = velocity * force;
    }
    private void OnCollisionEnter(Collision other) {

        if(other.transform.CompareTag("goldenPin")){
            goldenShot = true;
        }
        if(other.transform.CompareTag("pin") || other.transform.CompareTag("goldenPin") ){
            Collider[] hits = Physics.OverlapSphere(rigidbody.position,!goldenShot? radius: (radius * 3f));
            List<Collider> pins = new List<Collider>();
            foreach(Collider pin in hits){
                if(pin.transform.CompareTag("pin")){
                    pins.Add(pin);
                     Rigidbody rb = pin.GetComponent<Rigidbody>();
                     rb.AddExplosionForce(!goldenShot? velocity * force:velocity * force * 2f, rigidbody.position,!goldenShot? radius: (radius * 4f));
                     sucHit = true;
                }
            }
         //   StartCoroutine(calculate(pins));
         StartCoroutine(restart());
        }
    }
    private IEnumerator calculate(List<Collider> colliders){
        yield return new WaitForSeconds(0.3f);
        foreach(Collider pin in colliders){
            Rigidbody rb = pin.GetComponent<Rigidbody>();
            StartCoroutine(checkOrienttaion(rb.transform));
        }
    }
   private IEnumerator checkOrienttaion(Transform body){
       yield return new WaitForSeconds(0.5f);
       float yaxis = Mathf.Abs(body.localEulerAngles.z);
       if(yaxis > 70){
           if(!body.GetComponent<hitSetter>().isGrounded){
               gameManager.succesShots++;
               body.GetComponent<hitSetter>().isGrounded = true;
               print(gameManager.succesShots);
           }
       }
   }

   private IEnumerator restart(){
       yield return new WaitForSeconds(1.2f);
       controller.isthrown = false;
       rigidbody.velocity = Vector3.zero;
       rigidbody.useGravity = false;
       rigidbody.position = orientation.position;
       rigidbody.rotation = orientation.rotation;
       sucHit = false;
   }
   private void OnTriggerEnter(Collider other) {
       if(other.CompareTag("dead")){
           StartCoroutine(restart());
           foreach(Transform pin in pinsParent.transform){
               if(pin.GetComponent<hitSetter>()){
                   hitSetter setter = pin.GetComponent<hitSetter>();
                   setter.resetPins();
               }
           }
           if(!sucHit){
                gameManager.succesShots = 0;
                gameManager.lastScore = 0;
           }
       }
   }
}
