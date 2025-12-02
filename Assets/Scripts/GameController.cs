using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool selectionMode = false; // At the moment the game only has 2 states.

    public bool ToggleUI() 
    {
        selectionMode = !selectionMode;
        return true; // Return toggleFinished, added this to add delay to the toggle later.
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
