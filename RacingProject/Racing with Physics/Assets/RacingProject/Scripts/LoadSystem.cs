using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSystem : MonoBehaviour
{
    public GameObject car1 = null;
    public GameObject car2 = null;
    public VehicleBehaviour.Utils.CameraFollow cameraFollow = null; 
    Timer timer;
    Countdown countdown;

    private void Awake()
    {
        timer = GetComponent<Timer> ();
        countdown = GetComponent<Countdown>();

        int id = PlayerPrefs.GetInt( "car", 0 );

        if (id == 0)
        {
            timer.vehicle = car1.GetComponent<VehicleBehaviour.WheelVehicle> ();
            countdown.vehicle = car1.GetComponent<VehicleBehaviour.WheelVehicle> ();
            cameraFollow.target = car1.transform;

            if (car1)
            {
                car1.SetActive(true);
            }
            

        }
        else if (id == 1)
        {
            timer.vehicle = car2.GetComponent<VehicleBehaviour.WheelVehicle>();
            countdown.vehicle = car2.GetComponent<VehicleBehaviour.WheelVehicle>();
            cameraFollow.target = car2.transform;
            if ( car2)
            {
                car2.SetActive(true);
            }
            

        }
    }
}
