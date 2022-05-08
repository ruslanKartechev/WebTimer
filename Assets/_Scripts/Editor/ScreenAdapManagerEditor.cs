using UnityEditor;
using UnityEngine;

namespace UIAdapter
{
    [CustomEditor(typeof(ScreenAdapManager))]
    public class ScreenAdapManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ScreenAdapManager me = target as ScreenAdapManager;
            if (GUILayout.Button("GetAdapters"))
            {
                me.GetAdapters();
            }
            GUILayout.Space(20);


            GUILayout.BeginHorizontal();
            if (GUILayout.Button("LoadPortrait"))
            {
                me.LoadPortrait();
            }
            if (GUILayout.Button("LoadLandscape"))
            {
                me.LoadLandscape();
            }
            GUILayout.EndHorizontal();

            GUILayout.Space(20);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("SavePortrait"))
            {
                me.SavePortrait();
            }
            if (GUILayout.Button("SaveLandscape"))
            {
                me.SaveLandscape();
            }
            GUILayout.EndHorizontal();
        }
    }
}