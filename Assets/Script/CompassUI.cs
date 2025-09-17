using UnityEngine;
using UnityEngine.UI;

public class CompassUI : MonoBehaviour
{
    public RectTransform compassArrow;

    void Start()
    {
        Input.compass.enabled = true; // enable compass
    }

    void Update()
    {
        float heading = Input.compass.trueHeading; // 0 = North
        compassArrow.localEulerAngles = new Vector3(0, 0, -heading);
    }
}
