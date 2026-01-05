using BepInEx;
using BepInEx.Logging;
using Unity.VisualScripting;
using UnityEngine;

namespace braveWizardChan;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
        
    private void Awake()
    {
        // Plugin startup logic
	
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

	// The heavy lifting was already done by MonoMod.RuntimeDetour.HookGen
	// We will just use its hooks.
        On.WizardChanMovement.checkScared += (orig, WIchan) =>
        {
            // If you need to preserve original and do something before/after it
	    // put
            //     orig.Invoke(WIchan);
	    // Where you need to call the original method. 
	    // (since we're just getting rid of the check we 
	    // don't need to call the original, but be carefull,
	    // sometimes the game breakes without original method, 
	    // you can check decompilation in vscode by pressing 
	    // rightclick on WIchan and pressing go to type definition
	    // and see original methods)
	    
            WIchan.scared = false; // brave WizardChan 
        };
    }
}
