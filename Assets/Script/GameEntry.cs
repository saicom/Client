using UnityEngine;
using Network;
using View;
using GameState;
using Task;

public class GameEntry : MonoBehaviour {
	public static GameEntry Instance{
		set;get;
	}

    private static bool m_openGM = false;

	void Awake(){
		if (Instance != null) {
			Destroy(this.gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad (this.gameObject);
        Application.runInBackground = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        WindowManager.Instance.ChangeScenseToLogin(EScenesType.EST_None);
        GameStateManager.Instance.EnterDefaultState();
    }

	// Use this for initialization
	void Start () {
        MsgHandlerManager.Instance.Init();
	}

    void OnDestroy() {
    }

	// Update is called once per frame
	void Update ()
    {
        //更新网络模块
        NetworkManager.Instance.Update();
        WindowManager.Instance.Update(Time.deltaTime);
        TaskManager.Instance.Update();
        CheckGMInput();
    }

    private void CheckGMInput()
    {
        if(Input.GetKeyUp(KeyCode.F12))
        {
            if(m_openGM == false)
            {
                //EventCenter.Broadcast(EGameEvent.eGameEvent_GmEnter);
                m_openGM = true;
            }
            else
            {
                //EventCenter.Broadcast(EGameEvent.eGameEvent_GmExit);
                m_openGM = false;
            }
        }
    }

    void OnEnable()
	{
      
	}
	void OnDisable()
	{
       
	}

    //游戏退出前执行（玩家强行关闭游戏）
    void OnApplicationQuit()
    {
        Debug.Log("游戏退出前执行了OnAppliactionQuit");
        NetworkManager.Instance.Close();
    }

}
