using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] float timeDelay = 1f;

    [SerializeField] TextMeshProUGUI displayBalance;
    private void Awake()
    {
        currentBalance = startingBalance;
        updateDisplay();
    }
    public int CurrentBalance { get { return currentBalance; } }

    public void Deposit(int Amount)
    {
        currentBalance += Mathf.Abs(Amount);
        updateDisplay();
    }

    public void Withdraw(int Amount)
    {
        currentBalance -= Mathf.Abs(Amount);
        updateDisplay();
        if(currentBalance < 0)
        {
            Invoke("ReloadScene", timeDelay);
            //GameLost
        }
    }
    // Start is called before the first frame update
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void updateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }
}
