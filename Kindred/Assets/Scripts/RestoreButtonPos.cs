using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreButtonPos : MonoBehaviour
{
    private Transform savedTransform;
    public GameObject walk;
    public GameObject walking;
    public GameObject parent;
    public bool go;
     public float i;
    public void Awake()
    {
        savedTransform = this.transform;

    }

    public void RestorePosition()
    {
        walking = Instantiate(walk, walk.transform.position, walk.transform.rotation, walk.transform.parent);
        walking.transform.SetParent(parent.transform);
        go = false;
    }
    public void Update()
    {
        if (go)
        {
            transform.position += transform.right * 3 * Time.deltaTime;

            if (i < 5)
            {
                i += Time.deltaTime;

            }
            
            else if(i>5)
            {
                RestorePosition();
            }
        }
    }

}

 