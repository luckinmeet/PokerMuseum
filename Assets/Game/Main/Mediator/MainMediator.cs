using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using PureMVC.Patterns.Mediator;
using PureMVC.Interfaces;

public class MainMediator : Mediator
{
    public new static string NAME = "MainMediator";

    public Button profileButton;
    public Button inviteButton;
    public Button aboutButton;
    public Button gameBtn;

    public MainMediator(GameObject root):base(NAME){
        foreach(Button button in root.GetComponentsInChildren<Button>()){
            switch (button.gameObject.name){
                case "ProfileButton":
                    profileButton = button;
                    break;
                case "InviteButton":
                    inviteButton = button;
                    break;
                case "AboutButton":
                    aboutButton = button;
                    break;
            }
        }
        // gameBtn是隐藏节点，需要使用transform查找
        gameBtn = root.gameObject.transform.Find("GameButton").GetComponent<Button>();

        gameBtn.onClick.AddListener(() => SceneManager.LoadScene(2));
        profileButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        inviteButton.onClick.AddListener(() => SendNotification(ShowInviteCommand.NAME));
    }

    public override string[] ListNotificationInterests()
    {
        string[] list = new string[] { MainNotification.SHOW_INNER_GAME };
        return list;
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name){
            case MainNotification.SHOW_INNER_GAME:
                // 展示游戏入口按钮
                gameBtn.gameObject.SetActive(true);
                break;
        }
    }
}
