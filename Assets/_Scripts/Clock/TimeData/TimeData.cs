using System;
using UnityEngine;

namespace ClockApplication
{
    [System.Serializable]
    public struct TimeData
    {
        [Header("Date")]
        public int Year;
        public int Month;
        public int Day;
        [Header("Time")]
        public int Hours;
        public int Minutes;
        public int Seconds;

        public void ProcessResponse(string dateTime)
        {
            string[] parsed = dateTime.Split(new char[] { 'T' });
            string[] HHmmss = parsed[1].Split(new char[] { ':', '.' });
            Hours = Int16.Parse(HHmmss[0]);
            Minutes = Int16.Parse(HHmmss[1]);
            Seconds = Int16.Parse(HHmmss[2]);
        }
        public void DebugTime()
        {
            Debug.Log($"hh: {Hours}, mm {Minutes}, ss {Seconds}");
        }
    }
}
