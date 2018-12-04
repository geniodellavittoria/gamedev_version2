using System;
using Assets.GameObjects.Characters;
using UnityEngine;

namespace Assets.GameObjects.Grounds
{
    public class GripGround : Ground
    {
        [SerializeField]
        private int gripValue = 1;

        private int multiplicator = 10000;

        private Rigidbody2D rb2d;
        private float defaultVelocity;

        private void Start()
        {
            Nature = GroundNature.Slippery;
            Value = gripValue;
            rb2d = Hero.GetComponent<Rigidbody2D>();
            defaultVelocity = rb2d.velocity.magnitude;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);
            if (HeroOnGround)
            {
                base.OnCollisionEnter2D(collision);
                Hero.GetComponent<ScriptableCharacter>().Speed = Hero.GetComponent<ScriptableCharacter>().Speed / 2;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {

            if (collision.gameObject.CompareTag("hero"))
            {
                //rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * rb2d.velocity.magnitude, rb2d.velocity.y);
                Hero.GetComponent<ScriptableCharacter>().Speed = Hero.GetComponent<ScriptableCharacter>().Speed * 2;
                rb2d.AddForce(Vector2.up * Hero.GetComponent<ScriptableCharacter>().Jumping);
                //rb2d.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }
    }
}
