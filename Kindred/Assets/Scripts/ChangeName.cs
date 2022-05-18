using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeName : MonoBehaviour
{
    [SerializeField] public InputField inp;
    [SerializeField] public string name;
    private void Awake()
    {
        inp = GetComponent<InputField>();
    }

    public void Update()
    {
        name = inp.text;

    }
}
