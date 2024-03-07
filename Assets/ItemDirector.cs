using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ItemDirector : MonoBehaviour
{
    [SerializeField] Transform[] SetPositions;
    public static ItemDirector id;
    public GameObject[] Items;

    public int PackingInday = 4;
    private int count = 0;

    private int days = 1;
    private int score = 0;

    public Text DaysText;
    public Text ScoreText;
    public Text ScoreChangeText;
    public Text PackingInDays;

    public Area[] areas;

    public GameObject result;
    public Text resultScore;

    void Awake(){
        id = this;
        SetItemAll();
    }
    
    void Start(){
        StateTextUpdate();
    }

    public void ScoreUpdate(int point){
        score += point;
        string PlusMinus = "+";
        if(point < 0)
            PlusMinus = "";
        ScoreChangeText.text = PlusMinus + point.ToString();
        StateTextUpdate();
    }
    void GameEnd(){
        result.SetActive(true);
        resultScore.text = score.ToString();
    }

    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CountPacking(){
        count++;
        if(count == PackingInday){
            count = 0;
            days++;
            foreach(Area a in areas)
                a.Minus();
            if(days == 8)
                GameEnd();
        }
        StateTextUpdate();
    }
    public void StateTextUpdate(){
        DaysText.text = days.ToString() + "/7" + "日目";
        ScoreText.text = score.ToString() + "点";
        PackingInDays.text = (count+1).ToString() + "/" + PackingInday.ToString();
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
