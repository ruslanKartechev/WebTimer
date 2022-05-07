using UnityEditor;
using UnityEngine;

namespace ClockApplication
{
    [CustomEditor(typeof(WebTimeRequester))]
    public class TimeRequesterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            WebTimeRequester me = target as WebTimeRequester;

            if (GUILayout.Button("GetTime"))
            {
                me.GetCorrectTime(null);
            }
        }
    }
}