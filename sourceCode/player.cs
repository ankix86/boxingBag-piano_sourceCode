using UnityEngine;

public class player : MonoBehaviour
{
    public lifeHandler life;
    public AudioSource audioSource;
    private void Start()
    {
       
        life = GameObject.Find("life").GetComponent<lifeHandler>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "ground")
        {
            audioSource.Play();
        }
        
        if (collision.gameObject.CompareTag("spike"))
        { 
            life.LifeLost();
            Destroy(gameObject);
        }
    
    }

}
