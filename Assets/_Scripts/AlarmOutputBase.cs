using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockApplication
{
    public abstract class AlarmOutputBase : MonoBehaviour
    {
        public abstract void ShowAlarmData(TimeData data);

    }
}