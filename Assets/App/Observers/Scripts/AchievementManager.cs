using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.Observers
{
    public class AchievementManager : MonoBehaviour
    {
        [SerializeField] StageSubject subject;

        private AchievementObserver _achievementObserver;

        private void Start()
        {
            _achievementObserver = new AchievementObserver();

            subject.AddObserver(_achievementObserver);
        }
    }
}

