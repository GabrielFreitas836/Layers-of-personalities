using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private GameObject[] movObjs;

    public float distance = 2f;
    public float speed = 1f;

    private float t;

    public Text fpsText;
    private int fps;

    void Awake()
    {
        movObjs = GameObject.FindGameObjectsWithTag("MovingObject");
    }

    void Start()
    {
        StartCoroutine(FPSText());
    }
    void Update()
    {
        // Resetar level atual ao apertar R
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        t += Time.deltaTime * speed;
        foreach (GameObject movObj in movObjs)
        {
            float x = Mathf.Lerp(distance -2f, distance + 0.75f, Mathf.PingPong(t, 1f));
            Vector2 pos = movObj.transform.position;
            pos.x = x;

            movObj.transform.position = pos;

        }
    }

    IEnumerator FPSText()
    {
        while (true)
        {
            fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = $"FPS: {fps}";
            yield return new WaitForSecondsRealtime(1.5f);
        }
    }
}
