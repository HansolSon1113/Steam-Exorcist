using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField] ItemSO ItemSO;
    public List<GameObject> items = new List<GameObject>();
    private List<ItemElements> itemElements = new List<ItemElements>();
    void Start()
    {
        foreach(ItemElements itemElement in ItemSO.items)
        {
            itemElements.Add(itemElement);
        }

        for(int i = 0; i < this.transform.childCount; i++)
        {
            GameObject spawnLocation = this.transform.GetChild(i).gameObject;
            foreach(ItemElements itemElement in itemElements)
            {
                if(itemElement.name == spawnLocation.name)
                {
                    var item = Instantiate(itemElement.fieldPrefab, spawnLocation.transform.position, Quaternion.identity);
                    ItemController itemController = item.GetComponent<ItemController>();
                    itemController.Setup(itemElement);
                    items.Add(item);
                }
            }
        }
    }
}
