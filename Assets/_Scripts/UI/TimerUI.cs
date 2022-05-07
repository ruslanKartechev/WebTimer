using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace ClockApplication
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private TimerUIChannelSO _channel;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private ClockRevolver _revolver;
        private void Awake()
        {
            _channel.UpdateView = UpdateTime;
        }

        public void UpdateTime(TimeData data)
        {
            _timerText.text = $" {data.Hours} : {data.Minutes} : {data.Seconds}";
            _revolver?.UpdateTime(data.Seconds, data.Minutes, data.Hours);
        }



    }
}