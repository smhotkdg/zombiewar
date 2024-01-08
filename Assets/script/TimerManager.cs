using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour
{
    // Use this for initialization
    System.DateTime OldTime;
    double RemantsTimeMinerals;

    private void Awake()
    {
        OldTime = System.DateTime.Now;
    }

    double remantsTimeHire3;
    void Start()
    {

    }
    public void SetTextTimeKor(int time, Text _inputText)
    {
        RemantsTimeMinerals = time;
        int seconds = (int)(RemantsTimeMinerals % 60);
        int minutes = (int)(RemantsTimeMinerals / 60) % 60;
        int hours = (int)(RemantsTimeMinerals / 3600);

        string niceTime = string.Format("{0:0}시간{1:00}분{2:00}초", hours, minutes, seconds);
        _inputText.text = niceTime;
    }


    public void SetTextTime(int time, Text _inputText)
    {
        RemantsTimeMinerals = time;
        int seconds = (int)(RemantsTimeMinerals % 60);
        int minutes = (int)(RemantsTimeMinerals / 60) % 60;
        int hours = (int)(RemantsTimeMinerals / 3600);

        string niceTime = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
        _inputText.text = niceTime;
    }
    public float GetFillAmount(string name, int _timerequired)
    {
        OldTime = System.DateTime.Now;
        if (CheckTimer(name, _timerequired))
        {
            if (RemantsTimeMinerals > 0)
            {
                RemantsTimeMinerals -= Time.deltaTime;
            }
        }
        return 0;
    }
    public int SetTimerText(string name, int _timerequired)
    {
        OldTime = System.DateTime.Now;
        if (CheckTimer(name, _timerequired))
        {
            if (RemantsTimeMinerals > 0)
            {
                RemantsTimeMinerals -= Time.deltaTime;

                int seconds = (int)(RemantsTimeMinerals % 60);
                int minutes = (int)(RemantsTimeMinerals / 60) % 60;
                int hours = (int)(RemantsTimeMinerals / 3600);

                string niceTime = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
                //text.text = niceTime;
                // 시간 진행중
                return 1;
            }
            else
            {
                string niceTime = string.Format("{0:0}:{1:00}:{2:00}", 0, 0, 0);
                //text.text = niceTime;
                //완료
                return -1;

            }
        }
        else
        {
            //저장 데이터 없음
            return 2;
        }
    }
    public double GetRemantsTime(string name, int _timerequired)
    {
        OldTime = System.DateTime.Now;
        CheckTimer(name, _timerequired);
        return RemantsTimeMinerals;
    }

    public string GetTimerString(string name, int _timerequired)
    {
        OldTime = System.DateTime.Now;
        if (CheckTimer(name, _timerequired))
        {
            if (RemantsTimeMinerals > 0)
            {
                RemantsTimeMinerals -= Time.deltaTime;

                int seconds = (int)(RemantsTimeMinerals % 60);
                int minutes = (int)(RemantsTimeMinerals / 60) % 60;
                int hours = (int)(RemantsTimeMinerals / 3600);

                string niceTime = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
                //text.text = niceTime;
                // 시간 진행중
                return niceTime;
            }
            else
            {
                string niceTime = string.Format("{0:0}:{1:00}:{2:00}", 0, 0, 0);
                //text.text = niceTime;
                //완료
                return string.Empty;

            }
        }
        else
        {
            //저장 데이터 없음
            return string.Empty;
        }
    }

    public int SetTimerText(string name, Text text, int _timerequired)
    {
        OldTime = System.DateTime.Now;
        if (CheckTimer(name, _timerequired))
        {
            if (RemantsTimeMinerals > 0)
            {
                RemantsTimeMinerals -= Time.deltaTime;

                int seconds = (int)(RemantsTimeMinerals % 60);
                int minutes = (int)(RemantsTimeMinerals / 60) % 60;
                int hours = (int)(RemantsTimeMinerals / 3600);

                string niceTime = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
                text.text = niceTime;
                // 시간 진행중
                return 1;
            }
            else
            {
                string niceTime = string.Format("{0:0}:{1:00}:{2:00}", 0, 0, 0);
                text.text = niceTime;
                //완료
                return -1;

            }
        }
        else
        {
            //저장 데이터 없음
            return 2;
        }
    }

    bool CheckTimer(string name, int _timerequired)
    {
        remantsTimeHire3 = _timerequired;

        double Hirecount;
        string key = name;
        string startTimeStr = PlayerPrefs.GetString(key);
        if (startTimeStr != "")
        {
            System.DateTime start = System.DateTime.Parse(startTimeStr);
            System.DateTime LoginTime = start;
            System.TimeSpan AAA = OldTime - LoginTime;
            Hirecount = AAA.TotalSeconds;

            remantsTimeHire3 -= (float)Hirecount;
            RemantsTimeMinerals = remantsTimeHire3;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void StartTimer(string name, int _timerequired)
    {
        AddTimer(name);
        OldTime = System.DateTime.Now;
    }


    void AddTimer(string key)
    {
        string timerKeyStr = key;
        string now = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        PlayerPrefs.SetString(timerKeyStr, now);
        PlayerPrefs.Save();
    }
}
