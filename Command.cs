using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts
{
  public class Command : MonoBehaviour, ICommand
  {
    [SerializeField]
    private KeyCode keyCode = KeyCode.None;
    [SerializeField]
    private bool eventDriven = false;
    [SerializeField]
    private string eventTrigger = null;
    [SerializeField]
    private string eventToFire = null;

    protected DesktopCommander commander;
    protected virtual void Start ()
    {
      FindInput();
      MapKeyCode();
    }

    void Awake()
    {
      StartListening();
    }

    void OnDestroy()
    {
      StopListenting();
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

    public virtual void Execute() {}

    protected string FireEvent () {
      if (eventToFire == null) return null;

      Debug.Log(eventToFire);
      EventManager.TriggerEvent(eventToFire);
      return eventToFire;
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
}