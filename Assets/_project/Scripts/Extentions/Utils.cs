using UnityEngine;

namespace _project.Scripts.Extentions
{
    public static class Utils
    {
        public static Vector3 ScreenToWorldPoint(Camera camera, Vector3 screenPoint)
        {
            screenPoint.z = camera.nearClipPlane;
            return camera.ScreenToWorldPoint(screenPoint);
        }
        
    }
}