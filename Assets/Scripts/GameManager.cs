using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] movObjs;

    public float distance = 2f;
    public float speed = 1f;

    private float t;

    void Awake()
    {
        movObjs = GameObject.FindGameObjectsWithTag("MovingObject");
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
}
