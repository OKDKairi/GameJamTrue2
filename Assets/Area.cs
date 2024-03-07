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

    public int PackingInday;
    private int count = 0;

    private int days = 1;
    private int score;

    public Text DaysText;
    public Text ScoreText;
    
    public AudioClip rightSound;
    public AudioClip wrongSound;
    AudioSource audioSource;
    void CountPacking(){
        count++;
        if(count == PackingInday){
            count = 0;
            days++;
        }
    }
    

    void Start()
    {
        ReSeed();
        TextUpdate();
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
        TextUpdate();
    }
    public void TextUpdate(){
        food.text = "食料"+current_food.ToString();
        water.text = "水"+current_water.ToString();
        health.text = "健康"+current_health.ToString();
    }
    public void Plus(ItemType item){
        switch(item){
            case ItemType.HealthPotion:
                current_health += 4;
                audioSource.PlayOneShot(rightSound);
                break;
            case ItemType.Food:
                current_food += 4;
                audioSource.PlayOneShot(rightSound);
                break;
            case ItemType.Water:
                current_water += 4;
                audioSource.PlayOneShot(rightSound);
                break;
            case ItemType.Waste:
            audioSource.PlayOneShot(wrongSound);
                break;
        }
        TextUpdate();
    }
    
}
