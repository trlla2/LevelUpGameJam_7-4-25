using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Popup_controler : MonoBehaviour
{
    [Header("SETUP")]
    [SerializeField] private List<GameObject> popupList;
    [SerializeField] private float popupSpawnTime = 5f;
    private float popupSpawnTimer = 0;

    [Header("EVENT TRIGGER")]
    public UnityEvent OnPopupSpawn;

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

        // random popup
        int newPopUpId = Random.Range(0, popupList.Count);

        // get panel rectangle in LOCAL space
        Rect rect = rectTrans.rect;

        float sizeX = popupList[newPopUpId].GetComponent<RectTransform>().rect.size.x;
        float sizeY = popupList[newPopUpId].GetComponent<RectTransform>().rect.size.y;


        float minX = rect.xMin + sizeX / 2;
        float maxX = rect.xMax - sizeX / 2;
        float minY = rect.yMin + sizeY / 2;
        float maxY = rect.yMax - sizeY / 2;

        // generate rndom position
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector2 randomPos = new Vector3(randomX, randomY);

        GameObject temp = Instantiate(popupList[newPopUpId], rectTrans );

        temp.transform.localPosition = randomPos;
        OnPopupSpawn.Invoke();

        Image tempImage = temp.GetComponent<Image>();

        Color c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        tempImage.color = c;

        Debug.Log("Spawn powerUp: " + temp);
    }
}
