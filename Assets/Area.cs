using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    // Areaクラスの変数
    public int current_food;
    public int day_food;
    public int current_water;
    public int day_water;
    public int current_clean;
    public int day_clean;
    void Start()
    {

    }  
    public void Plus(ItemType item){
        switch(item){
            case ItemType.HealthPotion:
                current_clean += 2;
                break;
            case ItemType.Food:
                current_food += 2;
                break;
            case ItemType.Water:
                current_water += 2;
                break;
            case ItemType.Waste:
                break;
        }
    }
    
}
