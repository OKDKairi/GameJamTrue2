using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulp : MonoBehaviour
{
    [SerializeField] List<Transform> StickPositions;
    void Start(){
        StickPositions = new List<Transform>(); 
        foreach (Transform child in this.gameObject.transform){
            StickPositions.Add(child);
        }
    }
    public void Stick(GameObject StickedObj){
        if(GameDirector.DraggingObject){
            foreach(Transform pos in StickPositions){
                if(Vector2.Distance(StickedObj.transform.position,pos.position) < 1.0f){
                    StickedObj.transform.position = pos.position;
                    return;
                }
            }
        }
    }
}
