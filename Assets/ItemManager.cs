using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    HealthPotion,
    Food,
    Water,
    Waste,
    // 他にも必要なアイテムがあれば追加
}
public class ItemManager : MonoBehaviour
{
    // Itemの種類を表すenum
    
    // Itemクラス
    public ItemType thisItem;
    public int number;
    public void ItemDelete(){
        ItemDirector.id.SetItem(number);
        Destroy(this.gameObject);
    }
}
