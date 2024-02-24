using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode_Odin : MonoBehaviour
{
    Script_SceneStateController currentSceneStateController = new Script_SceneStateController();

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        //�H�D��欰��l�a��
        currentSceneStateController.SetSceneState(new SceneState_MainMenu(currentSceneStateController));



    }

    // Update is called once per frame
    void Update()
    {
        currentSceneStateController.SceneStateUpdate();
    }
}
