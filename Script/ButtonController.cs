using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private GameObject gameManager;
    private OthelloLogic script;

    // Start is called before the first frame update
    void Start()
    {
        this.gameManager = GameObject.Find("GameManager");
        script = gameManager.GetComponent<OthelloLogic>();
    }

    public void PassButtonDown(){//playerを変えるメソッド呼び出し
        script.PlayerChange();
    }

    public void EndButtonDown(){
        SceneManager.LoadScene("ENDScene");
    }
}
