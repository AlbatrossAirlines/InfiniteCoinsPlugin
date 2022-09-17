using System;
using BepInEx;
using HarmonyLib;

namespace InfiniteCoins;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class InfiniteCoins : BaseUnityPlugin
{
    private static Harmony _harmony;
    
    private void Awake()
    {
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        _harmony = new Harmony(string.Format("harmony-auto-{0}", (object)Guid.NewGuid()));
        
        var updatePatch = typeof(InfiniteCoinPatches).GetMethod("Update");
        _harmony.Patch(
            AccessTools.Method(typeof(Revolver), "Update"),
            postfix: new HarmonyMethod(updatePatch)
        );
        
        var refreshPatch = typeof(InfiniteCoinPatches).GetMethod("RefreshWeaponCharges");
        _harmony.Patch(
            AccessTools.Method(typeof(WeaponCharges), "Charge"),
            postfix: new HarmonyMethod(refreshPatch)
        );
    }

    private void OnDestroy()
    {
        _harmony?.UnpatchSelf();
    }
}

class InfiniteCoinPatches
{
    private const float MAX_COIN_CHARGE = 400.0f;

    // Patch update to eliminate animation delay
    public static void Update(ref Revolver __instance)
    {
        __instance.pierceCharge = 10000.0f; // Arbitrary large number
    }

    // Patch charge to always refresh coins to max
    public static void RefreshWeaponCharges(float amount, ref WeaponCharges __instance)
    {
        __instance.rev1charge = MAX_COIN_CHARGE;
    }
}
