using LilLycanLord_Official;
using UnityEngine;
using UnityEngine.Assertions;

namespace LilLycanLord_Official
{
    public class TaskPopUp : MonoBehaviour
    {
        //* ╔════════════╗
        //* ║ Components ║
        //* ╚════════════╝
        RectTransform rectTransform;

        //* ╔══════════╗
        //* ║ Displays ║
        //* ╚══════════╝
        // [Header("Displays")]

        //* ╔════════╗
        //* ║ Fields ║
        //* ╚════════╝
        [Space(10)]
        [Header("Fields")]
        [SerializeField]
        float growDuration = 1.0f;

        [SerializeField]
        float shrinkDuration = 1.0f;

        //* ╔════════════╗
        //* ║ Attributes ║
        //* ╚════════════╝

        //* ╔═══════════════╗
        //* ║ Monobehaviour ║
        //* ╚═══════════════╝
        void Awake() { }

        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            rectTransform.localScale = Vector3.zero;
        }

        void Update() { }

        //* ╔═════════════════════╗
        //* ║ Non - Monobehaviour ║
        //* ╚═════════════════════╝
        [ContextMenu("Grow")]
        void Grow()
        {
            rectTransform.LeanScale(Vector3.one, growDuration).setEase(LeanTweenType.easeOutBounce);
        }

        [ContextMenu("Shrink")]
        public void Shrink()
        {
            rectTransform
                .LeanScale(Vector3.zero, shrinkDuration)
                .setEase(LeanTweenType.easeInBounce);
        }
    }
}
