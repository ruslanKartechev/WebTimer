using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace ClockApplication {
    public class TimeCorrecter : ScriptableObject
    {
        public virtual void GetCorrectTime(Action<TimeData> reciver)
        {
            
        }
    }
}