using UnityEngine;
using System.Collections;
using Assets.Controllers;

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

        protected new void Update()
        {
            if (Finished)
            {
                return;
            }
            Timer += Time.deltaTime;
            if (Triggered)
            {
                if (Timer <= Duration)
                {
                    Activate();
                    Timer = 0f;
                }
                else
                {
                    Deactivate();
                    Finished = true;
                }
            }
        }

        public virtual void Deactivate()
        {

        }

        private float GetDurationValue()
        {
            if (DurationValues != null)
            {
                var ran = Random.Range(0, durationValues.Length);
                return durationValues[ran];
            }
            return 0;
        }

    }
}
