using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
  private Canvas canvas;

  void Awake() {
    canvas = GetComponent<Canvas>();
  }

  public void ToggleUI () {
    canvas.enabled = !canvas.enabled;
  }

  public void EnableUI () {
    canvas.enabled = true;
  }

  public void DisableUI () {
    canvas.enabled = false;
  }

}