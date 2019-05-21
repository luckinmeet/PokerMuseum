using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;

public class ShowInviteCommand : SimpleCommand
{
    public const string NAME = "Main.ShowInviteCommand";
    public override void Execute(INotification notification)
    {
        base.Execute(notification);
    }
}
