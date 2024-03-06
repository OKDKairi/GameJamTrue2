using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDirector : MonoBehaviour
{
    [SerializeField] Transform[] SetPositions;
    public static ItemDirector id;
    public GameObject[] Items;

    void Awake(){
        id = this;
        SetItemAll();
    }

    public void SetItem(int num){
        GameObject item = Instantiate(Items[Random.Range(0, Items.Length)], SetPositions[num].transform.position,Quaternion.identity);
        item.GetComponent<ItemManager>().number = num;
    }
    public void SetItemAll(){
        for(int i = 0; i < 4; i++){
            SetItem(i);
        }
    }
}
