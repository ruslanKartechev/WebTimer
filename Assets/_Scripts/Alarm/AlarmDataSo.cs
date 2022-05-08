using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockApplication
{
    [CreateAssetMenu(fileName = "AlarmData", menuName = "SO/AlarmData", order = 0)]

    public class AlarmDataSo : ScriptableObject
    {
        public TimeData Data;

        public bool IsActive = true;
    }
}