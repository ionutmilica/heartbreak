using UnityEngine;
using System.Collections;

namespace Mechanics
{
    public class Cloud : MonoBehaviour
    {
        public const float DisapearAfter = 0.7f;

        void Start()
        {
            // Called on initialization
        }

        void Update()
        {
            // Update is called once per frame
        }

        void OnCollisionEnter2D(Collision2D collider)
        {
            Destroy(this.gameObject, DisapearAfter);
        }
    }
}
