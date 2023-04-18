using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamePhase { NORMALPHASE, ZONEPHASE }

public class ZoneManager : MonoBehaviour
{
    [SerializeField] private float normalPhaseDuration;
    [SerializeField] private float zonePhaseDuration;
    [SerializeField] private float phaseDuration;
    [SerializeField] private GamePhase phase;
    [SerializeField] private GameObject zone;

    private float phaseDurationCD = 0;

    private void Update()
    {
        if(phaseDurationCD < phaseDuration)
        {
            phaseDurationCD += Time.deltaTime;
        }
        else
        {
            SwapPhase();
        }

    }

    private void SwapPhase()
    {
        if(phase == GamePhase.NORMALPHASE)
        {
            phase = GamePhase.ZONEPHASE;
            phaseDuration = zonePhaseDuration;
            GameObject g = Instantiate(zone, transform.position, Quaternion.identity);
            g.GetComponent<ZoneController>().Setup(phaseDuration);
        }
        else
        {
            phase = GamePhase.NORMALPHASE;
            phaseDuration = normalPhaseDuration;
        }
        phaseDurationCD = 0;
    }
}
