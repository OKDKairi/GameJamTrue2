using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemDirector : MonoBehaviour
{
    [SerializeField] Transform[] SetPositions;
    public static ItemDirector id;
    public GameObject[] Items;

    public int PackingInday;
    private int count = 0;

    private int days = 1;
    private int score = 0;

    public Text DaysText;
    public Text ScoreText;
    public Text PackingInDays;

    void Awake(){
        id = this;
        SetItemAll();
    }

    void CountPacking(){
        count++;
        if(count == PackingInday){
            count = 0;
            days++;
        }
    }
    public void StaticTextUpdate(){
        DaysText.text = days.ToString() + "日目";
        ScoreText.text = score.ToString() + "点";
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
