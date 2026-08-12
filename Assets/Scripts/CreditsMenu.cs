using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
