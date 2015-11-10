using UnityEngine;
using System.Collections;
using HeartBreak;

namespace Mechanics
{
    public class Mushroom : MonoBehaviour
    {
        private Player player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (Random.Range(0, 100) > 75)
            {
                player.DecreaseLife(1);
                Animation animation = other.GetComponent<Animation>();

                if (animation)
                {
                    animation.Play();
                }
            }
            else
            {
                GameManager.points += 50;
            }

            Destroy(this.gameObject);
        }

        void Update()
        {
            //
        }
    }

}
