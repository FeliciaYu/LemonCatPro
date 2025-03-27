using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //TODO
    // 1.获取玩家输入，在场景中移动玩家角色游戏对象
    // 2.移动时，除了位置外position，还需要考虑转动rotation
    // 3.考虑动画

    // 创建一个3D矢量，来表示玩家角色的移动
    Vector3 m_Movement;
    //创建变量，获取用户输入的方向
    float horizontal;
    float vertical;
    //创建刚体对象
    Rigidbody m_Rigibody;
    //创建Animator组件对象
    Animator m_Animator;
    //用四元数对象m_Rotation来表示3D游戏中的旋转
    //初始化四元数对象，初始化为不旋转
    Quaternion m_Rotation = Quaternion.identity;

    //旋转速度
    public float turnSpeed = 20.0f;

    //获取音源组件
    AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        //在游戏运行开始后，获取刚体组件对象和Animator组件
        m_Animator = GetComponent<Animator>();
        m_Rigibody = GetComponent<Rigidbody>();
        //获取当前游戏对象的音频源组件对象
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取用户输入
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
    }

    private void FixedUpdate()
    {
        //移动赋值
        //将用户输入组装成3d运动需要的三维矢量
        m_Movement.Set(horizontal,0.0f,vertical);
        //归一化，不考虑距离只考虑方向
        m_Movement.Normalize();

        //通过m_Movement来判断当前的玩家角色是否在移动
        //判断是否横向或纵向移动
        bool hasHorizontal = !Mathf.Approximately(horizontal,0.0f);
        bool hasVertical = !Mathf.Approximately(vertical,0.0f);
        //只要有一个方向移动，就认为玩家角色处于移动状态
        bool isWalking = hasHorizontal || hasVertical;
        //将变量传递给动画管理器
        m_Animator.SetBool("IsWalking",isWalking);

        //用三维矢量来表示转向后的玩家角色的朝向
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward,m_Movement,turnSpeed*Time.deltaTime,0f);
        //设置四元数对象的值
        m_Rotation = Quaternion.LookRotation(desiredForward);
        
        //如果走动播放音效否则停止播放
        //isWalking为true，表示玩家角色正在走动
        if(isWalking)
        {
            //保证不是每帧都重复从头播放
            //如果检测到音频正在播放，则不会调用play方法
            //如果取消了监测，会一直调用play，从而发不出脚步声
            if(!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            //表示玩家停止移动，声音停止播放
            m_AudioSource.Stop();
        }
    }

    private void OnAnimatorMove(){
        //使用从用户输入获取到的三维矢量作为移动方向，使用动画中每次0.02s移动的距离作为距离来移动
        m_Rigibody.MovePosition(m_Rigibody.position + m_Movement*m_Animator.deltaPosition.magnitude);
        //使用刚体旋转游戏对象
        m_Rigibody.MoveRotation(m_Rotation);
    }
}
