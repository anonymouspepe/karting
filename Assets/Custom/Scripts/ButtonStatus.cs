using UnityEngine;
using UnityEngine.UI;
using NRKernal;

public class ButtonStatus : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        if (NRDevice.Subsystem.GetDeviceCategory() == NRDeviceCategory.REALITY)
        {
            button.gameObject.SetActive(true);
        }
        else
        {
            button.gameObject.SetActive(false);
        }
    }
}
