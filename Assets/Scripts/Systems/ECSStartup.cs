using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public class ECSStartup : MonoBehaviour{
	private EcsWorld _world;
	private EcsSystems _systems;

	private void systemsAdd(){
		_systems
			.Add(new SGun())//выстрел из пушки
			.Add(new SSpawn())//спавн астероидов и тарелок
			.Add(new SColliders())//все столкновения
			.Add(new SLifetime())//время жизни выстрелов
		;
	}

	private void systemsAddOneFrame(){
		_systems
			.OneFrame<EInputFire>()
			.OneFrame<EInputFireAlt>()
			.OneFrame<EInputAccelerationStarted>()
			.OneFrame<EInputAccelerationStopped>()
			.OneFrame<EInputSlowdownStarted>()
			.OneFrame<EInputSlowdownStopped>()
			.OneFrame<EInputRotationLeftStarted>()
			.OneFrame<EInputRotationLeftStopped>()
			.OneFrame<EInputRotationRightStarted>()
			.OneFrame<EInputRotationRightStopped>()
			.OneFrame<ETriggerEnter>()
		;
	}	
	
	private void Start(){
		_world = new EcsWorld();
		_systems = new EcsSystems(_world);
		_systems.ConvertScene();
		systemsAdd();
		systemsAddOneFrame();
		_systems.Init();
	}

	private void Update(){
		_systems.Run();
	}

	private void OnDestroy(){
		_systems.Destroy();
		_systems = null;
		_world.Destroy();
		_world = null;
	}
}