using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemy1;
    public float period = 0.5f;
    float timer;
    float y;
    float y1;
    public Transform enemyHolder;
    public Transform enemyHolder1;
    public GameObject gameOverPanel;
    public GameObject gameStartPanel;

    bool isPlaying = true;

    private void Start()
    {
        gameStartPanel.SetActive(true);
        isPlaying = false;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!isPlaying)
        return;

        timer += Time.deltaTime;
        if(timer > period)
        {
            timer = 0;
            y = Random.Range(12.5f, -12.5f);
            y1 = Random.Range(12f, -12f);
            GameObject enemy = Instantiate(Enemy,new Vector3(23f, y, 0), transform.rotation);
            GameObject enemy1 = Instantiate(Enemy1,new Vector3(25f, y1, 0), transform.rotation);
            enemy.transform.parent = enemyHolder;
            enemy1.transform.parent = enemyHolder1;
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        isPlaying = false;
        FindObjectOfType<PLayerController>().gameObject.SetActive(false);
        Destroy(enemyHolder.gameObject);
        Destroy(enemyHolder1.gameObject);
    }

    public void GameStart()
    {
        isPlaying = true;
        gameStartPanel.SetActive(false);
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
   {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
   }
}
