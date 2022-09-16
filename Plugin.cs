using BepInEx;
using HarmonyLib;

namespace InfiniteCoins;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class ExplosiveCoins : BaseUnityPlugin
{
    private static Harmony _harmony;
    
    private void Awake()
    {
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        _harmony = Harmony.CreateAndPatchAll(typeof(InfiniteCoins));
    }

    private void OnDestroy()
    {
        _harmony?.UnpatchSelf();
    }
}

[HarmonyPatch(typeof(WeaponCharges), nameof(WeaponCharges.Charge))]
class InfiniteCoins
{
    private const float MAX_COIN_CHARGE = 400.0f;
    
    [HarmonyPostfix]
    public static void RefreshCoinCharges(float _, ref WeaponCharges __instance)
    {
        __instance.rev1charge = MAX_COIN_CHARGE;
    }
}
