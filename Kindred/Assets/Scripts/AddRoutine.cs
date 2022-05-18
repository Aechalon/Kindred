using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddRoutine : MonoBehaviour
{
    public Transform scrollTrans;
    public GameObject btn;

    [SerializeField] public GameObject btnPlacement;
    [SerializeField] private GameObject timePicker;
    [SerializeField] private TaskCounter taskCounter;

    private void Awake()
    {
        taskCounter = FindObjectOfType<TaskCounter>();
       
    }
    private void Update()
    {
      
    }
    public void OpenPicker()
    {
        timePicker.SetActive(true);
    }
    public void SpawnButton()
    {
   
        GameObject btnHolder = Instantiate(btn,btn.transform.position,btn.transform.rotation,btn.transform.parent);
    
        btnHolder.transform.SetParent(scrollTrans.transform);
        btnHolder.transform.localScale = new Vector3(1, 1, 1);
     

    }

}
