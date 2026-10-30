using System;
using UnityEngine;

namespace DLLTimer
{
    public class Timer
    {
        public float timeLeft;
        public event Action TimesUp;

        public void StartTimer(float time)
        {
            timeLeft = time;
        }

        public void TimeRanOut()
        {
            TimesUp?.Invoke();
        }

        public float RaiseTimer(float increase)
        {
            timeLeft += increase;
            return timeLeft;
        }

        public float ReduceTimer(float decrease)
        {
            timeLeft -= decrease;
            if (timeLeft < 0)
            {
                TimeRanOut();
            }
            return timeLeft;
        }
    }
}