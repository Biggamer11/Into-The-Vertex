

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    
    public AudioSource win;
    public AudioSource loose;
    public AudioSource rouge;
    public AudioSource notworking;
    public int score = 0;
    public int red = 0;
    public int green = 0;
    public int blue = 0;
    public int lives = 3;
    private int finalscore;
    private bool final;
    public GameObject player;
    public GameObject fade;

    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }


    }

    private void Start()
    {
       
    }


    public void DecLives()
    {
        lives -= 1;
        if (lives < 0 && final == false)
        {
            finalscore = score;
            final = true;
            Debug.Log("Final");
            
            loose.Play();
            StartCoroutine(End());

            player.SetActive(false);
            fade.SetActive(true);

        }
        if (lives < 0)
        {
            lives = 0;
        }
    }
    public void IncLives()
    {
        lives += 1;
    }

    public int GetLives()
    {
        return lives;
    }

    public void DecScore()
    {
        score -= 1;
    }
    public void IncScore()
    {
        score += 1;

        if (score >= 3)
        {
            if (GetRed() >= 2)
            {
                rouge.Play();
            }
            else if (green >= 2)
            {
                win.Play();
            }
            else if (blue >= 2)
            {
                notworking.Play();
            }
            
            else
            {
                notworking.Play();
            }
            
            StartCoroutine(End());
            fade.SetActive(true);
            player.SetActive(false);
        }
        
        
    }

    public int GetScore()
    {
        return score;
    }

    public void IncGreen()
    {
        IncScore();
        green += 1;
    }
    public void IncRed()
    {
        IncScore();
        red += 1;
    }
    public void IncBlue()
    {
        IncScore();
        blue += 1;
    }

    public int GetGreen()
    {
        return green;
    }
    public int GetRed()
    {
        return red;
    }
    public int GetBlue()
    {
        return blue;
    }

    IEnumerator End()
    {
        

        yield return new WaitForSeconds(20);
        LoadScene("PreStage");
    }

    public void LoadScene(string Level)
    {
        if (Level == "Stage 1")
        {
            SceneManager.LoadScene("Stage1");
        }

        if (Level == "Main Menu")
        {
            Debug.Log("Not Implemented");
        }

        if (Level == "PreStage")
        {
            SceneManager.LoadScene("preStage");
        }
    }
}
