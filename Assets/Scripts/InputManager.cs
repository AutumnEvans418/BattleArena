using UnityEngine;

namespace Assets.Scripts
{
    public class InputManager : MonoBehaviour
    {
        public FollowObject FollowObject;
        public void OnPlayerJoined(GameObject obj)
        {
            FollowObject.Follow = obj.transform;
            FollowObject.SetupOffset();
        }
    }
}