﻿using Harmony;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace AircraftSwap
{
   

    [HarmonyPatch(typeof(PilotSelectUI), "Start")]
    class PilotSelectStartPatch
    {

        //Stores whether or not the ccustom vehicle is currently selected
        private static bool tempAircraftSelected = false;

        //Sets the temporary storage to if the vehicle is selected
        public static void Prefix()
        {
           // if (AircraftInfo.AircraftSelected)
            {
              tempAircraftSelected = true;
            }

        }

        //Changes the aircraftselected variable back to true if it was initially selected
        public static void Postfix()
        {

            if (tempAircraftSelected)
            {
                AircraftInfo.AircraftSelected = true;
               AircraftSwapper.instance.checkMPloaded();
                if (AircraftSwapper.instance.MPActive)
                {
                    AircraftSwapper.instance.SetCustomPlaneMP();
                }

                tempAircraftSelected = false;
            }

        }
    }


    [HarmonyPatch(typeof(PilotSelectUI), "SelectVehicle")]
    class VehicleSelectPatch
    {
        private static bool lockAircraftSelect = false;
        public static bool Prefix(PilotSelectUI __instance, PlayerVehicle vehicle)
        {
            F16Debug.Log("Prefix ran!");
            if (vehicle.vehicleName == AircraftInfo.AircraftName)
            {

                F16Debug.Log("f16 ran!");
                //Bool that decides whether or not to run all the aircraft spawn code
                AircraftInfo.AircraftSelected = true;

                AircraftSwapper.instance.checkMPloaded();
                if (AircraftSwapper.instance.MPActive)
                {
                    AircraftSwapper.instance.SetCustomPlaneMP();
                }

                lockAircraftSelect = true;

                __instance.SelectVehicle(PilotSaveManager.GetVehicle("F/A-26B"), null);
                return false;
            }

            if (!lockAircraftSelect)
            {
                AircraftInfo.AircraftSelected = false;
            }

            lockAircraftSelect = false;
            return true;
        }
    }
}