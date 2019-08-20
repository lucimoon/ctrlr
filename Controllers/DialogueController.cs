using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
  public Text dialogue;

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }

  public void Talk() {
    Debug.Log("talking");
    dialogue.text = @"My package was supposedly delivered today,
but I haven't seen it. Can you let me know if you
see it? Don't open it!!!";

    EventManager.TriggerEvent("enter-dialogue");
    EventManager.TriggerEvent("neighbor-interaction");
  }

  public void ExitDialogue() {
    EventManager.TriggerEvent("exit-dialogue");
  }
}
