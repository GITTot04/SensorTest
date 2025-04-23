using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class MoveWithSensor : MonoBehaviour
{
    private void OnEnable()
    {
        /*
        if (AttitudeSensor.current != null)
        {
            InputSystem.EnableDevice(AttitudeSensor.current);
        }
        */
    }
    private void Start()
    {
        StartCoroutine("WaitAndWork");
    }

    private void Update()
    {
        
        if (AttitudeSensor.current != null /*&& !AttitudeSensor.current.enabled*/)
        {
            //InputSystem.EnableDevice(AttitudeSensor.current);
            //Debug.Log(":(");
        }
        
    }
    void OnRotate()
    {
        Debug.Log("Rotating");
        gameObject.transform.rotation = AttitudeSensor.current.attitude.ReadValue();
    }

    void EnableSensor()
    {
        if (AttitudeSensor.current != null)
        {
            InputSystem.EnableDevice(AttitudeSensor.current);
            Debug.Log(AttitudeSensor.current.enabled);
        }
    }
    IEnumerator WaitAndWork()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Time's up");
        EnableSensor();
        yield return new WaitForSeconds(2);
        Debug.Log(AttitudeSensor.current.enabled);

    }
    
}
