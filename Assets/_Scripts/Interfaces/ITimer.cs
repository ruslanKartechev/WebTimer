using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockApplication
{
    public interface ITimer
    {
        TimeData GetCorrectTime();
    }
}