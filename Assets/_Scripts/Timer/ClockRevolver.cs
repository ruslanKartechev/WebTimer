using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClockApplication
{
    [System.Serializable]
    public class ClockRevolver
    {
        [SerializeField] private float angleOffset = 90;
        [SerializeField] private Transform SecNeedle;
        [SerializeField] private Transform MinNeedle;
        [SerializeField] private Transform HourNeedle;

        public void UpdateTime(int seconds, int minutes, int hours)
        {
            float secAngle = -(6f * seconds) + 90;
            //Debug.Log($"sec angle {secAngle}");
            float minAngle = -(6f * minutes) + 90 - Mathf.Lerp(0f, 6f, (float)seconds / 60);
            float hourAngle = -(15 * hours) + 90 - Mathf.Lerp(0f, 15f, (float)minutes / 60);
            SetAngle(SecNeedle,secAngle);
            SetAngle(MinNeedle, minAngle);
            SetAngle(HourNeedle, hourAngle);

        }

        private void SetAngle(Transform target, float zAngle)
        {
            target.localEulerAngles = new Vector3(target.eulerAngles.x, target.eulerAngles.y, zAngle);
        }
    }
}