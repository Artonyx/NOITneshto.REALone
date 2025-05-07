using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class levelEnd : MonoBehaviour
{
    public double moveTime = 1f;
    public GameObject triggerThingy;
    public GameObject winScreen;
    public List<bool> winsForPlanets = new List<bool>();
    public bool winMercury = false;
    public bool winVenus = false;
    public bool winEarth = false;
    public bool winMars = false;
    public bool winJupiter = false;
    public bool winSaturn = false;
    public bool winUranus = false;
    public bool winNeptune = false;
    public bool winPluto = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        triggerThingy.transform.position = new Vector2(10000, 10000);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f;
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 2:
                {
                    winMercury = true;
                }
                    break;
                case 3:
                {
                    winVenus = true;
                }
                    break;
                case 4:
                {
                    winEarth = true;
                }
                    break;
                case 5:
                {
                    winMars = true;
                }
                    break;
                case 6:
                {
                    winJupiter = true;
                }
                    break;
                case 7:
                {
                    winSaturn = true;
                }
                    break;
                case 8:
                {
                    winUranus = true;
                }
                    break;
                case 9:
                {
                    winNeptune = true;
                }
                    break;
                case 10:
                {
                    winPluto = true;
                }
                    break;
                default:
                {
                    Debug.LogError("Bro wtf did you do how is this even possible what the hell");
                }
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= moveTime)
        {
            //triggerThingy.SetActive(true);
            triggerThingy.transform.position = new Vector2(-200, -200);
        }
    }
}
