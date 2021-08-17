using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Image bulletColorImage;
    private Color color;
 
    void Start()
    {
         bulletColorImage.color = bulletPrefab.GetComponent<Renderer>().sharedMaterial.color;
    }

    // Update is called once per frame
    void Update()
    {
        GetColorInput();
    }

    public void GetColorInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) ChangeBulletColor(1);
        if(Input.GetKeyDown(KeyCode.Alpha2)) ChangeBulletColor(2);
        if(Input.GetKeyDown(KeyCode.Alpha3)) ChangeBulletColor(3);
        if(Input.GetKeyDown(KeyCode.Alpha4)) ChangeBulletColor(4);
        if(Input.GetKeyDown(KeyCode.Alpha5)) ChangeBulletColor(5);
        



    }

    public void ChangeBulletColor(int index)
    {
        
        switch(index)
        {
            case 1:
                ColorUtility.TryParseHtmlString("#00D1FF",out color);
                bulletPrefab.GetComponent<Renderer>().sharedMaterial.color = color;
                break;
            case 2:
                ColorUtility.TryParseHtmlString("#39FF00",out color);
                bulletPrefab.GetComponent<Renderer>().sharedMaterial.color = color;
                break;
            case 3:
                ColorUtility.TryParseHtmlString("#FF0808",out color);
                bulletPrefab.GetComponent<Renderer>().sharedMaterial.color = color;
                break;
            case 4:
                ColorUtility.TryParseHtmlString("#FF00A0",out color);
                bulletPrefab.GetComponent<Renderer>().sharedMaterial.color = color;
                break;
             case 5:
                ColorUtility.TryParseHtmlString("#844204",out color);
                bulletPrefab.GetComponent<Renderer>().sharedMaterial.color = color;
                break;
        }
            bulletColorImage.color = color;

        
    }
}
