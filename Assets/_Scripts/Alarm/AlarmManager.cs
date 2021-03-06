using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace ClockApplication
{
    public class AlarmManager : AlarmBase
    {
        public event Action OnAlarmFire;
        [SerializeField] private AlarmDataSo _alarmSO;
        [Space(10)]
        [SerializeField] private ClockBase _clock;
        [Space(10)]
        [SerializeField] private AlarmOutputBase _output;
        [SerializeField] private AlarmEffectBase _effect;

        private Coroutine _alarmCheck;

        private void Start()
        { 
            if(_clock != null)
            {
                StartAlarmCheck();
            }
            _output.ShowAlarmData(_alarmSO.Data);

        }

        public override void StartAlarmCheck()
        {
            if (_alarmCheck != null)
                StopCoroutine(_alarmCheck);
            _alarmCheck = StartCoroutine(AlarmCheck());
        }
        public override void StopAlarmCheck()
        {
            if (_alarmCheck != null)
                StopCoroutine(_alarmCheck);
            
        }


        public override void SubscribeToAlarm(Action subscriber)
        {
            OnAlarmFire += subscriber;
        }

        private IEnumerator AlarmCheck()
        {
            while (true)
            {
                if (_alarmSO.IsActive)
                {
                    TimeData data = _clock.CurrentDateTime;
                    if (data.Hours == _alarmSO.Data.Hours)
                    {
                        if (data.Minutes == _alarmSO.Data.Minutes)
                        {
                            if (data.Seconds >= _alarmSO.Data.Seconds)
                            {
                                FireAlarm();
                                _alarmSO.IsActive = false;
                                _alarmCheck = null;
                                yield break;
                            }
                        }
                    }
                }

                yield return null;
            }
        }

        public void FireAlarm()
        {
            OnAlarmFire?.Invoke();
            _effect?.ShowAlarmEffect($"{_alarmSO.Data.Hours}: {_alarmSO.Data.Minutes}: {_alarmSO.Data.Seconds}");
        }

        public override void SetAlarm(TimeData data)
        {
            _alarmSO.Data = data;
            _alarmSO.IsActive = true;
            _output.ShowAlarmData(data);
        }
        

    }
}