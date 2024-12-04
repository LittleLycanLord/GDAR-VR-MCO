using System.Collections.Generic;
using LilLycanLord_Official;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace LilLycanLord_Official
{
    [RequireComponent(typeof(RawImage))]
    public class TaskBehaviour : TaskPopUp
    {
        //* ╔════════════╗
        //* ║ Components ║
        //* ╚════════════╝

        //* ╔══════════╗
        //* ║ Displays ║
        //* ╚══════════╝
        // [Header("Displays")]
        //* ╔════════╗
        //* ║ Fields ║
        //* ╚════════╝
        // [Space(10)]
        // [Header("Fields")]

        //* ╔════════════╗
        //* ║ Attributes ║
        //* ╚════════════╝

        //* ╔═══════════════╗
        //* ║ Monobehaviour ║
        //* ╚═══════════════╝
        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();

            rawImage = GetComponent<RawImage>();
            taskID = Random.Range(1, taskTextures.Count);
            rawImage.texture = taskTextures[taskID - 1];
        }

        void Start() { }

        void Update() { }

        //* ╔═════════════════════╗
        //* ║ Non - Monobehaviour ║
        //* ╚═════════════════════╝
        public void Resolve()
        {
            TaskManager.Instance.ResolveTask(this);
            Shrink();
        }
    }
}
