using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private ARTapToSwitchScene sceneCaller;

    // Update is called once per frame
    void Update()
    {
        sceneCaller.LoadScene("SampleScene");
    }
}
