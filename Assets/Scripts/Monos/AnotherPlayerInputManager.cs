using UnityEngine;
using UnityEngine.InputSystem;

public class AnotherPlayerInputManager : MonoBehaviour{

	public void Acceleration(InputAction.CallbackContext context) => processContinuousPress<EInputAccelerationStarted, EInputAccelerationStopped>(context.phase);
	public void Slowdown(InputAction.CallbackContext context) => processContinuousPress<EInputSlowdownStarted, EInputSlowdownStopped>(context.phase);
	public void RotateLeft(InputAction.CallbackContext context) => processContinuousPress<EInputRotationLeftStarted, EInputRotationLeftStopped>(context.phase);
	public void RotateRight(InputAction.CallbackContext context) => processContinuousPress<EInputRotationRightStarted, EInputRotationRightStopped>(context.phase);
	public void Fire(InputAction.CallbackContext context) => processSinglePress<EInputFire>(context.phase);
	public void FireAlt(InputAction.CallbackContext context) => processSinglePress<EInputFireAlt>(context.phase);

	private void processSinglePress<T>(InputActionPhase phase) where T : struct{
		if (phase == InputActionPhase.Started)
			ECSEventGenerator.Generate<T>(new T());
	}

	private void processContinuousPress<T, K>(InputActionPhase phase) where T : struct where K : struct{
		if (phase == InputActionPhase.Started)
			ECSEventGenerator.Generate<T>(new T());
		if (phase == InputActionPhase.Canceled)
			ECSEventGenerator.Generate<K>(new K());
	}
}