using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirTimeDisplay : MonoBehaviour
{
    public Image airTimeBar;
    private float maxAirTime = 10.0f;
    private float currentAirTime = 0.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            Float();
        float fillPercentage = (maxAirTime - currentAirTime) / maxAirTime;
        airTimeBar.fillAmount = fillPercentage;
    }

    private void Float()
    {
        if (currentAirTime < maxAirTime)
        {
            currentAirTime += Time.deltaTime;
        }

    }
}

