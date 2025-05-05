using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public void goBack()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1f;
    }

    public void goToLevelPicker(){
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1f;
    }
    public void PlayLvl1()
    {
        SceneManager.LoadSceneAsync(2);
        Time.timeScale = 1f;
    }
    public void PlayLvl2()
    {
        SceneManager.LoadSceneAsync(3);
        Time.timeScale = 1f;
    }
    public void PlayLvl3()
    {
        SceneManager.LoadSceneAsync(4);
        Time.timeScale = 1f;
    }
    public void PlayLvl4()
    {
        SceneManager.LoadSceneAsync(5);
        Time.timeScale = 1f;
    }
    public void PlayLvl5()
    {
        SceneManager.LoadSceneAsync(6);
        Time.timeScale = 1f;
    }
    public void PlayLvl6()
    {
        SceneManager.LoadSceneAsync(7);
        Time.timeScale = 1f;
    }public void PlayLvl7()
    {
        SceneManager.LoadSceneAsync(8);
        Time.timeScale = 1f;
    }
    public void PlayLvl8()
    {
        SceneManager.LoadSceneAsync(9);
        Time.timeScale = 1f;
    }
    public void PlayLvl9()
    {
        SceneManager.LoadSceneAsync(10);
        Time.timeScale = 1f;
    }
    
}
