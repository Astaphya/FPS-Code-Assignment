using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChecker : MonoBehaviour
{
    [SerializeField] private GameObject[] cubes;
    [SerializeField] private GameObject Ground;
    [SerializeField] private Text cubeDropsIndex;

    Color groundColor;

    private int buttonDropIndex;
    
    void Start()
    {
        
    }

    void Update()
    {
        groundColor = Ground.GetComponent<Renderer>().material.color;
        ControlColors();
        
    }

    public void ControlColors()
    {
        for(int i = 0 ; i< cubes.Length;i++)
        {
            if(cubes[i] != null)
            {
            if(groundColor == cubes[i].GetComponent<Renderer>().material.color)
            {
                cubes[i].AddComponent<Rigidbody>();
                cubes[i].GetComponent<BoxCollider>().enabled = false;
                cubes[i] = null;
                buttonDropIndex++;
            }

            cubeDropsIndex.text = "Düşen küp sayısı : " + buttonDropIndex.ToString();
            }

            
            
        }

    }

    
}
