using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPos : MonoBehaviour
{
    [SerializeField] List<Transform> StickPositions;
    void Start(){
        GameDirector.stc = this;
        StickPositions = new List<Transform>(); 
        foreach (Transform child in this.gameObject.transform){
            StickPositions.Add(child);
        }
    }
    public bool Stick(GameObject StickedObj){
            foreach(Transform pos in StickPositions){
                if(Vector2.Distance(StickedObj.transform.position,pos.position) < 2.0f){
                    StickedObj.transform.position =new Vector3(pos.position.x,pos.position.y,StickedObj.transform.position.z);
                    Area a = pos.gameObject.GetComponent<Area>();
                    ItemManager item = StickedObj.GetComponent<ItemManager>();
                    if(a != null){
                        a.Plus(item.thisItem);
                        ItemDirector.id.CountPacking();
                    }else{
                        Debug.Log("waste");
                    }
                    item.ItemDelete();
                    return true;
                }
            }
            return false;
    }
}
