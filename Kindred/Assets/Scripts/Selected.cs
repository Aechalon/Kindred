using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    [SerializeField] public bool isSelected;
    [SerializeField] public GameObject timePicker;

    private void Awake()
    {
      
    }
    public void OnClick(bool click)
    {
        isSelected = click;
    }
    private void Update()
    {
        if(timePicker.activeSelf == false)
        {
            isSelected = false;
        }
    }


}
