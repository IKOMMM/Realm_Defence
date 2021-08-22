using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PointHandler : MonoBehaviour
{
    [SerializeField] int startBalance = 200;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] UIGameHandler uiGameHandler;

    [SerializeField] AudioSource winSFX;
    [SerializeField] AudioSource loseSFX;

    private void Awake()
    {
        currentBalance = startBalance;
        UpdateDisplay();
    }

    public void PointDeposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();

        if (currentBalance > 1000)
        {
            uiGameHandler.winUI.SetActive(true);
            winSFX.Play();
            Invoke(nameof(ReloadScene), 6f);
        }
    }

    public void WithdrawPoints(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentBalance < 0)
        {
            uiGameHandler.endUI.SetActive(true);
            loseSFX.Play();
            Invoke(nameof(ReloadScene), 6f);
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Points: " + currentBalance;
    }


    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
        
}
