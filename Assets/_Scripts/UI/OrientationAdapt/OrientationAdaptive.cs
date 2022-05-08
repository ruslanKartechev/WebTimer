
using UnityEngine ;
namespace UIAdapter
{
    public abstract class OrientationAdaptive : MonoBehaviour
    {
        public abstract void SavePortrait();
        public abstract void SaveLandscape();
        public abstract void LoadPortrait();
        public abstract void LoadLandscape();
    }
}