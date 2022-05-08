using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace ClockApplication
{
    public class SimpleClock : ClockBase
    {
        [SerializeField] protected TimeCorrecter _timeCorrecter;
        [Tooltip("Correct time from the web every")]
        [SerializeField] protected int _correctDelay = 3600;
        private Coroutine _timing;

        private void Awake()
        {
            if (_timeCorrecter == null)
                Debug.Log("Time Corrector was not assigned");
        }
        
        public override void Enable()
        {
            _timeCorrecter.GetCorrectTime(StartTiming);
        }
        public override void Disable()
        {
            if (_timing != null)
                StopCoroutine(_timing);
        }

        public void StartTiming(TimeData data)
        {
            _currentData = data;
            if (_timing != null)
                StopCoroutine(_timing);
            _timing = StartCoroutine(Timing());
        }

        private IEnumerator Timing()
        {
            float startTime = _currentData.Hours * 3600f + _currentData.Minutes * 60f + _currentData.Seconds * 1f;
            double time = startTime;
            float elapsed = 0;
            while (true)
            {
                TimeSpan t = TimeSpan.FromSeconds(time);
                _currentData.Hours = t.Hours;
                _currentData.Minutes = t.Minutes;
                _currentData.Seconds = t.Seconds;
                time += Time.deltaTime;
                elapsed += Time.deltaTime;
                if(elapsed >= _correctDelay)
                {
                    elapsed = 0;
                    RequestTime();
                }
                _channelUI?.RaiseUpdateView(_currentData);
                yield return null;
            }
        }

        private void RequestTime()
        {
            _timeCorrecter.GetCorrectTime(OnTimeResult);
        }

        private void OnTimeResult(TimeData data)
        {
            Debug.Log("requested to recorrect clock");
            _currentData = data;
            if (_timing != null)
                StopCoroutine(_timing);
            _timing = StartCoroutine(Timing());
        }

    }
}