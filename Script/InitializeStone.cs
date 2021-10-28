using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//盤上の初期化まで
public class InitializeStone : MonoBehaviour
{
    public GameObject blackStone;
    public GameObject whiteStone;
    protected const int EMPTY = 0;//盤上の状態を表す定数
    protected const int BLACK = 1;
    protected const int WHITE = 2;
    protected int [,] stoneStatus = new int [8 , 8];//盤上の状態を保存する配列
    protected GameObject [,] stoneBody = new GameObject[8 , 8];//石の実体の状態を保存

    void start()
    {
     initialize();   
    }
//盤上の初期化
    protected void initialize(){
        for(int i = 0; i < 8; i++){
            for(int j = 0; j < 8; j++){
                stoneStatus[i , j] = EMPTY;
            }
        }
        stoneBody[3 , 4] = Instantiate(blackStone , new Vector3(3 ,0.4f , 4) , Quaternion.identity);
        stoneStatus[3 , 4] = BLACK;
        stoneBody[4 , 3] = Instantiate(blackStone , new Vector3(4 ,0.4f , 3) , Quaternion.identity);
        stoneStatus[4 , 3] = BLACK;    
        stoneBody[3 , 3] = Instantiate(whiteStone , new Vector3(3 ,0.4f , 3) , Quaternion.identity);
        stoneStatus[3 , 3] = WHITE;     
        stoneBody[4 , 4] = Instantiate(whiteStone , new Vector3(4 ,0.4f , 4) , Quaternion.identity);
        stoneStatus[4 , 4] = WHITE;      
    }
}
    
