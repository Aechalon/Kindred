using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickButton : MonoBehaviour
{



    [SerializeField] public GameObject timePicker;
    public void OnClick()
    {
        timePicker.SetActive(false);

    }
   
   
}



