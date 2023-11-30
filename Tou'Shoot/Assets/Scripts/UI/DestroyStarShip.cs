using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyStarShip : MonoBehaviour
{
    public void Destroy()
    {
        GameObject.Find("StarShip").SetActive(false);
    }

    public void SwitchScene()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
