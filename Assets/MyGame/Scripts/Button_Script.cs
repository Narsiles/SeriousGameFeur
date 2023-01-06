using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour
{
    [SerializeField] GameObject Option;
    [SerializeField] GameObject Vic1;
    [SerializeField] GameObject Vic2;
    [SerializeField] GameObject Vic3;
    [SerializeField] GameObject Vic4;
    [SerializeField] GameObject sPlayer;
    [SerializeField] GameObject sThree;
    [SerializeField] GameObject SoundOn;
    [SerializeField] GameObject SoundOff;
    [SerializeField] GameObject signUI1;
    [SerializeField] GameObject signUI2;
    [SerializeField] GameObject signUI3;

    public void QuestOneAccept()
    {
        Destroy(sThree);
        sPlayer.SetActive(true);
        FindObjectOfType<GameManager>().SpawnGarden1();
        FindObjectOfType<Three>().QuestOneAccept();
        FindObjectOfType<NavArrow>().QuestOneAccept();
    }

    public void QuestTwoAccept()
    {
        FindObjectOfType<GameManager>().SpawnGarden2();
        FindObjectOfType<Three>().QuestTwoAccept();
        FindObjectOfType<NavArrow>().QuestTwoAccept();
    }

    public void QuestTreeAccept()
    {
        FindObjectOfType<GameManager>().SpawnGarden3();
        FindObjectOfType<Three>().QuestTreeAccept();
        FindObjectOfType<NavArrow>().QuestTreeAccept();
        FindObjectOfType<PlayerController>().Upgrade();
    } 
    
    public void QuestFourAccept()
    {
        FindObjectOfType<GameManager>().SpawnGarden4();
        FindObjectOfType<Three>().QuestFourAccept();
        FindObjectOfType<NavArrow>().QuestFourAccept();
    }

    public void signItem1()
    {
        signUI1.SetActive(false);
        Time.timeScale = 1;
    }

    public void signItem2()
    {
        signUI2.SetActive(false);
        Time.timeScale = 1;
    }

    public void signItem3()
    {
        signUI3.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Option.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Victoir1()
    {
        Vic1.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Victoir2()
    {
        Vic2.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void sound()
    {
        AudioListener.volume = 1;
        SoundOn.gameObject.SetActive(false); 
        SoundOff.gameObject.SetActive(true);
    }

    public void soundOff()
    {
        AudioListener.volume = 0;
        SoundOff.gameObject.SetActive(false);
        SoundOn.gameObject.SetActive(true);
    }


    public void Victoir3()
    {
        Vic3.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Victoir4()
    {
        Vic4.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReturnVictoir1()
    {
        Vic1.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ReturnVictoir2()
    {
        Vic2.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnVictoir3()
    {
        Vic3.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Play() 
    {
        Option.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
