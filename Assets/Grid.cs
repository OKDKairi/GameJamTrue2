using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool [,] InGrid = new bool[4,4];

    private static int[] aroundx = {1,1,-1,-1},aroundy = {1,-1,-1,1};
    
    public static void ResetGrid(){
        for(int i = 0; i < 4; i++){
            for(int j = 0;j < 4;j++){
                InGrid[i,j] = false;
            }
        }
    }

    public static bool IsSetGrid(int x,int y){
        for(int i = 0;i < 4;i++){
            if(!InGrid[aroundx[i] + x,aroundy[i] + y])
                return false;
        }
        return true;
    }

    public static void SetGrid(int x,int y){
        for(int i = 0;i < 4;i++){
            InGrid[aroundx[i] + x,aroundy[i] + y] = true;
        }
    }

    public static bool SetPosition(int x, int y) {
        System.Console.WriteLine("({0},{1})=({2},{3})", x, y, (x+3) / 2, 3 - (y+3) / 2);
        return true;
    }
    void Start()
    {
        ResetGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
