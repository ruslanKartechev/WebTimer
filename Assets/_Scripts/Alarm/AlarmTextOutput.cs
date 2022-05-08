using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ClockApplication
{
    public class AlarmTextOutput : AlarmOutputBase
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string OutputText = "Next Alarm:";
        public override void ShowAlarmData(TimeData data)
        {
            _text.text = $"{ OutputText}\n{data.Hours}:{data.Minutes}:{data.Seconds}";
        }
    }
}