using UnityEngine;

namespace ProjectTA.Module.GameConstants
{
    [CreateAssetMenu(fileName = "GameConstants", menuName = "ProjectTA/GameConstants", order = 0)]
    public class SO_GameConstants : ScriptableObject
    {
        public bool isJoystickActive;
        public int initialHealth;
        public float shootingRate;
    }
}
