using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField] ItemSO ItemSO;
    public List<GameObject> Items = new List<GameObject>();
    private List<ItemElements> ItemElements = new List<ItemElements>();
    void Start()
    {
        foreach(ItemElements ItemElement in ItemSO.items)
        {
            ItemElements.Add(ItemElement);
        }

        for(int i = 0; i < this.transform.childCount; i++)
        {
            GameObject spawnLocation = this.transform.GetChild(i).gameObject;
            foreach(ItemElements ItemElement in ItemElements)
            {
                if(ItemElement.name == spawnLocation.name)
                {
                    var Item = Instantiate(ItemElement.prefab, spawnLocation.transform.position, Quaternion.identity);
                    // ItemController ItemController = Item.GetComponent<ItemController>();
                    // ItemController.Setup(ItemElement.Item, ItemElement.health, ItemElement.maxHealth);
                    Items.Add(Item);
                    break;
                }
            }
        }
    }
}
