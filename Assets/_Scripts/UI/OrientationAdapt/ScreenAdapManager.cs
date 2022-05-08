using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace UIAdapter {
    public class ScreenAdapManager : MonoBehaviour
    {
       [SerializeField]  private List<OrientationAdaptive> _adapters = new List<OrientationAdaptive>();
        public bool DoAdapt = true;
        private Coroutine _oritationCheck;
        private char _current = 'n';
        void Start()
        {
            GetAdapters();
            if(DoAdapt == true)
            {
                _oritationCheck = StartCoroutine(CheckForChange());
            }
        }
        public void GetAdapters()
        {
            _adapters = new List<OrientationAdaptive>();
            var list = GameObject.FindObjectsOfType<OrientationAdaptive>();
            foreach(OrientationAdaptive adp in list)
            {
                _adapters.Add(adp);
            }
        }

        public void SavePortrait()
        {
            foreach (OrientationAdaptive adp in _adapters)
            {
                adp?.SavePortrait();
            }
        }

        public void SaveLandscape()
        {
            foreach (OrientationAdaptive adp in _adapters)
            {
                adp.SaveLandscape();
            }
        }

        public void LoadLandscape()
        {
            foreach (OrientationAdaptive adp in _adapters)
            {
                adp?.LoadLandscape();
            }
        }
        public void LoadPortrait()
        {
            foreach (OrientationAdaptive adp in _adapters)
            {
                adp?.LoadPortrait();
            }
        }

        private IEnumerator CheckForChange()
        {
            while (true)
            {

                if (Screen.height > Screen.width)
                {
                    if (_current != 'P')
                    {
                        LoadPortrait();
                        _current = 'P';
                    }
                }
                else
                {
                    if (_current != 'L')
                    {
                        LoadLandscape();
                        _current = 'L';
                    }
                }

           
                yield return null;
            }

        }
    }
}