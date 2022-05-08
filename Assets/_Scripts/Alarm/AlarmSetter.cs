using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ClockApplication
{
    public class AlarmSetter : MonoBehaviour
    {
        [SerializeField] private ValueSetBlock HH;
        [SerializeField] private ValueSetBlock MM;
        [SerializeField] private ValueSetBlock SS;


        [SerializeField] private Button _setButton;
        [SerializeField] private AlarmBase _alarm;

        private void OnEnable()
        {
            _setButton.onClick.AddListener(SetAlarm);
        }
        private void OnDisable()
        {
            _setButton.onClick.RemoveListener(SetAlarm);
        }
        public void SetAlarm()
        {
            TimeData data = new TimeData();
            data.Hours = HH.CurrentValue;
            data.Minutes = MM.CurrentValue;
            data.Seconds = SS.CurrentValue;

            _alarm.SetAlarm(data);
            _alarm.StartAlarmCheck();
        }

    }
}