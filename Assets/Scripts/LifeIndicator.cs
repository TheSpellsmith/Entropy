using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIndicator : MonoBehaviour
{
    [SerializeField] private int lifeNum;

    private void Update()
    {
        if(GameManager.Instance.playerLives >= lifeNum)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
} 
