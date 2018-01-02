using UnityEngine;

namespace tardigrage_alpha.Assets.Scripts.Ctrlr
{
    public class Command : MonoBehaviour
    {
        protected DesktopCommander commander;
        protected virtual void Start ()
        {
            GameObject input = GameObject.Find("DesktopInput");
            if (input != null) {
                Debug.Log("Input found.");
                commander = input.GetComponent<DesktopCommander>();
            } else {
                Debug.LogWarning("No input component found.");
            }
        }
    }
}