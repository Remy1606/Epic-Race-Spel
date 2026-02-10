using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;  

public class RaceStart : MonoBehaviour
{
    public GameObject countdown;
    public GameObject car;
    public GameObject timer;

    void Start()
    {
        StartCoroutine(StartRaceCoroutine());
    }

    IEnumerator StartRaceCoroutine()
    {
        car.GetComponent<PlayerController>().enabled = false;
        timer.GetComponent<TimeKeeper>().enabled = false;
        yield return new WaitForSeconds(1);
        countdown.GetComponent<Text>().color = Color.red;
        countdown.GetComponent<Animation>().Play("RaceStartAnim");
        countdown.GetComponent<Text>().text = "3";
        yield return new WaitForSeconds(1);
        countdown.GetComponent<Text>().color = new Color(1f, 0.5f, 0f);
        countdown.GetComponent<Animation>().Play("RaceStartAnim");
        countdown.GetComponent<Text>().text = "2";
        yield return new WaitForSeconds(1);
        countdown.GetComponent<Text>().color = Color.yellow;
        countdown.GetComponent<Animation>().Play("RaceStartAnim");
        countdown.GetComponent<Text>().text = "1";
        yield return new WaitForSeconds(1);
        countdown.GetComponent<Text>().color = Color.green;
        countdown.GetComponent<Animation>().Play("RaceStartAnim");
        countdown.GetComponent<Text>().text = "GO!";
        car.GetComponent<PlayerController>().enabled = true;
        timer.GetComponent<TimeKeeper>().enabled = true;
    }

    void Update()
    {
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

}
