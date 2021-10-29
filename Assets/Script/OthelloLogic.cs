using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Main画面のGameManagerなScript
public class OthelloLogic : GameController
{
    protected int x;//クリックした座標を入れる
    protected int z;
    private GameObject canNotText;
    // Start is called before the first frame update
    void Start()
    {
        initialize();
        camera_object = GameObject.Find("Main Camera").GetComponent<Camera>();
        this.canNotText = GameObject.Find("CanNotText");
        this.canNotText.SetActive(false);//Objectを取得したら消しておく
        
    }
    void Update()
    {
            stonePut();
    }

    public int GetPlayerStatus(){
        return player;
    }
    
    public void PlayerChange(){
        if(player == BLACK){
            player = WHITE;
            enemy = BLACK;
        }else if(player == WHITE){
            player = BLACK;
            enemy = WHITE;
        }
    }

    protected override void stonePut(){
        //マウスがクリックされたとき
        if (Input.GetMouseButtonDown(0))
        {
            bool putCheck = true;//一ターンに二回石を置かないように判定
            //マウスのポジションを取得してRayに代入
            Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);

            //マウスのポジションからRayを投げて何かに当たったらhitに入れる
            if (Physics.Raycast(ray, out hit))
            {
                //x,zの値を取得
                x = (int)hit.collider.gameObject.transform.position.x;
                z = (int)hit.collider.gameObject.transform.position.z;

                //マスが空のとき
                if(stoneStatus[x,z] == EMPTY)
                {
                    try{
                        if(putCheck == true && x < 6 && stoneStatus[x + 1 , z] == enemy){//置いた石の一つ右が相手の石なら
                            for(int i = (x + 2); i < 8; i++){//右端まで石の色をチェックする
                                if(stoneStatus[i , z] == player){//途中自分の石があったら石を置く                    
                                    if(player == BLACK){
                                        stoneBody[x ,z] = Instantiate(blackStone , new Vector3(x ,0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = BLACK;
                                        player = WHITE;
                                        enemy = BLACK;
                                    } else if(player == WHITE){
                                        stoneBody[x , z] = Instantiate(whiteStone , new Vector3(x , 0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = WHITE;
                                        player = BLACK;
                                        enemy = WHITE;
                                    }
                                    putCheck = false;
                                    logic();//ひっくり返せるか判定
                                    break;//途中に自分石があったらbreakして次のif文に行く
                                }
                            }
                        }
                    }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
                    }

                    try{
                        if(putCheck == true && x > 1 && stoneStatus[x - 1 , z] == enemy){//置いた石の一つ左が相手の石なら
                            for(int i = (x - 2); i > -1; i--){
                                if(stoneStatus[i , z] == player){
                                    if(player == BLACK){
                                        stoneBody[x ,z] = Instantiate(blackStone , new Vector3(x ,0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = BLACK;
                                        player = WHITE;
                                        enemy = BLACK;
                                    } else if(player == WHITE){
                                        stoneBody[x , z] = Instantiate(whiteStone , new Vector3(x , 0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = WHITE;
                                        player = BLACK;
                                        enemy = WHITE;
                                    }
                                    putCheck = false;
                                    logic();   
                                    break;
                                }
                            }
                        }
                    }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
                    }

                    try{                        
                        if(putCheck == true && z < 6 && stoneStatus[x , z + 1] == enemy){//置いた石の一つ上が相手の石なら
                            for(int i = (z + 2); i < 8; i++){
                                if(stoneStatus[x , i] == player){
                                    if(player == BLACK){
                                        stoneBody[x ,z] = Instantiate(blackStone , new Vector3(x ,0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = BLACK;
                                        player = WHITE;
                                        enemy = BLACK;
                                    } else if(player == WHITE){
                                        stoneBody[x , z] = Instantiate(whiteStone , new Vector3(x , 0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = WHITE;
                                        player = BLACK;
                                        enemy = WHITE;
                                    }
                                    putCheck = false;
                                    logic();   
                                    break;
                                }
                            }
                        }
                    }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
                    }

                    try{
                        if(putCheck == true && z > 1 && stoneStatus[x , z - 1] == enemy){//置いた石の一つ下が相手の石なら
                            for(int i = (z - 2); i > -1; i--){
                                if(stoneStatus[x , i] == player){
                                    if(player == BLACK){
                                        stoneBody[x ,z] = Instantiate(blackStone , new Vector3(x ,0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = BLACK;
                                        player = WHITE;
                                        enemy = BLACK;
                                    } else if(player == WHITE){
                                        stoneBody[x , z] = Instantiate(whiteStone , new Vector3(x , 0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = WHITE;
                                        player = BLACK;
                                        enemy = WHITE;
                                    }
                                    putCheck = false;
                                    logic();   
                                    break;
                                }
                            }
                        }
                    }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
                    }

                    try{
                        if(putCheck == true && x < 6 && z < 6 && stoneStatus[x + 1 , z + 1] == enemy){//置いた石の一つ右上が相手の石なら
                            for(int i = (x + 2) , j = (z + 2); i < 8 || j < 8; i++ , j++){
                                if(stoneStatus[i , j] == player){
                                    if(player == BLACK){
                                        stoneBody[x ,z] = Instantiate(blackStone , new Vector3(x ,0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = BLACK;
                                        player = WHITE;
                                        enemy = BLACK;
                                    } else if(player == WHITE){
                                        stoneBody[x , z] = Instantiate(whiteStone , new Vector3(x , 0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = WHITE;
                                        player = BLACK;
                                        enemy = WHITE;
                                    }
                                    putCheck = false;
                                    logic();   
                                    break;
                                }
                            }
                        }
                    }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
                    }

                    try{
                        if(putCheck == true && x > 1 && z > 1 && stoneStatus[x - 1 , z - 1] == enemy){//置いた石の一つ左下が相手の石なら
                            for(int i = (x - 2) , j = (z - 2); i > -1 || j > -1; i-- , j--){
                                if(stoneStatus[i , j] == player){
                                    if(player == BLACK){
                                        stoneBody[x ,z] = Instantiate(blackStone , new Vector3(x ,0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = BLACK;
                                        player = WHITE;
                                        enemy = BLACK;
                                    } else if(player == WHITE){
                                        stoneBody[x , z] = Instantiate(whiteStone , new Vector3(x , 0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = WHITE;
                                        player = BLACK;
                                        enemy = WHITE;
                                    }
                                    putCheck = false;
                                    logic();   
                                    break;
                                }
                            }
                        }
                    }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
                    }

                    try{
                        if(putCheck == true && x > 1 && z < 6 && stoneStatus[x - 1 , z + 1] == enemy){//置いた石の一つ左上が相手の石なら
                            for(int i = (x - 2) , j = (z + 2); i > -1 || j < 8; i-- , j++){
                                if(stoneStatus[i , j] == player){
                                    if(player == BLACK){
                                        stoneBody[x ,z] = Instantiate(blackStone , new Vector3(x ,0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = BLACK;
                                        player = WHITE;
                                        enemy = BLACK;
                                    } else if(player == WHITE){
                                        stoneBody[x , z] = Instantiate(whiteStone , new Vector3(x , 0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = WHITE;
                                        player = BLACK;
                                        enemy = WHITE;
                                    }
                                    putCheck = false;
                                    logic();   
                                    break;
                                }
                            }
                        }
                    }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
                    }

                    try{
                        if(putCheck == true && x < 6 && z > 1 && stoneStatus[x + 1 , z - 1] == enemy){//置いた石の一つ右下が相手の石なら
                            for(int i = (x + 2) , j = (z - 2); i < 8 || j > -1; i++ , j--){
                                if(stoneStatus[i , j] == player){
                                    if(player == BLACK){
                                        stoneBody[x ,z] = Instantiate(blackStone , new Vector3(x ,0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = BLACK;
                                        player = WHITE;
                                        enemy = BLACK;
                                    } else if(player == WHITE){
                                        stoneBody[x , z] = Instantiate(whiteStone , new Vector3(x , 0.4f ,z) , Quaternion.identity);
                                        stoneStatus[x , z] = WHITE;
                                        player = BLACK;
                                        enemy = WHITE;
                                    }
                                    putCheck = false;
                                    logic();   
                                    break;
                                }
                            }
                        }
                    }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
                    }
                    if(putCheck == true){//石が置けなかったら
                        this.canNotText.SetActive(true);//Textに置けない、と画面に表示
                        this.canNotText.GetComponent<AudioSource>().Play();//バツブザーを鳴らす
                    }
                }   
            }
        }
    }
    private void logic(){
        this.canNotText.SetActive(false);//石が置けたらTextの置けない、表示を消す
        try{
            if(x < 6 && stoneStatus[x + 1 , z] == player){//置いた石の一つ右が相手の石なら
                for(int i = (x + 2); i < 8; i++){//右端まで石の色をチェックする
                    if(stoneStatus[i , z] == enemy){//途中自分の石があったら
                        for(; i > x; i--){//間の石を自分の石に変える
                            if(player != BLACK){//黒の手番の時
                            Destroy(stoneBody[i , z]);
                            stoneBody[i , z] = Instantiate(blackStone , new Vector3(i ,0.4f , z) , Quaternion.identity);
                            stoneStatus[i , z] = BLACK;
                            }else if(player != WHITE){//白の手番
                            Destroy(stoneBody[i , z]);
                            stoneBody[i , z] = Instantiate(whiteStone , new Vector3(i ,0.4f ,z) , Quaternion.identity);
                            stoneStatus[i , z] = WHITE;
                            }
                        }
                        break;
                    }
                }
            }
        }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
        }

        try{
            if(x > 1 && stoneStatus[x - 1 , z] == player){//置いた石の一つ左が相手の石なら
                for(int i = (x - 2); i > -1; i--){//左端まで石の色をチェックする
                    if(stoneStatus[i , z] == enemy){//途中自分の石があったら
                        for(; i < x; i++){
                            if(player != BLACK){
                            Destroy(stoneBody[i , z]);
                            stoneBody[i , z] = Instantiate(blackStone , new Vector3(i ,0.4f , z) , Quaternion.identity);
                            stoneStatus[i , z] = BLACK;
                            }else if(player != WHITE){
                            Destroy(stoneBody[i , z]);
                            stoneBody[i , z] = Instantiate(whiteStone , new Vector3(i ,0.4f ,z) , Quaternion.identity);
                            stoneStatus[i , z] = WHITE;
                            }
                        }
                        break;
                    }
                }
            }
        }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
        }
        
        try{
            if(z < 6 && stoneStatus[x , z + 1] == player){//置いた石の一つ上が相手の石なら
                for(int i = (z + 2); i < 8; i++){//上まで石の色をチェックする
                    if(stoneStatus[x , i] == enemy){//途中自分の石があったら
                        for(; i > z; i--){
                            if(player != BLACK){
                            Destroy(stoneBody[x , i]);
                            stoneBody[x , i] = Instantiate(blackStone , new Vector3(x ,0.4f , i) , Quaternion.identity);
                            stoneStatus[x , i] = BLACK;
                            }else if(player != WHITE){
                            Destroy(stoneBody[x , i]);
                            stoneBody[x , i] = Instantiate(whiteStone , new Vector3(x ,0.4f ,i) , Quaternion.identity);
                            stoneStatus[x , i] = WHITE;
                            }
                        }
                        break;
                    }
                }
            }
        }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
        }

        try{
            if(z > 1 && stoneStatus[x , z - 1] == player){//置いた石の一つ下が相手の石なら
                for(int i = (z - 2); i > -1; i--){//下まで石の色をチェックする
                    if(stoneStatus[x , i] == enemy){//途中自分の石があったら
                        for(; i < z; i++){
                            if(player != BLACK){
                            Destroy(stoneBody[x , i]);
                            stoneBody[x , i] = Instantiate(blackStone , new Vector3(x ,0.4f , i) , Quaternion.identity);
                            stoneStatus[x , i] = BLACK;
                            }else if(player != WHITE){
                            Destroy(stoneBody[x , i]);
                            stoneBody[x , i] = Instantiate(whiteStone , new Vector3(x ,0.4f ,i) , Quaternion.identity);
                            stoneStatus[x , i] = WHITE;
                            }
                        }
                        break;
                    }
                }
            }
        }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
        }

        try{
            if(x < 6 && z < 6 && stoneStatus[x + 1 , z + 1] == player){//置いた石の一つ右上が相手の石なら
                for(int i = (x + 2) , j = (z + 2); i < 8 || j < 8; i++ , j++){//右上まで石の色をチェックする
                    if(stoneStatus[i , j] == enemy){//途中自分の石があったら
                        for(; i > x || j > z; i-- , j--){
                            if(player != BLACK){
                            Destroy(stoneBody[i , j]);
                            stoneBody[i , j] = Instantiate(blackStone , new Vector3(i ,0.4f , j) , Quaternion.identity);
                            stoneStatus[i , j] = BLACK;
                            }else if(player != WHITE){
                            Destroy(stoneBody[i , j]);
                            stoneBody[i , j] = Instantiate(whiteStone , new Vector3(i ,0.4f ,j) , Quaternion.identity);
                            stoneStatus[i , j] = WHITE;
                            }
                        }
                        break;
                    }
                }
            }
        }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
        }        

        try{   
            if(x > 1 && z > 1 && stoneStatus[x - 1 , z - 1] == player){//置いた石の一つ左下が相手の石なら
                for(int i = (x - 2) , j = (z - 2); i > -1 || j > -1; i-- , j--){//左下まで石の色をチェックする
                    if(stoneStatus[i , j] == enemy){//途中自分の石があったら
                        for(; i < x || j < z; i++ , j++){
                            if(player != BLACK){
                            Destroy(stoneBody[i , j]);
                            stoneBody[i , j] = Instantiate(blackStone , new Vector3(i ,0.4f , j) , Quaternion.identity);
                            stoneStatus[i , j] = BLACK;
                            }else if(player != WHITE){
                            Destroy(stoneBody[i , j]);
                            stoneBody[i , j] = Instantiate(whiteStone , new Vector3(i ,0.4f ,j) , Quaternion.identity);
                            stoneStatus[i , j] = WHITE;
                            }
                        }
                        break;
                    }
                }
            }
        }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
        }

        try{        
            if(x > 1 && z < 6 && stoneStatus[x - 1 , z + 1] == player){//置いた石の一つ左上が相手の石なら
                for(int i = (x - 2) , j = (z + 2); i > -1 || j < 8; i-- , j++){//左上まで石の色をチェックする
                    if(stoneStatus[i , j] == enemy){//途中自分の石があったら
                        for(; i < x || j > z; i++ , j--){
                            if(player != BLACK){
                            Destroy(stoneBody[i , j]);
                            stoneBody[i , j] = Instantiate(blackStone , new Vector3(i ,0.4f , j) , Quaternion.identity);
                            stoneStatus[i , j] = BLACK;
                            }else if(player != WHITE){
                            Destroy(stoneBody[i , j]);
                            stoneBody[i , j] = Instantiate(whiteStone , new Vector3(i ,0.4f ,j) , Quaternion.identity);
                            stoneStatus[i , j] = WHITE;
                            }
                        }
                        break;
                    }
                }
            }
        }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
        }        

        try{
            if(x < 6 && z > 1 && stoneStatus[x + 1 , z - 1] == player){//置いた石の一つ右下が相手の石なら
                for(int i = (x + 2) , j = (z - 2); i < 8 || j > -1; i++ , j--){//右下まで石の色をチェックする
                    if(stoneStatus[i , j] == enemy){//途中自分の石があったら
                        for(; i > x || j < z; i-- , j++){
                            if(player != BLACK){
                            Destroy(stoneBody[i , j]);
                            stoneBody[i , j] = Instantiate(blackStone , new Vector3(i ,0.4f , j) , Quaternion.identity);
                            stoneStatus[i , j] = BLACK;
                            }else if(player != WHITE){
                            Destroy(stoneBody[i , j]);
                            stoneBody[i , j] = Instantiate(whiteStone , new Vector3(i ,0.4f ,j) , Quaternion.identity);
                            stoneStatus[i , j] = WHITE;
                            }
                        }
                        break;
                    }
                }
            }
        }catch(System.IndexOutOfRangeException){
                        Debug.Log("配列外を参照したので次のifへ");
        }        
    }
}
      