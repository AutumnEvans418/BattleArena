using UnityEngine;

namespace Assets.Scripts
{
    public class InputManager : MonoBehaviour
    {
        public CameraFollow CameraFollow;
        public void OnPlayerJoined(GameObject obj)
        {
            CameraFollow.Follow = obj.transform;
            CameraFollow.SetupOffset();
        }
    }
}