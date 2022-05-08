using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockApplication
{
    public abstract class AlarmEffectBase : MonoBehaviour
    {
        public abstract void ShowAlarmEffect(string time);
    }
}