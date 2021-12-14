using App.Template;
using UnityEngine;

namespace App.Observers
{
    public class AchievementObserver : IObserver
    {
        public void OnNotify(Actor actor, Event receiveEvent)
        {
            switch (receiveEvent)
            {
                case Event.EventPlayerScreenOut:
                    UnLock(Achievement.AchievementPlayerScreenOut);
                    break;
                default:
                    break;
            }
        }

        private void UnLock(Achievement achievement)
        {
            switch (achievement)
            {
                case Achievement.AchievementPlayerScreenOut:
                    Debug.Log("player screen out");
                    break;
                default:
                    break;
            }
        }

    }

}
