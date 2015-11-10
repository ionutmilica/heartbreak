using UnityEngine;
using System.Collections;

namespace Mechanics
{
    public class Damage : MonoBehaviour
    {

        private Player player;
        private float timeForEvent = 2.0f;
        private float nextTime = 0;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player" && Time.time > nextTime)
            {
                if (this.tag != "Enemy")
                {
                    player.DecreaseLife(1);
                    StartCoroutine(player.Knockback(0.017f, 20.0f, player.transform.position));
                    Destroy(this.gameObject);
                }
                else
                {
                    player.DecreaseLife(1);
                    StartCoroutine(player.Knockback(0.017f, 20.0f, player.transform.position));
                }

                other.GetComponent<Animation>().Play("Damage");

                nextTime = Time.time + timeForEvent;
            }
        }
    }
}
