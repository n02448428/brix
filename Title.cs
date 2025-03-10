using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    public Text toStart;

    // Start is called before the first frame update
    void Start()
    {
        toStart = GameObject.Find("Text").GetComponent<Text>();
        toStart.text = "by Dmitry Markelov - @novel.films - Click To Start";
        InvokeRepeating("ChangeColor", 0, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadSceneAsync("Level 1");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadSceneAsync("Level 1");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadSceneAsync("Level 2");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadSceneAsync("Level 3");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadSceneAsync("Level 4");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadSceneAsync("Level 5");
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadSceneAsync("Bonus");
        }
    }

    void ChangeColor()
    {
        toStart.color = new Color(Random.value, Random.value, Random.value);
    }
}
