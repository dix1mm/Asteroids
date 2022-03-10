using UnityEngine;
using System;
using System.Collections.Generic;

public static class UnityEventGenerator{
	private static Dictionary<UEvent, Action<object>> _events = new Dictionary<UEvent, Action<object>>();

	public static void Generate(UEvent currEvent, object arg = null){
		if (_events.TryGetValue(currEvent, out Action<object> e))
			e?.Invoke(arg);
	}

	public static void Subscribe(UEvent currEvent, Action<object> subscriber){
		if (_events.TryGetValue(currEvent, out Action<object> e))
			e += subscriber;
		else
			_events.Add(currEvent, subscriber);
	}

	public static void Unsubscribe(UEvent currEvent, Action<object> subscriber){
		if (_events.TryGetValue(currEvent, out Action<object> e))
			e -= subscriber;
	}
}