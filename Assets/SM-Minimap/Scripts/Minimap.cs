using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[System.Serializable]
public class ItemData
{
    public string itemName;
    public Image itemIcon;
    public Color itemColor;
    public bool useColor;
}

public class Minimap : MonoBehaviour
{
    [Header("Minimap Follow")] public GameObject minimapFollow;

    public float mapFollowSpeed;

     public float mapYPosition;

     public bool rotateWithFollowTarget;

     public List<ItemData> itemsList;

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, mapYPosition, transform.position.z);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, mapYPosition, transform.position.z),
            new Vector3(minimapFollow.transform.position.x, mapYPosition, minimapFollow.transform.position.z), mapFollowSpeed * Time.deltaTime);

        if (rotateWithFollowTarget)
        {
            transform.rotation =
                Quaternion.RotateTowards(new Quaternion(0, transform.rotation.y, 0, transform.rotation.w),
                    new Quaternion(0, minimapFollow.transform.rotation.y, 0, minimapFollow.transform.rotation.w),
                    mapFollowSpeed);
        }
    }
}
