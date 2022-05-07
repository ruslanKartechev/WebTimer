using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ClockApplication
{
    public class TimerController : MonoBehaviour
    {
        public ClockBase Manager;
        private void OnEnable()
        {
            Manager.Enable();
        }
        private void OnDisable()
        {
            Manager.Disable();
        }
    }
}