using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CinematicController : MonoBehaviour
{
    private Animator anim;
    public static bool isCutSceneOn;

    public static event Action<bool> onCutscene;


    private void OnEnable()
    {
        OnAnimationFinished.onAnimationFinished += StopCutscene;
        CinematicTrigger.onCinematicIsTriggered += RunCinematic;
    }

    private void OnDisable()
    {
        OnAnimationFinished.onAnimationFinished -= StopCutscene;
        CinematicTrigger.onCinematicIsTriggered -= RunCinematic;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        if(GameManager.INSTANCE.currentGameState == eGameStates.GAME_VILLAGE)
        {
            RunCinematic("Introduction");
        }
    }

    private void RunCinematic(string transitionName)
    {
        anim.SetBool(transitionName, true);
        isCutSceneOn = true;
        onCutscene?.Invoke(isCutSceneOn);
    }

    private void StopCutscene(string transitionName)
    {
        anim.SetBool(transitionName, false);
        isCutSceneOn = false;
        onCutscene?.Invoke(isCutSceneOn);
    }

}
