using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIToggle))]

public class UIController : MonoBehaviour {

  public void ToggleUI () {
    if (gameObject.activeInHierarchy) {
      gameObject.SetActive(false);
    } else {
      gameObject.SetActive(true);
    }
  }

}