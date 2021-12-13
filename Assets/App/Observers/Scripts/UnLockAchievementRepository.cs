using System.Collections.Generic;
using UnityEngine;

namespace App.Observers
{
    public class UnLockAchievementRepository
    {
        public List<Achievement> columns { get; private set; }

        public void GetAchievement(Achievement achievement)
        {
            columns.Add(achievement);
        }

        public bool IsHasAchievement(Achievement achievement)
        {
            for (var i = 0; i < columns.Count; i++)
            {
                if (columns[i] == achievement)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
