using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    
    [SerializeField]int currentBalance;

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
    }
    // Start is called before the first frame update

}
