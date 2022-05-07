using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ClockApplication
{
    public class AlarmTextOutput : AlarmOutputBase
    {
        [SerializeField] private TextMeshProUGUI _text;
        public override void ShowAlarmData(TimeData data)
        {
            Debug.Log("outputting data");
            _text.text = $"Next Alarm: {data.Hours}:{data.Minutes}:{data.Seconds}";
        }
    }
}