using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    
    [SerializeField]int currentBalance;

    [SerializeField] float timeDelay = 1f;

    private void Awake()
    {
        currentBalance = startingBalance;
    }
    public int CurrentBalance { get { return currentBalance; } }

    public void Deposit(int Amount)
    {
        currentBalance += Mathf.Abs(Amount);
    }

    public void Withdraw(int Amount)
    {
        currentBalance -= Mathf.Abs(Amount);

        if(currentBalance < 0)
        {
            Invoke("ReloadScene", timeDelay);
            
        }
    }
    // Start is called before the first frame update
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
