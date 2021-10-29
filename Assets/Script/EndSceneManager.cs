using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    private GameObject resultText;
    private GameObject countTextBlack;
    private GameObject countTextWhite;

    // Start is called before the first frame update
    void Start()
    {
        this.resultText = GameObject.Find("ResultText");
        this.countTextBlack = GameObject.Find("BlackStoneCount");
        this.countTextWhite = GameObject.Find("WhiteStoneCount");

        //石の枚数を表示
        this.countTextBlack.GetComponent<Text>().text = "黒:" + EndScenePass.resultCountBlack.ToString("D") + "枚";
        this.countTextWhite.GetComponent<Text>().text = "白:" + EndScenePass.resultCountWhite.ToString("D") + "枚";
        
        if(EndScenePass.resultCountBlack > EndScenePass.resultCountWhite){
            this.resultText.GetComponent<Text>().color = new Color(0 , 0 , 0 ,255);//テキストカラーを黒に
            this.resultText.GetComponent<Text>().text = "黒の勝ち!!";
        }else if(EndScenePass.resultCountWhite > EndScenePass.resultCountBlack){
            this.resultText.GetComponent<Text>().color = new Color(255 , 255 , 255 ,255);
            this.resultText.GetComponent<Text>().text = "白の勝ち!!";
        }else if(EndScenePass.resultCountBlack == EndScenePass.resultCountWhite){
            this.resultText.GetComponent<Text>().color = new Color(0.5f , 0.5f , 0.5f ,255);
            this.resultText.GetComponent<Text>().text = "引き分け";
        }
        

    }
    void Update(){
    }

    public void RestartButtonDown(){//シーン遷移用
        SceneManager.LoadScene("StartScene");
    }
}
