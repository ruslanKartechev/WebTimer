using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace ClockApplication
{
    [CreateAssetMenu(fileName = "TimerUIChannel", menuName = "SO/TimerUIChannel", order = 0)]
    public class TimerUIChannelSO : ScriptableObject
    {
        public Action<TimeData> UpdateView;

        public void RaiseUpdateView(TimeData data)
        {
            if(UpdateView != null)
            {
                UpdateView?.Invoke(data);
            }
            else
            {
                Debug.Log("UpdateView action not assigned");
            }
        }

    }
}