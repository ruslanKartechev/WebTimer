using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace ClockApplication
{
    public abstract class AlarmBase : MonoBehaviour
    {

        public abstract void SetAlarm(TimeData data);
        public abstract void StartAlarmCheck();
        public abstract void StopAlarmCheck();
        public abstract void SubscribeToAlarm(Action subscriber);
    }
}