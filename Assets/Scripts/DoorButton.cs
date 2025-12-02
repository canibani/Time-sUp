using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject gate;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Sphere") {
            gate.GetComponent<DoorController>().PermanentlyOpenDoor();
        }
    }
}
