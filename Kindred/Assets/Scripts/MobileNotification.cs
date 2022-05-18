using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class MobileNotification : MonoBehaviour
{
    public void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        
        //Channel Creation
        var channel = new AndroidNotificationChannel()

        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        RecieveCallBack();
        StoreRetrieveData();

       
    }
    public void SendNotification(string title, string body)
    {
     

        //send notifc
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = body;
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";
      
        notification.FireTime = System.DateTime.Now.AddSeconds(1);


        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
        




    }
    public void RecieveCallBack()
    {
        AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler =
       delegate (AndroidNotificationIntentData data)
       {
           var msg = "Notification received : " + data.Id + "\n";
           msg += "\n Notification received: ";
           msg += "\n .Title: " + data.Notification.Title;
           msg += "\n .Body: " + data.Notification.Text;
           msg += "\n .Channel: " + data.Channel;
           Debug.Log(msg);
       };

        AndroidNotificationCenter.OnNotificationReceived += receivedNotificationHandler;


    }
    public void StoreRetrieveData()
    {
        var notification = new AndroidNotification();
        notification.IntentData = "{\"title\": \"Notification 1\", \"data\": \"200\"}";
        AndroidNotificationCenter.SendNotification(notification, "channel_id");

        var notificationIntentData = AndroidNotificationCenter.GetLastNotificationIntent();
        if (notificationIntentData != null)
        {
            Debug.Log("App was opened with notif");
        }
    }
}

