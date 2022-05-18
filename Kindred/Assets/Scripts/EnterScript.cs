using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnterScript : MonoBehaviour
{
    [SerializeField] private GameObject screen1;
    [SerializeField] private GameObject screen2;

    [SerializeField] private bool isSingle;

    public void onClick()
    {

        if (isSingle)
        {
            screen2.SetActive(true);
        }
        else

        {
            screen1.SetActive(false);
            screen2.SetActive(true);
        }
    }
}
