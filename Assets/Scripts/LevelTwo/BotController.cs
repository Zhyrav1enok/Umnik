using UnityEngine;

namespace LevelTwo
{
    public class BotController : MonoBehaviour
    {
        public GameObject tablet;

        void Start()
        {
            tablet.SetActive(false);
        }
    }
}
