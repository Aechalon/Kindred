using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnClickTask : MonoBehaviour
{
    [SerializeField] DataManager dataManager;
    [SerializeField] private int rID;
    [SerializeField] private GameObject nxtScreen;
    [SerializeField] private TaskCounter taskCounter;
    [SerializeField] private bool week;

    private void Awake()
    {
        taskCounter = FindObjectOfType<TaskCounter>();
        dataManager = FindObjectOfType<DataManager>();
        dataManager.file = PlayerPrefs.GetString("PetName") + ".txt";
        dataManager.Load();
        dataManager.data.alarmData = new List<AlarmName>();
    }
 
    public void OnClick(int routineID)
    {
     
        
            PlayerPrefs.SetInt("RoutineID", routineID);
            rID = PlayerPrefs.GetInt("RoutineID");
            nxtScreen.SetActive(true);
          
            taskCounter.dayID = routineID;
        
    }
    
    

}
