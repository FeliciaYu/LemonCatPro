using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//用来通过触发器代表的敌人视线监视玩家的代码
public class Observer : MonoBehaviour
{
    //声明共有的玩家变换组件对象，用来挂接玩家
    public Transform player;
    //设置开关表示玩家是否被视线扫到
    //即是否进入代表敌人实现的触发器区域内
    bool m_IsPlayerInRange;
    //声明游戏结束脚本组件类对象，为了调用游戏结束脚本中的公有方法
    public GameEnding gameEnding;

    //进入触发器事件
    //玩家进入视线触发器区域
    //更改开关
    private void OnTriggerEnter(Collider other)
    {
        //进入触发器区域是玩家则将开关设置为真
        if(other.transform == player)
        {
            m_IsPlayerInRange = true;
        }      
    }

    //离开触发器事件
    private void OnTriggerExit(Collider other)
    {
        //当触发器区域中的是玩家，离开后设置为false
        if(other.transform == player)
        {
            m_IsPlayerInRange = false;
        }      
    }

    //在Update中监控开关的值，一旦玩家进行视线触发器区域则执行对应的方法
    // Update is called once per frame
    void Update()
    {
        //触发器已被触发
        if(m_IsPlayerInRange)
        {
            //设置投射射线用到的方向矢量，调整位置到大概石像鬼眼睛的位置
            Vector3 direction = player.position - transform.position + Vector3.up;
            //创建射线
            Ray ray = new Ray(transform.position,direction);

            //射线击中对象，包含射线碰撞信息
            RaycastHit raycastHit;

            //使用物理系统发射射线，如果碰到物体
            //进入第一层if
            //out代表第二个参数是输出参数，可以带出数据到参数中
            if(Physics.Raycast(ray,out raycastHit))
            {
                //如果碰到的是玩家，则调用失败
                if(raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
        
    }

    private void EndLevel()
    {
        throw new NotImplementedException();
    }
}
