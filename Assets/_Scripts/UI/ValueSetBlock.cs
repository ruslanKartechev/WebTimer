using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
namespace ClockApplication
{
    public class ValueSetBlock : MonoBehaviour
    {
        [SerializeField] private float _scrollSpeed;
        [Space(10)]
        [SerializeField] private int MaxValue = 60;
        [Space(10)]
        [SerializeField] private ProperButton _increase;
        [SerializeField] private ProperButton _decrease;
        [SerializeField] private TextMeshProUGUI _text;
        [Space(10)]
        public int CurrentValue = 0;
        private Coroutine _valueChanging;
        private void OnEnable()
        {
            _increase.OnDown += OnUpButton;
            _decrease.OnDown += OnDownButton;
            _increase.OnUp += OnButtonRelease;
            _decrease.OnUp += OnButtonRelease;
            OutputValue();
        }
        private void OnDisable()
        {
            _increase.OnDown -= OnUpButton;
            _decrease.OnDown -= OnDownButton;
            _increase.OnUp -= OnButtonRelease;
            _decrease.OnUp -= OnButtonRelease;
        }

        public void OnUpButton()
        {
            if (_valueChanging != null)
                StopCoroutine(_valueChanging);
            _valueChanging = StartCoroutine(ValueChange(1/ _scrollSpeed, IncreaseVal));
        }

        public void OnDownButton()
        {
            if (_valueChanging != null)
                StopCoroutine(_valueChanging);
            _valueChanging = StartCoroutine(ValueChange(1 / _scrollSpeed, DecreaseVal));
        }
        public void OnButtonRelease()
        {
            if (_valueChanging != null)
                StopCoroutine(_valueChanging);
        }


        private void IncreaseVal()
        {
            CurrentValue++;
            CurrentValue = (int)Mathf.Repeat(CurrentValue, MaxValue);
            OutputValue();
        }

        private void DecreaseVal()
        {
            CurrentValue--;
            CurrentValue = (int)Mathf.Repeat(CurrentValue, MaxValue);
            OutputValue();
        }

        public void SetValue(int value)
        {
            CurrentValue = value;
            
        }

        private void OutputValue()
        {
            _text.text = CurrentValue.ToString();
        }

        private IEnumerator ValueChange(float timeDelay, Action call)
        {
            if(timeDelay <= 0)
            {
                timeDelay = 0.1f;
            }
            while (true)
            {
                call?.Invoke();
                yield return new WaitForSeconds(timeDelay);
            }

        }
    }
}