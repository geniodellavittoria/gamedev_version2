using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

namespace Assets.GameSceneUI
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField]
        private bool HorizontalMovement = true;

        [SerializeField]
        private float MovingDistance = 2f;

        [SerializeField]
        private float Speed = 1f;

        private Vector2 StartPosition;
        private Vector2 EndPosition;

        private Direction Direction;

        private bool Started = false;
        // Use this for initialization
        void Start()
        {
            Started = true;
            StartPosition = transform.position;
            if (HorizontalMovement)
            {
                EndPosition = new Vector2(transform.position.x + MovingDistance, transform.position.y);
                Direction = Direction.Right;
            }
            else
            {
                EndPosition = new Vector2(transform.position.x, transform.position.y + MovingDistance);
                Direction = Direction.Down;
            }
        }

        private void FixedUpdate()
        {
            if (Started)
            {

                if (HorizontalMovement)
                {
                    MoveHorizontally();

                }
                else
                {
                    MoveVertically();
                }

            }
        }

        private void OnBecameVisible()
        {
            Started = true;
        }

        private void MoveHorizontally()
        {
            var movingDistance = Vector2.right * Speed * Time.deltaTime;
            if (Direction == Direction.Right)
            {
                if (transform.position.x + movingDistance.x < EndPosition.x)
                {
                    transform.Translate(movingDistance);
                }
                else
                {
                    transform.position = EndPosition;
                    Direction = DirectionMethods.ReverseDirection(Direction);
                }
            }
            else
            {
                if (transform.position.x + movingDistance.x > StartPosition.x)
                {
                    transform.Translate(-movingDistance);
                }
                else
                {
                    transform.position = StartPosition;
                    Direction = DirectionMethods.ReverseDirection(Direction);
                }
            }
        }

        private void MoveVertically()
        {
            var movingDistance = Vector2.up * Speed * Time.deltaTime;
            if (Direction == Direction.Up)
            {
                if (transform.position.y + movingDistance.y < EndPosition.y)
                {
                    transform.Translate(movingDistance);
                }
                else
                {
                    transform.position = EndPosition;
                    Direction = DirectionMethods.ReverseDirection(Direction);
                }
            }
            else
            {
                if (transform.position.y + movingDistance.y > StartPosition.y)
                {
                    transform.Translate(-movingDistance);
                }
                else
                {
                    transform.position = StartPosition;
                    Direction = DirectionMethods.ReverseDirection(Direction);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("hero"))
            {
                col.gameObject.transform.parent = transform;
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("hero"))
            {
                col.gameObject.transform.parent = null;
            }
        }
    }
}
