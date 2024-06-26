using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TestUI : MonoBehaviour
{
    private VisualElement _root;
    private Button _spawnBall;
    private Button _spawnCube;
    private Button _clearAll;
    private IntegerField _numSpawn;

    private int intSpawn;

    private void Start() 
    {
        this._root = GetComponent<UIDocument>().rootVisualElement;
        this._spawnBall = this._root.Q<Button>("SpawnBall");
        this._spawnCube = this._root.Q<Button>("SpawnCube");
        this._clearAll = this._root.Q<Button>("ClearAll");
        this._numSpawn = this._root.Q<IntegerField>("InputNum");

        this._spawnBall.clicked += this.OnSpawnBallClicked;
        this._spawnCube.clicked += this.OnSpawnCubeClicked;
        this._clearAll.clicked += this.OnClearAllClicked;
    }

    private void OnSpawnBallClicked()
    {
        //Init Params
        if(this._numSpawn.text == "...") 
        {
            intSpawn = 0;
            Debug.Log("Invalid Input");
        }
        else intSpawn = int.Parse(this._numSpawn.text);
        Parameters parameters = new Parameters();
        parameters.PutExtra(TestSpawn.NUM_SPAWN_KEY, intSpawn);

        //Init Observer for SpawnBall
        EventBroadcaster.Instance.PostEvent(EventNames.Spawner.ON_SPAWN_BALL, parameters);

        //Debug
        Debug.Log(intSpawn);
    }

    private void OnSpawnCubeClicked()
    {
        //Init Params
        if(this._numSpawn.text == "...") 
        {
            intSpawn = 0;
            Debug.Log("Invalid Input");
        }
        else intSpawn = int.Parse(this._numSpawn.text);
        Parameters parameters = new Parameters();
        parameters.PutExtra(TestSpawn.NUM_SPAWN_KEY, intSpawn);

        //Init Observer for SpawnCube
        EventBroadcaster.Instance.PostEvent(EventNames.Spawner.ON_SPAWN_CUBE, parameters);

        //Debug
        Debug.Log(intSpawn);
    }

    private void OnClearAllClicked()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.Spawner.ON_CLEAR_ALL);

        //Debug
        Debug.Log("All Objects Cleared.");
    }
}
