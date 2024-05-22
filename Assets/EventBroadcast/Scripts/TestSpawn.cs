using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    //Init Ball and Cube GameObject From Scene
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject cube;
    [SerializeField] private List<GameObject> objectList;
    
    public const string NUM_SPAWN_KEY = "NUM_SPAWN_KEY";
    void Start()
    {
        this.ball.SetActive(false);
        this.cube.SetActive(false);
        EventBroadcaster.Instance.AddObserver(EventNames.Spawner.ON_SPAWN_BALL, this.OnSpawnBallEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.Spawner.ON_SPAWN_CUBE, this.OnSpawnCubeEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.Spawner.ON_CLEAR_ALL, this.OnClearAllEvent);
    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Spawner.ON_SPAWN_BALL);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Spawner.ON_SPAWN_CUBE);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Spawner.ON_CLEAR_ALL);
    }

    private void OnSpawnBallEvent(Parameters parameters)
    {
        int numSpawn = parameters.GetIntExtra(NUM_SPAWN_KEY, 1);
        for(int i = 0; i < numSpawn; i++) {
            GameObject instance = GameObject.Instantiate(this.ball, this.transform);
            instance.SetActive(true);
            this.objectList.Add(instance);
        }
    }
    private void OnSpawnCubeEvent(Parameters parameters)
    {
        int numSpawn = parameters.GetIntExtra(NUM_SPAWN_KEY, 1);
        for(int i = 0; i < numSpawn; i++) {
            GameObject instance = GameObject.Instantiate(this.cube, this.transform);
            instance.SetActive(true);
            this.objectList.Add(instance);
        }
    }

    private void OnClearAllEvent()
    {
        //Insert Code

        for (int i = 0; i < this.objectList.Count; i++)
        {
            GameObject.Destroy(this.objectList[i].gameObject);
        }

        this.objectList.Clear();
    }
}
