using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.UI;

public class Popup_controler : MonoBehaviour
{
    [Header("SETUP")]
    [SerializeField] private List<GameObject> popupList;
    [SerializeField] private float popupSpawnTime = 5f;
    private float popupSpawnTimer = 0;
    private int numPopupSpawned = 1;


    private RectTransform rectTrans;

    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(popupSpawnTimer >= popupSpawnTime)
        {
            popupSpawnTimer = 0;

            SpawnPopup();
        }
        else
        {
            popupSpawnTimer += Time.deltaTime;
        }
    }

    private void SpawnPopup()
    {
        if(popupList.Count == 0)
        {
            Debug.LogError("No Popup in the list");
        }
        numPopupSpawned++;

        // Random between all pop
        int newPopUpId = Random.Range(0, popupList.Count);

        // Get the panel's rectangle in LOCAL space
        Rect rect = rectTrans.rect;

        float sizeX = popupList[newPopUpId].GetComponent<RectTransform>().rect.size.x;
        float sizeY = popupList[newPopUpId].GetComponent<RectTransform>().rect.size.y;


        float minX = rect.xMin + sizeX / 2;
        float maxX = rect.xMax - sizeX / 2;
        float minY = rect.yMin + sizeY / 2;
        float maxY = rect.yMax - sizeY / 2;

        // Generate random position
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        //Debug.Log("RectX: min" + rect.xMin + ", max " + rect.xMax);
        //Debug.Log("RectY: min" + rect.yMin + ", max " + rect.yMax);
        //Debug.Log("Random X: " + randomX + "Random Y: " + randomY);

        Vector2 randomPos = new Vector3(randomX, randomY, numPopupSpawned);

        GameObject temp = Instantiate(popupList[newPopUpId], rectTrans );

        temp.transform.localPosition = randomPos;

        temp.GetComponent<RawImage>().color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));

        Debug.Log("Spawn powerUp: " + temp);
    }
}
