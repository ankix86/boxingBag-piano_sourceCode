using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    private int score;
    private int highScore;
    public Text scoreText, highScoreText,GoS,GoH;
    public Transform levelIncrsser;
    private Vector2 pos;
    public spawner spawnerScript;
    private Vector3 startpos;
    public Transform levelUp;
    int c;
    private Vector3 oldlevelUpPos;
    public Vector3 levelUpPosChange;
    public Text level;
    public int levelCount;
    public int mode;

    public Text modeTex;
    private string playerPrefsHighscore = "highscore";
    //1 - eazy
    //2 - normal
    //3 - hard

    public void checkMode()
    {
       
        if(modeTex.text == "HARD-MODE")
        {
            mode = 3;
        }
        else if (modeTex.text == "EAZY-MODE")
        {
            mode = 1;
        }
        else if (modeTex.text == "NORMAL-MODE")
        {
            mode = 2;
        }
    }

    void Start()
    {
        checkMode();
        levelCount = 0;
        level.text = levelCount.ToString();
        oldlevelUpPos = levelUp.position;
        playerPrefsHighscore += mode.ToString();
        if (PlayerPrefs.GetInt(playerPrefsHighscore) != null)
        {
            highScore = PlayerPrefs.GetInt(playerPrefsHighscore);
        }
        else
        {
            highScore = 00;
        }
        highScoreText.text = highScore.ToString();
        startpos = levelIncrsser.position;
        c = 0;
        pos = levelIncrsser.position;
       
    }


    public void setScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        c++;
        if (c > 10)
        {
            incressLevel();
            c = 0;
        }
    }
    public void incressLevel()
    {
        if (pos.y <= .8f)
        {
            StartCoroutine(levelUPAnimation());
            pos.y += .5f;
            levelIncrsser.transform.position = pos;
            levelCount++;
            level.text = levelCount.ToString();
        }
        else
        {
            spawnerScript.speedIncress();
            levelIncrsser.position = startpos;
            pos = levelIncrsser.position;
        }
    }
    public int getScore()
    {
        return score;
    }
    public void setHighScore()
    {
        if(spawnerScript.getStartGame()){
            spawnerScript.setStartGame(false);
        }
        if (score > highScore)
        {
            PlayerPrefs.SetInt(playerPrefsHighscore, score);
            highScore = score;
        }
        StartCoroutine(textAnimation(2f));
    }
    public IEnumerator textAnimation(float sec)
    {
        while (sec > 0)
        {
            GoH.text = (Random.Range(0, 100)).ToString();
            GoS.text = (Random.Range(0, 100)).ToString();
            sec -= Time.deltaTime;
            yield return null;
        }
        GoH.text = highScore.ToString();
        GoS.text = score.ToString();
        
    }
    public IEnumerator levelUPAnimation()
    {
        while (levelUp.position.y <= 6f)
        {
            levelUp.position += levelUpPosChange;
            yield return null;
        }
        levelUp.position = oldlevelUpPos;
    }
}
