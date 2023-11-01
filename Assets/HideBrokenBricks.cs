using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBrokenBricks : StateMachineBehaviour
{
    [SerializeField] string gameObjectName;
    private GameObject brokenBrick;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        brokenBrick = GameObject.Find(gameObjectName);
        brokenBrick.SetActive(false);
    }
}
