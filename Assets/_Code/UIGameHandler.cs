using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameHandler : MonoBehaviour
{
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject gameplayUI;
    [SerializeField] public GameObject endUI;
    [SerializeField] public GameObject winUI;

    void Awake()
    {
        startUI.SetActive(true);
        endUI.SetActive(false);
        winUI.SetActive(false);
        gameplayUI.SetActive(false);
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {            
            startUI.SetActive(false);
            gameplayUI.SetActive(true);
            Time.timeScale = 1f;
        }
    }
}
