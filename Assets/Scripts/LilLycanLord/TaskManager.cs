using System.Collections.Generic;
using System.Threading.Tasks;
using AYellowpaper;
using LilLycanLord_Official;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace LilLycanLord_Official
{
    public class TaskManager : MonoBehaviour
    {
        //! ╔═══════════════════╗
        //! ║ SINGLETON CONTENT ║
        //! ╚═══════════════════╝
        //* SUMMARY
        //* This singleton pattern is used to make singletons which recognize preset singletons
        //* within the Scene, and if there are none,
        //* automatically create instances of themselves when needed.
        static bool logSingleton = false;
        static TaskManager instance;
        public static TaskManager Instance
        {
            get
            {
                if (instance == null)
                    CheckForExisitingSingleton(true);
                return instance;
            }
            private set { }
        }

        static void CheckForExisitingSingleton(bool fromGet)
        {
            if (instance != null)
                return;
            UnityEngine.Object[] existingSingleton = FindObjectsByType(
                typeof(TaskManager),
                FindObjectsSortMode.None
            );
            if (existingSingleton.Length > 0)
            {
                instance = existingSingleton[0].GetComponent<TaskManager>();
                if (!logSingleton)
                    return;
                string logMessage;
                if (fromGet)
                    logMessage = "(Get)";
                else
                    logMessage = "(Awake)";
                Debug.Log(
                    logMessage
                        + " Preset singleton found; "
                        + instance.name
                        + " set as singleton instance."
                );
            }
            else
            {
                instance = new GameObject("Task Manager").AddComponent<TaskManager>();
                Debug.LogWarning("New " + instance.gameObject.name + " created.");
            }
        }

        void Awake()
        {
            CheckForExisitingSingleton(false);
            transform.parent = null;
            if (transform.parent == null)
                DontDestroyOnLoad(gameObject);
            if (instance == this)
            {
                NonSingletonAwake();
                return;
            }
            if (instance != null)
            {
                if (logSingleton)
                    Debug.Log(
                        name + " was overwritten by existing singleton: " + instance.gameObject.name
                    );
                Destroy(gameObject);
                return;
            }
            if (logSingleton)
                Debug.Log(name + " set as singleton instance.");
            instance = this;
            NonSingletonAwake();
        }

        void NonSingletonAwake() { }

        //! - - - - - - - - - - -

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
        [Space(10)]
        [Header("Fields")]
        [SerializeField]
        int taskChance = 3;

        [SerializeField]
        GameObject taskPopUpPrefab;

        [SerializeField]
        GameObject taskPrefab;

        [SerializeField]
        List<GameObject> tasks;

        [SerializeField]
        Canvas taskList;

        //* ╔════════════╗
        //* ║ Attributes ║
        //* ╚════════════╝
        GameObject listContent;

        //* ╔═══════════════╗
        //* ║ Monobehaviour ║
        //* ╚═══════════════╝
        void Start()
        {
            listContent = taskList
                .transform.Find("Scroll View")
                .Find("Viewport")
                .Find("Content")
                .gameObject;
        }

        void Update()
        {
            if (listContent != null)
                listContent.SetActive(SceneManager.GetActiveScene().name == "Tasks");
        }

        //* ╔═════════════════════╗
        //* ║ Non - Monobehaviour ║
        //* ╚═════════════════════╝
        [ContextMenu("Get Task")]
        public void GetTask()
        {
            if (Random.Range(1, taskChance) == 1)
            {
                Debug.Log("Task Get!");
                GameObject.Instantiate(taskPopUpPrefab, taskList.transform);
            }
            else
                Debug.Log("Failed to get task");
        }

        public void AddTask(int taskID)
        {
            GameObject
                .Instantiate(taskPrefab, listContent.transform)
                .GetComponent<TaskBehaviour>()
                .SetTask(taskID);
        }

        public void ResolveTask(TaskBehaviour task)
        {
            tasks.Remove(task.gameObject);
        }
    }
}
