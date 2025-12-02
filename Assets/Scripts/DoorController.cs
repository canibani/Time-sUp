using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool isOpen = false;
    private bool permanentlyOpen = false;
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    [SerializeField] private GameObject leftDoorOpen;
    [SerializeField] private GameObject rightDoorOpen;

    private Vector3 leftDoorClosed;
    private Vector3 rightDoorClosed;
    
    [SerializeField] private int doorOpenTime;
    private const float doorSpeed = 0.001f;
    
    private void Awake() {
        leftDoorClosed = leftDoor.transform.localPosition;
        rightDoorClosed = rightDoor.transform.localPosition;
    }
    void Start()
    { 
        OpenDoor();
    }

    public void OpenDoor() {
        StartCoroutine(Opening());
    }

    public IEnumerator Opening() {
        while(!isOpen) {
            // Do open door and once it is open set isOpen to true
            leftDoor.transform.localPosition = Vector3.MoveTowards(leftDoor.transform.localPosition, leftDoorOpen.transform.localPosition, doorSpeed);
            rightDoor.transform.localPosition = Vector3.MoveTowards(rightDoor.transform.localPosition, rightDoorOpen.transform.localPosition, doorSpeed);
            if (leftDoor.transform.localPosition.x == leftDoorOpen.transform.localPosition.x && rightDoorOpen.transform.localPosition.x == rightDoor.transform.localPosition.x) {
                isOpen = true;
            }

            yield return null;
        }

        yield return new WaitForSeconds(doorOpenTime);
        
        StartCoroutine(Closing());
    }

    IEnumerator Closing() {
        if (permanentlyOpen) {
            yield break;
        }
        while(isOpen) 
        {
            // Do close door and once it is open set isOpen to false
            leftDoor.transform.localPosition = Vector3.MoveTowards(leftDoor.transform.localPosition, leftDoorClosed, doorSpeed);
            rightDoor.transform.localPosition = Vector3.MoveTowards(rightDoor.transform.localPosition, rightDoorClosed, doorSpeed);
            if (leftDoor.transform.localPosition.x == leftDoorClosed.x && rightDoorClosed.x == rightDoor.transform.localPosition.x) {
                isOpen = false;
            }
            yield return null;
        }
    }

    public void PermanentlyOpenDoor() {
        permanentlyOpen = true;
        StartCoroutine(Opening());
    }
}
