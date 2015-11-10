using UnityEngine;
using HeartBreak;

namespace Mechanics
{
    public class Die : MonoBehaviour
    {
        private Player player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player" && ! player.isImmortal)
            {
                AudioSource audio = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>();

                if (audio)
                {
                    audio.Stop();
                }

                GameManager.points = 0;
                GameManager.level = 1;
                Application.LoadLevel(2);
            }
        }

    }
}
