using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorScript : MonoBehaviour
{
    public Transform target; // Reference to the target object
    public GameObject indicatorPrefab; // Reference to the indicator prefab

    private RectTransform rectTransform;
    private GameObject indicatorInstance;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        indicatorInstance = Instantiate(indicatorPrefab, transform);
    }

    private void Update()
    {

        Vector3 targetPosition = Camera.main.WorldToViewportPoint(target.position);
        bool isOffScreen = targetPosition.x < 0 || targetPosition.x > 1 || targetPosition.y < 0 || targetPosition.y > 1;

        indicatorInstance.SetActive(isOffScreen);

        if (isOffScreen)
        {

            Vector3 indicatorPosition = Camera.main.WorldToScreenPoint(target.position);
            rectTransform.position = indicatorPosition;
        }
    }
}
