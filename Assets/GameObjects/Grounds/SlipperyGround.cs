using System;
using Assets.Controllers;
using Assets.GameObjects.Characters;
using UnityEngine;

namespace Assets.GameObjects.Grounds
{
    public class SlipperyGround : Ground
    {
        [SerializeField]
        private int slipperyValue = 1;

        [SerializeField]
        private GameObject GameManager;

        private Rigidbody2D rb2d;
        private Vector2 defaultVelocity;

        private void Start()
        {
            GameManager.GetComponent<InputController>().Jump += Jump;
            Nature = GroundNature.Slippery;
            Value = slipperyValue;
            rb2d = Hero.GetComponent<Rigidbody2D>();
            defaultVelocity = rb2d.velocity;

        }

        void Jump()
        {
            if (HeroOnGround)
            {
                rb2d.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }


        private void FixedUpdate()
        {
            if (HeroOnGround)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                rb2d.velocity += Vector2.right * slipperyValue * moveHorizontal; // right as its vector is positive
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
