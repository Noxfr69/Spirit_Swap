using UnityEngine;

public class DontDestroyOnLoadLevel : MonoBehaviour
{
    public static DontDestroyOnLoadLevel instance;
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);


    }

}
