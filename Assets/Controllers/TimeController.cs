using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Controllers
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField]
        private Text timeText;

        [SerializeField]
        private float startMinutes;

        [SerializeField]
        private float startSeconds;

        private string minutes;
        private string seconds;

        private float timer;

        private void Start()
        {
            minutes = startMinutes.ToString("00");
            seconds = startSeconds.ToString("00");
            timer = startMinutes * 60 + startSeconds;
        }

        private void Update()
        {
            timer -= Time.deltaTime;

            if (seconds == "00" && minutes == "00")
            {
                print("GameOver");
            }
            else
            {
                minutes = Mathf.Floor(timer / 60).ToString("00");
                seconds = (timer % 60).ToString("00");
            }

            ShowText();
        }

        public void ShowText()
        {
            timeText.text = GetTimerText();
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

        public string GetTimerText()
        {
            return string.Format("{0}:{1}", minutes, seconds); ;
        }
    }
}
