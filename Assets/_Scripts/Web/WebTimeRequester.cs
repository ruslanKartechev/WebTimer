using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;

namespace ClockApplication
{
    [CreateAssetMenu(fileName = "WebTime", menuName = "SO/WebTime", order = 0)]
    public class WebTimeRequester : TimeCorrecter
    {
        [Header("IANA Time Zone")]
        [SerializeField] private string _region;
        [SerializeField] private string _city;

        [Header("Web resources")]
        [SerializeField] private string _resource_1;
        [SerializeField] private string _resource_2;
        [SerializeField] private bool _useSecond = false;
        [Space(10)]
        public TimeData LastUpdate;

        public override async void GetCorrectTime(Action<TimeData> reciver)
        {
            if (_useSecond)
            {
                await GetTimeRes2();
            }
            else
            {
                await GetTimeRes1();
            }
            reciver?.Invoke(LastUpdate);
        }

        public async Task GetTimeRes1()
        {
            string url = _resource_1 + $"/{_region}/{_city}";
            UnityWebRequest request = UnityWebRequest.Get(url);

            request.SendWebRequest();
            while (request.isDone == false)
            {
                await Task.Yield();
            }
            Debug.Log($"Server {1} Responce {request.result}");

            if (request.result == UnityWebRequest.Result.Success)
            {
                //Debug.Log(request.downloadHandler.text);
                WebTime_1 info_1 = JsonUtility.FromJson<WebTime_1>(request.downloadHandler.text);
                LastUpdate = new TimeData();
                LastUpdate.ProcessResponse(info_1.datetime);

            }
        }

        public async Task GetTimeRes2()
        {
            string url = _resource_2 + $"={_region}/{_city}";
            UnityWebRequest request = UnityWebRequest.Get(url);

            request.SendWebRequest();
            while (request.isDone == false)
            {
                await Task.Yield();
            }
            Debug.Log($"Server {2} Responce {request.result}");
            if (request.result == UnityWebRequest.Result.Success)
            {
                WebTime_2 info = JsonUtility.FromJson<WebTime_2>(request.downloadHandler.text);
                LastUpdate = new TimeData();
                LastUpdate.ProcessResponse(info.currentLocalTime);

            }
        }

    }


    
}