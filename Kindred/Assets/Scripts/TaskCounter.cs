
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TaskCounter : MonoBehaviour
{
    [SerializeField] DataManager dataManager;
    [SerializeField] public int dayID;
    [SerializeField] public int rID;
    [SerializeField] public string dayWeek;
    [SerializeField] private double[] taskDis;
    [SerializeField] private Dropdown extHours, extMinutes;
    [SerializeField] private SimpleDateTime routine;
    [SerializeField] private int petType;
    [SerializeField] private GameObject timePickerObj;
    [SerializeField] private GameObject catObj;
    [SerializeField] private GameObject dogObj;
    [SerializeField] private GameObject[] catEmot;
    [SerializeField] private GameObject[] dogEmot;
    [SerializeField] private double[] hrFree = new double[] { 24, 24, 24, 24, 24, 24, 24 };
    [SerializeField] private double tempMn, ntvalue, sleepVal, actVal, lesVal, drop2value;
    [SerializeField] private double[] tempHr;
    [SerializeField] public int curSelect;
    [SerializeField] private Text txtCount;
    [SerializeField] public int btnCount;
    [SerializeField] private GameObject[] basicIMG;
    [SerializeField] Animation anim;
    [SerializeField] GameObject mainPanel;
    [SerializeField] private bool isPlay;

    [SerializeField] private TimeManager timeManager;

    private void Awake()
    {
        isPlay = false;
        anim.Play();
        Invoke("StartApp", 1f);
        dataManager = FindObjectOfType<DataManager>();
        routine = FindObjectOfType<SimpleDateTime>();
        dataManager = FindObjectOfType<DataManager>();
        dataManager.file = PlayerPrefs.GetString("PetName");
        dataManager.Load();
        dataManager.data.alarmData = new List<AlarmName>();
        petType = PlayerPrefs.GetInt("PetType");
        timeManager = FindObjectOfType<TimeManager>();
       

    }
    private void Update()
    {
        if (isPlay)
        {
            mainPanel.SetActive(true);
            switch (petType)
            {
                case 0:
                    basicIMG[0].SetActive(true);
                    basicIMG[1].SetActive(false);
                    dogObj.SetActive(true);
                    catObj.SetActive(false);
                    isPlay = false;
                    break;
                case 1:
                    basicIMG[1].SetActive(true);
                    basicIMG[0].SetActive(false);
                    dogObj.SetActive(false);
                    catObj.SetActive(true);
                    isPlay = false;
                    break;
            }
        }

        DayofWeek(dayID);
        routine.rID = rID;
        txtCount.text = hrFree[dayID].ToString();
        if (hrFree[dayID] < 1)
        {
            hrFree[dayID] = 0;
            EmotCounter();
        }




    }
    public void ResetTaskSched()
    {
        hrFree[dayID] = 24;
        if (petType == 0) { DogEmoteType(1); } else if (petType == 1) { CatEmoteType(1); }
        for (int i = 0; i < 7; i++)
        {
            PlayerPrefs.DeleteKey(dayWeek + i.ToString());
        }

    }
    public void DayofWeek(int objID)
    {
        switch (objID)
        {
            case 0:
                dayWeek = System.DayOfWeek.Monday.ToString();
                break;
            case 1:
                dayWeek = System.DayOfWeek.Tuesday.ToString();
                break;
            case 2:
                dayWeek = System.DayOfWeek.Wednesday.ToString();
                break;
            case 3:
                dayWeek = System.DayOfWeek.Thursday.ToString();
                break;
            case 4:
                dayWeek = System.DayOfWeek.Friday.ToString();
                break;
            case 5:
                dayWeek = System.DayOfWeek.Saturday.ToString();
                break;
            case 6:
                dayWeek = System.DayOfWeek.Sunday.ToString();
                break;
        }
    }


    public void OnAdd()
    {
        tempHr[rID] = extHours.value;
        if (hrFree[dayID] >= tempHr[rID])
        {


            tempMn = extMinutes.value;
            tempMn /= 100;
            TaskCount(tempHr[rID], tempMn, dayID);

            timeManager.SetTime(dayWeek, rID, timeManager.totalTime);
            btnCount += 1;
            GetDate(rID);



            dataManager.Save();


            timePickerObj.SetActive(false);

            Debug.Log("thismightworks");
        }
        else
        {
            Debug.Log("Reduce Hours");
        }




    }
    private void TaskCount(double drop1, double drop2, int taskCnt)
    {

        if (drop2 > 0) { drop2value = .40; } else { drop2value = 0; }
        tempHr[rID] = drop1 + (drop2 + drop2value);

        hrFree[taskCnt] -= tempHr[rID];



        taskDis[rID] += tempHr[rID];

    }

    public void EmotCounter()
    {
        ntvalue = taskDis[0] + taskDis[2] + taskDis[4];
        sleepVal = taskDis[5];
        lesVal = taskDis[3];
        actVal = taskDis[1] + taskDis[6];
        //     PlayerPrefs.GetInt("PetType"
        if (petType == 1)
        {
            //cat
            // emot 0 is sad
            // emot 1 is happy
            // emot 2 is hungry
            // emot 3 is sleepy
            // emot 4 is tired

            if (sleepVal <= 5 && ntvalue >= 0 && actVal >= 0 && lesVal >= 0)
            {
                CatEmoteType(3);

            }
            else if (sleepVal > 5 && ntvalue < 1 && actVal >= 0 && lesVal >= 0)
            {
                CatEmoteType(2);
            }
            else if (sleepVal > 5 && ntvalue >= 1 && actVal > 8 && lesVal < 4)
            {
                CatEmoteType(4);
            }
            else if (sleepVal > 5 && ntvalue >= 1 && actVal <= 8 && lesVal <= 4)
            {
                CatEmoteType(0);
            }


        }
        else if (petType == 0)
        {
            //dog

            if (sleepVal <= 5 && ntvalue >= 0 && actVal >= 0 && lesVal >= 0)
            {
                DogEmoteType(3);

            }
            else if (sleepVal > 5 && ntvalue < 1 && actVal >= 0 && lesVal >= 0)
            {
                DogEmoteType(2);
            }
            else if (sleepVal > 5 && ntvalue >= 1 && actVal > 8 && lesVal < 4)
            {
                DogEmoteType(4);
            }
            else if (sleepVal > 5 && ntvalue >= 1 && actVal <= 8 && lesVal <= 4)
            {
                DogEmoteType(0);
            }

        }
    }

    public void GetDate(int i)
    {

        routine.dayNow[i] = PlayerPrefs.GetString(System.DateTime.Now.DayOfWeek.ToString() + i.ToString());

    }
    public void Remove()
    {

        btnCount -= 1;
        if (btnCount < 0)
        {
            btnCount = 0;
        }
        PlayerPrefs.DeleteKey(dayWeek + rID.ToString());
        routine.dayNow[rID] = "";
        PlayerPrefs.Save();


        Debug.Log("success");



        timePickerObj.SetActive(false);


    }
    public void RemoveData()
    {
        dataManager.Load();

        dataManager.data.alarmData.RemoveAt(rID);
        dataManager.Save();

    }
    public void onReset()
    {
        btnCount = 0;

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("InitialScreen");
    }
    private void CatEmoteType(int i)
    {
        switch (i)
        {
            case 0:
                catEmot[3].SetActive(false);
                catEmot[0].SetActive(true);
                catEmot[1].SetActive(false);
                catEmot[2].SetActive(false);
                catEmot[4].SetActive(false);
                break;
            case 1:
                catEmot[3].SetActive(false);
                catEmot[1].SetActive(true);
                catEmot[0].SetActive(false);
                catEmot[2].SetActive(false);
                catEmot[4].SetActive(false);
                break;
            case 2:
                catEmot[3].SetActive(false);
                catEmot[2].SetActive(true);
                catEmot[1].SetActive(false);
                catEmot[0].SetActive(false);
                catEmot[4].SetActive(false);
                break;
            case 3:
                catEmot[0].SetActive(false);
                catEmot[3].SetActive(true);
                catEmot[1].SetActive(false);
                catEmot[2].SetActive(false);
                catEmot[4].SetActive(false);
                break;
            case 4:
                catEmot[3].SetActive(false);
                catEmot[4].SetActive(true);
                catEmot[1].SetActive(false);
                catEmot[2].SetActive(false);
                catEmot[0].SetActive(false);
                break;

        }

    }
    private void DogEmoteType(int i)
    {
        switch (i)
        {
            case 0:
                dogEmot[3].SetActive(false);
                dogEmot[0].SetActive(true);
                dogEmot[1].SetActive(false);
                dogEmot[2].SetActive(false);
                dogEmot[4].SetActive(false);
                break;
            case 1:
                dogEmot[3].SetActive(false);
                dogEmot[1].SetActive(true);
                dogEmot[0].SetActive(false);
                dogEmot[2].SetActive(false);
                dogEmot[4].SetActive(false);
                break;
            case 2:
                dogEmot[3].SetActive(false);
                dogEmot[2].SetActive(true);
                dogEmot[1].SetActive(false);
                dogEmot[0].SetActive(false);
                dogEmot[4].SetActive(false);
                break;
            case 3:
                dogEmot[0].SetActive(false);
                dogEmot[3].SetActive(true);
                dogEmot[1].SetActive(false);
                dogEmot[2].SetActive(false);
                dogEmot[4].SetActive(false);
                break;
            case 4:
                dogEmot[3].SetActive(false);
                dogEmot[4].SetActive(true);
                dogEmot[1].SetActive(false);
                dogEmot[2].SetActive(false);
                dogEmot[0].SetActive(false);
                break;

        }

    }
    private void StartApp()
    {
        isPlay = true;
    }
}
