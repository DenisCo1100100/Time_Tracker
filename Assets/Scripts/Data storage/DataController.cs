using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController dataController;

    void Awake()
    {
        dataController = this;
    }
}
