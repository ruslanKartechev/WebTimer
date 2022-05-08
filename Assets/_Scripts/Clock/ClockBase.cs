using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockApplication
{
    public abstract class ClockBase : MonoBehaviour
    {
        [SerializeField] protected TimerUIChannelSO _channelUI;
        protected TimeData _currentData;
        public TimeData CurrentDateTime { get { return _currentData; } }
        public abstract void Enable();
        public abstract void Disable();
    }
}