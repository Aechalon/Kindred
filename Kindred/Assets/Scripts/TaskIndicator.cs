
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TaskIndicator : MonoBehaviour
{
    [SerializeField] private TaskCounter taskCounter;
    [SerializeField] private GameObject timePicker;
    [SerializeField] private GameObject doneBtn;
    [SerializeField] public int objID;
    
    [SerializeField] public string btnName;


    
    private void Awake()

    {
     
     
        taskCounter = FindObjectOfType<TaskCounter>();
    
       
    }
  
    public void OnClick()
    {
        
        taskCounter.rID = objID;
        taskCounter.curSelect = objID;
        doneBtn.SetActive(true);
        timePicker.SetActive(true);
    }
  
  
 

}
