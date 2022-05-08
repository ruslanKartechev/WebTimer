using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UIAdapter
{
    public class OrientationAdapter : OrientationAdaptive
    {
        public UIAdaptData Portrait;
        public UIAdaptData Landscape;
        public override void LoadLandscape()
        {
            Load(Landscape);
        }

        public override void LoadPortrait()
        {
            Load(Portrait);
        }


        public override void SaveLandscape()
        {
            Landscape = SaveCurrent();

        }

        public override void SavePortrait()
        {
            Portrait = SaveCurrent();
        }

        public UIAdaptData SaveCurrent()
        {
            UIAdaptData data = new UIAdaptData();
            RectTransform t = gameObject.GetComponent<RectTransform>();
            data.anchorMin = t.anchorMin;
            data.anchorMax = t.anchorMax;
            data.scale = t.localScale;
            data.lcoalPos = t.localPosition;
            data.zAngle = t.eulerAngles.z;
            return data;
        }

        public void Load(UIAdaptData data)
        {
            RectTransform t = gameObject.GetComponent<RectTransform>();
            t.anchorMin = data.anchorMin;
            t.anchorMax = data.anchorMax;
            t.localPosition = data.lcoalPos;
            t.localScale = data.scale;
            t.eulerAngles = new Vector3(0, 0, data.zAngle);
        }
    }
}