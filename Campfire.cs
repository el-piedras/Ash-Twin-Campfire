using HarmonyLib;
using OWML.Common;
using OWML.ModHelper;
using System.Reflection;

namespace Campfire;

public class Campfire : ModBehaviour
{
	public static Campfire Instance;
	public INewHorizons NewHorizons;

	public void Awake()
	{
		Instance = this;
	}

	public void Start()
	{
		NewHorizons = ModHelper.Interaction.TryGetModApi<INewHorizons>("xen.NewHorizons");
		NewHorizons.LoadConfigs(this);

		new Harmony("Stonesword.Campfire").PatchAll(Assembly.GetExecutingAssembly());

		// Example of accessing game code.
		OnCompleteSceneLoad(OWScene.TitleScreen, OWScene.TitleScreen); // We start on title screen
		LoadManager.OnCompleteSceneLoad += OnCompleteSceneLoad;
	}

	public void OnCompleteSceneLoad(OWScene previousScene, OWScene newScene)
	{
		if (newScene != OWScene.SolarSystem) return;
	}
}

