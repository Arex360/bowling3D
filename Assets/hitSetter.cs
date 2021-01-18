using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitSetter : MonoBehaviour
{
    public bool isGrounded;
    private Vector3 position;
    private Quaternion rotation; 
    private Rigidbody rigidbody;


    void Start()
    {
        isGrounded = false;
        position = this.transform.position;
        rotation = this.transform.rotation;
        rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update() {
        float zaxis = Mathf.Abs(this.transform.localEulerAngles.z);
        if(zaxis > 90 && !isGrounded){
            gameManager.succesShots++;
            isGrounded = true;
            StartCoroutine(ResetTransform());
            gameManager.lastScore = gameManager.succesShots;
        }
    }
    private IEnumerator ResetTransform(){
        yield return new WaitForSeconds(1.2f);
        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
        this.transform.position = position;
        this.transform.rotation = rotation;
        isGrounded = false;
        yield return new WaitForSeconds(0.5f);
        rigidbody.isKinematic = false;
         gameManager.succesShots = 0;
    }
    public void resetPins(){
        StartCoroutine(ResetTransform());
        gameManager.succesShots = 0;
    }
}
