using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespam;
    public int gemsCollected;

    private void Awake()
    {

        instance = this;
    }
    void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespam);
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position=CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();
        
    }

}

