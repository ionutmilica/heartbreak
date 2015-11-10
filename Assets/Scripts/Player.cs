using UnityEngine;
using System.Collections;
using HeartBreak;

public class Player : MonoBehaviour {

    public int playerLife = 3;
	public Sprite lifeEmpty;
	public bool isImmortal = false;

	private Rigidbody2D rb2d;

	void Start ()
    {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if (isImmortal)
        {
            return;
        }

        if (playerLife < 1)
        {
			GetComponent<AudioSource>().Stop();

			GameManager.points = 0;
			GameManager.level = 1;
			Application.LoadLevel(2);
		}
	}
	
	public void DecreaseLife(int x)
	{
		playerLife -= x;

		if (playerLife == 2)
			GameObject.Find ("life3").GetComponent<SpriteRenderer>().sprite = lifeEmpty;
		if (playerLife == 1)
			GameObject.Find ("life2").GetComponent<SpriteRenderer>().sprite = lifeEmpty;
		if (playerLife == 0)
			GameObject.Find ("life1").GetComponent<SpriteRenderer>().sprite = lifeEmpty;
	}
	
	void OnDisable()
	{
		PlayerPrefs.SetInt ("Life", playerLife);
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect (510, 8, 100, 30), "Score: " + GameManager.points);
		GUI.Label(new Rect (410, 8, 100, 30), "Level: " + GameManager.level);
	}

	public void win()
	{
		GameManager.level += 1;
		Application.LoadLevel (1);
	}

	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
	{
		float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            Vector2 force = -rb2d.velocity.normalized * knockbackPwr;

            if (force.y.Equals(0.0f))
            {
                force.y = 6.0f;
            }

			rb2d.AddForce(new Vector3(force.x * 2, force.y, transform.position.z), ForceMode2D.Impulse);
		}

		yield return 0;
		
	}

}
