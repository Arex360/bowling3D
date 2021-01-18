using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    public Transform ball;
    public Vector3 offset;
    public float followSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(ball.position.y);
        if(ball.position.y > -0.9f){
            Vector3 pos = Vector3.Lerp(this.transform.position, ball.position + offset,followSpeed * Time.deltaTime);
            this.transform.position = pos;
        }
    }
}
