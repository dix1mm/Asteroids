using UnityEngine;
using Leopotam.Ecs;

public class SMoveForward : IEcsRunSystem{
	private EcsFilter<CMoveForward> f = null;

	public void Run(){
		foreach (var i in f){
			ref var e = ref f.GetEntity(i);
			ref var c = ref f.Get1(i);
			c.Moving?.Translate(new Vector3(c.Speed * Time.deltaTime, 0, 0));
			if (e.Has<CPlayer>()){
				UnityEventGenerator.Generate(UEvent.SpeedChanged, c.Speed.ToString("f2"));
				UnityEventGenerator.Generate(UEvent.CoordsChanged, c.Moving.position.ToString());
				UnityEventGenerator.Generate(UEvent.RotationChanged, c.Moving.eulerAngles.z.ToString("f0"));
			}
		}
	}
}