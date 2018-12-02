using UnityEngine;
using System.Collections;
using Assets.GameObjects.Weapons;
using Assets.Controllers;
using System;

namespace Assets.GameObjects.Heroes
{
    public class HeroNearFieldAttack : NearFieldAttack
    {

        private InputController inputController;

        private void Start()
        {
            inputController = InputManager.GetComponent<InputController>();
            if (inputController == null)
            {
                Debug.LogError("GameObject does not contain inputController");
            }
            inputController.Shoot += Attack;
        }

        public void Attack()
        {
            Timer += Time.deltaTime;

            if (Timer >= AttackRate)
            {
                NearFieldAttack();
            }
        }

        private void NearFieldAttack()
        {
            throw new NotImplementedException();
        }

    }
}
