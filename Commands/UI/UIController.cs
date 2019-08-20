using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
  private Canvas canvas;

  void Awake() {
    canvas = GetComponent<Canvas>();
  }

  public void ToggleUI () {
    if (canvas.enabled) {
      DisableUI();
    } else {
      EnableUI();
    }
  }

  public void EnableUI () {
    canvas.enabled = true;
    Time.timeScale = 0f;
  }

  public void DisableUI () {
    canvas.enabled = false;
    Time.timeScale = 1f;
  }
}