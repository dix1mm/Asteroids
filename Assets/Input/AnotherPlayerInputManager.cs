/*
	покопал форумы, представитель юнити сначала добавил такую штуку как "продолжительное нажатие",
	чтобы ивент дергался постоянно, потом убрал из-за технических проблем
	некоторые предлагают как альтернативу ужасный велосипед с корутинами
	  это неудобно как минимум потому что требуется писать больше логики (нажимаем/отпускаем вместо "зажимаем", необходимость хранить флаги) для игрока
	если подходить к этому супер серьезно, то можно подтягивать все действия из Input Actions
	  и автоматически присваивать им методы по определенным правилам
	либо сделать свою реализацию такого нажатия, я вроде бы даже где-то видел готовую, но не стал тащить сюда решив что это перебор
	в данной ситуации этот посредник кажется мне наиболее оптимальным
*/
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class AnotherPlayerInputManager : MonoBehaviour
{
	private Action continuousPress;

	public void Acceleration(InputAction.CallbackContext context) => processContinuousPress(testW, context.phase);
	public void Slowdown(InputAction.CallbackContext context) => processContinuousPress(testS, context.phase);
	public void RotateLeft(InputAction.CallbackContext context) => processContinuousPress(testA, context.phase);
	public void RotateRight(InputAction.CallbackContext context) => processContinuousPress(testD, context.phase);
	public void Fire(InputAction.CallbackContext context) => processSinglePress(testLM, context.phase);
	public void FireAlt(InputAction.CallbackContext context) => processSinglePress(testRM, context.phase);

	private void processSinglePress(Action a, InputActionPhase phase)
	{
		if (phase == InputActionPhase.Started)
			a?.Invoke();
	}

	private void processContinuousPress(Action a, InputActionPhase phase)
	{
		if (phase == InputActionPhase.Started)
			continuousPress += a;
		if (phase == InputActionPhase.Canceled)
			continuousPress -= a;
	}

	private void FixedUpdate() => continuousPress?.Invoke();

	private void testLM() => Debug.Log("left mouse");
	private void testRM() => Debug.Log("right mouse");
	private void testW() => Debug.Log("W");
	private void testS() => Debug.Log("S");
	private void testA() => Debug.Log("A");
	private void testD() => Debug.Log("D");
}