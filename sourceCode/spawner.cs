using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    public GameObject[] pipes;
    private GameObject spawnedPipe;
    public Vector3 position;
    public Transform limiter;
    private int lastSpawned;
    private bool mouseCliecked;
    public bool canSpawned = true;
    public GameObject player;
    public Transform playerSpawn;
    private bool canPlayerSpawn = true;
    public lifeHandler life;
    private bool startGame = false;
    public GameObject startGamePanel;
    public GameObject luckyPipe;
    int luckypipcount;
        private void Start()
    {
        luckypipcount = Random.Range(12, 20);
        startGamePanel.SetActive(true);
    }
    void Update()
    {
        if(!startGame && Input.GetKeyDown(KeyCode.Mouse0))
        {
            startGame = true;
            transform.GetComponent<AudioSource>().Play();
            startGamePanel.SetActive(false);
        }
        if(!startGame)
            return;
        if (life.isGameOver())
            return;
        if (canPlayerSpawn)
        {
            Instantiate(player, playerSpawn.position, playerSpawn.rotation);
            canPlayerSpawn = false;
        }
        if (!canSpawned)
        {
            if(spawnedPipe.transform.position.x < limiter.position.x)
            {
                Destroy(spawnedPipe);
                ///spawnedPipe.transform.parent.transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                canSpawned = true;
            }
            else
            {
                spawnedPipe.transform.position += position;
            }
        }
        else
        {
            int  value = Random.Range(0, pipes.Length); 
            if (lastSpawned == value)
            {
                value = Random.Range(0, pipes.Length);
            }
            lastSpawned = value;
       
            if (luckypipcount != 0)
            {
                luckypipcount--;
                spawnedPipe = Instantiate(pipes[lastSpawned], transform.position, Quaternion.identity);
            }
            else
            {
                luckypipcount = Random.Range(12, 20);
                spawnedPipe = Instantiate(luckyPipe, transform.position, Quaternion.identity);
            }
            canSpawned = false;
        }
    }
    public void setCanPlayerSpawn(bool value)
    {
        canPlayerSpawn = value;
    }
    public void setCanSpawn(bool value)
    {
        canSpawned = value;
    }
 
    public void speedIncress()
    {
        position.x -= .025f;
    }

    public bool getStartGame(){
        return startGame;
    }
     public void setStartGame(bool value){
        startGame = value;
    }
    public string GetspawnedPipe()
    {
        return lastSpawned.ToString();
    }
    public GameObject GetspawnedObj()
    {
        return spawnedPipe;
    }

    public bool GetmouseClicked()
    {
        return mouseCliecked;
    }
    public void DestroyPipe()
    {
        Destroy(spawnedPipe);
    }
}
