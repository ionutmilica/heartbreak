using UnityEngine;
using System.Collections;

namespace Animations
{
    public class Character : MonoBehaviour
    {
        public float maxSpeed = 6f;
        bool right = true;

        Animator anim;

        bool ground = false;
        float grRadius = 0.2f;
        public Transform grCheck;
        public LayerMask wtGround;
        public float jForce = 100f;

        void Start()
        {
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (ground && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Ground", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jForce));
            }
        }

        void FixedUpdate()
        {
            ground = Physics2D.OverlapCircle(grCheck.position, grRadius, wtGround);

            anim.SetBool("Ground", ground);
            anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<AudioSource>().Play();
            }

            float move = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", Mathf.Abs(move));
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if ((move > 0 && !right) || (move < 0 && right))
            {
                Flip();
            }
        }

        void Flip()
        {
            right = ! right;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
