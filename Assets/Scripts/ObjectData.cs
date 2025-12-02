using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData
{
    public Vector3 position;
    public Vector3 velocity;

    public ObjectData(Vector3 position, Vector3 velocity ) 
    {
        this.position = position;
        this.velocity = velocity;
    }
}
