using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool endGame;
    // Start is called before the first frame update
    void Start()
    {
        endGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (endGame)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
