using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour {
    public static UI_manager manager_instance = null;
    Text high_score;
    Text current_score=null;
    Text timer = null;
    int highScore=0;
    Button start;
    Player_script ps;
    Game_Manager gm;
    private void Awake()
    {
        if (manager_instance == null)
        {
            manager_instance = this;
        }else if (manager_instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        start= GameObject.FindGameObjectWithTag("start_button").GetComponent<Button>();
        highScore = PlayerPrefs.GetInt("HighScore",0);
        high_score = GameObject.FindGameObjectWithTag("High_Score").GetComponent<Text>();
        high_score.text = highScore.ToString();
        start.onClick.AddListener(load_game);
    }
	
	// Update is called once per frame
	void Update () {
        if (current_score != null)
        {
            int time = (int)gm.timer;
            if (time < 0)
            {
                SceneManager.LoadScene("Menu_scene");
            }
            timer.text = time.ToString();
            current_score.text = "Current Score" + ps.score;
            if(ps.score>highScore)
            {
                PlayerPrefs.SetInt("HighScore", ps.score);
            }
        }
	}
    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            start.onClick.RemoveListener(load_game);
            ps = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_script>();
            high_score = GameObject.FindGameObjectWithTag("High_Score").GetComponent<Text>();
            current_score = GameObject.FindGameObjectWithTag("Current_Score").GetComponent<Text>();
            timer= GameObject.FindGameObjectWithTag("timer").GetComponent<Text>();
            high_score.text = "High Score"+highScore.ToString();
            current_score.text = "Current Score" + ps.score;
            gm = GameObject.FindGameObjectWithTag("game_manager").GetComponent<Game_Manager>();
        }
        else if (level == 0)
        {
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            start = GameObject.FindGameObjectWithTag("start_button").GetComponent<Button>();
            start.onClick.AddListener(load_game);
            high_score = GameObject.FindGameObjectWithTag("High_Score").GetComponent<Text>();
            high_score.text = highScore.ToString();
            current_score = null;
        }
    }
    public void load_game()
    {
       
        SceneManager.LoadScene("Game");
    }
}
