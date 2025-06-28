using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int score = 0;
    public TMP_Text scoreText;

    public TMP_Text timeText;
    public TMP_Text countdownText;
    public float countdownDuration = 3f;
    
    private float timeElapsed;
    public bool gameStarted = false;


    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        float count = countdownDuration;


        while (count > 0f)
        {
            countdownText.text = Mathf.Ceil(count).ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }

        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
        
        gameStarted = true;
        timeElapsed = 0f;
    }


    private void Update()
    {
        if (!gameStarted) return;
        
        timeElapsed += Time.deltaTime;
        timeText.text = "Zeit: " + timeElapsed.ToString("F1") + "s";
    }


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    public void AddPoints(int amount)
    {
        score += amount;
        UpdateUI();
    }


    void UpdateUI()
    {
        scoreText.text = "Punkte: " + score;
    }
}
