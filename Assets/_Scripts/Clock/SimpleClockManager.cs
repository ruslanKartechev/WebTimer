using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace ClockApplication
{
    public class SimpleClockManager : ClockBase
    {
        [SerializeField] protected TimeCorrecter _timeCorrecter;
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
            while (true)
            {
                TimeSpan t = TimeSpan.FromSeconds(time);
                _currentData.Hours = t.Hours;
                _currentData.Minutes = t.Minutes;
                _currentData.Seconds = t.Seconds;
                time += Time.deltaTime;
                _channelUI?.RaiseUpdateView(_currentData);
                yield return null;
            }
        }


    }
}