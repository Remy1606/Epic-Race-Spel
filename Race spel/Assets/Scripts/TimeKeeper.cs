using UnityEngine;
using TMPro;

public class TimeKeeper : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    static float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer/60);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);


        string time = string.Format("{0:0}:{01:00}", minutes, seconds);

        timerText.text = time;
    }
}
