using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIToggle))]

public class UIController : MonoBehaviour {
  private Canvas canvas;

  void Awake() {
    canvas = GetComponent<Canvas>();
  }

  public void ToggleUI () {
    canvas.enabled = !canvas.enabled;
  }

}