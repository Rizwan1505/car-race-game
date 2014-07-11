using UnityEngine;

[RequireComponent(typeof(CarController))]
public class CarUserControl : MonoBehaviour
{
    private CarController car;  // the car controller we want to use
    

    void Awake ()
    {
        // get the car controller
        car = GetComponent<CarController>();

		if (networkView.isMine) {
			GameObject.Find("Car Camera Rig").GetComponent<AutoCam>().SetTarget(this.gameObject.transform);
		}
    }


    void FixedUpdate()
    {
		if (networkView.isMine) {
						// pass the input to the car!
#if CROSS_PLATFORM_INPUT
						float h = CrossPlatformInput.GetAxis ("Horizontal");
						float v = CrossPlatformInput.GetAxis ("Vertical");
#else
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
#endif
						car.Move (h, v);
				}
    }
}
