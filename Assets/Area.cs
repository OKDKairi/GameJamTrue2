using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Area : MonoBehaviour
{
    // Areaクラスの変数
    private int current_food;
    public int day_food;
    private int current_water;
    public int day_water;
    private int current_health;
    public int day_health;

    public int Max;
    public int Min;

    public Text food;
    public Text water;
    public Text health;
    void Start()
    {
        ReSeed();
        TextUpdate();
    }  
    private void ReSeed(){
        current_food = Random.Range(Min, Max + 1);
        current_water = Random.Range(Min, Max + 1);
        current_health = Random.Range(Min, Max + 1);
    }
    public void Minus(){
        current_food -= day_food;
        current_water -= day_water;
        current_health -= day_health;
        TextUpdate();
    }
    public void TextUpdate(){
        food.text = "食料"+current_food.ToString();
        water.text = "水"+current_water.ToString();
        health.text = "健康"+current_water.ToString();
    }
    public void Plus(ItemType item){
        switch(item){
            case ItemType.HealthPotion:
                current_health += 2;
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
        TextUpdate();
    }
    
}
