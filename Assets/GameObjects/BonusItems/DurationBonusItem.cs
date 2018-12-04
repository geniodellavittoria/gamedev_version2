using UnityEngine;
using System.Collections;
using Assets.Controllers;
using System;

namespace Assets.GameObjects.BonusItems
{
    public class DurationBonusItem : BonusItem, IDurationBonusItem
    {
        private float duration;

        private float[] durationValues;

        private bool finished = false;

        public float Timer { get; set; }

        public float Duration
        {
            get
            {
                return duration;
            }

            set
            {
                duration = value;
            }
        }

        public float[] DurationValues
        {
            get
            {
                return durationValues;
            }

            set
            {
                durationValues = value;
            }
        }

        public bool Finished
        {
            get
            {
                return finished;
            }
            set
            {
                finished = value;
            }
        }

        protected new void Start()
        {
            base.Start();
            Duration = GetDurationValue();
        }

        protected void Update()
        {
            if (Finished)
            {
                return;
            }
            Timer += Time.deltaTime;
            if (Triggered && Duration <= Timer)
            {
                Deactivate();
                Finished = true;
            }
        }

        protected void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("hero") && !Triggered)
            {
                Timer = 0f;
                base.OnTriggerEnter2D(col);
            }
        }

        public virtual void Deactivate()
        {

        }

        private float GetDurationValue()
        {
            if (DurationValues != null)
            {
                var ran = UnityEngine.Random.Range(0, durationValues.Length);
                return durationValues[ran];
            }
            return 0;
        }

    }
}
