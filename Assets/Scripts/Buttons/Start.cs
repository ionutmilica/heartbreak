using UnityEngine;

public class Start : MonoBehaviour {

	void OnGUI()
	{
		if (GUI.Button(new Rect (270, 270, 80, 30), "Start"))
        {
			Application.LoadLevel(1);
        }
	}
}
