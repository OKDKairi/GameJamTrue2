using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop2D : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    private  Vector3 BackPos;
    void Start(){
        BackPos = this.gameObject.transform.position;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = Physics2D.OverlapPoint(clickPosition);
            if (collider != null && collider.gameObject == this.gameObject)
            {
                // クリックしたオブジェクトが対象のオブジェクトであればドラッグを開始
                GameDirector.DraggingObject = this.gameObject;
                isDragging = true;
                offset = this.transform.position - new Vector3(clickPosition.x, clickPosition.y, 0);
            }
        }
        if (isDragging && Input.GetMouseButton(0))
        {
            // マウスがクリックされている間、オブジェクトを移動
            Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = new Vector3(currentPosition.x, currentPosition.y, 0) + offset;
        }
        if (Input.GetMouseButtonUp(0))
        {
            // マウスが離されたらドラッグを終了
            if(!GameDirector.stc.Stick(this.gameObject)){
                this.gameObject.transform.position = BackPos;
            }else{
                int x = (int)this.gameObject.transform.position.x;
                int y = (int)this.gameObject.transform.position.y;
                Debug.Log("x:"+x+"y:"+y);
                
            }
            GameDirector.DraggingObject = null;
            isDragging = false;
        }
    }
}
