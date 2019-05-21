using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PureMVC.Patterns.Mediator;
using PureMVC.Interfaces;

public class InviteMediator : Mediator
{
    public new static string NAME = "Main.InviteMediator";

    public GameObject panel;

    public Button confirmBtn;
    public Button cancelBtn;
    public Text text;
    public InputField input;
    public string CODE = "LKXXXZL008";

    public InviteMediator(GameObject root):base(NAME){
        panel = root;

        foreach (Button button in root.GetComponentsInChildren<Button>())
        {
            switch (button.gameObject.name)
            {
                case "ConfirmButton":
                    confirmBtn = button;
                    break;
                case "CancelButton":
                    cancelBtn = button;
                    break;
            }
        }
        text = root.gameObject.transform.Find("WarnningText").GetComponent<Text>();
        input = root.GetComponentInChildren<InputField>();

        confirmBtn.onClick.AddListener(CheckInviteCode);
        cancelBtn.onClick.AddListener(ClosePanel);
    }

    public override string[] ListNotificationInterests()
    {
        string[] list = new string[]{ ShowInviteCommand.NAME };
        return list;
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name) {
            case ShowInviteCommand.NAME:
                // 隐藏提示文案
                text.gameObject.SetActive(false);
                // 展示邀请码激活界面
                panel.gameObject.SetActive(true);
                break;
        }
    }

    private void CheckInviteCode(){
        Debug.Log("Current invite code:" + input.text);
        if(CODE.Equals(input.text)){
            SendNotification(MainNotification.SHOW_INNER_GAME);
            // 关闭窗口
            ClosePanel();
        } else {
            // 展示错误文案
            text.gameObject.SetActive(true);
        }
        // 清除邀请码输入框
        input.text = "";
    }

    private void ClosePanel(){
        // 清除邀请码输入框
        input.text = "";
        // 隐藏提示文案
        text.gameObject.SetActive(false);
        // 隐藏邀请码界面
        panel.gameObject.SetActive(false);
    }
}
