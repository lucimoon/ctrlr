using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts.Ctrlr
{
  public class Command : MonoBehaviour, ICommand
  {
    [SerializeField]
    private KeyCode keyCode = KeyCode.None;
    protected DesktopCommander commander;
    protected virtual void Start ()
    {
      FindInput();
      MapKeyCode();
    }

    private void FindInput()
    {
      GameObject input = GameObject.Find("DesktopInput");
      if (input != null) {
        Debug.Log("Input found.");
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
  }
}