using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("levelPicker");
    }
}
