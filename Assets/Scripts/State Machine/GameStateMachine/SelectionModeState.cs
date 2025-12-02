using UnityEngine;

public class SelectionModeState : GameState
{
    public GameObject selectionModeUI;
    private GameObject[] timeObjects;

    public override void Awake() {
        base.Awake();
        AddTransition<StandardState>(() => !gameController.selectionMode);
        timeObjects = GameObject.FindGameObjectsWithTag("TimeObject");
    }
    public void Start() {
    }

    public override void OnEnable() 
    { 
        selectionModeUI.SetActive(true);
        gameController.PauseGame();
        ToggleSelectionMode(true);
    }

    public override void OnDisable() 
    {
        selectionModeUI.SetActive(false);
        ToggleSelectionMode(false);
        gameController.ResumeGame();
    }

    private void ToggleSelectionMode(bool setTo) 
    {
        foreach (GameObject timeObject in timeObjects)
        {
            TimeObjectController timeObjectController = timeObject.GetComponent<TimeObjectController>();
            timeObjectController.SetSelectionMode(setTo);
        }
    }
}

