using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameObject blackStoneCountText;
    private GameObject whiteStoneCountText;
    private GameObject orderText;
    private GameObject gameManager;
    private OthelloLogic script;
    private int playerStatus;
    private int countBlack;
    private int countWhite;
    protected const int BLACK = 1;
    protected const int WHITE = 2;

    // Start is called before the first frame update
    void Start()
    {
        this.blackStoneCountText = GameObject.Find("BlackStoneCount");
        this.whiteStoneCountText = GameObject.Find("WhiteStoneCount");
        this.orderText = GameObject.Find("OrderText");
        this.gameManager = GameObject.Find("GameManager");
        script = gameManager.GetComponent<OthelloLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        countBlack = GameObject.FindGameObjectsWithTag("Black").Length;//盤上に石が何枚あるか取得
        countWhite = GameObject.FindGameObjectsWithTag("White").Length;

        //盤上に石が何枚あるかTextに表示
        this.blackStoneCountText.GetComponent<Text>().text = "黒:" + countBlack.ToString("D2") + "枚";
        this.whiteStoneCountText.GetComponent<Text>().text = "白:" + countWhite.ToString("D2") + "枚";

        //手番を表示
        this.playerStatus = script.GetPlayerStatus();
        if(this.playerStatus == BLACK){
            this.orderText.GetComponent<Text>().color = new Color(0 , 0 , 0 ,255);//Textカラーを黒に
            this.orderText.GetComponent<Text>().text = "黒の手番です";
        }else if(this.playerStatus == WHITE){
            this.orderText.GetComponent<Text>().color = new Color(255 , 255 , 255 ,255);
            this.orderText.GetComponent<Text>().text = "白の手番です";
        }
    }
}
