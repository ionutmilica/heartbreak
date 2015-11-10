using UnityEngine;

namespace Buttons
{
    public class Door : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Application.LoadLevel(1);
            }
        }

        public void OnMouseDown()
        {
            Application.LoadLevel(1);
        }
    }
}
