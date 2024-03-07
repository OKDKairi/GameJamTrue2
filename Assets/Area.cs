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

    
    
    public AudioClip rightSound;
    public AudioClip wrongSound;
    AudioSource audioSource;
    

    void Start()
    {
        ReSeed();
        ItemTextUpdate();
        audioSource = GetComponent<AudioSource>();
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
        if(current_food < 1){
            current_food = 0;      
            ItemDirector.id.ScoreUpdate(-200);
        }

        if(current_water < 1){
            current_water = 0;
            ItemDirector.id.ScoreUpdate(-200);            
        }

        if(current_health < 1){
            current_health = 0;          
            ItemDirector.id.ScoreUpdate(-200);  
        }

        ItemTextUpdate();
    }
    
    public void ItemTextUpdate(){
        food.text = "食料"+current_food.ToString();
        water.text = "水"+current_water.ToString();
        health.text = "健康"+current_health.ToString();
    }
    public void Plus(ItemType item){
        switch(item){
            case ItemType.Waste:
                audioSource.PlayOneShot(wrongSound);
                ItemDirector.id.ScoreUpdate(-200);
                break;
            case ItemType.HealthPotion:
                current_health += 5;
                audioSource.PlayOneShot(rightSound);
                ItemDirector.id.ScoreUpdate(100);
                break;
            case ItemType.Food:
                current_food += 5;
                audioSource.PlayOneShot(rightSound);
                ItemDirector.id.ScoreUpdate(100);
                break;
            case ItemType.Water:
                current_water += 5;
                audioSource.PlayOneShot(rightSound);
                ItemDirector.id.ScoreUpdate(100);
                break;
            
        }
        ItemTextUpdate();
    }
    
}
