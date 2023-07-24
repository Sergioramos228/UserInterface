using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Extensions
{
    static class EventSystemExtensions
    {
        public static T GetFirstComponentUnderPointer<T>(this EventSystem system, PointerEventData eventData) where T : class
        {
            List<RaycastResult> result = new();
            system.RaycastAll(eventData, result);

            foreach (RaycastResult raycast in result)
                if (raycast.gameObject.TryGetComponent(out T component))
                    return component;

                return null;
        }
    }
}
