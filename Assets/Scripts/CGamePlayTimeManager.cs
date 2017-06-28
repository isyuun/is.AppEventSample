using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGamePlayTimeManager : MonoBehaviour
{

    public bool _ispaused; // 일시정지 여부
    public bool _isfocus; // 포커스 여부

    System.DateTime _startTime; // 게임 시작 시간
    System.DateTime _timeSubract; // 게임 일시정지(종료) 시간

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 어플리케이션 포커스
    // 비활성화 되기 바로 전, 활성화 된 후 발동
    void OnApplicationFocus(bool focusStatus)
    {
        _isfocus = focusStatus;

        Debug.Log("OnApplicationFocus() => " + _isfocus);

        if (_isfocus)
        {
            // 게임이 활성화 된 시간
            _startTime = System.DateTime.Now;

            Debug.Log("OnApplicationFocus() => " + _startTime);
        }
        else
        {
            System.DateTime endTime = System.DateTime.Now;

            Debug.Log("OnApplicationFocus() => " + endTime);

            System.TimeSpan timeSubract;
            timeSubract = endTime.Subtract(_startTime);

            Debug.Log("Game Play Time => " + timeSubract.TotalSeconds);
        }
    }

    // 어플리케이션 일시정지
    // 비활성화 된 바로 후, 활성화 되기 바로 전
    void OnApplicationPause(bool pauseStatus)
    {
        _ispaused = pauseStatus;

        Debug.Log("OnApplicationPause() => " + _ispaused);
    }

    // 어플리케이션 종료
    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
    }
}
