using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    public int points = 0;
    public Text pointText;

    // Update is called once per frame
    void Update()
    {
        pointText.text = points.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Box")
        {
            points += 1;
            Destroy(other.gameObject);
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
