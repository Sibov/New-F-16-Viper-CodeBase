using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AircraftSwap
{
    public class AircraftSwapper : VTOLMOD
    {
        private bool AssetLoaded = false;
        private string PathToBundle;
        private GameObject newAircraftPrefab;
        private GameObject newAircraftUnit;
        private Vector3 vehicleScale;
        private VTOLVehicles vehicleType;
        
        

        public override void ModLoaded() { base.ModLoaded(); }
        private void Awake()
        {
            //Asset bundle file name needs to be "f16plane" or the code here needs to be changed for your asset bundle name
            PathToBundle = Directory.GetCurrentDirectory() + @"\VTOLVR_ModLoader\mods\f16plane\f16plane";
            vehicleType = VTOLAPI.GetPlayersVehicleEnum();
            
            //If we haven't already loaded the Asset Bundle
            if (!AssetLoaded)
            {
                //--------------------------------------------Prefab inside the asset bundle needs to be named "f16v2" (case sensitive) or you need to change the code  below to match the prefab name
                newAircraftPrefab = FileLoader.GetAssetBundleAsGameObject(PathToBundle, "f16v2.prefab");
                AssetLoaded = true;
            }
            VTOLAPI.SceneLoaded += SceneLoaded;
            VTOLAPI.MissionReloaded += OnMissionRestart;
            DontDestroyOnLoad(this.gameObject);
        }

        private void SceneLoaded(VTOLScenes arg0)
        {
            switch (arg0)
            {
                case VTOLScenes.Akutan:
                    StartCoroutine(InitWaiter());
                    break;
                case VTOLScenes.OpenWater:
                    StartCoroutine(InitWaiter());
                    break;
                case VTOLScenes.CustomMapBase:
                    StartCoroutine(InitWaiter());
                    break;
            }
        }

        //Waits 2 seconds for the scenario to initialize and the player vehicle to spawn in.
        //Probably doesn't need to be anywhere near this long, but it's just for those guys with old slow hard drives
        private IEnumerator InitWaiter()
        {
            yield return new WaitForSeconds(0.75f);
            SetupNewAircraft();
            yield break;
        }

        private void OnMissionRestart()
        {

            //Additional cleanup in case the plane has crashed/pilot has ejected, and not despawned during the restart.
            if (newAircraftUnit != null)
            {
                Destroy(newAircraftUnit);
                newAircraftUnit = null;
                StartCoroutine(InitWaiter());
            }
            else
            {
                StartCoroutine(InitWaiter());
            }
        }

        private void SetupNewAircraft()
        {
            //Make sure we were able to load the prefab - more null checks == better :*)
            if(newAircraftPrefab != null)
            {
                
              

                //Vehicle specific default local offsets and actions
                Vector3 localOffset = Vector3.zero;
                bool aircraftswitchEnabled = false;

                //Adding localOffset to offset to position the aircraft shell correctly. the first vector is the axis sideways, the second is the height vector, and third is forwards and backwards
                
                VTOLVehicles cv = VTOLAPI.GetPlayersVehicleEnum();
                switch (cv)
                {
                    case VTOLVehicles.FA26B:
                        localOffset = new Vector3(2.9f, -4.2f, 4.3f);
                        aircraftswitchEnabled = true;
                        break;
                    default:
                        aircraftswitchEnabled = false;
                        break;
                }

                if (aircraftswitchEnabled)
                {
                    GameObject defaultAircraft = GameObject.Find("BobblePilot");

                    newAircraftUnit = GameObject.Instantiate(newAircraftPrefab);

                    GameObject aircraftRoot = GameObject.Instantiate(defaultAircraft);
                    aircraftRoot.transform.SetParent(defaultAircraft.transform.parent, true);
                    aircraftRoot.transform.localPosition = localOffset;
                    aircraftRoot.transform.localRotation = Quaternion.Euler(0,0,0);

                    
                    
                    
                    for(int i = 0; i < aircraftRoot.transform.childCount; i++)
                    {
                        Destroy(aircraftRoot.transform.GetChild(i).gameObject);
                    }

                    


                    

                    vehicleScale = newAircraftUnit.transform.localScale;
                    newAircraftUnit.transform.parent = aircraftRoot.transform;
                    newAircraftUnit.transform.localPosition = aircraftRoot.transform.localPosition;
                    newAircraftUnit.transform.localRotation = aircraftRoot.transform.localRotation;

                    //this makes the whole body disappear by setting the scale to zero

                    GameObject.Find("body").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("intakeLeft").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("intakeRight").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("wingRightPart").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("wingLeftPart").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("Canopy").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("airbrakeParent").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("elevonLeftPart").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("elevonRightPart").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("fa26-leftEngine").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("fa26-rightEngine").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("HookTurret").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("sidePanels").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("windshield").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("rudderLeft").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("rudderRight").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("verticalStabLeft_model").transform.localScale = new Vector3(0, 0, 0);
                    GameObject.Find("verticalStabRight_model").transform.localScale = new Vector3(0, 0, 0);

                    Debug.Log("attempting to hide");



                    
                }
            }
        }
    }
}
