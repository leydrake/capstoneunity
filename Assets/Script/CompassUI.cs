using UnityEngine;
using UnityEngine.UI;

public class CompassUI : MonoBehaviour
{
    public RectTransform compassArrow;

    void Start()
    {
        // Enable compass on phone
        Input.compass.enabled = true;
        Input.location.Start(); // sometimes needed to unlock compass
    }

    void Update()
    {
        // Heading in degrees (0 = North)
        float heading = Input.compass.trueHeading;

        // Rotate arrow inside UI (negative because UI y-axis flips)
        compassArrow.localEulerAngles = new Vector3(0, 0, -heading);
    }
}
