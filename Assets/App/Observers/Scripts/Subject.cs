using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using App.Template;

namespace App.Observers
{
    public class Subject : MonoBehaviour
    {
        private readonly List<IObserver> observers = new List<IObserver>();
        protected void Notify(Actor actor, Event sendEvent)
        {
            for (var i = 0; i < observers.Count; i++)
            {
                observers[i].OnNotify(actor, sendEvent);
            }
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}

