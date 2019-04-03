using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int startHealth = 50;
    private int currentHealth;
    public int damage;

    public Text playerHealth ;
    public Text score;

    private int temp;

    public static int currentScore = 0;

    public SceneLoader _SceneLoader;
    
    // Start is called before the first frame update
    void Start()
    {

        currentHealth = startHealth;
       
        playerHealth.text = $"Health: {startHealth.ToString()}/{startHealth.ToString()}";
    }

    
    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
            PlayerDeath();
        score.text = "Score " +  currentScore.ToString();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Hit();
            Destroy(other.gameObject);
        }
    }

    void Hit()
    {
        currentHealth -= damage;
        playerHealth.text = $"Health: {currentHealth.ToString()}/{startHealth.ToString()}";
        
    }

    void PlayerDeath()
    {
       
        if (PlayerPrefs.GetInt("Highscore") < currentScore)
        {
            temp = PlayerPrefs.GetInt("Highscore");
            PlayerPrefs.SetInt("Highscore", currentScore);
            currentScore = temp;
        }

        if (PlayerPrefs.GetInt("Highscore2") < currentScore)
        {
            temp = PlayerPrefs.GetInt("Highscore2");
            PlayerPrefs.SetInt("Highscore2", currentScore);
            currentScore = temp;
        }

        if (PlayerPrefs.GetInt("Highscore3") < currentScore)
        {
            temp = PlayerPrefs.GetInt("Highscore3");
            PlayerPrefs.SetInt("Highscore3", currentScore);
            currentScore = temp;
        }


        if (PlayerPrefs.GetInt("Highscore4") < currentScore)
        {
            temp = PlayerPrefs.GetInt("Highscore4");
            PlayerPrefs.SetInt("Highscore4", currentScore);
            currentScore = temp;
        }

        if (PlayerPrefs.GetInt("Highscore5") < currentScore)
        {
            temp = PlayerPrefs.GetInt("Highscore5");
            PlayerPrefs.SetInt("Highscore5", currentScore);
            currentScore = temp;
        }

        SceneManager.LoadScene("GameOver"); //Ask about this, Scene MAnager script wasnt working
       


    }

}
