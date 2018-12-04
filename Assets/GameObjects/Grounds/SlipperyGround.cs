using System;
using Assets.GameObjects.Characters;
using UnityEngine;

namespace Assets.GameObjects.Grounds
{
    public class SlipperyGround : Ground
    {
        [SerializeField]
        private int slipperyValue = 1;

        private Rigidbody2D rb2d;
        private Vector2 defaultVelocity;

        private void Start()
        {
            Nature = GroundNature.Slippery;
            Value = slipperyValue;
            rb2d = Hero.GetComponent<Rigidbody2D>();
            defaultVelocity = rb2d.velocity;

        }

        private void Update()
        {
            if (HeroOnGround)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                //float moveVertical = Input.GetAxis("Vertical");
                //print(moveHorizontal);
                //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                rb2d.velocity += Vector2.down * slipperyValue * moveHorizontal;
                //Hero.GetComponent<Rigidbody2D>().AddForce(new Vector2(slipperyValue * 50 * moveHorizontal * Hero.GetComponent<ScriptableCharacter>().Speed * Time.deltaTime, rb2d.velocity.y));
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("hero"))
            {
                rb2d.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }
    }
}
