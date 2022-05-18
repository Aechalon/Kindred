using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    [SerializeField] private Text txtFreeHrs;

    [SerializeField] private Dropdown[] drop;
    [SerializeField] DataManager dataManager;
    [SerializeField] TaskCounter taskCounter;
    [SerializeField] private string doubleD, tempHrs, tempMns, tempSnd, day;
    [SerializeField] private int extHrs,extMnt;
    [SerializeField] public string totalTime;
    private void Awake()
    {

        dataManager = GetComponent<DataManager>();
        dataManager.file = PlayerPrefs.GetString("PetName") + ".txt"; ;
        dataManager.Load();
        dataManager.data.alarmData = new List<AlarmName>();
        taskCounter = FindObjectOfType<TaskCounter>();

    }
    private void Update() 
    {
        SetHMSD();
        TimeAssembly(tempHrs, tempMns, tempSnd, day);
        
        
    }
    public void SetTime(string day, int rID, string time)
    {
  
                PlayerPrefs.SetString(day + rID.ToString(), time);
        PlayerPrefs.Save();

        
    }
    private void SetHMSD()
    {

        SetDay(drop[3].value);
        extHrs = drop[4].value;
        extMnt = drop[5].value;
      
        SetHMS(drop[0].value + extHrs, 0);
        SetHMS(drop[1].value + extMnt , 1);
        SetHMS(drop[2].value, 2);
      
        
    
    }
    private void ReturnDay(int i)
    {
        switch (i)
        {
            case 0:
                day = "PM";
                break;
            case 1:
                day = "AM";
                break;
          


        }
    }

    private void DDChecker(int val)
    {

        if ( val <= 9)
        {
            doubleD = "0";
        }
        else
        {
            doubleD = "";
        }
    }
    private void SetHMS(int dropValue, int valType)
    {
        
        switch (valType)
        {
            case 0:
              
                if (dropValue >= 12)
                {
                    dropValue -= 12;
                    ReturnDay(drop[3].value);

                }
                double minutes;
                minutes = drop[1].value + extMnt;
                if (minutes >= 60) { dropValue += 1; }
                DDChecker(dropValue);
                tempHrs = doubleD + dropValue.ToString();
              
                break;
            case 1:
                if (dropValue >= 60) { dropValue -=60; }
                DDChecker(dropValue);
                tempMns = doubleD + dropValue.ToString();
             

                break;
            case 2:
                DDChecker(dropValue);
                tempSnd = doubleD + dropValue.ToString();
               
                break;

        }
       

    }
    private void SetDay(int val)
    {
        
        switch (val)
        {
            case 0:
                day = "AM";
                break;
            case 1:
                day = "PM";
                break;


        }
    }
    private void TimeAssembly(string hr, string mns, string snd, string day)
        {

        totalTime = hr + ":" + " " + mns + ":" + " " + snd + " " +  day;
        //hh: mm: ss tt

        }

}
