using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Vector2 inputs;
    private Vector3 position;
    public float speed;
    public List<Transform> constraints;
    public float sinAngle;
    void Start()
    {
        position = this.transform.position;
        print("debug");
    }

    // Update is called once per frame
    void Update()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = Input.GetAxis("Vertical");
        position = this.transform.localPosition;
        position.z = Mathf.Clamp(position.z, constraints[1].transform.localPosition.z, constraints[0].transform.localPosition.z);
        this.transform.localPosition = position;

        this.transform.Translate(new Vector3(inputs.y * speed * Time.deltaTime   ,0, -inputs.x * speed * Time.deltaTime+ Mathf.Sin(Time.time)/sinAngle));

    }
}
