using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelfHIde : MonoBehaviour
{
    [SerializeField] private Text txtTime;
    

    private void Update()
    {
        if(txtTime.text != "")
        {
            this.gameObject.SetActive(false);
        }
    }

}
