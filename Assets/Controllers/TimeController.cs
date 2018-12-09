using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Controllers
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField]
        private Text timeText;


        private string minutes;
        private string seconds;

        private float timer;

        private void Update()
        {
            timer += Time.deltaTime;

            minutes = Mathf.Floor(timer / 60).ToString("00");
            seconds = (timer % 60).ToString("00");

            ShowText();
        }

        private void ShowText()
        {
            timeText.text = string.Format("{0}:{1}", minutes, seconds);
        }

        public void ReduceSeconds(int sec)
        {
            timer -= sec;
        }

        public void AddSeconds(int sec)
        {
            timer += sec;
        }
        
        public float GetTimer()
        {
            return this.timer;
        }
    }
}
