using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [MinAttribute(0)]
    public float mass;

    [MinAttribute(0)]
    public float radius;

    [MinAttribute(0)]
    public float angularMomentum;

    public float shapeConstant;

    private float momentOfInertia;
    
    [Header("Angular Velocity")]
    public float angularVelocity;

    public Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        if (shapeConstant == 0.0f)
        {
            shapeConstant = 1.0f;
        }
        momentOfInertia = shapeConstant * mass * radius * radius;
        angularVelocity = angularMomentum / momentOfInertia;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(scale.x * radius, transform.localScale.y, scale.z * radius);
        momentOfInertia = shapeConstant * mass * radius * radius;
        angularVelocity = angularMomentum / momentOfInertia;
        transform.Rotate(0.0f, angularVelocity * Time.deltaTime, 0.0f, Space.Self);
    }
}
