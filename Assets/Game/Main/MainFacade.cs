using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class MainFacade : MonoBehaviour
{
    public GameObject mainRoot;
    public GameObject invitePannel;
    // Start is called before the first frame update
    void Start()
    {
        AppFacade.Instance.RegisterMediator(new MainMediator(mainRoot));
        AppFacade.Instance.RegisterMediator(new InviteMediator(invitePannel));


        AppFacade.Instance.RegisterCommand(ShowInviteCommand.NAME, () => new ShowInviteCommand() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
