using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public class ECSStartup : MonoBehaviour{
	private EcsWorld _world;
	private EcsSystems _systems;

	private void systemsAdd(){
		/*_systems
			.Add(new WeaponSystem())
		;*/
	}
	
	private void Start(){
		_world = new EcsWorld();
		_systems = new EcsSystems(_world);
		_systems.ConvertScene();
		systemsAdd();
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