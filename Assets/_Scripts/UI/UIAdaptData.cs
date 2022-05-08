using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
namespace UIAdapter
{
    [System.Serializable]
    public struct UIAdaptData
    {
        public Vector2 anchorMin;
        public Vector2 anchorMax;
        public Vector3 scale;
        public float zAngle;
        public Vector3 lcoalPos;
    }
}
