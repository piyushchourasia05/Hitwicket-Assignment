using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform player;
    [Header("OnStart")]
    public GameObject[] objectsToEnableOnStart;
    public GameObject[] objectsToDisableOnStart;
    [Header("OnDeath")]
    public GameObject[] objectsToEnableOnDeath;
    public GameObject[] objectsToDisableOnDeath;
    [Header("OnControl")]
    public GameObject[] objectsToEnableOnControl;
    public GameObject[] objectsToDisableOnControl;

    void Start()
    {
        instance = this;
    }

    public void StartGame()
    {
        Camera.main.transform.parent = player;
        foreach (GameObject objectToEnable in objectsToEnableOnStart)
        {
            objectToEnable.SetActive(true);
        }
        foreach (GameObject objectToDisable in objectsToDisableOnStart)
        {
            objectToDisable.SetActive(false);
        }
    }
    

    
    public void Control(){
         foreach (GameObject objectToEnable in objectsToEnableOnControl)
        {
            objectToEnable.SetActive(true);
        }
        foreach (GameObject objectToDisable in objectsToDisableOnControl)
        {
            objectToDisable.SetActive(false);
        }
    }
    public void Death()
    {
        foreach (GameObject objectToEnable in objectsToEnableOnDeath)
        {
            objectToEnable.SetActive(true);
        }
        foreach (GameObject objectToDisable in objectsToDisableOnDeath)
        {
            objectToDisable.SetActive(false);
        }
    }
    public void Exit(){
        Application.Quit();
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

