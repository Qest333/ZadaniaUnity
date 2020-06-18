using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetect : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject PauseB;
    public Text gameScore;
    public Text endScore;
    // Start is called before the first frame update
    private void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Box")
        {
            endScore.text = gameScore.text;
            gameOverPanel.gameObject.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0f;
            PauseB.gameObject.SetActive(false);
        }
    }
}
