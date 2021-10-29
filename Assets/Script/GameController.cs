using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//石を置けるようになるところまで
public class GameController : InitializeStone
{
    protected int player = BLACK;
    protected int enemy = WHITE;
    protected Camera camera_object;
    protected RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        initialize();
        camera_object = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        stonePut();
    }

    protected virtual void stonePut(){
        //マウスがクリックされたとき
        if (Input.GetMouseButtonDown(0))
        {
            //マウスのポジションを取得してRayに代入
            Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);

            //マウスのポジションからRayを投げて何かに当たったらhitに入れる
            if (Physics.Raycast(ray, out hit))
            {
                //x,zの値を取得
                int x = (int)hit.collider.gameObject.transform.position.x;
                int z = (int)hit.collider.gameObject.transform.position.z;

                //マスが空のとき
                if(stoneStatus[x,z] == EMPTY)
                {
                    if(player == BLACK){
                        stoneBody[x ,z] = Instantiate(blackStone , new Vector3(x ,1 ,z) , Quaternion.identity);
                        stoneStatus[x , z] = BLACK;
                        player = WHITE;
                        enemy = BLACK;
                    } else if(player == WHITE){
                        stoneBody[x , z] = Instantiate(whiteStone , new Vector3(x ,1 ,z) , Quaternion.identity);
                        stoneStatus[x , z] = WHITE;
                        player = BLACK;
                        enemy = WHITE;
                    }
                }
            }
        }
    }
}