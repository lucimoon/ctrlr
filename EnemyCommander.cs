using UnityEngine;
using System.Collections.Generic;

namespace tardigrage_alpha.Assets.Scripts
{
  [RequireComponent(typeof(TDDown))]
  [RequireComponent(typeof(TDUp))]
  [RequireComponent(typeof(TDLeft))]
  [RequireComponent(typeof(TDRight))]
  public class EnemyCommander : MonoBehaviour
  {
    public enum EnemyCommand {
      up,
      down,
      left,
      right,
      fire
    }
    public Dictionary<EnemyCommand, ICommand> CommandMap = new Dictionary<EnemyCommand, ICommand>();

    public EnemyCommand command;

    private void Start()
    {
      CommandMap.Add(EnemyCommand.left, GetComponent<TDLeft>());
      CommandMap.Add(EnemyCommand.down, GetComponent<TDDown>());
      CommandMap.Add(EnemyCommand.up, GetComponent<TDUp>());
      CommandMap.Add(EnemyCommand.right, GetComponent<TDRight>());
      CommandMap.Add(EnemyCommand.fire, GetComponentsInChildren<Fire>()[0]);
    }

    void Update()
    {
      DecideWhatToDo();
    }

    void OnBecameInvisible()
    {
      gameObject.SetActive(false);
    }

    private void DecideWhatToDo ()
    {
      CommandMap[command].Execute();
      CommandMap[EnemyCommand.fire].Execute();
    }
  }
}