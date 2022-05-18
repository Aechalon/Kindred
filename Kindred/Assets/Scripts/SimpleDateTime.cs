using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleDateTime : MonoBehaviour
{
    [SerializeField] private Text txtCurTime;
    public DataManager dataManager;
    [SerializeField] public string[] dayNow;

    [SerializeField] private string petName;
   
    [SerializeField] MobileNotification mNotification;
    [SerializeField] public int rID;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] public string totalGivenTime;
    [SerializeField] private int tempComp;
    [SerializeField] TaskCounter taskCounter;
    public bool notif;
    [SerializeField] private Text largeText;
    [SerializeField] private Text petText;

    public float i;

    private void Awake()
    {
        taskCounter = FindObjectOfType<TaskCounter>();
        timeManager = FindObjectOfType<TimeManager>();
        petName = PlayerPrefs.GetString("PetName");
        dataManager.file = PlayerPrefs.GetString("PetName") + ".txt"; ;
        dataManager.Load();
        dataManager.data.alarmData = new List<AlarmName>();
       

    }
    void Update()
    {
        for (int i = 0; i < 7; i++)
        {
            RetrieveData(i);
        }
        petText.text = petName  ;
        txtCurTime.text = PlayerPrefs.GetString(taskCounter.dayWeek + rID.ToString());
        string timeUS = System.DateTime.UtcNow.ToLocalTime().ToString("hh:mm:ss tt");
        largeText.text = timeUS + " - ." + System.DateTime.Now.DayOfWeek;

        if (notif)
        {
            if (i < 60)
            {
                i += Time.deltaTime;
            }
            else
            {
                notif = false;
            }
        }


     
        dataManager.file = PlayerPrefs.GetString("PetName") + ".txt"; ;


        //   Debug.Log(PlayerPrefs.GetString(dayWeek + rID.ToString()));

        // Debug.Log(PlayerPrefs.GetString(System.DateTime.Now.DayOfWeek.ToString() + rID.ToString()));
        for (int i = 0; i < 7; i++)
        {   
            Notification(dayNow[i]);
        }
       

    }
   
    private void RetrieveData(int i)
    {
        dayNow[i] = PlayerPrefs.GetString(System.DateTime.Now.DayOfWeek.ToString() + i.ToString());
      
    }
    public void Notification(string totalTime)
    {

  
  
        if (System.DateTime.UtcNow.ToLocalTime().ToString("hh: mm: ss tt") == totalTime) //Global Time == "User Given Time"
        {

            Debug.Log("Notificate Phase");
            if (tempComp < 7)
            {
                DetermineTask(totalTime);
                tempComp += 1;
          
            }
            else if (tempComp > 6)
            {
                tempComp = 0;
              
            }


        }
    }
    public void DetermineTask(string time)
    {
        
    

      if(time == dayNow[0])
        {
            Debug.Log("NotifyMEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            mNotification.SendNotification("Done with breakfast?", "Tap here to time-in.");
        }
      if(time == dayNow[1])
        {
            Debug.Log("Notify");
            mNotification.SendNotification("Are you done with your activities?", "Tap here to time-in.");
        }
      if(time == dayNow[2])
        {
            Debug.Log("Notify");
            mNotification.SendNotification("Finished eating?", "Tap here to time-in.");
        }
      if(time == dayNow[3])
        {

            Debug.Log("Notify");
            mNotification.SendNotification("Have you relaxed?", "Tap here to time-in.");
        }
      if(time == dayNow[4])
        {
            Debug.Log("Notify");
            mNotification.SendNotification("Have you finished eating Dinner?", "Tap here to time-in.");
        }
      if(time == dayNow[5])
        {

            Debug.Log("Notify");
            mNotification.SendNotification("Just Woke up?", "Tap here to time-in.");

        }
        if (time == dayNow[6])
        {

            mNotification.SendNotification("Ready to do your next task?", "Tap here to time-in.");
            Debug.Log("Notify");
        }


        
    }

    public void AddItem(int i, string k, string rName, int tHours, int mnts, bool day)
    {
        dataManager.data.alarmData.Add(new AlarmName { routineID = i, routineTime = k, routineName = rName, totalHours = tHours, totalMinutes = mnts, am = day });

        dataManager.Save();
    }
    public void RemoveItem(int i)
    {
                             
        dataManager.data.alarmData.RemoveAt(1);
        dataManager.Save();
    }
    public void RemoveRange(int i,int k)
    {
        dataManager.data.alarmData.RemoveRange(i,k);
        dataManager.Save();
    }
    public void QuitApp()
    {
       Application.Quit();
    }



}
/* foreach (AlarmName data in dataManager.data.alarmData) //toAccess
        {
            if (data.routineID == 1)
            {
                data.routineID = 3;
                Debug.Log(data.routineID);
                dataManager.Save();
            }
        }
        */
