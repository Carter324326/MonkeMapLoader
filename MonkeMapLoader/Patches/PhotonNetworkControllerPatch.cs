﻿using HarmonyLib;
using GorillaNetworking;
using VmodMonkeMapLoader.Behaviours;

namespace VmodMonkeMapLoader.Patches
{
    [HarmonyPatch(typeof(PhotonNetworkController))]
    [HarmonyPatch("OnJoinedRoom", MethodType.Normal)]
    internal class PhotonNetworkControllerPatch
    {
        private static void Prefix(PhotonNetworkController __instance)
        {
            try
			{
				if(__instance.currentGameType != null)
				{
					if(MapLoader._lobbyName != null)
					{
						if (__instance.currentGameType == "") return;
						if (__instance.currentGameType.Contains(MapLoader._lobbyName) == false) MapLoader.ResetMapProperties();
					}
				}
				else
				{
					MapLoader.ResetMapProperties();
				}
			} catch
			{
				UnityEngine.Debug.LogError("Error in monkemaploader on joined room prefix");
			}
        }
    }
}