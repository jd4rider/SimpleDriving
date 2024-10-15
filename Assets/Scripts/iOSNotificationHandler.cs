using UnityEngine;
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class iOSNotificationHandler : MonoBehaviour
{
    #if UNITY_IOS
        private const string NotificationCategory = "category_a";
    
        public void ScheduleNotification(int minutes)
        {
            iOSNotification notification = new iOSNotification
            {
                Title = "Energy Recharged!",
                Body = "Your energy has recharged, come back to play again!",
                Trigger = new iOSNotificationTimeIntervalTrigger

            };

        }  
    
    
    #endif
}
