using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public double moveTime = 1f;
    public GameObject triggerThingy;
    public GameObject winScreen;

    // Dictionary to track win states for each planet
    public Dictionary<string, bool> planetWins = new Dictionary<string, bool>
    {
        { "Mercury", false },
        { "Venus", false },
        { "Earth", false },
        { "Mars", false },
        { "Jupiter", false },
        { "Saturn", false },
        { "Uranus", false },
        { "Neptune", false },
        { "Pluto", false }
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        triggerThingy.transform.position = new Vector2(10000, 10000);
        StartCoroutine(MoveTriggerAfterDelay());
    }

    IEnumerator MoveTriggerAfterDelay()
    {
        yield return new WaitForSeconds((float)moveTime);
        triggerThingy.transform.position = new Vector2(-200, -200);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f;

            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Map the scene index to the corresponding planet name
            string planetName = GetPlanetNameFromSceneIndex(sceneIndex);
            
            if (planetName != null)
            {
                planetWins[planetName] = true;
            }
            else
            {
                Debug.LogError("Unexpected scene index: " + sceneIndex);
            }
        }
    }

    private string GetPlanetNameFromSceneIndex(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 2: return "Mercury";
            case 3: return "Venus";
            case 4: return "Earth";
            case 5: return "Mars";
            case 6: return "Jupiter";
            case 7: return "Saturn";
            case 8: return "Uranus";
            case 9: return "Neptune";
            case 10: return "Pluto";
            default: return null;
        }
    }
}
