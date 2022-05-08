using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockApplication
{
    public class DebugAlarmEffect : AlarmEffectBase
    {
        public override void ShowAlarmEffect(string time)
        {
            Debug.Log($"ALLLLARRRRRMM: {time}");
        }
    }
}