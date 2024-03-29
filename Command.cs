using UnityEngine;

public class Command : MonoBehaviour, ICommand
{
  [SerializeField]
  protected KeyCode keyCode = KeyCode.None;
  [SerializeField]
  private bool eventDriven = false;
  [SerializeField]
  private string eventTrigger = null;
  [SerializeField]
  private string eventToFire = null;
  [SerializeField]
  private ActivationType activationType = ActivationType.keyPress;

  public bool disabledOnKeyUp = false;

  protected DesktopCommander commander;
  protected virtual void Start ()
  {
    FindInput();
    MapKeyCode();
  }

  protected virtual void After () {}

  void Awake()
  {
    StartListening();
  }

  void OnDestroy()
  {
    StopListenting();
  }

  void Update() {
    if (disabledOnKeyUp) {
      if (Input.GetKeyUp(keyCode)) {
        After();
      }
    }
  }

  public virtual void Execute() {}

  public ActivationType ActivationType {
    get {
      return this.activationType;
    }
  }

  protected string FireEvent () {
    if (eventToFire != null) EventManager.TriggerEvent(eventToFire);
    return eventToFire;
  }

  private void FindInput()
  {
    GameObject input = GameObject.Find("Input");
    if (input != null) {
      commander = input.GetComponent<DesktopCommander>();
    } else {
      Debug.LogWarning("No input component found.");
    }
  }

  private void MapKeyCode ()
  {
    if (keyCode != KeyCode.None) {
      commander.CommandMap.Add(keyCode, this);
    }
  }

  private void StartListening ()
  {
    if (eventDriven && eventTrigger != null) EventManager.StartListening(eventTrigger, Execute);
  }

  private void StopListenting ()
  {
    if (eventDriven && eventTrigger != null) {
      EventManager.StopListening(eventTrigger, Execute);
    }
  }
}