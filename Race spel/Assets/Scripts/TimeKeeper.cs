using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  

public class TimeKeeper : MonoBehaviour
{
    public TrackCheckpoints trackCheckpoints;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI LastLapText;
    public TextMeshProUGUI BestLapText;
    static float timer;
    public float totalTime = 0.0f;
    public float lastLapTime = 0.0f;
    public float bestLapTime = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = (float)(timer - minutes * 60);

        string time = string.Format("{0:0}:{1:00.00}", minutes, seconds);
        totalTime = minutes * 60 + seconds;
        

        timerText.text = time;

        if (Input.GetKeyDown("r"))
        {
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Racing");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Titel");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (trackCheckpoints.nextCheckpointSingleIndex == 0){
            LastLapText.text = timerText.text;
            lastLapTime = totalTime;
            timer = 0.0f;

            if (bestLapTime == 0)
            {
                BestLapText.text = LastLapText.text;
                bestLapTime = lastLapTime;
            } 
            else if (lastLapTime < bestLapTime)
            {
            BestLapText.text = LastLapText.text;
                bestLapTime = lastLapTime;
            }

        }

    }

}
