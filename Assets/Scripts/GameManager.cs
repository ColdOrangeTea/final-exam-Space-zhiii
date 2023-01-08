using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        // 玩家(還沒開始/已經結束)玩遊戲
        if (!isPlaying)
            return; // 立刻跳回上面

        timeCounting();
        EndingJudgment();

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    // 計時隨機跑出怪物
    void timeCounting()
    {
        timer += Time.deltaTime;
        if (timer > period)
        {
            timer = 0;
            y = Random.Range(12.5f, -12.5f);
            y1 = Random.Range(12f, -12f);
            GameObject enemy = Instantiate(Enemy, new Vector3(23f, y, 0), transform.rotation);
            GameObject enemy1 = Instantiate(Enemy1, new Vector3(25f, y1, 0), transform.rotation);
            enemy.transform.parent = enemyHolder;
            enemy1.transform.parent = enemyHolder1;
        }
    }

    // 決定結局分支
    public void EndingJudgment()
    {
        // 抓UIManager的物件
        GameObject UI = GameObject.Find("UI");
        int scoreJudge = UI.GetComponent<UIManager>().score; // 抓UIManager的score資料 存進scoreJudge
        bool firstEnable = UI.GetComponent<UIManager>().first.enabled; // 抓UIManager的first資料 存進firstEnable

        // 好結局
        if (scoreJudge >= 50)
        {
            Debug.Log("好結局達成!!");
            //跳到好結局Scene 
            SceneManager.LoadScene("GoodEnd");
        }

        // 壞結局
        if (firstEnable == false)
        {
            Debug.Log("壞結局了!!");
            //跳到壞結局Scene
            SceneManager.LoadScene("BadEnd");
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
