using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadUp : MonoBehaviour
{
    [SerializeField] DataManager dataManager;
    [SerializeField] private int isInitial;
    [SerializeField] private string dataName;
    [SerializeField] private Text petName;
    [SerializeField] private GameObject nxtScreen;
    [SerializeField] private LoadUp[] loadUp;
   
    private void Awake()
    {
      
      
        nxtScreen.SetActive(true);
        isInitial = PlayerPrefs.GetInt("LogIn");
        dataName = PlayerPrefs.GetString("PetName");

        
        if (isInitial>1)
        {
            dataManager.file = dataName + ".txt";
            dataManager.Load();
            dataManager.data.alarmData = new List<AlarmName>();
  
            SceneManager.LoadScene("HomeScreen");

         
        }
        else
        {

           
            nxtScreen.SetActive(false);
            dataManager.file = dataName + "player.txt";
            dataManager.Load();
            dataManager.data.alarmData = new List<AlarmName>();
            PlayerPrefs.DeleteAll();

        }


        

    }
    public void onReset()
    {
        PlayerPrefs.DeleteAll();
    }
    public void onClick()
    { 
      
            dataName = petName.text;
            isInitial += 1;
            PlayerPrefs.SetInt("LogIn", isInitial);
            PlayerPrefs.SetString("PetName", dataName);
            dataManager.file = dataName + ".txt";
            dataManager.data.petName = dataName;
            dataManager.Save();
            SceneManager.LoadScene("PetSelection");
        
       
        

    }

}
