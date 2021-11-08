using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text lapTimeText = null;
    public Text bestTimeText = null;
    public Text lapCounterText = null;
    public TextMesh lapText = null;
    public GameObject raceCompleteUi = null;

    [ HideInInspector ] public bool checkpointReached = true;
    public int lapCountTotal = 3;

    float startTime;
    float ellapsedTime;
    float bestTime = 1000;
    int lapCounter = 0;
    bool startCounting = false;
    bool enableBestTIme = false;
    bool countTime = false;

    public VehicleBehaviour.WheelVehicle vehicle;

    private void Update()
    {
        if (startCounting)
        {
            startCounting = false;
            startTime = Time.time;
            countTime = true;

        }

        if (countTime)
        {
            ellapsedTime = Time.time - startTime;
            lapTimeText.text = ellapsedTime.ToString("f2"); 

        }
        lapText.text = LapLabel();
        lapCounterText.text = lapCounter.ToString() + " / " + lapCountTotal;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Trigger")
        {
            if (ellapsedTime<= bestTime && enableBestTIme && checkpointReached)
            {
                bestTime = ellapsedTime;
                bestTimeText.text = lapTimeText.text;
            }
            if (checkpointReached)
            {
                checkpointReached = false;
                startCounting = true;
                lapCounter++;
            }
            if (lapCounter == lapCountTotal + 1)
            {
                vehicle.IsPlayer = false;
                raceCompleteUi.SetActive( true );
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Trigger")
        {
            enableBestTIme = true;
        }
    }

    string LapLabel()
    {
        string val = "";

        switch (lapCounter)
        {
            case 0: val = "START"; break;
            case 1: val = "LAP 2"; break;
            case 2: val = "LAP 3"; break;
            case 3: val = "FINISH!"; break ;
            default: val = ""; break;
        }

        return val;
    }
    public void GoToLevel( int id )
    {
        SceneManager.LoadScene( id );
    }
}
