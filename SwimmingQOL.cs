using BepInEx;
using HarmonyLib;
using System;
using System.ComponentModel;
using UnityEngine;
using Utilla;
using BepInEx.Configuration;
using System.IO;
using System.Reflection;
using Pathfinding.Util;
using Photon.Pun;

namespace SwimmingQOL
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin("com.kongo.gorillatag.swimmingqol", "SwimmingQOL", "1.0.0")]
    public class SwimmingQOL : BaseUnityPlugin
    {
        bool inRoom;
        bool enable;
        void OnEnable()
        {
            {
                enable = true;
                {
                    if (!enable)
                    {
                GorillaLocomotion.Player.Instance.swimmingParams.swimmingHapticsStrength = -4f;
                        GorillaLocomotion.Player.Instance.waterParams.splashEffectScale = 3f;
                    }
            if (!inRoom)
                return;
            
                    {
                        GorillaLocomotion.Player.Instance.swimmingParams.waterSurfaceJumpMaxSpeed = 2f;
                        GorillaLocomotion.Player.Instance.swimmingParams.handAccelToRedirectAmount = AnimationCurve.Linear(0f, 3f, 3f, 0f);
                        GorillaLocomotion.Player.Instance.swimmingParams.diveDampingMultiplier = 3f;
                        GorillaLocomotion.Player.Instance.swimmingParams.palmFacingToRedirectAmount = AnimationCurve.Linear(0f, 0f, 3f, 3f);
                        GorillaLocomotion.Player.Instance.swimmingParams.handSpeedToRedirectAmount = AnimationCurve.Linear(0f, 3f, 3f, 0f);
                    }
                }
            }
        }

        void OnDisable()
        {
            enable = false;
            GorillaLocomotion.Player.Instance.swimmingParams.swimmingHapticsStrength = 0.5f;
            GorillaLocomotion.Player.Instance.waterParams.splashEffectScale = 1f;
            GorillaLocomotion.Player.Instance.swimmingParams.waterSurfaceJumpMaxSpeed = 1f;
            GorillaLocomotion.Player.Instance.swimmingParams.handAccelToRedirectAmount = AnimationCurve.Linear(0f, 1f, 1f, 0f);
            GorillaLocomotion.Player.Instance.swimmingParams.diveDampingMultiplier = 1f;
            GorillaLocomotion.Player.Instance.swimmingParams.palmFacingToRedirectAmount = AnimationCurve.Linear(0f, 0f, 1f, 3f);
            GorillaLocomotion.Player.Instance.swimmingParams.handSpeedToRedirectAmount = AnimationCurve.Linear(0f, 1f, 1f, 0f);
        }

        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)

        {
            inRoom = true;
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            inRoom = false;
        }
    }
}
class PluginInfo
{
}