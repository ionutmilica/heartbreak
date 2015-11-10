using UnityEngine;

public class EasyMove : MonoBehaviour {

    private bool gotThere = false;
    private float move = 0.05f;
	private float positionTo;
	private float positionFrom;

	void Start()
    {
		positionFrom = transform.position.x;
		positionTo = transform.position.x + 4;
	}

	void Update()
    {
		if (transform.position.x < positionTo && ! gotThere)
        {    
			transform.position = new Vector2(transform.position.x + move, transform.position.y);

            if (transform.position.x >= positionTo)
            {
				gotThere = true;
			}
		}
        else if(transform.position.x > positionFrom && gotThere)
        {
			transform.position = new Vector2(transform.position.x - move, transform.position.y);

            if (transform.position.x <= positionFrom)
            {
				gotThere = false;
			}
		}
	}

}
