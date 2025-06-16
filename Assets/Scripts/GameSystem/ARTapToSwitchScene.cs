using UnityEngine;
using UnityEngine.SceneManagement;

public class ARTapToSwitchScene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            SceneManager.LoadScene(sceneName);
    }
}
