using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //����ģʽ
    public static GameManager Instance;
    //��ʾ��Ϸ״̬
    public GameState State;

    private void Awake()
    {
        //����ģʽ��ȷ����Ϸ�е�GameManagerֻ��һ��ʵ�����ڣ����ڳ����л�ʱ��������
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //������Ϸ״̬
    public void UpdateGameState(GameState newState)
    {
        //������Ϸ�ĵ�ǰ״̬
        State = newState;

        //״̬��ת
        switch (newState)
        { 
            //��ͣ�˵������ڣ����и���ͣ�İ�ť
            case GameState.StopMenu:
                break;
            //ʤ��״̬
            case GameState.Victory:
                break;
            //ʧ��״̬������״̬��
            case GameState.Lose:
                break;
        }
    }
    //ö���࣬��ʾ��Ϸ״̬
    public enum GameState 
    {
        //��ͣ�˵������ڣ����и���ͣ�İ�ť��
        StopMenu,
        //ʤ��״̬
        Victory,
        //ʧ��״̬������״̬��
        Lose
    }
}
