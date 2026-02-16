using System.Collections;
using UnityEngine;

public class DonutBakerScript : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] donutPrefabs;
    public GameObject goldenDonutPrefab;
    public ObjectCatchScript playerScript;

    [Header("Settings")]
    [Range(0f, 1f)]
    public float goldenChance = 0.1f;
    public float bakeInterval = 1.0f;
    public float offset = 0.7f;

    [Header("References")]
    public GameTimer gameTimer;

    float minPoz, maxPoz;
    Transform ovenTransform;

    void Start()
    {
        ovenTransform = GetComponent<Transform>();
    }

    public void BakeDonut(bool state)
    {
        if (state)
        {
            if (gameTimer != null) gameTimer.ResetTimer();
            if (gameTimer != null) gameTimer.StartTimer();
            if (playerScript != null) playerScript.ResetPlayerStats(); 

            StartCoroutine(Bake());
        }
        else
        {
            StopAllCoroutines();
            if (gameTimer != null) gameTimer.StopTimer();
        }
    }


    IEnumerator Bake()
    {
        while (true)
        {
            minPoz = ovenTransform.position.x - offset;
            maxPoz = ovenTransform.position.x + offset;
            float randPoz = Random.Range(minPoz, maxPoz);
            Vector2 spawnPoz = new Vector2(randPoz, ovenTransform.position.y);

            float chance = Random.value;

            if (chance <= goldenChance)
            {
                Instantiate(goldenDonutPrefab, spawnPoz, Quaternion.identity, ovenTransform);
            }
            else
            {
                int donutIndex = Random.Range(0, donutPrefabs.Length);
                Instantiate(donutPrefabs[donutIndex], spawnPoz, Quaternion.identity, ovenTransform);
            }

            yield return new WaitForSeconds(bakeInterval);
        }
    }
}