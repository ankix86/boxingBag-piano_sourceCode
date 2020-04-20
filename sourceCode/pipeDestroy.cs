using UnityEngine;


public class pipeDestroy : MonoBehaviour
{
    bool canDestroy;
    public GameObject life;
    public ParticleSystem partical;
    private bool isGone = false;
    private bool spacePressed = false;
    public AudioSource audioSource;
    public audioHandler audioMan;
    public bool noBuzzer = false;

    private spawner spawnerS;
    private void Start()
    {
        canDestroy = false;
        audioMan =   GameObject.FindGameObjectWithTag("am").GetComponent<audioHandler>();
        audioSource = gameObject.GetComponent<AudioSource>();
        spawnerS = GameObject.Find("spawner").GetComponent<spawner>();
    }

    private void Update()
    {   
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            transform.GetComponent<SpriteRenderer>().color = Color.red;
            if (canDestroy && transform.position.x < 6 && !isGone && !spacePressed)
            {
                audioSource.PlayOneShot(audioMan.getCuttingFX()[Random.Range(0, audioMan.getCuttingFX().Length)], .5f);
                transform.tag = "xx";
              
                isGone = true;
                Instantiate(partical, transform.position, partical.transform.rotation);
                transform.parent.transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                GameObject.Find("spawner").GetComponent<spawner>().setCanSpawn(true);
                transform.parent.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
                gameObject.transform.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
                if (gameObject.name == "lucky")
                {
                    GameObject.Find("ScoreManager").GetComponent<scoreManager>().setScore(Random.Range(1,10));
                }
                else
                {
                    GameObject.Find("ScoreManager").GetComponent<scoreManager>().setScore(1);
                }
                Color c = transform.parent.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                c.a -= .5f;
                transform.parent.transform.GetChild(0).GetComponent<SpriteRenderer>().color = c;
                transform.gameObject.GetComponent<SpriteRenderer>().color = c;
                Destroy(gameObject, 3f);
           
                gameObject.transform.GetComponent<pipeDestroy>().enabled = false;
                 noBuzzer = true;
            }
            if (!noBuzzer && spawnerS.getStartGame())
            {
                audioSource.PlayOneShot(audioMan.buzzer, .6f);
                noBuzzer = true;
            }
            
            spacePressed = true;
        }
      
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.name == "lucky")
        {
            canDestroy = true;
        }
        if ((char)transform.gameObject.name[0] == (char)collision.gameObject.name[0] )
        {
            canDestroy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (transform.name == "lucky")
        {
            canDestroy = false;
        }
        if ((char)transform.gameObject.name[0] == (char)collision.gameObject.name[0])
        {
         
            canDestroy = false;
        }
    }

    public bool getIsCanDestroy()
    {
        return canDestroy;
    }
}
