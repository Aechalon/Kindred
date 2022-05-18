using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PetSelect : MonoBehaviour
{
    [SerializeField] DataManager dataManager;
    [SerializeField] private int logIn;
    [SerializeField] private string dataName;
    private void Awake()
    {
        dataManager = FindObjectOfType<DataManager>();
        dataManager.file = PlayerPrefs.GetString("PetName") + ".txt";
        dataManager.Load();
        dataManager.data.alarmData = new List<AlarmName>();
        logIn = PlayerPrefs.GetInt("LogIn");
        dataName = PlayerPrefs.GetString("PetName");
    }
    public void onClick(int petType)
    {
        dataManager.data.petType = petType;
        
        logIn += 1;
        PlayerPrefs.SetInt("PetType", petType);
        PlayerPrefs.SetInt("LogIn",logIn);
        dataManager.Save();
        SceneManager.LoadScene("HomeScreen");
    }
   

}
