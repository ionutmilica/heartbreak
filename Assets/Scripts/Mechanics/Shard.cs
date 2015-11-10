using UnityEngine;

namespace Mechanics
{
    public class Shard : MonoBehaviour
    {
        private float nextActionTime = 0.0f;
        private int state = 0;
        public float period = 0.1f;

        private Player player;
        private bool isWinner = false;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if ( ! isWinner)
            {
                player.win();
            }

            isWinner = true;
        }

        void Update()
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                Vector3 v = transform.position;

                if (state == 0)
                {
                    v.y -= 3;
                    state = 1;
                }
                else if (state == 1)
                {
                    v.y += 3;
                    state = 0;
                }

                transform.position = Vector3.Lerp(transform.position, v, Time.deltaTime * 1);
            }
        }

    }

}
