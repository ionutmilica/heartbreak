using UnityEngine;

public class CameraRun : MonoBehaviour
{
    public Transform player;

	void OnTriggerEnter2D(Collider2D other)
    {
		transform.position = new Vector3(0, 0, -10);
	}

	void Update () 
	{
		transform.position = new Vector3(player.position.x, player.position.y, -10);
	}

}
