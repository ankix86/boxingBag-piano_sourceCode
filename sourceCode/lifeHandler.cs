using System.Collections;
using UnityEngine;


public class lifeHandler : MonoBehaviour
{
    private int c, totalChildCount;
    public spawner spawnerScript;
    public Vector3 GameOverUpPosChange;
    public scoreManager socreMan;
    public Animator gameOverAnime;
    private bool gameOver = false;

    
    void Start()
    {
        c = 0;
        totalChildCount = transform.GetChildCount();
    }
    public bool isGameOver()
    {
        return gameOver;
    }
    public void LifeLost()
    {
        if (c < totalChildCount)
        {
            transform.GetChild(c).GetComponent<SpriteRenderer>().color = Color.red;
            transform.GetChild(c).transform.GetChild(0).gameObject.SetActive(true);
            c++;
            spawnerScript.setCanPlayerSpawn(true);
        }
        else
        {
            gameOver = true;
            socreMan.setHighScore();
            gameOverAnime.SetBool("gameOver", true);
            Debug.Log("GameOver");
        }
    }

}
