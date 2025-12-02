public class NormalState : TimeObjectState
{
    public override void Awake() {
        base.Awake();
        AddTransition<ObjectSelectionModeState>(() => timeObjectController.selectionMode == true);
    }

    public override void OnEnable() 
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        timeObjectController.lastStateEnum = TimeOptionsEnum.NORMAL;
    }

    public override void Update() {
        timeObjectController.Record();
    }

    private void FixedUpdate() {
        timeObjectController.Play();
    }
}
