using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeObjectController : MonoBehaviour
{
    private const int maxNumberOfFrames = 10000;
    public LinkedList<ObjectData> objectRecording;
    public Renderer renderer;
    public Rigidbody rigidbody;
    public TimeOptionsEnum? lastStateEnum = TimeOptionsEnum.NORMAL;
    private ObjectData objectData;
    public bool selectionMode;

    private void Awake() {
        objectRecording = new LinkedList<ObjectData>();
        rigidbody = transform.GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
    }

    public virtual void Play() 
    {
    }

    public void Record()
    {
        objectRecording.AddLast(new ObjectData(transform.position, rigidbody.velocity));
        if (objectRecording.Count == maxNumberOfFrames)
        {
            objectRecording.RemoveFirst();
        }
    }

    public void Rewind() 
    {
        if (objectRecording.Count < 1) {
            return;
        }

        ObjectData objectData = objectRecording.Last.Value;
        transform.position = objectData.position;
        rigidbody.velocity = objectData.velocity;
        objectRecording.RemoveLast();
        if (objectRecording.Count == 0)
        {
            return;
        }
    }

    public void Pause() 
    {
        rigidbody.Sleep();
    }

    public void Resume() 
    {
        // transform.position = objectData.position;
        rigidbody.velocity = objectData.velocity;
        //rigidbody.WakeUp();
    }

    public void SetSelectionMode(bool selectionMode)
    {
        this.selectionMode = selectionMode;
    }

    public void StoreObjectData() 
    {
        objectData = new ObjectData(transform.position, rigidbody.velocity);
    }
}
