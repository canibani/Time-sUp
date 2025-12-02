using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSelector : MonoBehaviour
{
    List<Transform> options;

    Transform selected;

    public int selectedIndex;
    private int numberOfOptions;
    

    private void Awake() 
    {
        options = GetChildren();
        numberOfOptions = options.Count;   
        Select();
    }

    private void Update() {
        if (this.enabled) 
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
            {
                SelectNext();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
            {
                SelectPrevious();
            }
        }
    }

    private List<Transform> GetChildren() 
    {
        List<Transform> children = new List<Transform>();
        foreach(Transform child in transform) 
        {
            children.Add(child);
        }
        return children;
    }

    private void SelectNext() 
    {
        if(selectedIndex < numberOfOptions - 1) 
        { 
            selectedIndex++;
            Select(); 
        }
    }

    private void SelectPrevious() 
    {
        if (selectedIndex > 0) 
        { 
            selectedIndex--;
            Select();
        }
    }

    private void Select() 
    {
        if (selected) {
            selected.localScale = new Vector3(1.0f,1.0f,1.0f);
        }
        selected = options[selectedIndex];
        selected.localScale = new Vector3(1.5f,1.5f,1.5f);
    }

    public TimeOptionsEnum GetOption() 
    {
        return options[selectedIndex].GetComponent<Option>().timeOption;
    }
}
