using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float timeLeft = 90f;
    public GameObject TimeCounter;
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        UpdateUI();
    }

    void UpdateUI()
    {
        TimeCounter.GetComponent<TextMeshProUGUI>().text = "Time Left:"+Mathf.Floor(timeLeft).ToString();
        if(timeLeft <= 0)
        {
            GameOver.SetActive(true);
        }
    }
    public void OnWin()
    {
        GameOver.SetActive(true);
        GameOver.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "You Win";
    }

    public void OnLose()
    {
        GameOver.SetActive(true);
    }
}
