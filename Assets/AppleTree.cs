using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //初始化苹果实例的预设
    public GameObject applePrefab;
    //苹果树的移动速度，单位： 米/秒
    public float speed = 1f;
    //苹果树的移动区域，到达边界则改变方向
    public float leftAndRightEdge = 10f;
    //苹果树改变方向的概率
    public float chanceToChangeDirections = 0.1f;
    //苹果出现的时间间隔
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //每秒掉落一个苹果
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }
    
    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
        // 尝试做平抛运动
        // Vector3 applePos = transform.position;
        // applePos.x += Time.deltaTime * speed;
        // apple.transform.position = applePos;
    }

    // Update is called once per frame
    void Update()
    {
        //基本运动
        Vector3 pos = transform.position;
        pos.x += Time.deltaTime * speed;
        transform.position = pos;
        //改变方向
        if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed);
        }else if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        //随机改变运动方向，并且与帧数无关，只与时间有关
        if (Random.value <= chanceToChangeDirections) {
            speed = -speed;
        }
    }
}
