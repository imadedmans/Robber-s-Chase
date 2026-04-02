using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessManager : MonoBehaviour
{
    public Transform roadLoader;
    public GameObject[] roads;
    public float positionRelocator;

    int roadChoser;
    GameObject currentRoad;
    public Text scoreBoard; 
    public Transform player;

    void Start()
    {
        StartCoroutine(Randomiser());
    }

    void Update()
    {
        float playerPositionAmount = player.position.z - 274; 
        scoreBoard.text = playerPositionAmount.ToString("0");
    }

    IEnumerator Randomiser()
    {
        roadChoser = Random.Range(0, roads.Length);
        currentRoad = roads[roadChoser];
        Debug.Log(roadChoser);

        Instantiate(currentRoad, roadLoader.position, roadLoader.rotation);
        roadLoader.position += new Vector3(0f, 0f, positionRelocator);

        yield return new WaitForSeconds(5f);
        StartCoroutine(Randomiser());
    }
}
