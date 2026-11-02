using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using System;
public class Timer : MonoBehaviour
{
    #region Variables

    [SerializeField] private TextMeshProUGUI timerText;

    public float currentTime = 120f; 
    private bool isTimerActive = true;

    #endregion

    #region Unity Functions (Start and Update)
    private void Start()
    {
        GameObject text = GameObject.Find("CountdownTimer"); // Name your timer text CountdownTimer so it can automatically assign the text reference here
        if(text != null)
        {
            timerText = text.GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTimerActive)
        {
            return;
        }

        currentTime -= Time.deltaTime;
        UpdateTimerText();

        if (currentTime <= 0)
        {
            StopTimer();
        }
    }

    #endregion

    #region Script Functions
    private void UpdateTimerText()
    {
        if (currentTime > 0 && currentTime < 30)
        {
            timerText.color = Color.yellow;
        }
        else if(currentTime < 10)
        {
            timerText.color = Color.red;
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = time.TotalSeconds.ToString("F0");
    }

    private void StopTimer()
    {
        isTimerActive = false;
        currentTime = 0f;
        UpdateTimerText();
    }

    #endregion
}
