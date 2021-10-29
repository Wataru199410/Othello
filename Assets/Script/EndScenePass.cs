using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScenePass : MonoBehaviour
{
    public static int resultCountBlack;//次のシーンで使うのでpublic , static
    public static int resultCountWhite;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);//ENDSceneに石の数を渡すため
    }
    public void countStorage(){//ENDSceneに遷移時呼び出される
            resultCountBlack = GameObject.FindGameObjectsWithTag("Black").Length;//盤上に石が何枚あるか取得
            resultCountWhite = GameObject.FindGameObjectsWithTag("White").Length;
    }
        

}
