using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Harmony;
using TMPro;
using UnityEngine.UI.Extensions;
using System.Reflection;
using UnityEngine.Networking;


namespace AircraftSwap
{
    //class ClientAircraftSwapF16 : MonoBehaviour
    //{
    //    public GameObject planeObject;
    //    public GameObject newAircraftUnit;

    //    public AircraftSwapper aSwaper;
    //    private void Awake()
    //    {

    //    }
    //    public void doSetup()
    //    {
    //        Transform bodytohide = planeObject.transform.Find("aFighter2");
    //        GameObject bodytohideobj = bodytohide.gameObject;

    //        F16Debug.Log("Running ClientAircraftSwapF16 DoSetup");

    //        MeshRenderer[] meshes = bodytohideobj.GetComponentsInChildren<MeshRenderer>(true);

    //        foreach (MeshRenderer meshtohide in meshes)
    //        {
    //            F16Debug.Log("Hiding: " + meshtohide.ToString());
    //            meshtohide.enabled = false;
    //        }

    //        newAircraftUnit = Instantiate(AircraftSwapper.newAircraftPrefab, planeObject.transform);
    //        ///newAircraftUnitbody = aSwaper.PickupAllChildrensTransforms(newAircraftUnit, "Body");


    //        newAircraftUnit.transform.localScale = Vector3.Scale(newAircraftUnit.transform.localScale, new Vector3(1.22f, 1.22f, 1.22f));
    //        newAircraftUnit.transform.localPosition = new Vector3(0.0f, 1.2f, -0.12f);
    //        newAircraftUnit.transform.localRotation = planeObject.transform.localRotation;
    //        newAircraftUnit.transform.localEulerAngles = new Vector3(0f, 90.0000f, 0f);


    //    }
    //    void FixedUpdate()
    //    {

    //    }
    //    public void OnDestroy()
    //    {

    //    }
    //}
    
    class AircraftInfo
    {
        public static bool AircraftSelected = false;

        //Info about your aircraft
        public const string AircraftName = "F16";
        public const string AircraftNickName = "F16 Viper";
        public const string AircraftDescription = "A multi-role light fighter";
        public static Texture2D MenuTexture;
        //Names of the various files you need to put in your builds folder
        public  const string PreviewPngFileName = "preview.png";
        public static string ModFolderString;
    }
   
    class ClientAircraftSwapF16 : MonoBehaviour
    {
        public GameObject planeObject;
        public GameObject newAircraftUnit;

        public AircraftSwapper aSwaper;
        private AIPilot aiPilot;
        private GameObject RightLGmainpivot;
        private GameObject LeftLGmainpivot;
        private GameObject FrontLGPivot;
        private GameObject f16leftgearcover;
        private GameObject f16rightgearcover;
        private GameObject f16frontgearcover;
        private Vector3 f16leftgearcoverup = new Vector3(-90, 0, 0);
        private Vector3 f16rightgearcoverup = new Vector3(0, 0, 0);
        private Vector3 f16frontgearcoverup = new Vector3(90, 0, 0);
        private Vector3 f16leftgearcoverdown = new Vector3(10, 0, 0);
        private Vector3 f16rightgearcoverdown = new Vector3(-100, 0, 0);
        private Vector3 f16frontgearcoverdown = new Vector3(0, 0, 0);
        private Transform tailnavlightsf26;
        private Transform frontlandinglightsf26;
        private Transform frontlandinglightsflaref26;
        private Transform leftNavLightredf26;
        private Transform LeftRedStrobeLightf26;
        private Transform leftNavLightRearWhitef26;
        private Transform LeftStrobeLightWhitef26;
        private Transform rightNavLightGreenf26;
        private Transform rightNavLightRearWhitef26;
        private Transform RightRedStrobeLightf26;
        private Transform RightStrobeLightWhitef26;
        private Transform frontlandinglightsf16transform;
        private Transform rightwingtoplightsf16transform;
        private Transform leftwingtoplightsf16transform;
        private Transform rightwingbottomlightsf16transform;
        private Transform leftwingbottomlightsf16transform;
        private Transform rightintakelightsf16transform;
        private Transform leftintakelightsf16transform;
        private Transform taillightsf16transform;
        private Transform rearfuselageleftlightsf16transform;
        private Transform rearfuselagerightlightsf16transform;
       
        private GameObject LeftStrobeLightWhitef26obj;
        private GameObject RightRedStrobeLightf26obj;
        private GameObject RightStrobeLightWhitef26obj;
        private GameObject frontlandinglightsf26parent;
        private Transform frontlandinglightsf26light;
        private GameObject landinglightobj;
        private Transform IntakeLightLeft;
        private Transform IntakeLightRight;
        private Transform tailLight;
        private Light IntakeLightLeftLightComp;
        private Light IntakeLightRightLightComp;
        private Light tailLightComp;
        private Transform tailLightCylinder;
        private Material[] tailLightCompRendererMaterials;
        private Material tailLightCompRendererMaterial;
        private Component[] allComponents;
        private int i;
        private Transform HelperLights;
        private Transform aiCockpit;
        private Transform ActiveSwitches;
        private Transform cockpit_in;
        private Transform InstrumentLights;
        private Transform console_F;
        private Transform eject_seat;
        private Transform glareshield;
        private Transform opt_sight;
        private Transform PointerKnob;
        private Transform FullTwisty;
        private Transform SmallTwisty;
        private Transform Normalswitches;
        private Transform cons_F_ins;
        private Transform cons_L_aux;
        private Transform cons_R_aux;
        private Transform console_L;
        private Transform console_R;
        private Transform consR_lamp;
        private Transform leftwingtipvapors;
        private Transform rightwingtipvapors;
        private Transform leftwinginnervapors;
        private Transform rightwinginnervapors;
        private Transform leftwingovervapors;
        private Transform rightwingovervapors;
        private Transform leftwingvaporf16;
        private Transform righttwingvaporf16;
        private Transform leftwingvaporinnerf16;
        private Transform rightwingvaporinnerf16;
        private Transform leftwingovervaporf16;
        private Transform rightwingovervaporf16;

        private void Awake()
        {
            aiPilot = GetComponent<AIPilot>();
            
        }

        public Transform PickupAllChildrensTransforms(GameObject go, string namewanted)
        {
            F16Debug.Log("Running PickupAllChildrensTransforms for : " + go + " , " + namewanted);
            Transform[] allChildren = go.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in allChildren)
            {
                F16Debug.Log("Getting child: " + child.gameObject.name);


                if (child.gameObject.name != namewanted)
                {

                }
                else
                {
                    F16Debug.Log("Getting components of children");

                    GameObject childobj = child.gameObject;

                    //this just lists all the components in the system for the one we were looking for to help with fixing
                    allComponents = childobj.GetComponents(typeof(Transform));
                    i = 0;
                    foreach (Transform component in allComponents)
                    {
                        ++i;
                        F16Debug.Log(childobj.name + " Text " + i + ": " + component.name);

                        return component;
                    }




                }



            }
            return null;
        }

        private void vapors()
        {
            //wingtip vapors
            leftwingtipvapors = PickupAllChildrensTransforms(gameObject, "WingVapor (7)");
            rightwingtipvapors = PickupAllChildrensTransforms(gameObject, "WingVapor (6)");
            leftwinginnervapors = PickupAllChildrensTransforms(gameObject, "WingVapor (3)");
            rightwinginnervapors = PickupAllChildrensTransforms(gameObject, "WingVapor (1)");
            leftwingovervapors = PickupAllChildrensTransforms(gameObject, "WingVapor (4)");
            rightwingovervapors = PickupAllChildrensTransforms(gameObject, "WingVapor (2)");


            leftwingvaporf16 = PickupAllChildrensTransforms(newAircraftUnit, "leftwingvaporf16");
            righttwingvaporf16 = PickupAllChildrensTransforms(newAircraftUnit, "rightwingvaporf16");
            leftwingvaporinnerf16 = PickupAllChildrensTransforms(newAircraftUnit, "leftwingvaporf16innerwing");
            rightwingvaporinnerf16 = PickupAllChildrensTransforms(newAircraftUnit, "rightwingvaporf16innerwing");
            leftwingovervaporf16 = PickupAllChildrensTransforms(newAircraftUnit, "leftwingvaporf16overwing");
            rightwingovervaporf16 = PickupAllChildrensTransforms(newAircraftUnit, "rightwingvaporf16overwing");


            leftwingtipvapors.position = leftwingvaporf16.position;
            rightwingtipvapors.position = righttwingvaporf16.position;
            leftwinginnervapors.position = leftwingvaporinnerf16.position;
            rightwinginnervapors.position = rightwingvaporinnerf16.position;
            leftwingovervapors.position = leftwingovervaporf16.position;
            rightwingovervapors.position = rightwingovervaporf16.position;
            leftwingovervapors.localScale = new Vector3(0.66f, 1f, 0.66f);
            rightwingovervapors.localScale = new Vector3(0.66f, 1f, 0.66f);
        }

        private void hardpoints()
        {
            GameObject HP1actual = PickupAllChildrensTransforms(gameObject, "HP1").gameObject;
            GameObject HP2actual = PickupAllChildrensTransforms(gameObject, "HP2").gameObject;
            GameObject HP9actual = PickupAllChildrensTransforms(gameObject, "HP9").gameObject;
            GameObject HP10actual = PickupAllChildrensTransforms(gameObject, "HP10").gameObject;
            GameObject HP3actual = PickupAllChildrensTransforms(gameObject, "HP3").gameObject;
            GameObject HP4actual = PickupAllChildrensTransforms(gameObject, "HP4").gameObject;
            GameObject HP5actual = PickupAllChildrensTransforms(gameObject, "HP5").gameObject;
            GameObject HP6actual = PickupAllChildrensTransforms(gameObject, "HP6").gameObject;
            GameObject HP7actual = PickupAllChildrensTransforms(gameObject, "HP7").gameObject;
            GameObject HP8actual = PickupAllChildrensTransforms(gameObject, "HP8").gameObject;
            GameObject HP13actual = PickupAllChildrensTransforms(gameObject, "HP13DropTank").gameObject;
            GameObject HP12actual = PickupAllChildrensTransforms(gameObject, "HP12DropTank").gameObject;
            GameObject HP11actual = PickupAllChildrensTransforms(gameObject, "HP11DropTank").gameObject;
            GameObject HP14actual = PickupAllChildrensTransforms(gameObject, "HP14 TGP").gameObject;
            

            Transform f16HP1 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint1");
            Transform f16HP2 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint2");
            Transform f16HP3 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint3");

            Transform f16HP8 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint8");
            Transform f16HP9 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint9");
            Transform f16HP10 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint10");
            Transform f16HP11 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint11");
            Transform f16HP12 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint12");
            Transform f16HP13 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint13");
            Transform f16HP14 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint14");
            Transform f16GunTransform = PickupAllChildrensTransforms(newAircraftUnit, "f16gunbarrels");

            
            

            Transform f26GunBoxTransform = PickupAllChildrensTransforms(gameObject, "HPGun");
            f26GunBoxTransform.position = f16GunTransform.position;

            

           

            //Move Hardpoints


            HP1actual.transform.position = f16HP1.position;
            HP1actual.transform.SetParent(f16HP1);
            HP2actual.transform.position = f16HP2.position;
            HP2actual.transform.SetParent(f16HP2);
            HP3actual.transform.position = f16HP3.position;
            HP3actual.transform.rotation = f16HP3.rotation;
            HP3actual.transform.SetParent(f16HP3);
            HP8actual.transform.position = f16HP8.position;
            HP8actual.transform.SetParent(f16HP8);
            HP8actual.transform.rotation = f16HP8.rotation;
            HP9actual.transform.position = f16HP9.position;
            HP9actual.transform.SetParent(f16HP9);
            HP10actual.transform.position = f16HP10.position;
            HP10actual.transform.SetParent(f16HP10);
            HP11actual.transform.position = f16HP11.position;
            HP11actual.transform.SetParent(f16HP11);
            HP12actual.transform.position = f16HP12.position;
            HP12actual.transform.SetParent(f16HP12);
            HP13actual.transform.position = f16HP13.position;
            HP13actual.transform.SetParent(f16HP13);
            HP14actual.transform.position = f16HP14.position;
            HP14actual.transform.rotation = f16HP14.rotation;
            HP14actual.transform.SetParent(f16HP14);

        }

        private void lights()
        {
            //get all lights from f26

            F16Debug.Log("lights_1");

            tailnavlightsf26 = PickupAllChildrensTransforms(gameObject, "TailNavLight");
            enableMesh(tailnavlightsf26.gameObject);
            leftNavLightredf26 = PickupAllChildrensTransforms(gameObject, "LeftFwdLight");
            enableMesh(leftNavLightredf26.gameObject); 
            LeftRedStrobeLightf26 = PickupAllChildrensTransforms(gameObject, "LeftRedStrobeLight");
            enableMesh(LeftRedStrobeLightf26.gameObject);
            leftNavLightRearWhitef26 = PickupAllChildrensTransforms(gameObject, "LeftRearLight");
            enableMesh(leftNavLightRearWhitef26.gameObject);
            LeftStrobeLightWhitef26 = PickupAllChildrensTransforms(gameObject, "LeftStrobeLight");
            enableMesh(LeftStrobeLightWhitef26.gameObject);
            rightNavLightGreenf26 = PickupAllChildrensTransforms(gameObject, "RightFwdNavLight");
            enableMesh(rightNavLightGreenf26.gameObject);
            rightNavLightRearWhitef26 = PickupAllChildrensTransforms(gameObject, "RightRearNavLight");
            enableMesh(rightNavLightRearWhitef26.gameObject);
            RightRedStrobeLightf26 = PickupAllChildrensTransforms(gameObject, "RightRedStrobeLight");
            enableMesh(RightRedStrobeLightf26.gameObject);
            RightStrobeLightWhitef26 = PickupAllChildrensTransforms(gameObject, "RightStrobeLight");
            enableMesh(RightStrobeLightWhitef26.gameObject);

            frontlandinglightsf26 = PickupAllChildrensTransforms(gameObject, "LandingLightGearDownEnabler");
            enableMesh(frontlandinglightsf26.gameObject);
            F16Debug.Log("lights_2");
            //get all f16 light locations in model
            frontlandinglightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "frontlandinglightsf16transform");
            rightwingtoplightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "rightwingtoplightsf16transform");
            leftwingtoplightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "leftwingtoplightsf16transform");
            rightwingbottomlightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "rightwingbottomlightsf16transform");
            leftwingbottomlightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "leftwingbottomlightsf16transform");
            rightintakelightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "rightintakelightsf16transform");
            leftintakelightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "leftintakelightsf16transform");
            taillightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "taillightsf16transform");

            rearfuselageleftlightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "rearfuselageleftlightsf16transform");
            rearfuselagerightlightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "rearfuselagerightlightsf16transform");

            F16Debug.Log("lights_3");

            List<Transform> LightList = new List<Transform>();
            LightList.Add(frontlandinglightsf26);

            LightList.Add(leftNavLightredf26);
            LightList.Add(LeftRedStrobeLightf26);
            LightList.Add(leftNavLightRearWhitef26);
            LightList.Add(LeftStrobeLightWhitef26);
            LightList.Add(rightNavLightGreenf26);
            LightList.Add(rightNavLightRearWhitef26);
            LightList.Add(RightRedStrobeLightf26);
            LightList.Add(RightStrobeLightWhitef26);
            LightList.Add(frontlandinglightsf16transform);
            LightList.Add(rightwingtoplightsf16transform);
            LightList.Add(leftwingtoplightsf16transform);
            LightList.Add(rightwingbottomlightsf16transform);
            LightList.Add(leftwingbottomlightsf16transform);
            LightList.Add(rightintakelightsf16transform);
            LightList.Add(leftintakelightsf16transform);
            LightList.Add(taillightsf16transform);

            foreach (Transform lightitem in LightList)

            {
                if (lightitem == null) { F16Debug.Log("This item could not be found = " + lightitem.name); } else { F16Debug.Log("This item found = " + lightitem.name); }
                Light lightComponent = lightitem.GetComponent<Light>();
                SpriteRenderer lightSprite = lightitem.GetComponent<SpriteRenderer>();
                if (lightComponent != null) { lightComponent.enabled = true; }
                if (lightSprite != null) { lightSprite.enabled = true; }


                if (lightitem.name == "TailNavLight") { lightSprite.enabled = false; lightComponent.enabled = false; }
            }


            //place all lights on f16 transforms
            frontlandinglightsf26.transform.position = frontlandinglightsf16transform.position;
            frontlandinglightsf26.transform.rotation = frontlandinglightsf16transform.rotation;


            F16Debug.Log("lights_4");
            leftNavLightredf26.position = leftintakelightsf16transform.position;
            LeftRedStrobeLightf26.position = leftwingbottomlightsf16transform.position;
            leftNavLightRearWhitef26.position = rearfuselageleftlightsf16transform.position;
            LeftStrobeLightWhitef26.position = rearfuselageleftlightsf16transform.position; //needs to be red

            F16Debug.Log("lights_5");
            rightNavLightGreenf26.position = rightintakelightsf16transform.position;
            rightNavLightRearWhitef26.position = rearfuselagerightlightsf16transform.position;
            RightRedStrobeLightf26.position = rightwingtoplightsf16transform.position; //needs to be green
            RightStrobeLightWhitef26.position = rightwingbottomlightsf16transform.position; //needs to be green
            F16Debug.Log("lights_6");

            Color color0 = Color.red;



            //change this white light to red
            LeftStrobeLightWhitef26obj = LeftStrobeLightWhitef26.gameObject;
            Light lsf26 = LeftStrobeLightWhitef26obj.GetComponent<Light>();
            lsf26.color = color0;




            Color color1 = Color.green;

            F16Debug.Log("lights_7");
            //change this red light to green
            RightRedStrobeLightf26obj = RightRedStrobeLightf26.gameObject;
            Light rrsf26 = RightRedStrobeLightf26obj.GetComponent<Light>();
            F16Debug.Log("lights_8");

            rrsf26.color = color1;

            //change this white light to green
            RightStrobeLightWhitef26obj = RightStrobeLightWhitef26.gameObject;
            Light rsw26 = RightStrobeLightWhitef26obj.GetComponent<Light>();

            rsw26.color = color1;




            IntakeLightLeft = PickupAllChildrensTransforms(leftintakelightsf16transform.gameObject, "leftIntakeLight");
            IntakeLightRight = PickupAllChildrensTransforms(rightintakelightsf16transform.gameObject, "rightIntakeLight");
            tailLight = PickupAllChildrensTransforms(taillightsf16transform.gameObject, "tailLight");

            IntakeLightLeftLightComp = IntakeLightLeft.GetComponent<Light>();
            IntakeLightRightLightComp = IntakeLightRight.GetComponent<Light>();
            tailLightComp = tailLight.GetComponent<Light>();

            tailLightCylinder = PickupAllChildrensTransforms(taillightsf16transform.gameObject, "Cylinder");
            tailLightCompRendererMaterials = tailLightCylinder.GetComponent<MeshRenderer>().materials;
            foreach (Material materialitem in tailLightCompRendererMaterials)
            {
                F16Debug.Log("Material Name = " + materialitem.name);
                if (materialitem.name == "taillight (Instance)")
                {
                    tailLightCompRendererMaterial = materialitem;

                }
            }


        }

        private void SetLandingGearClose()
        {
            F16Debug.Log("Landing Gear Close AI");
            RightLGmainpivot = GetChildWithName(newAircraftUnit, "RightLGmainpivot", true);
            LeftLGmainpivot = GetChildWithName(newAircraftUnit, "LeftLGmainpivot", true);
            FrontLGPivot = GetChildWithName(newAircraftUnit, "FrontLGPivot", true);
            f16leftgearcover = GetChildWithName(newAircraftUnit, "LeftMainLGCoverPivot",true);
            f16rightgearcover = GetChildWithName(newAircraftUnit, "RightMainLGCoverPivot", true);
            f16frontgearcover = GetChildWithName(newAircraftUnit, "frontLGcoverpivot", true);


            disableMesh(RightLGmainpivot);
            disableMesh(LeftLGmainpivot);
            disableMesh(FrontLGPivot);
            
            f16leftgearcover.transform.localEulerAngles = f16leftgearcoverup;
            f16rightgearcover.transform.localEulerAngles = f16rightgearcoverup;
            f16frontgearcover.transform.localEulerAngles = f16frontgearcoverup;


        }
        private void SetLandingGearOpen()
        {
            F16Debug.Log("Landing Gear Open AI");
            RightLGmainpivot = GetChildWithName(newAircraftUnit, "RightLGmainpivot", true);
            LeftLGmainpivot = GetChildWithName(newAircraftUnit, "LeftLGmainpivot", true);
            FrontLGPivot = GetChildWithName(newAircraftUnit, "FrontLGPivot", true);
            f16leftgearcover = GetChildWithName(newAircraftUnit, "LeftMainLGCoverPivot", true);
            f16rightgearcover = GetChildWithName(newAircraftUnit, "RightMainLGCoverPivot", true);
            f16frontgearcover = GetChildWithName(newAircraftUnit, "frontLGcoverpivot", true);


            

            f16leftgearcover.transform.localEulerAngles = f16leftgearcoverdown;
            f16rightgearcover.transform.localEulerAngles = f16rightgearcoverdown;
            f16frontgearcover.transform.localEulerAngles = f16frontgearcoverdown;
            enableMesh(RightLGmainpivot);
            enableMesh(LeftLGmainpivot);
            enableMesh(FrontLGPivot);

        }


        public void disableMesh(GameObject parent)
        {

            MeshRenderer[] meshes = parent.GetComponentsInChildren<MeshRenderer>(true);

            foreach (MeshRenderer meshtohide in meshes)
            {
                F16Debug.Log("Hiding: " + meshtohide.ToString());
                meshtohide.enabled = false;

            }

        }

        public void enableMesh(GameObject parent)
        {

            MeshRenderer[] meshes = parent.GetComponentsInChildren<MeshRenderer>(true);

            foreach (MeshRenderer meshtohide in meshes)
            {
                F16Debug.Log("unhiding: " + meshtohide.ToString());
                meshtohide.enabled = true;

            }

        }

        //public static void disableMesh(GameObject parent, WeaponManager wm)
        //{
        //    MeshRenderer[] meshes = parent.GetComponentsInChildren<MeshRenderer>(true);

        //    foreach (MeshRenderer mesh in meshes)
        //    {
        //        if (wm != null && !isHardPoint(mesh, wm))
        //        {
        //            mesh.enabled = false;
        //        }

        //    }

        //}
        public static bool isHardPoint(MeshRenderer mesh, WeaponManager wm)
        {
            foreach (Transform transform in wm.hardpointTransforms)
            {
                if (mesh.gameObject.transform.IsChildOf(transform) && transform != wm.hardpointTransforms[15])
                {
                    return true;
                }
            }

            return false;
        }
        public static GameObject GetChildWithName(GameObject obj, string name, bool active)
        {


            Transform[] children = obj.GetComponentsInChildren<Transform>(active);
            foreach (Transform child in children)
            {
                if (child.name == name || child.name.Contains(name + "(clone"))
                {
                    return child.gameObject;
                }
            }


            return null;

        }
        public void doSetup()
        {
           // F16Debug.unityLogger.logEnabled = true;
            F16Debug.Log("Do Setup Started");
            WeaponManager wm = planeObject.GetComponent<WeaponManager>();
            disableMesh(GetChildWithName(gameObject, "body", true));
            disableMesh(GetChildWithName(gameObject, "body (LOD1)", true));
            disableMesh(GetChildWithName(gameObject, "FuelPort", true));
            disableMesh(GetChildWithName(gameObject, "intakeLeft", true));
            disableMesh(GetChildWithName(gameObject, "intakeRight", true));
            disableMesh(GetChildWithName(gameObject, "elevonLeftPart", true));
            disableMesh(GetChildWithName(gameObject, "elevonRightPart", true));
            disableMesh(GetChildWithName(gameObject, "verticalStabLeft", true));
            disableMesh(GetChildWithName(gameObject, "verticalStabRight", true));
            disableMesh(GetChildWithName(gameObject, "wingLeftPart", true));
            disableMesh(GetChildWithName(gameObject, "wingRightPart", true));
            //disableMesh(GetChildWithName(gameObject, "vgEngineLowPoly", true));
            disableMesh(GetChildWithName(gameObject, "afterBurner", true));
            disableMesh(GetChildWithName(gameObject, "LandingGear", true));
            disableMesh(GetChildWithName(gameObject, "airbrakeParent", true));
            disableMesh(GetChildWithName(gameObject, "canopy", true));
            disableMesh(GetChildWithName(gameObject, "windshield", true));
            disableMesh(GetChildWithName(gameObject, "windshield.002 (LOD1)", true));
            disableMesh(GetChildWithName(gameObject, "cockpitFrame", true));
            disableMesh(GetChildWithName(gameObject, "cockpitFrame.002 (LOD1)", true));
            disableMesh(GetChildWithName(gameObject, "WingVapor (3)", true));
            disableMesh(GetChildWithName(gameObject, "WingVapor (1)", true));
            disableMesh(GetChildWithName(gameObject, "MachCloud", true));
            disableMesh(GetChildWithName(gameObject, "lod2", true));
            //disableMesh(GetChildWithName(gameObject, "ExtLights", true));
            disableMesh(GetChildWithName(gameObject, "HookTurret", true));
            disableMesh(GetChildWithName(gameObject, "lowPolyInterior", true));


           

            GameObject leftengine = GetChildWithName(gameObject, "vgEngineLowPoly", true);
            leftengine.SetActive(false);
            GameObject rightengine = GetChildWithName(gameObject, "vgEngineLowPoly", false);
            rightengine.SetActive(false);
            leftengine.SetActive(true);
            //disableMesh(GetChildWithName(gameObject, "WingVapor (3)"), wm);

            GameObject engineFXgo = GetChildWithName(gameObject, "EngineFX", true);

            engineFXgo.transform.localPosition = new Vector3(-0.2f, 0f, 0f);
            
            GameObject left2engineburner = GetChildWithName(gameObject, "afterBurner", true);
            left2engineburner.SetActive(false);
            GameObject rightengineburner = GetChildWithName(gameObject, "afterBurner", false);
            GameObject left2engineburnerouter = GetChildWithName(left2engineburner, "afterBurnerOuter", true);
            
            GameObject rightengineburnerouter = GetChildWithName(rightengineburner, "afterBurnerOuter", false);


            
            





            newAircraftUnit = Instantiate(AircraftSwapper.newAircraftPrefab, planeObject.transform);
            ///newAircraftUnitbody = aSwaper.PickupAllChildrensTransforms(newAircraftUnit, "Body");
            left2engineburner.SetActive(true);

            leftengine.transform.localPosition = new Vector3(0f, 0.13f,-2.6f);
            leftengine.transform.localScale = new Vector3(0.88f, 0.88f, 0.88f);
            left2engineburner.transform.localPosition = new Vector3(0f, 0f, 0f);


            rightengineburner.transform.localPosition = new Vector3 (0f, 0f,-1f) ;
            rightengineburnerouter.transform.localPosition = new Vector3(0f, 0f, -1f);

            rightengineburner.transform.localScale = new Vector3(0.88f, 0.88f, 0.88f);
            rightengine.transform.localPosition = new Vector3(2f, 1.32f, 2f);


            left2engineburner.GetComponent<ParticleSystem>().enableEmission = false;
            left2engineburnerouter.GetComponent<ParticleSystem>().enableEmission = false;
            rightengine.SetActive(false);
            disableMesh(rightengine);

            HelperLights = PickupAllChildrensTransforms(newAircraftUnit, "HelperLights");
            HelperLights.gameObject.SetActiveRecursively(false);
            InstrumentLights = PickupAllChildrensTransforms(newAircraftUnit, "InstrumentLights");
            InstrumentLights.gameObject.SetActiveRecursively(false);

            aiCockpit = PickupAllChildrensTransforms(newAircraftUnit, "f16cockpit");
            ActiveSwitches = PickupAllChildrensTransforms(aiCockpit.gameObject, "ActiveSwitches");
            ActiveSwitches.gameObject.SetActive(false);
            PointerKnob = PickupAllChildrensTransforms(aiCockpit.gameObject, "Pointerknob");
            PointerKnob.gameObject.SetActive(false);
            FullTwisty = PickupAllChildrensTransforms(aiCockpit.gameObject, "Fulltwisty");
            FullTwisty.gameObject.SetActive(false);
            SmallTwisty = PickupAllChildrensTransforms(aiCockpit.gameObject, "Smalltwisty");
            SmallTwisty.gameObject.SetActive(false);
            cons_F_ins = PickupAllChildrensTransforms(aiCockpit.gameObject, "cons_F_ins");
            cons_F_ins.gameObject.SetActive(false);
            cons_L_aux = PickupAllChildrensTransforms(aiCockpit.gameObject, "cons_L_aux");
            cons_L_aux.gameObject.SetActive(false);
            cons_R_aux = PickupAllChildrensTransforms(aiCockpit.gameObject, "cons_R_aux");
            cons_R_aux.gameObject.SetActive(false);
            console_L = PickupAllChildrensTransforms(aiCockpit.gameObject, "console_L");
            console_L.gameObject.SetActive(false);
            console_R = PickupAllChildrensTransforms(aiCockpit.gameObject, "console_R");
            console_R.gameObject.SetActive(false);
            consR_lamp = PickupAllChildrensTransforms(aiCockpit.gameObject, "consR_lamp");
            consR_lamp.gameObject.SetActive(false);



            newAircraftUnit.transform.localScale = Vector3.Scale(newAircraftUnit.transform.localScale, new Vector3(1.22f, 1.22f, 1.22f));
            newAircraftUnit.transform.localPosition = new Vector3(0.0f, 1.2f, -0.12f);
            newAircraftUnit.transform.localRotation = planeObject.transform.localRotation;
            newAircraftUnit.transform.localEulerAngles = new Vector3(0f, 90.0000f, 0f);
            aiPilot.gearAnimator.OnClosed.AddListener(SetLandingGearClose);
            aiPilot.gearAnimator.OnOpened.AddListener(SetLandingGearOpen);
            lights();
            vapors();
            hardpoints();

        }
        void FixedUpdate()
        {

        }
        public void OnDestroy()
        {

        }
    }


    public class AircraftSwapper : VTOLMOD
    {
        public static AircraftSwapper instance;
        private const int V = 0;
        private bool AssetLoaded = false;
        private string PathToBundle;
        public static GameObject newAircraftPrefab;
        private Transform f26UndercLeftSuspension;
        private Transform f26UndercRightSuspension;
        private Transform f26UndercFrontSuspension;
        private Transform f26UndercLeftGear;
        private Transform f26UndercRightGear;
        private Transform f26UndercFrontGear;
        private RaySpringDamper f26UndercFrontSuspensionRSD;
        private RaySpringDamper f26UndercLeftSuspensionRSD;
        private RaySpringDamper f26UndercRightSuspensionRSD;
        private Transform parachuteMesh;
        private SkinnedMeshRenderer parachuteMeshsMR;
        private GameObject newAircraftUnit;
        private Transform newAircraftUnitbody;
        private MeshFilter newAircraftUnitBodyMF;
        private VTOLVehicles vehicleType;
        private Quaternion HP9Rotation;
        private Vector3 HP4Offset;
        private Vector3 HP3Rotation;
        private Vector3 leftEnginePosition;
        private Vector3 GunOffset;
        private Vector3 UnderDroptankOffset;
        private string partDefined;
        private Transform defaultF26Transform;
        private Transform defaultF26AFTransform;
        private Transform defaultF26AFTransformBody;
        private MeshFilter defaultF26AFTransformBodyMF;
        private Vector3 HP14Rotation;
        private Vector3 HP14Offset;
        List<string> damageableparts = new List<string>() { "wingtipRight_damaged", "wingtipLeft_damaged", "aileronRight_damaged", "aileronLeft_damaged", "wingLeft_damaged", "wingLeft_destroyed", "wingRight_destroyed", "wingRight_damaged", "elevonLeft_destroyed", "elevonRight_destroyed", "elevonLeft_destroyed", "verticalStabLeft_destroyed", "verticalStabRight_destroyed" };
        private Vector3 HP5Rotation;
        private Vector3 HP5Offset;
        private Vector3 HP6Offset;
        private Vector3 HP8Offset;
        private Vector3 HP8Rotation;
        private Vector3 HP8Position;
        private float engMultiplier;
        private float waitVar;
        private float engValue;
        private Component[] allComponents;
        private int i;
        private Vector3 HP7Offset;
        private bool LockedHP;
        private VTOLScenes scene;
        public float changeAmount;
        private Vector3 leftEngineOffset;
        private Vector3 rightEngineOffset;
        private Vector3 HP11Offset;
        private Vector3 HP12Offset;
        private List<string> ListofDashObjects;
        private int partCounter;
        private GameObject partFlash;
        private string myText;
        public GameObject ParentMFDObject1;
        private Transform ParentMFDObject1Transform;
        public GameObject ChildMFDObject1;
        private GameObject ChildMFDObject2;
        private GameObject ChildMFDObject3;
        private GameObject ParentMFD2Object1;
        private GameObject ChildMFD2Object1;
        private GameObject ChildMFD2Object2;
        private GameObject ChildMFD2Object3;
        private Vector3 ParentMFD1Oldposition;
        private Vector3 ParentMFD1Oldrotation;
        private Vector3 ParentMFD2Oldposition;
        private Vector3 ParentMFD2Oldrotation;
        public List<GameObject> ListOfObjectsWithName = new List<GameObject>();
        private Vector3 HUDCanvasOffset;
        private Transform childElement;
        private List<string> EndPanels;
        private bool aircraftSwitchEnabled = false;
        private int lockedHPNum;
        private List<string> myEquips;
        private int equipCounter;
        private Transform f26LoadoutScreenTransform;
        private Transform TWRText;
        private Transform TitleText;
        private Text TWRTextScript;
        private Text TitleTextScript;
        private GameObject cockpit;
        private GameObject cockpitGlass;
        private GameObject cockpitBolts;
        private Transform cockpitHandles;
        private GameObject cockpitPivotObj;
        private string isDoneCockpitOpen;
        private Vector3 cockpitAngle;
        private Vector3 cockpitGlassAngle;
        private string nameWanted;
        private Text planeName;
        private GameObject searchInObject;
        private ParticleSystem myParticles;
        private float aircraftWeightInMetricTonnes;
        private float maxaircraftfuelinkg;
        private FuelTank ft;
        private string maverickx1Hardpoints;
        private GameObject maverickx1MissileObj;
        private int hpCount;
        private float startTime;
        private Quaternion newRotation;
        private Vector3 f26CockpitRotationWhenClosed;
        private Vector3 f26CockpitRotationWhenOpen;

        public GameObject f26Cockpit;

        private Transform f26CockpitTransform;
        private Vector3 f26CockpitRotationStateAtStartOfScene;
        private int flc;
        private int lglCheck;
        private Transform HelpLightsHolder;
        private GameObject CanopyLeverObject;
        private float waitInterval; // close the door after x seconds
        private float landinggearwaitInterval;
        private float landinggearcoverduration;
        private float landinggearduration;
        private float canopyduration; // rotation speed
        private Vector3 defaultRotation; // store the rotation when starting the game
        private bool isActive = false;
        private bool closeAgain; // close the door again?
        private Transform cockpitPivot;
        private Animator f16CanopyAnimator;
        private Vector3 targetRotationopen; // rotation angles
        private Vector3 pivotPosition;
        private Transform aileronleft;
        private GameObject aileronleftobj;
        private Transform aileronleftaero;
        private GameObject aileronleftaeroobj;
        private Transform aileronleftmodel;
        private GameObject aileronleftmodelobj;
        private GameObject AileronLeftf16;
        private Vector3 ScaleallHPS;
        private Vector3 Scaleoffset;
        private GameObject HP1actual;
        private GameObject HP2actual;
        private GameObject HP3actual;
        private GameObject HP4actual;
        private GameObject HP5actual;
        private GameObject HP6actual;
        private GameObject HP7actual;
        private GameObject HP8actual;
        private GameObject HP9actual;
        private GameObject HP10actual;
        private GameObject HP11actual;
        private GameObject HP12actual;
        private float aileronleftpos;
        private Transform AileronLeftf16t;
        private Vector3 f26aileronleftatrest;
        private Vector3 f16aileronlefthingeatrest;
        private Vector3 f16aileronleftatrest;
        private Vector3 f16taileronleftatrest;
        private Vector3 f26aileronleftdelta;
        private float f26aileronleftdeltax;
        private float f26aileronleftdeltay;
        private float f26aileronleftdeltaz;
        private float f26elevonleftdeltax;
        private float f26elevonleftdeltay;
        private GameObject aileronlefthinge;
        private Vector3 moveaileronlefthinge;
        private GameObject taileronlefthinge;
        private Vector3 movetaileronlefthinge;
        private GameObject Aileronrightf16;
        private Vector3 f16taileronlefthingeatrest;
        private Vector3 aileronlefthingestart;
        private Transform Aileronrightf16t;
        private Vector3 f26aileronrightatrest;
        private Transform elevonleft;
        private Vector3 f26elevonleftatrest;
        private Transform elevonright;
        private Vector3 f26elevonrightatrest;
        private Transform f26rudderleft;
        private Vector3 f26rudderleftatRest;
        private Vector3 f16aileronrighthingeatrest;
        private Vector3 f16aileronrightatrest;
        private Vector3 f16taileronrightatrest;
        private Vector3 f26aileronrightdelta;
        private float f26aileronrightdeltax;
        private float f26aileronrightdeltay;
        private float f26aileronrightdeltaz;
        private float f26elevonrightdeltax;
        private float f26elevonrightdeltay;
        private float f26elevonrightdeltaz;
        private GameObject aileronrighthinge;
        private Vector3 moveaileronrighthinge;
        private GameObject taileronrighthinge;
        private Vector3 movetaileronrighthinge;
        private GameObject rudderhinge;
        private Vector3 f16taileronrighthingeatrest;
        private Vector3 aileronrighthingestart;
        private Transform aileronright;
        private GameObject aileronrightobj;
        private Transform aileronrightaero;
        private GameObject aileronrightaeroobj;
        private Transform aileronrightmodel;
        private GameObject aileronrightmodelobj;
        private float f26elevonleftdeltaz;
        private float newaileronrightpositionz;
        private float newtaileronrightpositionz;
        private float newtaileronleftpositionz;
        private float newaileronleftpositionz;
        private Vector3 f16rudderhingeatrest;
        private Vector3 moverudderhinge;
        private float newrudderpositiony;
        private float f26rudderdeltax;
        private float f26rudderdeltay;
        private float f26rudderdeltaz;
        private GameObject leflaplefthinge;
        private Vector3 f16leflefthingeatrest;
        private Vector3 moveleftlefhinge;
        private Vector3 moveleftlefthinge;
        private GameObject leflaprighthinge;
        private Vector3 f16lefrighthingeatrest;
        private Vector3 moverightlefhinge;
        private Vector3 moverightrighthinge;
        private float newlefleftslatpositionz;
        private float newlefrightslatpositionz;
        public GameObject defaultf26;
        private float pitchvalue;
        private FlightInfo attitude;
        private float currentgvalue;
        private float yawvalue;
        private Vector3 verticalaxis;
        private int cl;
        private Transform leftwingtipvapors;
        private Transform rightwingtipvapors;
        private Transform leftwinginnervapors;
        private Transform rightwinginnervapors;
        private Transform leftwingovervapors;
        private Transform rightwingovervapors;
        private Transform leftwingvaporf16;
        private Transform righttwingvaporf16;
        private Transform leftwingvaporinnerf16;
        private Transform rightwingvaporinnerf16;
        private Transform leftwingovervaporf16;
        private Transform rightwingovervaporf16;
        private Transform WingFolder;
        private GameObject LandingFlapsLeverObject;
        private GameObject CanopyF26;
        private GameObject cockpitwindobj;
        private AudioSource cwnoise;
        private GameObject cockpitbreakobj;
        private AudioSource cbreaknoise;
        private Transform intakelAudio;
        private Transform jetlAudio;
        private Transform ablAudio;
        private Transform intakeAudio;
        private Transform jetAudio;
        private Transform abAudio;
        private CanopyAnimator CanopyF26Anim;
        private int Cockpitopenflagforf26;
        private GameObject CoMValueObj;
        private Transform Comvalue;
        private Transform f16com;
        private Transform aoaref;
        private Transform f16aoareftrans;
        private float landingflapposition;
        private GameObject airbrakeobj;
        private GameObject airbrakepiston;
        public AirBrakeController airBrakeController;
        private Vector3 defaultairbrakerotation = new Vector3(271.5f, 180f, 180f);
        private Transform airbrakelefthingeupperobj;
        private Transform airbrakelefthingelowerobj;
        private Transform airbrakerighthingeupperobj;
        private Transform airbrakerighthingelowerobj;
        private GameObject F26leftengine;
        private Transform F26Nozzle;
        private bool AircraftLoaded;
        private SpriteRenderer tailnavlightsf26sprite;
        private Transform MainBatterySwitchF26;
        private Transform MainBatterySwitchF26I;
        private VRInteractable MainBatterySwitchF26IVR;
        private Transform F26Posebounds;
        private Transform f26LeftPanelPoseBounds;
        private PoseBounds f26LeftPanelPoseBoundsComp;
        private Transform f26LeftPanel;
        private Transform f16posebounds;
        private Transform LeftDashPoseBoundsf16;
        private Transform RightDashPoseBoundsf16;
        private Transform f16leftpanelposebound;
        private Transform F16Cockpit;
        private Transform F16CockpitActiveSwitches;
        private Transform f16cockpitswitch_transform;
        private Transform f16masterarmswitch_transform;
        private Transform f16extlightingmaster_transform;
        private Transform extlightingflash_transform;
        private Transform extlightinganticollision_transform;
        private Transform extlightingwingtail_transform;
        private Transform extlightingfuselage_transform;
        private Transform jetfuelstart_transform;

        public Transform CMDSchaff_transform;
        public Transform CMDSflare_transform;
        public Transform RWRonoff_transform;

        private Transform parkingbrake_transform;

        public Transform MFDLeft_transform;
        public Transform MFDRight_transform;
        private Transform RWRMFD_transform;
        private Transform FuelFlowMeter_transform;
        private Transform SpeedIndicator_transform;
        private Transform AltitudeIndicator_transform;
        private Transform VSI_Indicator_trans;
        private Transform Attitude_Indicator_trans;
        private Transform Compass_Indicator_trans;
        private Transform SeatAdjustertrans;
        private Transform f16SeatAdjuster;
        private Transform F16ElectricMainSwitch;
        private Transform F26ElectricMainSwitchLever;
        private Transform F26ElectricMainSwitchParent;
        public Transform AltitudeLadder;
        private Transform AirspeedTransform;
        private Transform MachTransform;
        private Transform GmeterTransform;
        private RectTransform AltitudeLadderRect;
        private Vector3 airbrakelefthingeupperangle;
        private Vector3 airbrakelefthingelowerangle;
        private Vector3 airbrakerighthingeupperangle;
        private Vector3 airbrakerighthingelowerangle;
        private FlightAssist F26FlightAssist;
        private Transform blackoutEffectTransform;
        private GameObject blackoutEffectobj;
        private Transform intakerAudio;
        private Transform jetrAudio;
        private Transform abrAudio;
        private AudioSource intakelAudiocontroller;
        private AudioSource intakerAudiocontroller;
        private AudioSource jetlAudiocontroller;
        private AudioSource jetrAudiocontroller;
        private AudioSource ablAudiocontroller;
        private AudioSource abrAudiocontroller;
        private bool airbrakeflag;
        private Transform frontlandinglightsf26;
        private Transform frontlandinglightsflaref26;
        private Transform tailnavlightsf26;
        private Transform leftNavLightredf26;
        private Transform LeftRedStrobeLightf26;
        private Transform leftNavLightRearWhitef26;
        private Transform LeftStrobeLightWhitef26;
        private Transform rightNavLightGreenf26;
        private Transform rightNavLightRearWhitef26;
        private Transform RightRedStrobeLightf26;
        private Transform RightStrobeLightWhitef26;
        private Transform frontlandinglightsf16transform;
        private Transform rightwingtoplightsf16transform;
        private Transform leftwingtoplightsf16transform;
        private Transform rightwingbottomlightsf16transform;
        private Transform leftwingbottomlightsf16transform;
        private Transform rightintakelightsf16transform;
        private Transform leftintakelightsf16transform;
        private Transform taillightsf16transform;
        private Transform rearfuselageleftlightsf16transform;
        private Transform rearfuselagerightlightsf16transform;
        private Vector3 outputofcalc;
        private GameObject LeftStrobeLightWhitef26obj;
        private GameObject RightRedStrobeLightf26obj;
        private GameObject RightStrobeLightWhitef26obj;
        private GameObject frontlandinglightsf26parent;
        private Transform frontlandinglightsf26light;
        private GameObject landinglightobj;
        private float rswca;
        private GearAnimator gearAnim;
        private Traverse wheelAxisTraverse;
        private GameObject f16leftgear;
        private GameObject f16rightgear;
        private GameObject f16frontgear;
        private GameObject f16frontgearlever;
        private GameObject f16leftgearcover;
        private GameObject f16rightgearcover;
        private GameObject f16frontgearcover;
        private GameObject f16leftwheelpivotin;
        private GameObject f16rightwheelpivotin;
        private GameObject f16frontwheelpivotin;
        private GameObject LandingGearLeverObject;
        private Vector3 f16leftgeardown;
        private Vector3 f16rightgeardown;
        private Vector3 f16frontgeardown;
        private Vector3 f16frontgearleverdown;
        private Vector3 f16leftgearcoverdown;
        private Vector3 f16rightgearcoverdown;
        private Vector3 f16frontgearcoverdown;
        private Vector3 f16leftwheelpivotindown;
        private Vector3 f16rightwheelpivotindown;
        private Vector3 f16frontwheelpivotindown;
        private Vector3 f16leftgearup;
        private Vector3 f16rightgearup;
        private Vector3 f16frontgearup;
        private Vector3 f16frontgearleverup;
        private Vector3 f16leftgearcoverup;
        private Vector3 f16rightgearcoverup;
        private Vector3 f16frontgearcoverup;
        private Vector3 f16leftwheelpivotinup;
        private Vector3 f16rightwheelpivotinup;
        private Vector3 f16frontwheelpivotinup;
        private Transform f16HP1;
        private Transform f16HP2;
        private Transform f16HP3;
        private Transform f16HP4;
        private Transform f16HP5;
        private Transform f16HP6;
        private Transform f16HP7;
        private Transform f16HP8;
        private Transform f16HP9;
        private Transform f16HP10;
        private Transform f16HP11;
        private Transform f16HP12;
        private Transform f16HP13;
        private Transform f16HP14;
        private Transform rightengineRPMsprite;
        private Transform RPMGauge2t;
        private Transform partsToScaleTransform;
        private Transform subPartToScaleTransform;
        private bool stuffSpawnedIn = false;
        private int spawnCounter = 0;

        private ModuleEngine engine;
        private VehicleMaster vehMaster;
        private GameObject leftengineactual;
        private GameObject rightengineactual;
        private Transform findingf16sub;
        bool Setuprunning = false;
        private Transform mpRadioButton1;
        private Transform f16DED;
        private Transform f16DEDLine3R;
        private TextMeshPro f16DEDLine3RTM;
        private Transform f16DEDLine2L;
        private TextMeshPro f16DEDLine2LTM;
        private Transform f16DEDLine4L;
        private TextMeshPro f16DEDLine4LTM;
        private Transform f26MPRadio;
        private TextMeshPro f26MPRadioTMP;
        private WaypointManager f16WaypointManager;
        private Transform f16TestLight;
        private Light f16TestLightInt;
        private Transform f16CurrentWaypoint;
        private GameObject mpRadioButtonClr2;
        private DateTime currentTime;
        private string timeNow;
        private int currentHour;
        private int currentMinute;
        private Transform minuteNeedle;
        private Transform hourNeedle;
        private Transform compassBlock;
        private float positionToMoveCompassNeedleTo;
        private int positionToMoveMinuteNeedleTo;
        private int positionToMoveHourNeedleTo;
        private FuelTank[] fuelTanks;
        private float currentHeading;
        private ModuleEngine leftEngineVar;
        private ModuleEngine rightEngineVar;
        private float currentRPM;
        private float maxRPM;
        private float rpmPercentage;
        private float rpmAngle;
        private Transform rpmNeedle;
        private GameObject f26RPMGauge;
        private Transform f26RPMneedle;
        private Transform nozzleNeedle;
        private float nozzleNeedleDefault;
        private Transform fuelMainNeedle;
        private Transform fuelLeftNeedle;
        private Transform fuelRightNeedle;
        private Transform fuelUnderNeedle;
        private float fuelMNatZero;
        private float fuelLNatZero;
        private Transform HUDCanvasPieceHUD;
        private Transform HeadingPieceHUD;
        private int ilCheck;
        private GameObject instLightsTransformObj;
        private GameObject internalLightsLeverObject;
        private GameObject allInstrumentsLightsTransformParentObj;
        private GameObject allElecPowerLights;
        private Component[] allElecPowerLightsArrayOfLights;
        private Component[] allInstrumentsLights;
        private Transform leftPanelObj;
        private GameObject leftPanelgObj;
        private Material[] leftPanelRendererMaterials;
        private Renderer leftPanelRenderer;
        private Material leftPanelMaterial;
        private Color panelLightColorOn;
        private Color panelLightColorOff;
        private Material leftPanelRendererMaterial;
        private GameObject rightPanelgObj;
        private Material[] rightpanelrenderermaterials;
        private Material rightpanelrenderermaterial;
        private GameObject rightauxpanelgobj;
        private Material[] rightauxpanelrenderermaterials;
        private Material rightauxpanelrenderermaterial;
        private GameObject frontcentrepanelgobj;
        private Material[] frontcentrepanelrenderermaterials;
        private Material frontcentrepanelrenderermaterial;
        private GameObject frontupperpanelgobj;
        private Material[] frontupperpanelrenderermaterials;
        private Material frontupperpanelrenderermaterial;
        private GameObject leftauxpanelgobj;
        private Material[] leftauxpanelrenderermaterials;
        private Material leftauxpanelrenderermaterial;
        private GameObject frontsightpanelgobj;
        private GameObject rightAuxInstruments;
        private Material[] rightAuxInstrumentsRendererMaterials;
        private Material[] frontsightpanelrenderermaterials;
        private Material frontsightpanelrenderermaterial;
        private float f16RPMAngle;
        private float f16NozzleinstrumentAngle;
        private float currentNozzleAngle;
        private float currentNozzleAngleDifference;
        private float Nozzlepercentage;
        private Transform RadarTransform;
        private LockingRadar f16radarsystem;
        private AdvancedRadarController f16radaradvanced;
        private Radar f16radarbase;
        private Transform f26uiradar;
        private MFDRadarUI f26uiradarmfd;
        private float[] f26uiradarmfdviewr;
        private float maxfuel;
        private float totalfuelinaircraft;
        private List<FuelTank> externalfueltanks;
        private float currentfuelvalue;
        private float mainneedleangle;
        private float ff;
        private float fuelrnatzero;
        private float fuelunatzero;
        private Transform ftitneedle;
        private float ftitnatzero;
        private Transform cabinpressneedle;
        private float cabinpressatzero;
        private Transform Hydraulicsleftneed;
        private Transform Hydraulicsrightneed;
        private float Hydraulicsleftneedatzero;
        private float Hydraulicsrightneedatzero;
        private Transform AOAGauge;

        public float AOAGaugeatzero;

        private Transform HUDDashF26;
        private Transform HUDDashLocationF16;
        private Transform f26parkingbrakeswitchmain;
        private Transform f26parkingbrakeswitchbase;

        public Transform f26parkingswitch;
        private Transform f26parkingswitchlever;
        private MeshFilter f26parkingswitchlevermesh;
        private GameObject LeftWingObject;
        private GameObject RighttWingObject;
        private Health RightWingHealth;
        private float RightWingHealthStatus;
        private Health LeftWingHealth;
        private float LeftWingHealthStatus;
        private HeatEmitter heatemitter;
        private float engineheat;
        private ModuleEngine rightenginescripts;
        private float actualfuel;
        private float leftneedleangle;
        private float rightneedleangle;
        private float underneedleangle;
        private float realengineheat;
        private float ftitneedleangle;
        private float cockpitPressure;
        private float cabinpressneedleangle;
        private Transform HUDDashPoseBoundsF26;
        private Transform parenttransform;
        private GameObject parentransformobj;
        private Transform f16HudFontTf;
        private Text f16HudFont;
        private Component[] HUDCanvasElements;
        private Transform hudtransforms;
        private Transform HeadingtextTransform;
        private Transform weaponsublabelTransform;
        private Transform weaponInfoTransform;
        private Transform weaponlabelTransform;
        private Text weaponlabelTransformtext;
        private Transform GlassmaskTransform;
        private Transform weaponAmmocountlabelTransform;
        private Transform alphaTransform;
        private Transform verticalvelTransform;
        private Transform AltitudeModeBox;
        private Vector3 AngleLeftHydraulics;
        private Vector3 AngleRightHydraulics;
        private float aoavalue;
        private Transform aoaindexer;
        private Transform aoaRedLight;
        private Transform aoaGreenLight;
        private Transform aoaYellowLight;
        private Component[] aoaRedLight_lights;
        private Component[] aoaGreenLight_lights;
        private Component[] aoaYellowLight_lights;
        private Light aoaRedLight_light;
        private Light aoaGreenLight_light;
        private Light aoaYellowLight_light;
        private float AOAGaugeAngle;
        private bool reduceinstruments;
        private PoseBounds sizeofleftpanelpb;
        private VRLever BatteryLever;
        private int BatteryLeverCheck;
        private Transform APUPart;
        private AuxilliaryPowerUnit APUauxunit;
        private GameObject dashitems;
        private Transform fueldumppanel;
        private Transform fueldumppanel1;
        private Transform fueldumppanel2;
        private Transform f26combinerobject;
        private MeshCombiner2 CombinerMeshforF26;
        private Transform cmpanel;
        private Transform cmpanelparent;
        private Transform cmpanel1;
        private Transform cmpanel2;
        private Transform dashitemst;
        public List<GameObject> ListofpanelEnd1s = new List<GameObject>();
        private string nameofthing;
        public List<GameObject> ListofpanelEnd4s = new List<GameObject>();
        public List<GameObject> ListofpanelEnd3s = new List<GameObject>();
        public List<GameObject> ListofpanelEnd2s = new List<GameObject>();
        private Transform FlightAssistPanelpanel;
        private Transform FlightAssistPanelpanelparent;
        private Transform FlightAssistPanelpanel1;
        private Transform FlightAssistPanelpanel2;
        private Transform FlighAssistLines1;
        private Transform FlightAssistLines2;
        private Transform FlightAssistLines3;
        private Transform FlightAssistPitchAssistSwitch;
        private Transform FlightAssistPitchAssistSwitchInt;
        private VRLever FlightAssistPitchAssistLever;
        private Transform f26mastercautionswitchint;
        private VRInteractable f26MasterCautionI;
        private Transform f16refuelport;
        private Transform f26refuelport;
        private Transform f16fuelportswitch;
        private Transform FuelPortSwitchlpanel;

        public Transform FuelPortSwitchlpanelswitch { get; private set; }

        private Transform f16fuelportswitchlever;

        public Transform f26navlight { get; private set; }

        private Transform f26navlightParent;
        private Transform f16navlightt;
        private Transform FuelPortSwitchpanelparent;
        private Transform FuelPortSwitchpanel1;
        private Transform FuelPortSwitchpanel2;
        private Transform FuelPortSwitchpanelswitchbase;
        private Transform RadioDashpanel;
        private Transform RadioDashpanelparent;
        private Transform RadioDashpanel1;
        private Transform RadioDashpanel2;
        private Transform Basicpanel1panel;
        private Transform Basicpanel1panelparent;
        private Transform Basicpanel1panel1;
        private Transform Basicpanel1panel2;
        private Transform Basicpanel3panel;
        private Transform Basicpanel3panel1;
        private Transform Basicpanel3panel2;
        private Transform Basicpanel4panel;
        private Transform Basicpanel4panel1;
        private Transform Basicpanel4panel2;
        private Transform f26RightPanelPoseBounds;
        private PoseBounds f26RightPanelPoseBoundsComp;
        private Transform f26RightPanel;
        private Transform f16rightpanelposebound;
        private Transform Basicpanel4panelR;
        private Transform Basicpanel4panelR1;
        private Transform Basicpanel4panelR2;
        private Transform Basicpanel3panelR;
        private Transform Basicpanel3panelR1;
        private Transform Basicpanel3panelR2;
        private Transform Basicpanel2panelR;
        private Transform Basicpanel2panelR1;
        private Transform Basicpanel2panelR2;
        private Transform f26LeftFwdPanel;
        private Transform f26RightFwdPanel;
        private Transform Basicpanel4panelRF;
        private Transform Basicpanel4panelRF1;
        private Transform Basicpanel4panelRF2;
        private Transform Basicpanel2panelRF1;
        private Transform Basicpanel2panelRF2;
        private Transform Basicpanel4panelLF;
        private Transform Basicpanel4panelLF1;
        private Transform Basicpanel4panelLF2;
        private Transform Basicpanel3panelRF;
        private Transform Basicpanel3panelRF2;
        private Transform Basicpanel3panelRF1;
        private Transform f26masterArmSwitchlines;
        private Transform Afighter2t;
        private Transform ThrottleTrack;
        private Transform ThrottleParent;
        private Transform DashCanvast;
        private Transform f26mainDash;
        private Transform APAltNum;
        private Transform InternalLampTrans;
        private Transform InternalLampLightTrans;
        private Light InternalLampLight;
        private Material[] InternalLampTransrenderermaterials;
        private Transform APSpeedAdjusterInt;
        private VRInteractable APSpeedAdjusterIntVR;
        private Transform f26RWR;
        private Transform f26FuelFlowGauge;
        private Transform f26MFDLeft;
        private Transform f26MFDRight;
        private Transform f26masterArmSwitch;
        private Transform f26coverSwitchBase2;
        private Transform f26radioSwitchBase;
        private Transform f26masterarmswitchParent;
        private Transform f26masterarmradioswitch;
        private Transform f26masterarmradioswitchI;
        private Transform f26masterarmcoverswitch;
        private Transform f26masterarmcoverswitch2;
        private Transform f26masterarmcoverswitch2cover;
        private VRLever f26masterarmcoverswitch2coverlever;
        private VRLever f26masterarmcoverswitchvrl;
        private MeshFilter f26masterarmradioswitchmeshfilter;
        private Mesh f26masterarmradioswitchmesh;
        private Transform f26helmetpanel;
        private Transform f16rwrmodeswitch;
        private Transform f16rwrmodeswitchParent;
        private Transform radioSwitchInteractable;
        private GameObject newrwrmodeswitch;
        private Transform newrwrmodeswitchi;
        private VRInteractable newrwrmodeswitchvri;
        private Transform extstrobeswitch;
        private Transform extstrobeswitchParent;
        private Transform extstrobeswitchInteractable;
        private VRLever extstrobeswitchlr;
        private VRInteractable extstrobeswitchvri;
        private Transform strobeLightsP;

        public StrobeLightController StrobeLightCont { get; private set; }

        private VRLever newrwrmodeswitchivr;
        private Transform f26RWRModeSwitch;
        private Transform f26ILSHSI;
        private Transform f26SpeedGauge;
        private Transform f26AltGauge;
        private Transform f26AttSphere;
        private Transform f26AttitudeIndi;
        private Transform f26vsi;
        private Transform f26RadarPwrSwitch;
        private PoseBounds CanopyLeverObjectswitchleverIPB;
        private Transform MiniMFDRight;
        private Transform MiniMFDRightFT;
        private Transform MiniMFDRightIT;
        private Transform MiniMFDRightFDB;
        private Transform MiniMFDRightPower;
        private VRInteractable MiniMFDRightPowerVRI;
        private VRInteractable MiniMFDRightFDBVRI;
        private Transform MiniMFDLeft;
        private Transform MiniMFDLeftFDPage;
        private MMFDFuelDrainPage MiniMFDLeftFDPageComp;
        private Text TWRTextMMFD;
        private Transform AfterburnerIndicator;
        private Transform RightDashPoseBoundsF26;
        private Transform RightDashPoseBoundsF16;
        private Transform LeftDashPoseBoundsF26;
        private Transform MasterArmPoseBoundsF26;
        private Transform RightFWDDashPoseBoundsF26;
        private Transform RightFWDDashPoseBoundsF16;
        private Transform LeftFWDDashPoseBoundsF26;
        private Transform LeftFWDDashPoseBoundsF16;
        private Transform ConsFLowerF16;

        public Transform CenterDashPoseBoundsf26 { get; private set; }

        private Transform f26parkingswitchI;
        private VRInteractable f26parkingswitchIVR;
        private Transform f26leftenginestartswitchmain;
        private Transform f26rightenginestartswitchmain;
        private Transform f26leftengineew;
        private Transform f26leftenginestartswitchbase;
        private Transform f26leftenginestartswitch;
        private Transform f26leftenginestartswitchlever;
        private Transform f26leftenginestartswitchmaincover;
        private Transform f26leftenginestartswitchmaincoverparent;
        private Transform f26leftenginestartswitchbasemount;
        private Transform f26leftenginestartswitchlabel;
        private Transform f26leftenginestartswitchon;
        private Transform f26leftenginestartswitchoff;
        private Transform f26leftenginestartswitchmaincoverparentcoverSwitch2;
        private Transform f26leftenginestartswitchmaincoverparentcoverSwitch2I;
        private VRLever f26leftenginestartswitchmaincoverparentcoverSwitch2Ilever;
        private Transform f26leftenginestartswitchbaseI;
        private VRInteractable f26leftenginestartswitchbaseIVR;
        private VRLever f26leftenginestartswitchbaseLever;
        private Transform ConsoleLeftDashposeboundsF16;
        private Transform f16SpeedIndicator;
        private Transform f16AltitudeIndicator;
        private Transform f16VSIIndicator;
        private Transform f16AttitudeIndicator;
        private Transform f16CompassIndicator;
        private Transform f16CMSChaff;
        private Transform f16CMSFlare;
        private Transform f16AttitudeIndicatorSphere;
        private Transform f26SpeedIndicator;
        private Transform f26AltitudeIndicator;
        private Transform f26VSIIndicator;
        private Transform f26AttitudeIndicator;
        private Transform f26AttitudeIndicatorCircle;
        private Transform f26CompassIndicator;
        private Transform f26CMSChaff;
        private Transform f26CMSChaffSwitchLever;
        private Transform f26CMSFlare;
        private Transform f26CMSFlareSwitchLever;
        private Transform f26cmsparent;
        private Transform f26CMSChaffBase;
        private Transform f26CMSFlareBase;
        private Transform f26CMSChaffI;
        private Transform f26CMSFlareI;
        private VRInteractable f26CMSChaffInteractable;
        private VRInteractable f26CMSFlareInteractable;
        private Transform f26CMSChaffOn;
        private Transform f26CMSChaffOff;
        private Transform f26CMSFlareOn;
        private Transform MissileIndicator;
        private Transform LaunchIndicator;
        private Transform f16throttlepivot;
        private Transform f16throttle;
        private Transform f16throttletf;
        private Transform f26throttleintt;
        private VRThrottle throttlef26I;
        private VRIntGlovePoser throttlef26IG;
        private ThrottleAnimator f26ThrottleAnim;
        private float newf16throttleangle;
        private PoseBounds throttlef26IPB;
        private VRInteractable throttlef26IVR;
        private Transform f16canopyswitchtransform;
        private Transform CanopyLeverObjectbase;
        private Transform CanopyLeverObjectswitch;
        private Transform CanopyLeverObjectswitchlever;
        private Transform CanopyLeverObjectswitchleverI;
        private MeshFilter CanopyLeverObjectswitchlevermesh;

        public Transform AltitudeBox;
        public VRInteractable CanopyLeverObjectswitchleverIVR;
        private Transform f26LeftPanelRadio;
        private Transform f26LeftPanelRadioLines;
        private Transform f26LeftPanelFDS;
        private Transform f26fdslines;
        private Transform f26LeftPanelFAP;
        private Color panellinescolor;
        private Transform f26cmspanel;
        private Transform f26cmspanel1;
        private Transform f26cmspanel2;
        private MeshRenderer f26cmspanelmeshr;
        private MeshRenderer f26cmspanel1meshr;
        private MeshRenderer f26cmspanel2meshr;
        private Material[] f26cmspanelmateriala;
        private Material[] f26cmspanel1materialb;
        private Material[] f26cmspanel2materialc;
        private Material f26cmspanelmaterial;
        private Material f26cmspanel1material;
        private Material f26cmspanel2material;
        private Transform f16controlstick;
        private Transform f26sidestickobjects;
        private Transform f26controlstick;
        private Transform f26controlstickparent;
        private MeshFilter f26controlstickmesh;
        private MeshFilter f16controlstickmesh;
        private Mesh f26controlstickmeshitem;
        private Mesh f16controlstickmeshitem;
        private MeshRenderer f16controlstickmeshr;
        private MeshRenderer f26controlstickmeshr;
        private Transform f26hudTintKnob;
        private Transform f26hudBrightKnob;
        private Transform f26HMCSPower;
        private Transform f26HUDPower;
        private Transform f26DeclutterKnob;
        private Transform f26lightspanel;
        private Transform f26commspanel;
        private Transform lines1;
        private Transform lines2;
        private Transform lines3;
        private Transform lines4;
        private Transform lines5;
        private Transform lines6;
        private Transform lines7;
        private Transform lines8;
        private Transform lines9;
        private Transform lines10;
        private Transform lines11;
        private Transform lines12;
        private Transform lines13;
        private Transform lines14;
        private Transform lines15;
        private Transform lines16;
        private Transform lines17;
        private Transform lines18;
        private Transform lines19;
        private Transform cathook;
        private Transform landinghook;
        private Transform f26landinggearobject;
        private Transform f26landinggearpanel;
        private Transform f26landinggearpanellights;
        private Transform f26flapslever;
        private Transform f26CenterConsole;
        private Transform f26CenterConsolelines;
        private Transform f26jettisonAllHolder;
        private Transform f26JettisonAllButton;
        private Transform f16jettisonbutton;
        private Vector3 scaletozero;
        private Transform f26controlint;
        private Transform f16contstickint;
        private Transform landinghookswitch;
        private Transform f16landinghookt;
        private Transform f16landinggearleverParent;
        private Transform f16landinggearleverPivot;
        private Transform f16landinggearlever;
        private Transform f16landinggearlevertrans;
        private VRLever f16landinggearleverVRL;
        private PoseBounds noneposebounds;
        private Transform f26jettisonallbuttonint;
        private VRInteractable f26jettisonallbuttoni;
        private PoseBounds f26jettisonallbuttonpb;
        private Transform f26APAltPanel;
        private Transform f26APAltPanelBack;
        private Transform f26APAltPanelBack2;
        private Transform f26APAltPanelBack3;
        private Transform f26APAltPanelShadow;
        private Transform vsicoverpanel;
        private Transform f26RadarPwrSwitchLines1;
        private Transform f26RadarPwrSwitchLines2;
        private Transform f26RadarPwrSwitchLinesCS;
        private Transform f26RWRModeSwitchLines1;
        private Transform f26RWRModeSwitchLines2;
        private Transform f26RWRModeSwitchLinesCS;
        private Transform f26seatadjuster;
        private Transform f26seatupi;
        private Transform f26seatdowni;
        private Transform f26seatadjustposebounds;
        private VRInteractable f26seatupivr;
        private VRInteractable f26seatdownivr;
        private PoseBounds f26seatupipb;
        private PoseBounds f26seatdownipb;
        private Transform f26landinggearint;
        private VRLever f26landinggearintlever;
        private LandingGearLever f26landinggearleverscript;
        private Transform LandingGearRightLight;
        private Transform LandingGearRightLightCyl;
        private Transform LandingGearLeftLight;
        private Transform LandingGearLeftLightCyl;
        private Transform LandingGearTopLight;
        private Transform LandingGearTopLightCyl;
        private Material LandingGearLightCylMat;
        private VRInteractable f26landinggearintVR;
        private Transform f16landinggearleverint;
        private VRInteractable f26landinggearobjecti;
        private PoseBounds f26landinggearobjectpb;
        private Transform f16mastercautionswitch;
        private Transform f26MasterCaution;
        private Transform refuelIndexer;
        private Transform refuelDisconnectLight;
        private Transform refuelReadyLight;
        private Transform refuelLatchedLight;
        private Light refuelDisconnectLight_light;
        private Light refuelReadyLight_light;
        private Light refuelLatchedLight_light;
        private RefuelPort port;
        private Transform f26landinglights;
        private Transform f26landinglightslvr;
        private Transform extLightsLabels;
        private Transform extLabel;
        private Transform f26landinglighti;
        private Transform f16landinglightt;
        private Transform f26strobelight;
        private Transform f26strobelightParent;
        private Transform f16anticollisionlightt;
        private Transform f26strobelightbase;
        private Transform f26instlight;
        private Transform f16instlightswitch;
        private Transform f26interiorlight;
        private Transform f26interiorlightlabel;
        private Transform f26interiorlightoff;
        private Transform f26interiorlightbase;
        private Transform f26interiorlightswitch;
        private Transform f16interiorlightswitch;
        private Transform f26navlightbase;
        private Transform f26brightknob;
        private Transform f26CommsMicKnobswitch;
        private Transform f16commspowerswitch;
        private Transform f16audio1comm1parent;
        private Transform f16audio1comm1int;
        private VRTwistKnobInt f16audio1comm1intTK;
        private Transform MFDCommsMenu;
        private MFDCommsPage MFDCommsMenuIK;
        private Transform f16commsuhfvolume;
        private VRInteractable f26CommsVolumeKnobIVR;
        private Transform f26CommsMicKnobswitchI;
        private VRInteractable f26CommsMicKnobswitchIVR;
        private Transform f26hudpower;
        private Transform f26hudpoweri;
        private Transform f16hudpower;
        private Transform f26hmcspower;
        private Transform f26hmcspowerradioswitch;
        private Transform f26hmcspowerint;
        private Transform f16hmcspower;
        private Transform f16hmcspowerknobparent;
        private Transform f16hmcspowerknobint;
        private VRTwistKnobInt f26hmcspowerintTK;
        private Transform f26helmet;
        private HelmetController f26helmetcont;
        private VRInteractable f26hcmspowerintvr;
        private Transform f26RadarPwrSwitchKnob;
        private Transform f16radarpowert;
        private Transform f26RWRModeSwitchRadioswitch;
        private Transform f26RWRModeSwitchi;
        private VRInteractable f26RWRModeSwitchiVR;
        private Transform f26CMSFlareOff;
        private Transform f26CMSChaffIndic;
        private Transform f26CMSFlareIndic;
        private Transform f16ChaffInidicator;
        private Transform f16FlareInidicator;
        private Transform f26CMSChaffIndicText;
        private Transform f26CMSFlareIndicText;
        private Text f26CMSChaffIndicTextVTT;
        private Text f26CMSFlareIndicTextVTT;
        private VRInteractable f26landinglightiVR;
        private VRLever f26landinglightiVRLever;
        private MeshFilter landinghookswitchmesh;
        private Transform f26RadarPwrSwitchi;
        private VRInteractable f26RadarPwrSwitchiVR;
        private GameObject f26playerobject;
        private Transform f26playerobjectBody;
        private MeshFilter f26playerobjectBodyMesh;
        public int Spawncount = 0;
        private Transform FuelPortOCLabel;
        private Transform FuelPortSwitchLabel;
        private VTText FuelPortOCLabelVTT;
        bool instrumentsupdateflag = false;
        private Transform mpradiobutton2;
        private Transform mpradiobutton3;
        private Transform mpradiobutton4;
        private Transform mpradiobutton5;
        private Transform mpradiobutton6;
        private Transform mpradiobutton7;
        private Transform mpradiobutton8;
        private Transform mpradiobutton9;
        private Transform mpradiobutton0;
        private Transform mpradiobuttonClr;
        private Transform mpradionewDisplay;
        private Transform mpradionewDisplayall;
        private Transform f16radioparent;
        private Transform f16radiobuttonEnter;
        private Transform f16radiobutton1;
        private Transform f16radiobutton2;
        private Transform f16radiobutton3;
        private Transform f16radiobutton4;
        private Transform f16radiobutton5;
        private Transform f16radiobutton6;
        private Transform f16radiobutton7;
        private Transform f16radiobutton8;
        private Transform f16radiobutton9;
        private Transform f16radiobutton0;
        private Transform f16radiobuttonClr;
        private Transform f26ClearWaypointButton;
        private Transform f16radionewDisplay;
        private bool MPRadioRunAlready = false;
        private VRInteractable mpradiobutton2vr;
        private VRInteractable mpradiobutton1vr;
        private VRInteractable mpradiobutton3vr;
        private VRInteractable mpradiobutton4vr;
        private VRInteractable mpradiobutton5vr;
        private VRInteractable mpradiobutton6vr;
        private VRInteractable mpradiobutton7vr;
        private VRInteractable mpradiobutton8vr;
        private VRInteractable mpradiobutton9vr;
        private VRInteractable mpradiobutton0vr;
        private VRInteractable mpradiobuttonclrvr;
        private Transform f26instlightonlabel;
        private Transform f26instlightofflabel;
        private Transform f26instlightbase;
        private Transform f26instlightswitch;
        private Transform f26instlightswitchi;
        private VRInteractable f26instlightswitchivr;
        private Transform f26interiorlightlab;
        private Transform f26interiorlightswitchi;
        private VRInteractable f26interiorlightswitchivr;
        private Transform f26CommsVolumeKnob;
        private Transform f26CommsMicKnob;
        private int rwrmode;
        private DashRWR f26dashrwr;
        private VRInteractable newrwrmodeswitchivri;
        private VRLever newcmdo1switchivr;
        private VRInteractable newcmdo1switchivrint;
        private Transform f16normalswitches;
        private Transform f16cmd02parent;
        private Transform f16cmd02parentmeshswitch;
        private Transform f16cmd02interactable;
        private VRLever f16cmd02interactablevrlever;
        private Transform f16displayselect;
        private Transform f16displayselectmeshswitch;
        private Transform f16displayselectinteractable;
        private VRLever f16displayselect2interactablevrlever;
        private Transform f16ecmdim;
        private Transform f16ecmdimmeshswitch;
        private Transform f16ecmdiminteractable;
        private VRLever f16ecmdiminteractablevrlever;
        private Transform f16ecmopr;
        private Transform f16ecmoprmeshswitch;
        private Transform f16ecmoprinteractable;
        private VRLever f16ecmoprinteractablevrlever;
        private Transform f16ecmxmit;
        private Transform f16ecmxmitmeshswitch;
        private Transform f16ecmxmitinteractable;
        private VRLever f16ecmxmitinteractablevrlever;
        private Transform f16ecmbit;
        private Transform f16ecmbitmeshswitch;
        private Transform f16ecmbitinteractable;
        private VRLever f16ecmbitinteractablevrlever;
        private Transform f16audiomic;
        private Transform f16audiomicmeshswitch;
        private Transform f16audiomicinteractable;
        private VRLever f16audiomicinteractablevrlever;
        private Transform f16radiotone;
        private Transform f16radiotonemeshswitch;
        private Transform f16radiotoneinteractable;
        private VRLever f16radiotoneinteractablevrlever;
        private Transform f16radiosquelch;
        private Transform f16radiosquelchmeshswitch;
        private Transform f16radiosquelchinteractable;
        private VRLever f16radiosquelchinteractablevrlever;
        private Transform f16manualpitch;
        private Transform f16manualpitchmeshswitch;
        private Transform f16manualpitchinteractable;
        private VRLever f16manualpitchinteractablevrlever;
        private Transform f16engcont;
        private Transform f16engcontmeshswitch;
        private Transform f16engcontinteractable;
        private VRLever f16engcontinteractablevrlever;
        private Transform f16jetstartab;
        private Transform f16jetstartabmeshswitch;
        private Transform f16jetstartabinteractable;
        private VRLever f16jetstartabinteractablevrlever;
        private Transform f16epumain;
        private Transform f16epumainmeshswitch;
        private Transform f16epumaininteractable;
        private VRLever f16epumaininteractablevrlever;
        private Transform f16maxpower;
        private Transform f16maxpowermeshswitch;
        private Transform f16maxpowerinteractable;
        private VRLever f16maxpowerinteractablevrlever;
        private Transform f16fueltankinternal;
        private Transform f16fueltankinternalmeshswitch;
        private Transform f16fueltankinternalinteractable;
        private VRLever f16fueltankinternalinteractablevrlever;
        private Transform f16fueltankmaster;
        private Transform f16fueltankmastermeshswitch;
        private Transform f16fueltankmasterinteractable;
        private VRLever f16fueltankmasterinteractablevrlever;
        private Transform f16auxcommm4code;
        private Transform f16auxcommm4codemeshswitch;
        private Transform f16auxcommm4codeinteractable;
        private VRLever f16auxcommm4codeinteractablevrlever;
        private Transform f16auxtacan;
        private Transform f16auxtacanmeshswitch;
        private Transform f16auxtacaninteractable;
        private VRLever f16auxtacaninteractablevrlever;
        private Transform f16auxrfmodemonitor;
        private Transform f16auxrfmodemonitormeshswitch;
        private Transform f16auxrfmodemonitorinteractable;
        private VRLever f16auxrfmodemonitorinteractablevrlever;
        private Transform f16trimapdisc;
        private Transform f16trimapdiscmeshswitch;
        private Transform f16trimapdiscinteractable;
        private VRLever f16trimapdiscinteractablevrlever;
        private Transform f16fltbit;
        private Transform f16fltbitmeshswitch;
        private Transform f16fltbitinteractable;
        private VRLever f16fltbitinteractablevrlever;
        private Transform f16auxrfmodereply;
        private Transform f16auxrfmodereplymeshswitch;
        private Transform f16auxrfmodereplyinteractable;
        private VRLever f16auxrfmodereplyinteractablevrlever;
        private Transform f16flcsreset;
        private Transform f16flcsresetmeshswitch;
        private Transform f16flcsresetinteractable;
        private VRLever f16flcsresetinteractablevrlever;
        private Transform f16flcsleflaps;
        private Transform f16flcsleflapsmeshswitch;
        private Transform f16flcsleflapsinteractable;
        private VRLever f16flcsleflapsinteractablevrlever;
        private Transform f16fltdigibackup;
        private Transform f16fltdigibackupmeshswitch;
        private Transform f16fltdigibackupinteractable;
        private VRLever f16fltdigibackupinteractablevrlever;
        private Transform f16fltaltflaps;
        private Transform f16fltaltflapsmeshswitch;
        private Transform f16fltaltflapsinteractable;
        private VRLever f16fltaltflapsinteractablevrlever;
        private Transform f16fltmanualflyup;
        private Transform f16fltmanualflyupmeshswitch;
        private Transform f16fltmanualflyupinteractable;
        private VRLever f16fltmanualflyupinteractablevrlever;
        private Transform f16testtest;
        private Transform f16testtestmeshswitch;
        private Transform f16testtestinteractable;
        private VRLever f16testtestinteractablevrlever;
        private Transform f16testprobeheat;
        private Transform f16testprobeheatmeshswitch;
        private Transform f16testprobeheatinteractable;
        private VRLever f16testprobeheatinteractablevrlever;
        private Transform f16testepugen;
        private Transform f16testepugenmeshswitch;
        private Transform f16testepugeninteractable;
        private VRLever f16testepugeninteractablevrlever;
        private Transform f16testQXY;
        private Transform f16testQXYmeshswitch;
        private Transform f16testQXYinteractable;
        private VRLever f16testQXYinteractablevrlever;
        private Transform f16extlightingmaster;
        private Transform f16extlightingmastermeshswitch;
        private Transform f16extlightingmasterinteractable;
        private VRLever f16extlightingmasterinteractablevrlever;
        private Transform f16voicemessage;
        private Transform f16voicemessagemeshswitch;
        private Transform f16voicemessageinteractable;
        private VRLever f16voicemessageinteractablevrlever;
        private Transform f16zeroizeoep;
        private Transform f16zeroizeoepmeshswitch;
        private Transform f16zeroizeoepinteractable;
        private VRLever f16zeroizeoepinteractablevrlever;
        private Transform f16malindlts;
        private Transform f16malindltsmeshswitch;
        private Transform f16malindltsinteractable;
        private VRLever f16malindltsinteractablevrlever;
        private Transform f16brightnesshud;
        private Transform f16brightnesshudmeshswitch;
        private Transform f16brightnesshudinteractable;
        private VRLever f16brightnesshudinteractablevrlever;
        private Transform f16hudaltitudetype;
        private Transform f16hudaltitudetypemeshswitch;
        private Transform f16hudaltitudetypeinteractable;
        private VRLever f16hudaltitudetypeinteractablevrlever;
        private Transform f16hudspeedtype;
        private Transform f16hudspeedtypemeshswitch;
        private Transform f16hudspeedtypeinteractable;
        private VRLever f16hudspeedtypeinteractablevrlever;
        private Transform f16wvah;
        private Transform f16wvahmeshswitch;
        private Transform f16wvahinteractable;
        private VRLever f16wvahinteractablevrlever;
        private Transform f16attpm;
        private Transform f16attpmmeshswitch;
        private Transform f16attpminteractable;
        private VRLever f16attpminteractablevrlever;
        private Transform f16deddata;
        private Transform f16deddatameshswitch;
        private Transform f16deddatainteractable;
        private VRLever f16deddatainteractablevrlever;
        private Transform f16hudstby;
        private Transform f16hudstbymeshswitch;
        private Transform f16hudstbyinteractable;
        private VRLever f16hudstbyinteractablevrlever;
        private Transform f16sensorpwrradar;
        private Transform f16sensorpwrradarmeshswitch;
        private Transform f16sensorpwrradarinteractable;
        private VRLever f16sensorpwrradarinteractablevrlever;
        private Transform f16sensorpwrfcr;
        private Transform f16sensorpwrfcrmeshswitch;
        private Transform f16sensorpwrfcrinteractable;
        private VRLever f16sensorpwrfcrinteractablevrlever;
        private Transform f16sensorpwrrhdpt;
        private Transform f16sensorpwrrhdptmeshswitch;
        private Transform f16sensorpwrrhdptinteractable;
        private VRLever f16sensorpwrrhdptinteractablevrlever;
        private Transform f16nuclearconsent;
        private Transform f16nuclearconsentmeshswitch;
        private Transform f16nuclearconsentinteractable;
        private VRLever f16nuclearconsentinteractablevrlever;
        private Transform f16engineantiice;
        private Transform f16engineantiicemeshswitch;
        private Transform f16engineantiiceinteractable;
        private VRLever f16engineantiiceinteractablevrlever;
        private Transform f16iffselect;
        private Transform f16iffselectmeshswitch;
        private Transform f16iffselectinteractable;
        private VRLever f16iffselectinteractablevrlever;
        private Transform f16mfdpower;
        private Transform f16mfdpowermeshswitch;
        private Transform f16mfdpowerinteractable;
        private VRLever f16mfdpowerinteractablevrlever;
        private Transform f16ststapower;
        private Transform f16ststapowermeshswitch;
        private Transform f16ststapowerinteractable;
        private VRLever f16ststapowerinteractablevrlever;
        private Transform f16mmcpower;
        private Transform f16mmcpowermeshswitch;
        private Transform f16mmcpowerinteractable;
        private VRLever f16mmcpowerinteractablevrlever;
        private Transform f16ufcpower;
        private Transform f16ufcpowermeshswitch;
        private Transform f16ufcpowerinteractable;
        private VRLever f16ufcpowerinteractablevrlever;
        private Transform f16avionicspowerdl;
        private Transform f16avionicspowerdlmeshswitch;
        private Transform f16avionicspowerdlinteractable;
        private VRLever f16avionicspowerdlinteractablevrlever;
        private Transform f16uhfselect;
        private Transform f16uhfselectmeshswitch;
        private Transform f16uhfselectinteractable;
        private VRLever f16uhfselectinteractablevrlever;
        private Transform f16plaincrad1;
        private Transform f16plaincrad1meshswitch;
        private Transform f16plaincrad1interactable;
        private VRLever f16plaincrad1interactablevrlever;
        private Transform f16teststep;
        private Transform f16teststepmeshswitch;
        private Transform f16teststepinteractable;
        private VRLever f16teststepinteractablevrlever;
        private Transform f16extlightingwingtail;
        private Transform f16extlightingwingtailmeshswitch;
        private Transform f16extlightingwingtailinteractable;
        private VRLever f16extlightingwingtailinteractablevrlever;
        private Transform f16extlightingfuselage;
        private Transform f16extlightingfuselagemeshswitch;
        private Transform f16extlightingfuselageinteractable;
        private VRLever f16extlightingfuselageinteractablevrlever;
        private Transform f16extfuelTransfer;
        private Transform f16extfuelTransfermeshswitch;
        private Transform f16extfuelTransferinteractable;
        private VRLever f16extfuelTransferinteractablevrlever;
        private Transform f16avionicspowergps;
        private Transform f16avionicspowergpsmeshswitch;
        private Transform f16avionicspowergpsinteractable;
        private VRLever f16avionicspowergpsinteractablevrlever;
        private Transform f16cmd01parent;
        private Transform f16cmd01parentmeshswitch;
        private Transform f16cmd01interactable;
        private VRLever f16cmd01interactablevrlever;
        private Transform f16cmd02xparent;
        private Transform f16cmd02xparentmeshswitch;
        private Transform f16cmd02xinteractable;
        private VRLever f16cmd02xinteractablevrlever;
        private Transform f16CMDSMode;
        private Transform f16CMDSModeparent;
        private Transform f16CMDSModeknobint;
        private VRTwistKnobInt f16CMDSModeintTK;
        private Transform f16NWSSwitch;
        private Transform f16NWSSwitchparent;
        private Transform f16NWSSwitchint;
        private VRLever f16NWSModeintTK;
        private Transform f16StoresSwitch;
        private Transform f16StoresSwitchparent;
        private Transform f16StoresSwitchint;
        private VRLever f16StoresModeintTK;
        private Transform f16gndjettenableSwitch;
        private Transform f16gndjettenableSwitchparent;
        private Transform f16gndjettenableSwitchint;
        private VRLever f16gndjettenableintTK;
        private Transform f16brakeschan1Switch;
        private Transform f16brakeschan1Switchparent;
        private Transform f16brakeschan1Switchint;
        private VRLever f16brakeschan1intTK;
        private Transform f16pitchholdSwitch;
        private Transform f16pitchholdSwitchparent;
        private Transform f16pitchholdSwitchint;
        private VRLever f16pitchholdintTK;
        private Transform f16rollaltholdSwitch;
        private Transform f16rollaltholdSwitchparent;
        private Transform f16rollaltholdSwitchint;
        private VRLever f16rollaltholdintTK;
        private Transform f16LazerArmSwitch;
        private Transform f16LazerArmSwitchparent;
        private Transform f16LazerArmSwitchint;
        private VRLever f16LazerArmintTK;
        private Transform f16RFQuietSwitch;
        private Transform f16RFQuietSwitchparent;
        private Transform f16RFQuietSwitchint;
        private VRLever f16RFQuietintTK;
        private Transform f16CMDSBit;
        private Transform f16CMDSBitparent;
        private Transform f16CMDSBitknobint;
        private VRTwistKnobInt f16CMDSBitintTK;
        private Transform f16PointerKnobs;
        private Transform f16UHFmainboch;
        private Transform f16UHFmainbochparent;
        private Transform f16UHFmainbochint;
        private VRTwistKnobInt f16UHFmainbochintTK;
        private Transform f16UHFpreset;
        private Transform f16UHFpresetparent;
        private Transform f16UHFpresetint;
        private VRTwistKnobInt f16UHFpresetintTK;
        private Transform f16audio1Comm2Squelch;
        private Transform f16audio1Comm2Squelchparent;
        private Transform f16audio1Comm2Squelchint;
        private VRTwistKnobInt f16audio1Comm2SquelchintTK;
        private Transform f16audio1Comm1Squelch;
        private Transform f16audio1Comm1Squelchparent;
        private Transform f16audio1Comm1Squelchint;
        private VRTwistKnobInt f16audio1Comm1SquelchintTK;
        private Transform f16extfuelQty;
        private Transform f16extfuelQtyparent;
        private Transform f16extfuelQtyint;
        private VRTwistKnobInt f16extfuelQtyintTK;
        private Transform f16NavMode;
        private Transform f16NavModeparent;
        private Transform f16NavModeint;
        private VRTwistKnobInt f16NavModeintTK;
        private Transform f16NavInstrHeading;
        private Transform f16NavInstrHeadingparent;
        private Transform f16NavInstrHeadingint;
        private VRTwistKnobInt f16NavInstrHeadingintTK;
        private Transform f16SmallTwisty;
        private Transform audio1SecureVoice;
        private Transform audio1SecureVoiceparent;
        private Transform audio1SecureVoiceint;
        private VRTwistKnobInt audio1SecureVoiceintTK;
        private Transform f16audio1MSL;
        private Transform f16audio1MSLparent;
        private Transform f16audio1MSLint;
        private VRTwistKnob f16audio1MSLintTK;
        private Transform f16audio1threat;
        private Transform f16audio1threatparent;
        private Transform f16audio1threatint;
        private VRTwistKnob f16audio1threatintTK;
        private Transform f16audio1tf;
        private Transform f16audio1tfparent;
        private Transform f16audio1tfint;
        private VRTwistKnob f16audio1tfintTK;
        private Transform f16FullTwisty;
        private Transform f16trimyawtrim;
        private Transform f16trimyawtrimparent;
        private Transform f16trimyawtrimint;
        private VRTwistKnob f16trimyawtrimintTK;
        private Transform f16extlightsaerialrefuel;
        private Transform f16extlightsaerialrefuelparent;
        private Transform f16extlightsaerialrefuelint;
        private Transform f16JMRSwitch;
        private Transform f16JMRSwitchparent;
        private Transform f16JMRSwitchint;
        private VRLever f16JMRModeintTK;
        private Transform CanopyLightParent;

        public Component[] CanopyLights;
        private Transform f16cmdo1switch;
        private Transform f16cmdo1switchi;
        private Transform f16SecondaryAttIndicatorTrans;
        private GameObject f26SecondaryAttIndicator;
        private LoadoutConfigurator lc;
        private Transform lcleftpanel;
        private Transform lcleftpaneltitle;
        private Text lcleftpaneltitletext;
        private Transform lcleftpaneltwr;
        private Transform lcleftpanelweight;
        private Text lcleftpanelweighttxt;
        private int found;
        private string lcleftpanelweightfigure;
        private float lcleftpanelweightfigureint;
        private float TWRFigure;
        private Text lcleftpaneltwrtext;
        private GameObject lcmainpanel;
        private Transform lchp0;
        private Transform lchp1;
        private Transform lchp2;
        private Transform lchp3;
        private Transform lchp4;
        private Transform lchp5;
        private Transform lchp6;
        private Transform lchp7;
        private Transform lchp8;
        private Transform lchp9;
        private Transform lchp10;
        private Transform lchp11;
        private Transform lchp12;
        private Transform lchp13;
        private Transform lchp14;
        private VRInteractable lchp0vr;
        private VRInteractable lchp1vr;

        private VRInteractable lchp2vr;
        private VRInteractable lchp3vr;
        private VRInteractable lchp8vr;
        private VRInteractable lchp9vr;
        private VRInteractable lchp10vr;
        private VRInteractable lchp11vr;

        private VRInteractable lchp12vr;

        private VRInteractable lchp13vr;
        private VRInteractable lchp14vr;
        private Transform lchp15;
        private Transform lcimage;
        private RawImage lcimagetex;
        private Transform f16image;
        private RawImage f16imagetex;
        private int gearStateStart;
        private Material rightAuxInstrumentsHydraulics;
        private Material rightAuxInstrumentsFuel;
        private Material rightAuxInstrumentsOxygen;
        private Material rightAuxInstrumentsClock;
        private Material rightAuxInstrumentsCPressure;
        private Material rightAuxInstrumentsEPUFuel;
        private GameObject rightUpperInstruments;
        private GameObject Compasscylinderobj;
        private GameObject AOAcylinderobj;
        private Material[] AOAcylinderobjRendererMaterials;
        private Material[] CompasscylinderobjRendererMaterials;
        private Material[] rightUpperInstrumentsRendererMaterials;
        private Material rightUpperInstrumentsRPM;
        private Material rightUpperInstrumentsFTIT;
        private Material rightUpperInstrumentsOil;
        private Material rightUpperInstrumentsAtt2;
        private Material Compasscylindermaterial;
        private Material AOAcylindermaterial;
        private Material rightUpperInstrumentsNozzle;
        private int landinggearcount;
        private List<Mod> Usermods;
        private bool mploaded;
        private GameObject frontPanelICF;
        private Material[] frontPanelICFRendererMaterials;
        private Material frontPanelICFMat;
        private Transform pointerKnobsGroup;
        private Transform contr2Parent;
        private Material[] contr2ParentRendererMaterials;
        private Material[] pointerKnobsGroupRendererMaterials;
        private Material controlKnobMaterial;
        private Material contr1KnobMaterial;
        private Material contr2KnobMaterial;
        private Transform contr1Parent;
        private Material[] contr1ParentRendererMaterials;
        private Transform controlParent;
        private Material[] controlParentRendererMaterials;
        private Transform pointerKnobsGroup2;
        private Transform contr4Parent;
        private Material[] contr4ParentRendererMaterials;
        private Material contr4KnobMaterial;
        private Transform extnaviswitch;
        private Transform extnaviswitchParent;
        private Transform extnaviswitchInteractable;
        private VRLever extnaviswitchlr;
        private VRInteractable extnaviswitchvri;
        private Transform LeftnaviLightsP;
        private ObjectPowerUnit LeftnaviLightCont;
        private Transform RightnaviLightsP;
        private ObjectPowerUnit RightnaviLightCont;
        private Transform RearnaviLightsP;
        private ObjectPowerUnit RearnaviLightCont;
        private Transform IntakeLightLeft;
        private Transform IntakeLightRight;
        private Transform tailLight;
        private Light IntakeLightLeftLightComp;
        private Light IntakeLightRightLightComp;
        private Light tailLightComp;
        private Transform tailLightCylinder;
        private Material[] tailLightCompRendererMaterials;
        private Material InternalLamprenderermaterial;
        private Transform f16LampDial;
        private Transform f16LampDialparent;
        private Transform f16LampDialknobint;
        private VRTwistKnobInt f16LampDialintTK;
        private Material tailLightCompRendererMaterial;
        private Transform f16instrumentLightSwitch;
        private Transform f16instrumentLightSwitchParent;
        private Transform f16instrumentLightSwitchInteractable;
        private VRTwistKnobInt f16instrumentLightSwitchivr;
        private VRInteractable f16instrumentLightSwitchvri;
        private Transform f26labelLightPower;
        private VTTextIllumSwitcher f26labelLightPowerVTT;
        private Transform f16radarPowerSwitchParent;
        private Transform f16radarPowerSwitchInteractable;
        private VRTwistKnobInt f16radarPowerswitchivr;
        private VRInteractable f16radarPowerswitchvri;
        private VRTwistKnob f16extlightsaerialrefuelintTK;
        private Transform f16audiointercom;
        private Transform f16audiointercomparent;
        private Transform f16audiointercomint;
        private VRTwistKnob f16audiointercomintTK;
        private Transform f16audiotacan;
        private Transform f16audiotacanparent;
        private Transform f16audiotacanint;
        private VRTwistKnob f16audiotacanintTK;
        private Transform f16audioils;
        private Transform f16audioilsparent;
        private Transform f16audioilsint;
        private VRTwistKnob f16audioilsintTK;
        private Transform f16audio1comm2;
        private Transform f16audio1comm2parent;
        private Transform f16audio1comm2int;
        private VRTwistKnob f16audio1comm2intTK;
        private Transform f16uhfNumberChanger1;
        private Transform f16uhfNumberChanger1parent;
        private Transform f16uhfNumberChanger1int;
        private VRTwistKnobInt f16uhfNumberChanger1intTK;
        private Transform f16uhfNumberChanger2;
        private Transform f16uhfNumberChanger2parent;
        private Transform f16uhfNumberChanger2int;
        private VRTwistKnobInt f16uhfNumberChanger2intTK;
        private Transform f16uhfNumberChanger3;
        private Transform f16uhfNumberChanger3parent;
        private Transform f16uhfNumberChanger3int;
        private VRTwistKnobInt f16uhfNumberChanger3intTK;
        private Transform f16uhfNumberChanger4;
        private Transform f16uhfNumberChanger4parent;
        private Transform f16uhfNumberChanger4int;
        private VRTwistKnobInt f16uhfNumberChanger4intTK;
        private Transform f16uhfNumberChanger5;
        private Transform f16uhfNumberChanger5parent;
        private Transform f16uhfNumberChanger5int;
        private VRTwistKnobInt f16uhfNumberChanger5intTK;
        private Transform f16uhftext1trans;
        private TextMeshPro f16uhftext1text;
        private Transform f16uhftext2trans;
        private TextMeshPro f16uhftext2text;
        private Transform f16uhftext3trans;
        private TextMeshPro f16uhftext3text;
        private Transform f16uhftext4trans;
        private TextMeshPro f16uhftext4text;
        private Transform f16uhftext5trans;
        private TextMeshPro f16uhftext5text;
        private Transform f16fuelengfeed;
        private Transform f16fuelengfeedparent;
        private Transform f16fuelengfeedint;
        private VRTwistKnobInt f16fuelengfeedintTK;
        private Transform f16auxCNI;
        private Transform f16auxCNIparent;
        private Transform f16auxCNIint;
        private VRTwistKnobInt f16auxCNIintTK;
        private Transform f16auxcommmaster;
        private Transform f16auxcommmasterparent;
        private Transform f16auxcommmasterint;
        private VRTwistKnobInt f16auxcommmasterintTK;
        private Transform f16extlightsform;
        private Transform f16extlightsformparent;
        private Transform f16extlightsformint;
        private VRTwistKnob f16extlightsformintTK;
        private Transform f16AVTRdisplayselect;
        private Transform f16AVTRdisplayselectparent;
        private Transform f16AVTRdisplayselectint;
        private VRTwistKnobInt f16AVTRdisplayselectintTK;
        private Transform f16GsuitTD;
        private Transform f16GsuitTDparent;
        private Transform f16GsuitTDknobint;
        private VRTwistKnobInt f16GsuitTDintTK;
        private Transform f16GSuitPull;
        private Transform f16GSuitPullparent;
        private Transform f16GSuitPullknobint;
        private VRTwistKnobInt f16GSuitPullintTK;
        private Transform f16GSuitmode;
        private Transform f16GSuitmodeparent;
        private Transform f16GSuitmodeknobint;
        private VRTwistKnobInt f16GSuitmodeintTK;
        private Transform f16GSuitVolume;
        private Transform f16GSuitVolumeparent;
        private Transform f16GSuitVolumeknobint;
        private VRTwistKnob f16GSuitVolumeintTK;
        private Transform f16tempauto;
        private Transform f16tempautoparent;
        private Transform f16tempautoknobint;
        private VRTwistKnobInt f16tempautointTK;
        private Transform f16airsource;
        private Transform f16airsourceparent;
        private Transform f16airsourceknobint;
        private VRTwistKnobInt f16airsourceintTK;
        private Transform f16dedbright;
        private Transform f16dedbrightparent;
        private Transform f16dedbrightknobint;
        private VRTwistKnobInt f16dedbrightintTK;
        private Transform f16consolesbright;
        private Transform f16consolesbrightparent;
        private Transform f16consolesbrightknobint;
        private VRTwistKnob f16consolesbrightintTK;
        private Transform f16DriftSwitch;
        private Transform f16DriftSwitchparent;
        private Transform f16DriftSwitchint;
        private VRLever f16DriftSwitchintTK;
        private Transform f16RTNSEQ;
        private Transform f16RTNSEQparent;
        private Transform f16RTNSEQint;
        private VRLever f16RTNSEQintTK;
        private Transform f16FLIRGain;
        private Transform f16FLIRGainparent;
        private Transform f16FLIRGainint;
        private VRLever f16FLIRGainintTK;
        private Func<AutoPilot> AutoPilot;
        private VTOLAutoPilot AutoPilot2;
        private Transform f16engineposition;
        private Transform FuelPortSwitchLever;
        private VRLever FuelPortSwitchLeverIK;
        private Transform HUDTK;
        private Transform HUDAMI;
        private Transform ClrWptButton;
        private Transform HUDHeading;
        private Transform HUDAltitude;
        private Transform HUDSpd;
        private Transform HUDAPOFF;
        private Transform HUDNav;
        private Transform HUDHMCSP;
        private Transform HUDBRK;
        private Transform HUDDCK;
        private Transform HUDMFDBK;
        private Transform HUDMFDSB;
        private bool TWRmanualset;
        private Transform defaultf26undercarriagetright;
        private Transform defaultf26undercarriagetleft;
        private Transform defaultf26undercarriagetleftcyl;
        private Transform defaultf26undercarriagetrightcyl;
        private Transform f16GunTransform;
        private Transform f26GunTransform;
        private Transform f26GunBoxTransform;
        private float wllift;
        private float totalLift;
        private Transform LeftElevonPart;
        private Transform RightElevonPart;
        private SimpleDrag LeftElevonPartSD;
        private SimpleDrag RightElevonPartSD;
        private Transform LeftWingPart;
        private Transform RightWingPart;
        private SimpleDrag RightWingPartSD;
        private SimpleDrag LeftWingPartSD;
        private Component[] f26MFDLeftTextElements;
        private Component[] f26MFDRightTextElements;
        private Component[] f26MiniMFDLeftTextElements;
        private Transform wingFoldSwitch;
        private Transform wingFoldSwitchI;
        private VRLever wingFoldSwitchIVR;
        private float Altitude;
        private float TemperatureatAltitude;
        private float LocalSpeedSound;
        private float MachNumber;
        private SimpleDrag sd;
        private Transform f16CollidersGroup;
        private Transform f16RightWingCollider;
        private BoxCollider f16RightWingColliderComponent;
        private Transform f16LeftWingCollider;
        private BoxCollider f16LeftWingColliderComponent;
        private Transform f16LeftElevonCollider;
        private BoxCollider f16LeftElevonColliderComponent;
        private Transform f16RightElevonCollider;
        private BoxCollider f16RightElevonColliderComponent;
        private Transform f16VertStabCollider;
        private BoxCollider f16VertStabColliderComponent;
        private Transform f16NoseCollider;
        private BoxCollider f16NoseColliderComponent;
        private Transform f16BodyCollider;
        private BoxCollider f16BodyColliderComponent;
        private Transform collidersGroup;
        private Transform colliderBody;
        private BoxCollider colliderBodyColC;
        private Transform colliderNose;
        private BoxCollider colliderNoseColC;
        private Transform colliderLeftElevon;
        private BoxCollider colliderLeftElevonColC;
        private Transform colliderRightElevon;
        private BoxCollider colliderRightElevonColC;
        private Vector3 vector;
        private float DragOutput;
        private float MachInternal;
        private float spdMultiplier;
        private float wrlift;
        private float rrlift;
        private float rllift;
        private float balift;
        private float wlolift;
        private float wrolift;
        private float wrelift;
        private float wlelift;
        private float wlvslift;
        private float wrvslift;
        private float flalift;
        private float fralift;
        private float alalift;
        private float aralift;
        private float lbllift;
        private Transform mainCameraGroup;
        private Transform rwmissilecam;
        private Transform lwweaponscam;
        private Transform underccam;
        private Transform tGCam;
        private Transform rADogfightCam;
        private Transform f26ExtCamMgr;
        private Transform f26ExtCam;
        private Transform f26ExtCam2;
        private Transform f26ExtCam2R;
        private Transform f26ExtCam3;
        private Transform f26ExtCamFrontWheel;
        private Transform f26jettisonAllCoverSwitchParent;
        private Transform f26JettisonAllCoverSwitch;
        private Transform f26JettisonAllCoverSwitchI;
        private VRLever f26JettisonAllCoverSwitchILever;
        private Transform colliderVertStab;
        private BoxCollider colliderVertStabColC;
        private Transform colliderVertStabRight;
        private BoxCollider colliderVertStabRightColC;
        private Transform wingLeftCollider;
        private BoxCollider wingLeftColliderC;
        private Transform wingRightCollider;
        private BoxCollider wingRightColliderC;
        private Transform wingTipFlexLeft;
        private Transform wingTipLefthitbox;
        private BoxCollider wingTipLefthitboxlC;
        private Transform wingTipLeftCollider;
        private BoxCollider wingTipLeftColliderlC;
        private Transform wingLeftOuterCollider;
        private BoxCollider wingLeftOuterColliderC;
        private Transform f16EngineCollider;
        private CapsuleCollider f16EngineColliderComponent;
        private Transform engineLeftHitbox;
        private CapsuleCollider engineLeftHitboxCollider;
        private Transform wingTipFlexRight;
        private Transform engineRightHitbox;
        private CapsuleCollider engineRightHitboxCollider;
        private Transform wingTipRighthitbox;
        private BoxCollider wingTipRighthitboxlC;
        private Transform wingTipRightCollider;
        private BoxCollider wingTipRightColliderlC;
        private Transform wingRightOuterCollider;
        private BoxCollider wingRightOuterColliderC;
        private Transform hitboxesGroup;
        private Transform hitboxBody;
        private BoxCollider hitboxBodyColC;
        private Transform hitboxNose;
        private BoxCollider hitboxNoseColC;
        private Transform hitboxLeftElevon;
        private BoxCollider hitboxLeftElevonColC;
        private Transform hitboxRightElevon;
        private BoxCollider hitboxRightElevonColC;
        private Transform hitboxVertStabLeft;
        private Transform hitboxVertStab;
        private BoxCollider hitboxVertStabColC;
        private Transform hitboxVertStabRightP;
        private Transform hitboxVertStabRight;
        private BoxCollider hitboxVertStabRightColC;
        private Transform wingLefthitbox;
        private BoxCollider wingLefthitboxC;
        private Transform wingRighthitbox;
        private BoxCollider wingRighthitboxC;
        private double MachD;
        private DashSpeedometer f26SpeedIndicatorComponent;
        private DashSpeedometer.SpeedoProfile[] f26SpeedIndicatorComponentProfiles;
        private Transform f26SpeedProfilesKnots;
        private Transform f26SpeedIndicator0;
        private Transform f26SpeedIndicator1;
        private Transform f26SpeedIndicator2;
        private Transform f26SpeedIndicator3;
        private Text f26SpeedIndicator4Text;
        private Transform f26SpeedIndicator4;
        private Text f26SpeedIndicator0Text;
        private Text f26SpeedIndicator1Text;
        private Text f26SpeedIndicator2Text;
        private Text f26SpeedIndicator3Text;
        private Transform landingLightLamps1;
        private Transform landingLightLamps2;
        private Transform testPick;
        private Transform f26EjectorHandle;
        private Transform f16EjectorHandle;
        private string noMPDEDRadioText;
        private Transform f26leftenginethrust;
       
        private VRInteractable clrWptButVRI;
        public bool MPActive;
        public bool PlaneSetupDone;
        private Transform LeftEngineJetWash;
        private Transform RightEngineJetWash;
     

  
        public IEnumerator CreatePlaneMenuItem()
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(Path.Combine(AircraftInfo.ModFolderString, AircraftInfo.PreviewPngFileName));
            yield return www.SendWebRequest();

            if (www.responseCode != 200)
            {
                F16Debug.Log("WWW Response code isn't 200, it's " + www.responseCode + "\n" + www.error);
            }
            else
            {
                AircraftInfo.MenuTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                F16Debug.Log("Loaded plane image.");
            }

            F16Debug.Log("F16Debug 1");
            Traverse traverse = Traverse.Create(typeof(VTResources));
            PlayerVehicleList vehicles = (PlayerVehicleList)traverse.Field("playerVehicles").GetValue();

            F16Debug.Log("F16Debug 2");
            PlayerVehicle newVehicle = ScriptableObject.CreateInstance<PlayerVehicle>();
            newVehicle.vehicleName = AircraftInfo.AircraftName;
            newVehicle.nickname = AircraftInfo.AircraftNickName;
            newVehicle.description = AircraftInfo.AircraftDescription;
            newVehicle.campaigns = PilotSaveManager.GetVehicle("F/A-26B").campaigns;
            newVehicle.vehicleImage = AircraftInfo.MenuTexture;
            vehicles.playerVehicles.Add(newVehicle);

            F16Debug.Log("F16Debug 3");
            traverse.Field("playerVehicles").SetValue(vehicles);


            F16Debug.Log("F16Debug 4");
            Traverse traverse2 = Traverse.Create(typeof(PilotSaveManager));
            List<PlayerVehicle> vehicleList = (List<PlayerVehicle>)traverse2.Field("vehicleList").GetValue();
            vehicleList.Add(newVehicle);
            traverse.Field("vehicleList").SetValue(vehicleList);


        }

        public override void ModLoaded() {

            F16Debug.Log("Section 4");
            HarmonyInstance.Create("Bovine.OnlyEquipWhatISay").PatchAll();
            //VTOLAPI.SceneLoaded += SceneChanged; // So when the scene is changed SceneChanged is called
            //VTOLAPI.MissionReloaded += DoMain; // So when the mission is reloaded DoMain is called
            F16Debug.Log("Section 5");
            AircraftInfo.ModFolderString = ModFolder;
            base.ModLoaded();
            StartCoroutine(CreatePlaneMenuItem());
            AircraftSwapper.instance = this;
            checkMPloaded();
        }

        public void checkMPloaded()
        {
            F16Debug.Log("checking Multiplayer is installed");

            List<Mod> mods = new List<Mod>();

            mods = VTOLAPI.GetUsersMods();

            foreach (Mod m in mods)
            {
                if (m.name.Contains("ultiplayer"))
                {
                    F16Debug.Log("found Multiplayer set f16 mp");
                  
                    MPLock();
                }
            }
        }

        public void MPLock()
        {
            if (MPActive)
                return;
            //PlayerManager.PlayerIsCustomPlane = true;
            //PlayerManager.LoadedCustomPlaneString = "f16";
            PlayerManager.onSpawnLocalPlayer += MPRespawnHook;
            PlayerManager.onSpawnClient += ClientF16Spawned;

            PlayerManager.RegisterCustomPlane(AircraftInfo.AircraftName, "F/A-26B");
            MPActive = true;
            //PlayerManager.SetCustomPlane("f16");
        }
        public void SetCustomPlaneMP()
        {
             PlayerManager.SetCustomPlane(AircraftInfo.AircraftName);
        }

        public void ClientF16Spawned(PlayerManager.CustomPlaneDef def)
        {
            F16Debug.Log("checking if customplanestring is f16");
            if (def.CustomPlaneString == AircraftInfo.AircraftName)
            {
                F16Debug.Log("spawned f16 in mp");
                ClientAircraftSwapF16 f16client = def.planeObj.AddComponent<ClientAircraftSwapF16>();
                f16client.planeObject = def.planeObj;
                f16client.aSwaper = this;
                f16client.doSetup();
            }else
    AircraftInfo.AircraftSelected = false;

        }

        void Update()
        {
            //F16Debug.unityLogger.logEnabled = F16Debugbool;
            VTOLVehicles cv = VTOLAPI.GetPlayersVehicleEnum();
            if (!AircraftInfo.AircraftSelected)
                return;
            switch (cv)
            {
                case VTOLVehicles.FA26B:

                    reduceinstruments = false;
                    //mpradiobuttonclr2 = GameObject.Find("Clr");
                    //if (mpradiobuttonclr2 != null) { F16Debug.Log("Found Clr Button"); }

                    if (!AircraftLoaded)
                        return;

                    if (!instrumentsupdateflag) StartCoroutine(UpdateInstruments());




                    // these ones are important and have no replacement in the game
                    StartCoroutine(updateClock());

                    StartCoroutine(DEDElements());

                    StartCoroutine(updateFuel());

                    StartCoroutine(updateCompass());

                    if (Input.GetKey("2"))
                    {
                        PickupAllChildrensTransforms(defaultf26, "bullshit");
                    }

                    if (!Setuprunning) StartCoroutine(CheckForPlaneRespawnMPtimer());
                    StartCoroutine(ThrottleIAnimator());
                    StartCoroutine(AltitudePowerAdjustment());
                    StartCoroutine(AirbrakeCheck());

                    // These instruments are not as important and can be sacrificed for performance

                    if (reduceinstruments == false)
                    {
                        StartCoroutine(updateCockpitPressure());

                        //StartCoroutine(updateleftHydraulics());

                        //StartCoroutine(updaterightHydraulics());



                        StartCoroutine(updateRPM());

                        StartCoroutine(nozzleposition());

                        StartCoroutine(updateHeat());

                        StartCoroutine(refuelIndexerlights(port));

                    }
                   



                    if (newrwrmodeswitchivr != null) { F16Debug.Log("rwrmode = " + newrwrmodeswitchivr.currentState); }




                    //this code is only for development of new aircraft and allows you to move around the specific part as specified either below in the code
                    //if you press a key from 1-0 you get the hardpoints 1-10
                    //q,w,e control the drop tanks and the Gun. This in theory should make it easier to fix those pieces
                    //if you don't need to test moving items around then comment this whole thing



                    //if (Input.GetKey("1")) { f16TestLightInt.enabled = false; }
                    if (Input.GetKey("2")) {
                        //testPick = PickupAllChildrensTransforms(defaultf26, "testF17");
                        F16Debug.Log("key 2 pressed");
                    }



                    break;

                default:
                   // F16Debug.Log("f16 Off");
                    break;
            }
        }


        private void Awake()
        {

            //Asset bundle file name needs to be "f16plane" or the code here needs to be changed for your asset bundle name


            //string directory = ModFolder;
            //F16Debug.Log("Mod Path = " +directory);

            //PathToBundle = Directory.GetCurrentDirectory() + @"\VTOLVR_ModLoader\mods\f16\f16v12";
            //vehicleType = VTOLAPI.GetPlayersVehicleEnum();
            //mploaded = false;
            ////If we haven't already loaded the Asset Bundle
            //if (!AssetLoaded)
            //{
            //    //--------------------------------------------Prefab inside the asset bundle needs to be named "f16v2" (case sensitive) or you need to change the code  below to match the prefab name
            //    newAircraftPrefab = FileLoader.GetAssetBundleAsGameObject(PathToBundle, "f16v12.prefab");
            //    AssetLoaded = true;
            //}








            //==================== Change Characteristics



            VTOLAPI.SceneLoaded += SceneLoaded;
            VTOLAPI.MissionReloaded += OnMissionRestart;

            DontDestroyOnLoad(this.gameObject);
        }


        private void SceneLoaded(VTOLScenes arg0)
        {
            switch (arg0)
            {

                case VTOLScenes.Akutan:
                    changeAmount = 0.75f;
                    waitVar = 0.6f;
                    AircraftLoaded = false;
                    F16Debug.Log("InitWaiter being called by VTOLScenes Akutan Case");
                    if(AircraftInfo.AircraftSelected)
                    if (!MPActive)
                        StartCoroutine(InitWaiter(null));
                    
                    break;
                case VTOLScenes.OpenWater:
                    changeAmount = 0.75f;
                    waitVar = 0.6f;
                    AircraftLoaded = false;
                    F16Debug.Log("InitWaiter being called by VTOLScenes Open Water Case");
                    if (AircraftInfo.AircraftSelected)
                        if (!MPActive)
                        StartCoroutine(InitWaiter(null));
                    break;
                case VTOLScenes.CustomMapBase:

                    waitVar = 0.6f; changeAmount = 0.05f;
                    AircraftLoaded = false;
                    F16Debug.Log("InitWaiter being called by VTOLScenes CustomMap Case");
                    if (AircraftInfo.AircraftSelected)
                        if (!MPActive)
                        StartCoroutine(InitWaiter(null));
                    break;
                case VTOLScenes.ReadyRoom:
                    AircraftLoaded = false;
                    break;
                case VTOLScenes.LoadingScene:
                    AircraftLoaded = false;
                    
                    break;
                case VTOLScenes.VehicleConfiguration:
                    waitVar = 0.6f;
                    changeAmount = 0.05f;
                    AircraftLoaded = false;
                    F16Debug.Log("InitWaiter being called by VTOLScenes Vehicle Config Case");
                    if (AircraftInfo.AircraftSelected)
                        StartCoroutine(InitWaiter(null));
                    break;
            }
        }
        private void MPRespawnHook(PlayerManager.CustomPlaneDef def)
        {
            F16Debug.Log("MP Respawn Hook");
            MPRadioRunAlready = false;
            PlaneSetupDone = false;
            StartCoroutine(InitWaiter(def.planeObj));
            
            
        }

        //Waits 2 seconds for the scenario to initialize and the player vehicle to spawn in.
        //Probably doesn't need to be anywhere near this long, but it's just for those guys with old slow hard drives
        private IEnumerator InitWaiter(GameObject plane)
        {
            Setuprunning = true;
            F16Debug.Log("InitWaiter Started");
            yield return new WaitForSeconds(waitVar);
            SetupNewAircraft(plane);
            Setuprunning = false;

            yield break;
        }

        private IEnumerator Checkhowmanyitemscontainname(String startstringtosearchfor, Transform transftolookthru)
        {
            F16Debug.Log("Checkhowmanyitemscontainname Started");
            if (airbrakeobj == null) { yield break; }
            F16Debug.Log("Checkhowmanyitemscontainname Started = f26 not null");
            yield return new WaitForSeconds(2f);
            if (transftolookthru.name.Contains(startstringtosearchfor))
            {
                // this object starts with the string passed in "start":
                // do whatever you want with it...
                F16Debug.Log("Found this item when searching for (" + startstringtosearchfor + ") = " + transftolookthru.name); // like printing its name
            }
            // now search in its children, grandchildren etc.
            foreach (Transform childitems in transftolookthru)
            {
                Checkhowmanyitemscontainname(startstringtosearchfor, childitems);
            }
            yield break;
        }


        private void OnMissionRestart()
        {

            //Additional cleanup in case the plane has crashed/pilot has ejected, and not despawned during the restart.
            if (newAircraftUnit != null)
            {
                Destroy(newAircraftUnit);
                newAircraftUnit = null;
                F16Debug.Log("InitWaiter being called by VTOLScenes Mission Restart Case where NewAircraft not null ");
                waitVar = 0.6f;
                StartCoroutine(InitWaiter(null));
            }
            else
            {
                F16Debug.Log("InitWaiter being called by VTOLScenes Mission Restart Case where NewAircraft is null ");
                waitVar = 0.6f;
                StartCoroutine(InitWaiter(null));
            }
        }

        private void SetupNewAircraft(GameObject playeraircraft)
        {
            string directory = ModFolder;
            F16Debug.Log("Mod Path = " + directory);

            PathToBundle = directory + @"\f16v12";
            vehicleType = VTOLAPI.GetPlayersVehicleEnum();
            mploaded = false;
            //If we haven't already loaded the Asset Bundle
            if (!AssetLoaded)
            {
                //--------------------------------------------Prefab inside the asset bundle needs to be named "f16v2" (case sensitive) or you need to change the code  below to match the prefab name
                newAircraftPrefab = FileLoader.GetAssetBundleAsGameObject(PathToBundle, "f16v12.prefab");
                AssetLoaded = true;
            }

            //Make sure we were able to load the prefab - more null checks == better :*)
            if (newAircraftPrefab != null)
            {
                Setuprunning = true;
                F16Debug.Log("Setuprunning" + Setuprunning);




                F16Debug.Log("Section1");

                //Adding localOffset to offset to position the aircraft shell correctly. the first vector is the axis sideways, the second is the height vector, and third is forwards and backwards

                VTOLVehicles cv = VTOLAPI.GetPlayersVehicleEnum();
                switch (cv)
                {
                    case VTOLVehicles.FA26B:
                        //Create all the offsets for the items that will need moving

                        GunOffset = new Vector3(-0.1511995f, -0.3224909f, -0.7553959f);
                        leftEngineOffset = new Vector3(-0f, 0.894125f, 10.10243f);
                        rightEngineOffset = new Vector3(-0.002000013f, 0.894125f, 10.10243f);
                        HUDCanvasOffset = new Vector3(0f, 1.26f, 6.012417f);

                        //make sure it only works with the F26
                        aircraftSwitchEnabled = true;
                        break;
                    default:
                        aircraftSwitchEnabled = false;
                        break;
                }

                F16Debug.Log("Section2");

                if (aircraftSwitchEnabled)
                {
                    //set this to false to remove all F16Debug codes
                   // F16Debug.unityLogger.logEnabled = F16Debugbool;
                    F16Debug.Log("Section2_1");


                    VariableSetting();
                    F16Debug.Log("Section2_2");

                    //Move the aircraft around to fix issues

                    //This finds the undercarriage for the player vehicle
                    if (playeraircraft != null)
                        defaultf26 = playeraircraft;
                    else
                    {
                        if (VTOLAPI.currentScene == VTOLScenes.VehicleConfiguration)
                            defaultf26 = VTOLAPI.GetPlayersVehicleGameObject(); 
                        else
                            defaultf26 = FlightSceneManager.instance.playerActor.gameObject;
                    }
                       

                    F16Debug.Log("Section2_3");
                    defaultF26Transform = defaultf26.transform;
                    F16Debug.Log("Section2_4");
                    defaultF26AFTransform = PickupAllChildrensTransforms(defaultf26, "aFighter2");
                    F16Debug.Log("Section2_5");
                    defaultF26AFTransformBody = PickupAllChildrensTransforms(defaultF26AFTransform.gameObject, "body");
                    defaultF26AFTransformBodyMF = defaultF26AFTransformBody.GetComponent<MeshFilter>();
                    defaultF26AFTransformBody.localScale = new Vector3(0.01f, 0.01f, 0.01f);

                    Transform defaultf26undercarriaget = PickupAllChildrensTransforms(defaultF26Transform.gameObject, "LandingGear");
                    defaultf26undercarriagetright = PickupAllChildrensTransforms(defaultf26undercarriaget.gameObject, "rightGearPiston");
                    defaultf26undercarriagetleft = PickupAllChildrensTransforms(defaultf26undercarriaget.gameObject, "leftGearPiston");
                    defaultf26undercarriagetleftcyl = PickupAllChildrensTransforms(defaultf26undercarriaget.gameObject, "leftGearCylinder");
                    defaultf26undercarriagetrightcyl = PickupAllChildrensTransforms(defaultf26undercarriaget.gameObject, "rightGearCylinder");




                    GameObject defaultf26undercarriage = defaultf26undercarriaget.gameObject;
                    disableMesh(defaultf26undercarriage);
                    f26combinerobject = PickupAllChildrensTransforms(defaultf26, "cockpitStaticCombiner");
                    CombinerMeshforF26 = f26combinerobject.GetComponent<MeshCombiner2>();
                    CombinerMeshforF26.gatherMeshesFromChildren = false;
                    CombinerMeshforF26.combineOnStart = false;


                    


                    F16Debug.Log("Section Aero");




                    //change the weight of the aircraft to f16 weight in kg

                    MassUpdater bm = defaultf26.GetComponent<MassUpdater>();
                    // f16 :
                    bm.baseMass = aircraftWeightInMetricTonnes;



                    //Comvalue.position = new Vector3(0f, 0.03f, -5f);

                    F16Debug.Log("Section Fuel Tank");

                    //setting the fuel tank
                    maxaircraftfuelinkg = 3200f;
                    ft = defaultf26.GetComponent<FuelTank>();
                    ff = ft.fuelFraction;

                    F16Debug.Log("Fuel Fraction = " + ff);

                    actualfuel = 0.45f * ff;

                    ft.SetNormFuel(actualfuel);
                    ft.maxFuel = maxaircraftfuelinkg;

                    port = defaultf26.GetComponentInChildren<RefuelPort>();
                    F16Debug.Log("Section Engine");



                    //the value here is in kN not lbs
                    F16Debug.Log("engmultiplier = " + engMultiplier);

                    //f16:
                    engValue = 120f;



                    F16Debug.Log("eng value = " + engValue);

                    vehMaster = defaultf26.GetComponent<VehicleMaster>();
                    leftengineactual = PickupAllChildrensTransforms(defaultf26, "fa26-leftEngine").gameObject;
                    rightengineactual = PickupAllChildrensTransforms(defaultf26, "fa26-rightEngine").gameObject;
                    leftengineactual.gameObject.SetActiveRecursively(false);
                    rightengineactual.gameObject.SetActiveRecursively(false);

                    LeftEngineJetWash = PickupAllChildrensTransforms(leftengineactual, "JetWash");
                    RightEngineJetWash = PickupAllChildrensTransforms(rightengineactual, "JetWash");

                    

                    int i = 1;
                    foreach (var engine in vehMaster.engines)
                    {
                        engValue = engValue * i;
                        F16Debug.Log("Engine MT Before = " + engine.maxThrust);
                        engine.maxThrust = engValue;
                        F16Debug.Log("Engine MT After = " + engine.maxThrust);
                        engine.abThrustMult = 1.8f;
                        engine.abSpoolMult = 1.8f;
                        //engine.fuelDrain = 0; //aerodynamics test only
                        engine.GetComponent<VehiclePart>().partMass = 0f;
                        if (i == 1)
                        {
                            leftEngineVar = engine;
                            engine.fuelDrain = 1.333f;
                            engine.abDrainMult = 5f;
                        } else
                        {
                            engine.fuelDrain = 0f;
                            engine.StopImmediate();
                            engine.enabled = false;
                            
                            rightEngineVar = engine;
                            rightEngineVar.includeInTWR = false;
                        }

                        //f16:
                        i = i - 1;




                    }
                    leftengineactual.gameObject.SetActiveRecursively(true);
                    rightengineactual.gameObject.SetActiveRecursively(true);
                    LeftEngineJetWash.gameObject.SetActiveRecursively(false);
                    RightEngineJetWash.gameObject.SetActiveRecursively(false);

                    F16Debug.Log("Section HP");

                    // This allows you to disable hardpoints as needed only runs in the configurator screen


                    HardpointChecker();

                    //Setting aero capabilities
                    F16Debug.Log("Section Drag");

                    //simple drag is the drag area i scaled this by looking at the settings for the f35 which is equivalent to the f45 in game it has an area of ,18 in game
                    sd = defaultf26.GetComponent<SimpleDrag>();
                    F16Debug.Log("Default f26 Drag = " + sd.area);

                    //f16
                    sd.area = 0.07f;


                    //Changes flight characteristics
                    Wing wingLeft = PickupAllChildrensTransforms(defaultf26, "wingLeftAero").GetComponent<Wing>();
                    Wing wingRight = PickupAllChildrensTransforms(defaultf26, "wingRightAero").GetComponent<Wing>();
                    Wing rudderLeft = PickupAllChildrensTransforms(defaultf26, "rudderLeftAero").GetComponent<Wing>();
                    Wing rudderRight = PickupAllChildrensTransforms(defaultf26, "rudderRightAero").GetComponent<Wing>();
                    Wing bodyAero = PickupAllChildrensTransforms(defaultf26, "bodyLiftAero").GetComponent<Wing>();
                    Wing wingLeftOuter = PickupAllChildrensTransforms(defaultf26, "wingLeftFoldAero").GetComponent<Wing>();
                    Wing wingRightOuter = PickupAllChildrensTransforms(defaultf26, "wingRightFoldAero").GetComponent<Wing>();
                    Wing wingLeftElevon = PickupAllChildrensTransforms(defaultf26, "leftElevonAero").GetComponent<Wing>();
                    Wing wingRightElevon = PickupAllChildrensTransforms(defaultf26, "rightElevonAero").GetComponent<Wing>();
                    Wing wingLeftVertStab = PickupAllChildrensTransforms(defaultf26, "leftVertStabAero").GetComponent<Wing>();
                    Wing wingRightVertStab = PickupAllChildrensTransforms(defaultf26, "rightVertStabAero").GetComponent<Wing>();

                    Wing flapLeftAero = PickupAllChildrensTransforms(defaultf26, "flapLeftAero").GetComponent<Wing>();
                    Wing aileronLeftAero = PickupAllChildrensTransforms(defaultf26, "aileronLeftAero").GetComponent<Wing>();
                    Wing flapRightAero = PickupAllChildrensTransforms(defaultf26, "flapRightAero").GetComponent<Wing>();
                    Wing aileronRightAero = PickupAllChildrensTransforms(defaultf26, "aileronRightAero").GetComponent<Wing>();
                    Wing latBodyLift = PickupAllChildrensTransforms(defaultf26, "aileronRightAero").GetComponent<Wing>();

                    wllift = wingLeft.liftArea * wingLeft.liftCoefficient;
                    F16Debug.Log("Lifting: WLLift = " + wingLeft.liftArea + "*" + wingLeft.liftCoefficient);
                    wrlift = wingRight.liftArea * wingRight.liftCoefficient;
                    F16Debug.Log("Lifting: WRLift = " + wingRight.liftArea + "*" + wingRight.liftCoefficient);
                    rllift = rudderLeft.liftArea * rudderLeft.liftCoefficient;
                    F16Debug.Log("Lifting: RLLift = " + rudderLeft.liftArea + "*" + rudderLeft.liftCoefficient);
                    rrlift = rudderRight.liftArea * rudderRight.liftCoefficient;
                    F16Debug.Log("Lifting: RRLift = " + rudderRight.liftArea + "*" + rudderRight.liftCoefficient);
                    balift = bodyAero.liftArea * bodyAero.liftCoefficient;
                    F16Debug.Log("Lifting: BALift = " + bodyAero.liftArea + "*" + bodyAero.liftCoefficient);
                    wlolift = wingLeftOuter.liftArea * wingLeftOuter.liftCoefficient;
                    F16Debug.Log("Lifting: WLOLift = " + wingLeftOuter.liftArea + "*" + wingLeftOuter.liftCoefficient);
                    wrolift = wingRightOuter.liftArea * wingRightOuter.liftCoefficient;
                    F16Debug.Log("Lifting: WROLift = " + wingRightOuter.liftArea + "*" + wingRightOuter.liftCoefficient);
                    wlelift = wingLeftElevon.liftArea * wingLeftElevon.liftCoefficient;
                    F16Debug.Log("Lifting: WLELift = " + wingLeftElevon.liftArea + "*" + wingLeftElevon.liftCoefficient);
                    wrelift = wingRightElevon.liftArea * wingRightElevon.liftCoefficient;
                    F16Debug.Log("Lifting: WRELift = " + wingRightElevon.liftArea + "*" + wingRightElevon.liftCoefficient);
                    wlvslift = wingLeftVertStab.liftArea * wingLeftVertStab.liftCoefficient;
                    F16Debug.Log("Lifting: WLVSLift = " + wingLeftVertStab.liftArea + "*" + wingLeftVertStab.liftCoefficient);
                    wrvslift = wingRightVertStab.liftArea * wingRightVertStab.liftCoefficient;
                    F16Debug.Log("Lifting: WRVSLift = " + wingRightVertStab.liftArea + "*" + wingRightVertStab.liftCoefficient);
                    flalift = flapLeftAero.liftArea * flapLeftAero.liftCoefficient;
                    F16Debug.Log("Lifting: FLALift = " + flapLeftAero.liftArea + "*" + flapLeftAero.liftCoefficient);
                    fralift = flapRightAero.liftArea * flapRightAero.liftCoefficient;
                    F16Debug.Log("Lifting: FRALift = " + flapRightAero.liftArea + "*" + flapRightAero.liftCoefficient);
                    alalift = aileronLeftAero.liftArea * aileronLeftAero.liftCoefficient;
                    F16Debug.Log("Lifting: ALALift = " + aileronLeftAero.liftArea + "*" + aileronLeftAero.liftCoefficient);
                    aralift = aileronRightAero.liftArea * aileronRightAero.liftCoefficient;
                    F16Debug.Log("Lifting: ARALift = " + aileronRightAero.liftArea + "*" + aileronRightAero.liftCoefficient);
                    lbllift = latBodyLift.liftArea * latBodyLift.liftCoefficient;
                    F16Debug.Log("Lifting: LBLLift = " + latBodyLift.liftArea + "*" + latBodyLift.liftCoefficient);

                    totalLift = wllift + wrlift + rllift + rrlift + balift + wlolift + wrolift + wlelift + wrelift + wlvslift + wrvslift + flalift + fralift + alalift + aralift + lbllift;
                    F16Debug.Log("Lifting Total: = " + totalLift);



                    LeftElevonPart = PickupAllChildrensTransforms(defaultf26, "elevonLeftPart");
                    RightElevonPart = PickupAllChildrensTransforms(defaultf26, "elevonRightPart");
                    LeftElevonPartSD = LeftElevonPart.GetComponent<SimpleDrag>();
                    RightElevonPartSD = RightElevonPart.GetComponent<SimpleDrag>();
                    LeftWingPart = PickupAllChildrensTransforms(defaultf26, "wingLeftPart");
                    RightWingPart = PickupAllChildrensTransforms(defaultf26, "wingRightPart");
                    RightWingPartSD = RightWingPart.GetComponent<SimpleDrag>();
                    LeftWingPartSD = LeftWingPart.GetComponent<SimpleDrag>();
                    LeftWingPart = PickupAllChildrensTransforms(defaultf26, "wingLeftPart");
                    RightWingPart = PickupAllChildrensTransforms(defaultf26, "wingRightPart");
                    RightWingPartSD = RightWingPart.GetComponent<SimpleDrag>();
                    LeftWingPartSD = LeftWingPart.GetComponent<SimpleDrag>();
                    RightWingPartSD.area = 0.015f;
                    LeftWingPartSD.area = 0.015f;






                    //check for mp mod
                    
                    //Usermods = VTOLAPI.GetUsersMods();
                    //foreach (Mod moditem in Usermods)
                    //{
                    //    F16Debug.Log("Mod found: " + moditem.name);
                    //    if (moditem.name == "Multiplayer")
                    //    {
                    //        mploaded = true;
                    //        F16Debug.Log("Found MP");
                    //    }
                    //}






                    //This shrinks the undercarriage down so it  is the correct height for the new plane
                    defaultf26undercarriage.transform.localScale = new Vector3(1f, 0.30f, 1f);
                    f26UndercLeftSuspension = PickupAllChildrensTransforms(defaultf26undercarriage, "leftSuspension");
                    f26UndercRightSuspension = PickupAllChildrensTransforms(defaultf26undercarriage, "rightSuspension");
                    f26UndercFrontSuspension = PickupAllChildrensTransforms(defaultf26undercarriage, "frontSuspension");
                    f26UndercLeftGear = PickupAllChildrensTransforms(defaultf26undercarriage, "LeftGear");
                    f26UndercRightGear = PickupAllChildrensTransforms(defaultf26undercarriage, "RightGear");
                    f26UndercFrontGear = PickupAllChildrensTransforms(defaultf26undercarriage, "FrontGear");
                    f26UndercFrontGear.localPosition = new Vector3(0f, -1.03f, 3.1f);
                    //f26UndercRightGear.localPosition = new Vector3(1.68f, -0.434f, -1.5f);
                    //f26UndercLeftGear.localPosition = new Vector3(-1.68f, -0.434f, -1.5f);

                    f26UndercFrontSuspensionRSD = f26UndercFrontSuspension.GetComponent<RaySpringDamper>();
                    f26UndercLeftSuspensionRSD = f26UndercLeftSuspension.GetComponent<RaySpringDamper>();
                    f26UndercRightSuspensionRSD = f26UndercRightSuspension.GetComponent<RaySpringDamper>();

                    //Standard is 2.24
                    f26UndercLeftSuspensionRSD.suspensionDistance = 1.8f;
                    f26UndercRightSuspensionRSD.suspensionDistance = 1.8f;
                    f26UndercFrontSuspensionRSD.suspensionDistance = 1.6f;

                    //Constant is 650
                    f26UndercLeftSuspensionRSD.springConstant = 650f;
                    f26UndercRightSuspensionRSD.springConstant = 650f;

                    //Damper is def 100
                    f26UndercLeftSuspensionRSD.springDamper = 100f;
                    f26UndercRightSuspensionRSD.springDamper = 100f;





                    parachuteMesh = PickupAllChildrensTransforms(defaultf26, "parachute_mesh");
                    parachuteMeshsMR = parachuteMesh.GetComponent<SkinnedMeshRenderer>();
                    parachuteMeshsMR.enabled = false;
                    disableMesh(parachuteMesh.gameObject);
                    //this creates the new vehicle based on the old one and resizes it , then moves and rotates into position


                    newAircraftUnit = Instantiate(newAircraftPrefab, defaultf26.transform);
                   
                    newAircraftUnitbody = PickupAllChildrensTransforms(newAircraftUnit, "Body");
                    newAircraftUnitBodyMF = newAircraftUnitbody.GetComponent<MeshFilter>();
                    defaultF26AFTransformBodyMF.sharedMesh = newAircraftUnitBodyMF.sharedMesh;

                    newAircraftUnit.transform.localScale = Vector3.Scale(newAircraftUnit.transform.localScale, new Vector3(1.22f, 1.22f, 1.22f));
                    newAircraftUnit.transform.localPosition = new Vector3(0.0f, 1.2f, -0.12f);
                    newAircraftUnit.transform.localRotation = defaultF26Transform.localRotation;
                    newAircraftUnit.transform.localEulerAngles = new Vector3(0f, 90.0000f, 0f);
                    f16image = PickupAllChildrensTransforms(newAircraftUnit, "f16image");
                    f16imagetex = f16image.GetComponent<RawImage>();
                    lcimagetex.texture = f16imagetex.texture;


                    attitude = defaultF26Transform.GetComponent<FlightInfo>();

                    CoMValueObj = PickupAllChildrensTransforms(defaultf26, "CoM").gameObject;
                    Comvalue = CoMValueObj.transform;
                    f16com = PickupAllChildrensTransforms(newAircraftUnit, "CentreofMass");
                    Comvalue.position = f16com.position;
                    aoaref = PickupAllChildrensTransforms(CoMValueObj, "aoaRef");

                    f16aoareftrans = PickupAllChildrensTransforms(newAircraftUnit, "f16aoaref");
                    aoaref.SetParent(f16aoareftrans);
                    aoaref.position = f16aoareftrans.position;
                    //Turn off G Limiter
                    F26FlightAssist = defaultf26.GetComponent<FlightAssist>();
                    F26FlightAssist.SetGLimiter(1);
                    F26FlightAssist.gLimit = 9.7f;

                    //this changes G blackout rating for the f-16, due to inclined seat, how true this is irl is really open to debate



                    blackoutEffectTransform = PickupAllChildrensTransforms(defaultf26, "blackoutEffect");
                    if (blackoutEffectTransform == null) { }
                    else
                    {
                        F16Debug.Log("Blackout implemented");
                        blackoutEffectobj = blackoutEffectTransform.gameObject;
                        BlackoutEffect blackoutvars = blackoutEffectobj.GetComponent<BlackoutEffect>();
                        blackoutvars.gTolerance = 7.5f;
                        blackoutvars.gRecovery = 0.6f;
                        blackoutvars.blackoutRate = 0.04f;
                        blackoutvars.maxGAccum = 4f;

                    }

                    //radar setup for f16
                    F16Debug.Log("radar setup 1");


                    RadarTransform = PickupAllChildrensTransforms(defaultf26, "Radar");
                    f16radarsystem = RadarTransform.GetComponent<LockingRadar>();
                    f16radaradvanced = RadarTransform.GetComponent<AdvancedRadarController>();
                    f16radarbase = RadarTransform.GetComponent<Radar>();
                    F16Debug.Log("radar setup 2");
                    f26uiradar = PickupAllChildrensTransforms(defaultf26, "RadarUIController");
                    f26uiradarmfd = f26uiradar.GetComponent<MFDRadarUI>();

                    F16Debug.Log("radar setup 3");
                    f26uiradarmfdviewr = f26uiradarmfd.viewRanges;

                    F16Debug.Log("radar setup 4" + f26uiradarmfdviewr[3]);
                    f26uiradarmfdviewr[0] = 10000f;
                    f26uiradarmfdviewr[1] = 25000f;
                    f26uiradarmfdviewr[2] = 60000f;
                    f26uiradarmfdviewr[3] = 200000f;

                    if (f16radarsystem != null)
                    {
                        F16Debug.Log("Existing Radar Max Range = " + f16radarsystem.maxRange);
                        F16Debug.Log("Tansmissionstrength = " + f16radarsystem.transmissionStrength);

                        f16radarsystem.enabled = false;
                        f16radaradvanced.enabled = false;
                        f16radarbase.enabled = false;


                        f16radaradvanced.maxElevationOffset = 60f;
                        f16radarsystem.receiverSensitivity = 6000f;
                        f16radarsystem.transmissionStrength = 180000f;
                        f16radarbase.transmissionStrength = 2000000f;
                        f16radarbase.receiverSensitivity = 8500f;

                        f16radarsystem.enabled = true;



                        f16radaradvanced.enabled = true;

                        f16radarbase.enabled = true;
                    }


                    //lights - setup lights in the function
                    F16Debug.Log("Lights");
                    lights();

                    //wheels - setup wheel rotations in the function and start gear positions
                    F16Debug.Log("Wheels");
                    wheels();


                    F16Debug.Log("Section Control Surfaces");

                    frontlandinglightsf26light = PickupAllChildrensTransforms(defaultf26, "LandingLight");
                    if (frontlandinglightsf26light == null) { F16Debug.Log("Got light"); }


                    //hud scaling

                    //float hudCanvasScalerx = 0.0004200001f;
                    //float hudCanvasScalery = 0.0004200001f;
                    //RectTransform hudCanvasTf = PickupAllChildrensTransforms(defaultf26, "HUDParent").GetComponent<RectTransform>();
                    //hudCanvasTf.sizeDelta = Vector2.Scale(hudCanvasTf.sizeDelta, new Vector2(hudCanvasScalerx, hudCanvasScalery));


                    float hudMaskScaler = 0.4f;
                    RectTransform hudMaskTf = PickupAllChildrensTransforms(defaultf26, "GlassMask").GetComponent<RectTransform>();
                    hudMaskTf.sizeDelta = Vector2.Scale(hudMaskTf.sizeDelta, new Vector2(hudMaskScaler, 0.57f));
                    hudMaskTf.localPosition = new Vector3(0f, 0f, 0f);
                    CollimatedHUDUI HUD = PickupAllChildrensTransforms(hudMaskTf.gameObject, "CollimatedHud").GetComponent<CollimatedHUDUI>();
                    //HUD.depth = 10;
                    HUD.UIscale = 0.9f;

                    //get hinges and activators from f26
                    aileronleft = PickupAllChildrensTransforms(defaultf26, "aileronLeft");
                    f26aileronleftatrest = aileronleft.localEulerAngles;
                    aileronright = PickupAllChildrensTransforms(defaultf26, "aileronRight");
                    f26aileronrightatrest = aileronright.localEulerAngles;
                    elevonleft = PickupAllChildrensTransforms(defaultf26, "elevonLeft");
                    f26elevonleftatrest = elevonleft.localEulerAngles;
                    elevonright = PickupAllChildrensTransforms(defaultf26, "elevonRight");
                    f26elevonrightatrest = elevonright.localEulerAngles;
                    //get the rudder from f26
                    f26rudderleft = PickupAllChildrensTransforms(defaultf26, "rudderLeft");
                    f26rudderleftatRest = f26rudderleft.localEulerAngles;

                    //get the hinges and activators from f-16 model

                    F16Debug.Log("test 1_1");
                    //left elements
                    AileronLeftf16 = PickupAllChildrensTransforms(newAircraftUnit, "Aileron_Left").gameObject;
                    Transform AileronLeftf16t = AileronLeftf16.transform;
                    F16Debug.Log("test 1_2");
                    aileronlefthinge = PickupAllChildrensTransforms(newAircraftUnit, "aileronlefthinge").gameObject;
                    Transform aileronlefthinget = aileronlefthinge.transform;
                    f16aileronlefthingeatrest = aileronlefthinget.localEulerAngles;
                    F16Debug.Log("test 1_3");
                    taileronlefthinge = PickupAllChildrensTransforms(newAircraftUnit, "taileronlefthinge").gameObject;
                    Transform taileronlefthinget = taileronlefthinge.transform;
                    f16taileronlefthingeatrest = taileronlefthinget.localEulerAngles;
                    F16Debug.Log("test 1_4");
                    moveaileronlefthinge = f16aileronlefthingeatrest;
                    movetaileronlefthinge = f16taileronlefthingeatrest;
                    F16Debug.Log("test 1_5");
                    //right elements
                    Aileronrightf16 = PickupAllChildrensTransforms(newAircraftUnit, "Aileron_Right").gameObject;
                    Transform Aileronrightf16t = Aileronrightf16.transform;
                    F16Debug.Log("test 1_6");
                    aileronrighthinge = PickupAllChildrensTransforms(newAircraftUnit, "aileronrighthinge").gameObject;
                    F16Debug.Log("test 1_7");
                    Transform aileronrighthinget = aileronrighthinge.transform;
                    f16aileronrighthingeatrest = aileronrighthinget.localEulerAngles;
                    F16Debug.Log("test 1_8");
                    taileronrighthinge = PickupAllChildrensTransforms(newAircraftUnit, "taileronrighthinge").gameObject;
                    Transform taileronrighthinget = taileronrighthinge.transform;
                    f16taileronrighthingeatrest = taileronrighthinget.localEulerAngles;
                    F16Debug.Log("test 1_9");

                    moveaileronrighthinge = f16aileronrighthingeatrest;
                    movetaileronrighthinge = f16taileronrighthingeatrest;

                    //get rudder
                    rudderhinge = PickupAllChildrensTransforms(newAircraftUnit, "rudderhinge").gameObject;
                    Transform rudderhinget = rudderhinge.transform;
                    f16rudderhingeatrest = rudderhinget.localEulerAngles;
                    moverudderhinge = f16rudderhingeatrest;
                    F16Debug.Log("test 1_10");

                    //get lef 
                    //left
                    leflaplefthinge = PickupAllChildrensTransforms(newAircraftUnit, "leflaplefthinge").gameObject;
                    Transform leflaplefthinget = leflaplefthinge.transform;
                    f16leflefthingeatrest = leflaplefthinget.localEulerAngles;
                    moveleftlefhinge = f16leflefthingeatrest;
                    F16Debug.Log("test 1_11");
                    //right
                    leflaprighthinge = PickupAllChildrensTransforms(newAircraftUnit, "leflaprighthinge").gameObject;
                    Transform leflaprighthinget = leflaprighthinge.transform;
                    f16lefrighthingeatrest = leflaprighthinget.localEulerAngles;
                    moverightlefhinge = f16lefrighthingeatrest;
                    F16Debug.Log("test 1_12");





                    F16Debug.Log("Section4");

                    //create all the hardpoint variables

                    GameObject HP1actual = PickupAllChildrensTransforms(defaultf26, "HP1").gameObject;
                    GameObject HP2actual = PickupAllChildrensTransforms(defaultf26, "HP2").gameObject;
                    GameObject HP9actual = PickupAllChildrensTransforms(defaultf26, "HP9").gameObject;
                    GameObject HP10actual = PickupAllChildrensTransforms(defaultf26, "HP10").gameObject;
                    GameObject HP3actual = PickupAllChildrensTransforms(defaultf26, "HP3").gameObject;
                    GameObject HP4actual = PickupAllChildrensTransforms(defaultf26, "HP4").gameObject;
                    GameObject HP5actual = PickupAllChildrensTransforms(defaultf26, "HP5").gameObject;
                    GameObject HP6actual = PickupAllChildrensTransforms(defaultf26, "HP6").gameObject;
                    GameObject HP7actual = PickupAllChildrensTransforms(defaultf26, "HP7").gameObject;
                    GameObject HP8actual = PickupAllChildrensTransforms(defaultf26, "HP8").gameObject;
                    GameObject HP13actual = PickupAllChildrensTransforms(defaultf26, "HP13DropTank").gameObject;
                    GameObject HP12actual = PickupAllChildrensTransforms(defaultf26, "HP12DropTank").gameObject;
                    GameObject HP11actual = PickupAllChildrensTransforms(defaultf26, "HP11DropTank").gameObject;
                    GameObject HP14actual = PickupAllChildrensTransforms(defaultf26, "HP14 TGP").gameObject;
                    GameObject HUDCanvasactual = PickupAllChildrensTransforms(defaultf26, "HUDCanvas").gameObject;


                    refuelIndexer = PickupAllChildrensTransforms(newAircraftUnit, "refuelIndexer");
                    refuelDisconnectLight = PickupAllChildrensTransforms(refuelIndexer.gameObject, "refuelDisconnectLight");
                    refuelReadyLight = PickupAllChildrensTransforms(refuelIndexer.gameObject, "refuelReadyLight");
                    refuelLatchedLight = PickupAllChildrensTransforms(refuelIndexer.gameObject, "refuelLatchedLight");
                    refuelDisconnectLight_light = refuelDisconnectLight.GetComponent<Light>();
                    refuelReadyLight_light = refuelReadyLight.GetComponent<Light>();
                    refuelLatchedLight_light = refuelLatchedLight.GetComponent<Light>();


                    refuelDisconnectLight_light.enabled = true;
                    refuelReadyLight_light.enabled = false;
                    refuelLatchedLight_light.enabled = false;

                    //grab f16 hardpoints
                    TWRmanualset = false;

                    f16HP1 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint1");
                    f16HP2 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint2");
                    f16HP3 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint3");

                    f16HP8 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint8");
                    f16HP9 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint9");
                    f16HP10 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint10");
                    f16HP11 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint11");
                    f16HP12 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint12");
                    f16HP13 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint13");
                    f16HP14 = PickupAllChildrensTransforms(newAircraftUnit, "F16Hardpoint14");

                    //rightengineactual.transform.localScale = new Vector3(0f, 0f, 0f);
                    disableMesh(rightengineactual.gameObject);

                    //move the gun so it fits in the whole correctly
                    f16GunTransform = PickupAllChildrensTransforms(newAircraftUnit, "f16gunbarrels");

                    f26GunTransform = PickupAllChildrensTransforms(defaultf26, "gunBarrels");
                    
                    f26GunTransform.gameObject.SetActive(true);

                        
                        f26GunTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    f26GunBoxTransform = PickupAllChildrensTransforms(defaultf26, "HPGun");
                    f26GunBoxTransform.position = f16GunTransform.position;

                    f26GunTransform.position = f16GunTransform.position;

                    F16Debug.Log("Section5");

                    //Move Hardpoints


                    HP1actual.transform.position = f16HP1.position;
                    HP1actual.transform.SetParent(f16HP1);
                    HP2actual.transform.position = f16HP2.position;
                    HP2actual.transform.SetParent(f16HP2);
                    HP3actual.transform.position = f16HP3.position;
                    HP3actual.transform.rotation = f16HP3.rotation;
                    HP3actual.transform.SetParent(f16HP3);
                    HP8actual.transform.position = f16HP8.position;
                    HP8actual.transform.SetParent(f16HP8);
                    HP8actual.transform.rotation = f16HP8.rotation;
                    HP9actual.transform.position = f16HP9.position;
                    HP9actual.transform.SetParent(f16HP9);
                    HP10actual.transform.position = f16HP10.position;
                    HP10actual.transform.SetParent(f16HP10);
                    HP11actual.transform.position = f16HP11.position;
                    HP11actual.transform.SetParent(f16HP11);
                    HP12actual.transform.position = f16HP12.position;
                    HP12actual.transform.SetParent(f16HP12);
                    HP13actual.transform.position = f16HP13.position;
                    HP13actual.transform.SetParent(f16HP13);
                    HP14actual.transform.position = f16HP14.position;
                    HP14actual.transform.rotation = f16HP14.rotation;
                    HP14actual.transform.SetParent(f16HP14);


                    f16engineposition = PickupAllChildrensTransforms(newAircraftUnit, "EngineTransform");

                    leftengineactual.transform.position = f16engineposition.position;
                    leftengineactual.transform.rotation = f16engineposition.rotation;
                    f26leftenginethrust = PickupAllChildrensTransforms(leftengineactual, "thrustTf");
                    f26leftenginethrust.rotation = f16engineposition.rotation;

                    rightengineactual.transform.position = f16engineposition.position;

                    HUDCanvasactual.transform.localPosition = HUDCanvasOffset;
                    Scaleoffset = new Vector3(0.73f, 0.73f, 0.73f);
                    HP1actual.transform.localScale = Scaleoffset;
                    HP2actual.transform.localScale = Scaleoffset;
                    HP3actual.transform.localScale = Scaleoffset;
                    HP4actual.transform.localScale = Scaleoffset;
                    HP5actual.transform.localScale = Scaleoffset;
                    HP6actual.transform.localScale = Scaleoffset;
                    HP7actual.transform.localScale = Scaleoffset;
                    HP8actual.transform.localScale = Scaleoffset;
                    HP9actual.transform.localScale = Scaleoffset;
                    HP10actual.transform.localScale = Scaleoffset;
                    HP11actual.transform.localScale = Scaleoffset;
                    HP12actual.transform.localScale = Scaleoffset;
                    HP13actual.transform.localScale = Scaleoffset;
                    leftengineactual.transform.localScale = new Vector3(0.88f, 0.88f, 0.88f);

                    F16Debug.Log("Section6");

                    //this makes the whole body disappear by setting the renderer off

                    F16Debug.Log("Section7");

                    Transform bodytohide = defaultF26Transform.Find("aFighter2");
                    GameObject bodytohideobj = bodytohide.gameObject;
                    disableMesh(bodytohideobj);


                    F16Debug.Log("Section9");
                    Transform ejecttohide = defaultF26Transform.Find("EjectorSeat");
                    GameObject ejecttohideobj = ejecttohide.gameObject;
                    disableMesh(ejecttohideobj);

                    

                    F16Debug.Log("Section10");





                    F16Debug.Log("Section15");

                    //This reenables the things we need
                    List<string> partstounhidelist = new List<string>()
                    {
                        "HP1","HP2","HP3","HP8","HP9","HP10","HP11DropTank","HP12DropTank", "fa26-leftEngine","CenterStickObjects", "gunBarrels", "SideStickObjects", "throttleTrack", "throttle","acesCenterEjectBase", "acesEjectArmLever","CameraRigParent"
                        };
                    foreach (String partstounhidename in partstounhidelist)
                    {
                        F16Debug.Log("finding: " + partstounhidename);
                        GameObject parttounhide = PickupAllChildrensTransforms(defaultf26, partstounhidename).gameObject as GameObject;
                        if (parttounhide != null)
                        {


                            enableMesh(parttounhide);

                            F16Debug.Log("Part alive: " + partstounhidename);
                        }
                    }

                    //This disables things that are not in the main list
                    List<string> partstohidelist = new List<string>()
                    {  "RightEngineSwitch", "RPMGauge2","RPMGauge", "WingSwitch", "coverSwitchInteractable_rightEngine", "coverSwitchInteractable_leftEngine","APUGauge","APUSwitch"
                        };
                    foreach (String partstohidename in partstohidelist)
                    {
                        F16Debug.Log("finding: " + partstohidename);
                        GameObject parttohide = PickupAllChildrensTransforms(defaultf26, partstohidename).gameObject as GameObject;
                        if (parttohide != null)
                        {
                            VRInteractable interactor = parttohide.GetComponent<VRInteractable>();

                            if (interactor != null)
                            {
                                interactor.enabled = false;
                            }

                            disableMesh(parttohide);
                            disableSprites(parttohide);
                            disableVTT(parttohide);


                            F16Debug.Log("Part alive: " + partstohidename);
                        }
                    }

                    RPMGauge2t = PickupAllChildrensTransforms(defaultf26, "RPMGauge2");
                    disableMesh(RPMGauge2t.gameObject);


                    

                    partsToScaleTransform = PickupAllChildrensTransforms(defaultf26, "canopy");
                    subPartToScaleTransform = PickupAllChildrensTransforms(partsToScaleTransform.gameObject, "indicatorObj");
                    //subparttoscaletransform.localScale = new Vector3(0f, 0f, 0f);
                    disableMesh(subPartToScaleTransform.gameObject);
                    disableSprites(subPartToScaleTransform.gameObject);
                    subPartToScaleTransform.gameObject.SetActive(false);

                    F16Debug.Log("wingtipvapors");
                    //wingtip vapors
                    leftwingtipvapors = PickupAllChildrensTransforms(defaultf26, "WingVapor (7)");
                    rightwingtipvapors = PickupAllChildrensTransforms(defaultf26, "WingVapor (6)");
                    leftwinginnervapors = PickupAllChildrensTransforms(defaultf26, "WingVapor (3)");
                    rightwinginnervapors = PickupAllChildrensTransforms(defaultf26, "WingVapor (1)");
                    leftwingovervapors = PickupAllChildrensTransforms(defaultf26, "WingVapor (4)");
                    rightwingovervapors = PickupAllChildrensTransforms(defaultf26, "WingVapor (2)");


                    leftwingvaporf16 = PickupAllChildrensTransforms(newAircraftUnit, "leftwingvaporf16");
                    righttwingvaporf16 = PickupAllChildrensTransforms(newAircraftUnit, "rightwingvaporf16");
                    leftwingvaporinnerf16 = PickupAllChildrensTransforms(newAircraftUnit, "leftwingvaporf16innerwing");
                    rightwingvaporinnerf16 = PickupAllChildrensTransforms(newAircraftUnit, "rightwingvaporf16innerwing");
                    leftwingovervaporf16 = PickupAllChildrensTransforms(newAircraftUnit, "leftwingvaporf16overwing");
                    rightwingovervaporf16 = PickupAllChildrensTransforms(newAircraftUnit, "rightwingvaporf16overwing");


                    leftwingtipvapors.position = leftwingvaporf16.position;
                    rightwingtipvapors.position = righttwingvaporf16.position;
                    leftwinginnervapors.position = leftwingvaporinnerf16.position;
                    rightwinginnervapors.position = rightwingvaporinnerf16.position;
                    leftwingovervapors.position = leftwingovervaporf16.position;
                    rightwingovervapors.position = rightwingovervaporf16.position;
                    leftwingovervapors.localScale = new Vector3(0.66f, 1f, 0.66f);
                    rightwingovervapors.localScale = new Vector3(0.66f, 1f, 0.66f);

                    //F16Debug.Log("wing folders");
                    wingFoldSwitch = PickupAllChildrensTransforms(defaultf26, "WingSwitch");
                    wingFoldSwitchI = PickupAllChildrensTransforms(defaultf26, "WingSwitchInteractable");
                    wingFoldSwitchIVR = wingFoldSwitchI.GetComponent<VRLever>();
                    wingFoldSwitchIVR.RemoteSetState(0);
                    wingFoldSwitchIVR.LockTo(0);




                    //setting up landing flaps

                    LandingFlapsLeverObject = PickupAllChildrensTransforms(defaultf26, "FlapsLever").gameObject;
                    VRLever FlapsLeverCheck = LandingFlapsLeverObject.GetComponentInChildren<VRLever>();
                    flc = FlapsLeverCheck.currentState;



                    F16Debug.Log("Flap Lever State = " + flc);
                    //FlapsLeverCheck.OnSetState = new IntEvent();
                    FlapsLeverCheck.OnSetState.AddListener(FlapLeverCheckState);


                    //setting up the internal lights switch

                    instLightsTransformObj = PickupAllChildrensTransforms(defaultf26, "InstLightSwitch").gameObject;
                    internalLightsLeverObject = PickupAllChildrensTransforms(instLightsTransformObj, "radioSwitch").gameObject;
                    VRLever internalLightsLeverCheck = internalLightsLeverObject.GetComponentInChildren<VRLever>();
                    ilCheck = internalLightsLeverCheck.currentState;

                    F16Debug.Log("Internal Light State = " + lglCheck);
                    allInstrumentsLightsTransformParentObj = PickupAllChildrensTransforms(newAircraftUnit, "InstrumentLights").gameObject;
                    allInstrumentsLights = allInstrumentsLightsTransformParentObj.GetComponentsInChildren(typeof(Light));

                    F16Debug.Log("Internal Light 2 ");

                    //left panel
                    leftPanelgObj = PickupAllChildrensTransforms(newAircraftUnit, "console_L").gameObject;
                    leftPanelRendererMaterials = leftPanelgObj.GetComponent<MeshRenderer>().materials;
                    foreach (Material materialitem in leftPanelRendererMaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);
                        if (materialitem.name == "con_ltx (Instance)")
                        {
                            leftPanelRendererMaterial = materialitem;

                        }
                    }

                    //left aux panel
                    leftauxpanelgobj = PickupAllChildrensTransforms(newAircraftUnit, "cons_L_aux").gameObject;
                    leftauxpanelrenderermaterials = leftauxpanelgobj.GetComponent<MeshRenderer>().materials;
                    foreach (Material materialitem in leftauxpanelrenderermaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);
                        if (materialitem.name == "claux_tx (Instance)")
                        {
                            leftauxpanelrenderermaterial = materialitem;

                        }
                    }
                    //right panel
                    rightPanelgObj = PickupAllChildrensTransforms(newAircraftUnit, "console_R").gameObject;
                    rightpanelrenderermaterials = rightPanelgObj.GetComponent<MeshRenderer>().materials;
                    foreach (Material materialitem in rightpanelrenderermaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);
                        if (materialitem.name == "conr_txt (Instance)")
                        {
                            rightpanelrenderermaterial = materialitem;

                        }
                    }


                    //right aux panel
                    rightauxpanelgobj = PickupAllChildrensTransforms(newAircraftUnit, "cons_R_aux").gameObject;
                    rightauxpanelrenderermaterials = rightauxpanelgobj.GetComponent<MeshRenderer>().materials;
                    foreach (Material materialitem in rightauxpanelrenderermaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);
                        if (materialitem.name == "pan_txt (Instance)")
                        {
                            rightauxpanelrenderermaterial = materialitem;

                        }
                    }

                    //front centre panel
                    frontcentrepanelgobj = PickupAllChildrensTransforms(newAircraftUnit, "console_Fc").gameObject;
                    frontcentrepanelrenderermaterials = frontcentrepanelgobj.GetComponent<MeshRenderer>().materials;
                    foreach (Material materialitem in frontcentrepanelrenderermaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);
                        if (materialitem.name == "panel_tx (Instance)")
                        {
                            frontcentrepanelrenderermaterial = materialitem;

                        }
                    }

                    //front upper panel
                    frontupperpanelgobj = PickupAllChildrensTransforms(newAircraftUnit, "console_F").gameObject;
                    frontupperpanelrenderermaterials = frontupperpanelgobj.GetComponent<MeshRenderer>().materials;
                    foreach (Material materialitem in frontupperpanelrenderermaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);
                        if (materialitem.name == "conf_text (Instance)")
                        {
                            frontupperpanelrenderermaterial = materialitem;

                        }
                    }

                    //optical sight

                    frontsightpanelgobj = PickupAllChildrensTransforms(newAircraftUnit, "opt_sight").gameObject;
                    frontsightpanelrenderermaterials = frontsightpanelgobj.GetComponent<MeshRenderer>().materials;
                    foreach (Material materialitem in frontsightpanelrenderermaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);
                        if (materialitem.name == "sight_tx (Instance)")
                        {
                            frontsightpanelrenderermaterial = materialitem;

                        }
                    }



                    //Compass Cylinder
                    Compasscylinderobj = PickupAllChildrensTransforms(newAircraftUnit, "Compasscylinder").gameObject;
                    CompasscylinderobjRendererMaterials = Compasscylinderobj.GetComponent<MeshRenderer>().materials;
                    foreach (Material materialitem in CompasscylinderobjRendererMaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);
                        if (materialitem.name == "Material.001 (Instance)")
                        {
                            Compasscylindermaterial = materialitem;

                        }
                    }
                    //AOA Cylinder
                    AOAcylinderobj = PickupAllChildrensTransforms(newAircraftUnit, "Cylinderaoa").gameObject;
                    AOAcylinderobjRendererMaterials = AOAcylinderobj.GetComponent<MeshRenderer>().materials;
                    foreach (Material materialitem in AOAcylinderobjRendererMaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);
                        if (materialitem.name == "aoaindicator (Instance)")
                        {
                            AOAcylindermaterial = materialitem;

                        }
                    }

                    //Right Upper Ins
                    rightUpperInstruments = PickupAllChildrensTransforms(newAircraftUnit, "cons_F_ins").gameObject;
                    rightUpperInstrumentsRendererMaterials = rightUpperInstruments.GetComponent<MeshRenderer>().materials;
                    foreach (Material materialitem in rightUpperInstrumentsRendererMaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);
                        if (materialitem.name == "scale_07 (Instance)")
                        {
                            rightUpperInstrumentsRPM = materialitem;

                        }
                        if (materialitem.name == "scale_08 (Instance)")
                        {
                            rightUpperInstrumentsFTIT = materialitem;

                        }
                        if (materialitem.name == "scale_05 (Instance)")
                        {
                            rightUpperInstrumentsOil = materialitem;

                        }
                        if (materialitem.name == "scale_02 (Instance)")
                        {
                            rightUpperInstrumentsAtt2 = materialitem;

                        }
                        if (materialitem.name == "scale_06 (Instance)")
                        {
                            rightUpperInstrumentsNozzle = materialitem;

                        }
                    }
                    //KnobsMaterials

                    pointerKnobsGroup = PickupAllChildrensTransforms(newAircraftUnit, "Pointerknob");
                    contr2Parent = PickupAllChildrensTransforms(pointerKnobsGroup.gameObject, "rotatorknob11");
                    contr2ParentRendererMaterials = contr2Parent.GetComponent<MeshRenderer>().sharedMaterials;
                    foreach (Material materialitem in contr2ParentRendererMaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);

                        if (materialitem.name == "contr2")
                        {
                            contr2KnobMaterial = materialitem;

                        }
                    }
                    contr1Parent = PickupAllChildrensTransforms(pointerKnobsGroup.gameObject, "rotatorknob5");
                    contr1ParentRendererMaterials = contr1Parent.GetComponent<MeshRenderer>().sharedMaterials;
                    foreach (Material materialitem in contr1ParentRendererMaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);

                        if (materialitem.name == "contr1")
                        {
                            contr1KnobMaterial = materialitem;

                        }


                    }
                    controlParent = PickupAllChildrensTransforms(pointerKnobsGroup.gameObject, "rotatorknob9");
                    controlParentRendererMaterials = controlParent.GetComponent<MeshRenderer>().sharedMaterials;
                    foreach (Material materialitem in controlParentRendererMaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);

                        if (materialitem.name == "control")
                        {
                            controlKnobMaterial = materialitem;

                        }


                    }
                    pointerKnobsGroup2 = PickupAllChildrensTransforms(newAircraftUnit.gameObject, "Smalltwisty");
                    contr4Parent = PickupAllChildrensTransforms(pointerKnobsGroup2.gameObject, "rotatorknob8");
                    contr4ParentRendererMaterials = contr4Parent.GetComponent<MeshRenderer>().sharedMaterials;
                    foreach (Material materialitem in contr4ParentRendererMaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);

                        if (materialitem.name == "contr4")
                        {
                            contr4KnobMaterial = materialitem;

                        }


                    }



                    // Right AUX ins
                    F16Cockpit = PickupAllChildrensTransforms(newAircraftUnit, "f16cockpit");
                    rightAuxInstruments = PickupAllChildrensTransforms(F16Cockpit.gameObject, "cR_aux_ins").gameObject;
                    rightAuxInstrumentsRendererMaterials = rightAuxInstruments.GetComponent<MeshRenderer>().materials;
                    foreach (Material materialitem in rightAuxInstrumentsRendererMaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);
                        if (materialitem.name == "crau_sc3 (Instance)")
                        {
                            rightAuxInstrumentsHydraulics = materialitem;

                        }
                        if (materialitem.name == "crau_sc1 (Instance)")
                        {
                            rightAuxInstrumentsFuel = materialitem;

                        }
                        if (materialitem.name == "cRau_sc4 (Instance)")
                        {
                            rightAuxInstrumentsOxygen = materialitem;

                        }
                        if (materialitem.name == "crsaux6 (Instance)")
                        {
                            rightAuxInstrumentsClock = materialitem;

                        }
                        if (materialitem.name == "crausc7 (Instance)")
                        {
                            rightAuxInstrumentsCPressure = materialitem;

                        }
                        if (materialitem.name == "crauxsc5 (Instance)")
                        {
                            rightAuxInstrumentsEPUFuel = materialitem;

                        }
                    }


                    f26EjectorHandle = PickupAllChildrensTransforms(ejecttohide.gameObject, "acesCenterEjectHandle");
                    f16EjectorHandle = PickupAllChildrensTransforms(F16Cockpit.gameObject, "EjectorSeatHandle");
                    f26EjectorHandle.position = f16EjectorHandle.position;

                    //front panel

                    F16CockpitActiveSwitches = PickupAllChildrensTransforms(F16Cockpit.gameObject, "ActiveSwitches");

                    frontPanelICF = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "huddashbuttons").gameObject;
                    frontPanelICFRendererMaterials = frontPanelICF.GetComponent<MeshRenderer>().materials;
                    foreach (Material materialitem in frontPanelICFRendererMaterials)
                    {
                        F16Debug.Log("Material Name = " + materialitem.name);
                        if (materialitem.name == "key_txt 1 (Instance)")
                        {
                            frontPanelICFMat = materialitem;

                        }
                    }




                    internalLightsLeverCheck.OnSetState.AddListener(InternalLightsCheckState);

                    //HelperLights Setup

                    HelpLightsHolder = PickupAllChildrensTransforms(newAircraftUnit, "HelperLights");
                    disableMesh(HelpLightsHolder.gameObject);



                    //setting up the cockpit to move



                    CanopyLeverObject = PickupAllChildrensTransforms(defaultf26, "CanopyLever").gameObject;
                    VRLever CanopyLeverCheck = CanopyLeverObject.GetComponentInChildren<VRLever>();
                    cl = CanopyLeverCheck.currentState;


                    F16Debug.Log("Canopy State = " + cl);



               
                    //how loing to wait before starting
                    waitInterval = 0.5f;
                    //how long to take in seconds
                    canopyduration = 7f;

                    //create a new point pivot around


                    //select all the cockpit pieces
                    cockpitPivotObj = PickupAllChildrensTransforms(newAircraftUnit, "CockpitPivot").gameObject;

                    cockpit = PickupAllChildrensTransforms(cockpitPivotObj, "CockpitCap_low_").gameObject;
                    cockpitGlass = PickupAllChildrensTransforms(cockpitPivotObj, "cockpitcanopyfront").gameObject;
                    cockpitBolts = PickupAllChildrensTransforms(cockpitPivotObj, "Cockpit_El_2").gameObject;
                    cockpitHandles = PickupAllChildrensTransforms(cockpitPivotObj, "Hands");
                    
                    cockpitPivot = cockpitPivotObj.transform;
                    f16CanopyAnimator = cockpitPivot.GetComponent<Animator>();



                    //how much to rotate by
                    targetRotationopen = new Vector3(0f, 0f, -35.0f);


                    //now make the actual pivot transfor be in the right place
                     

                    F16Debug.Log("CockpitPivot Position = (" + cockpitPivot.transform.position.x + "," + cockpitPivot.transform.position.y + "," + cockpitPivot.transform.position.z + ")");

                    //tie the pivot point to the aircraft
                    //cockpitPivot.transform.SetParent(defaultF26Transform);
                    //parent the cockpit to the pivot
                    


                    F16Debug.Log("Cockpit Position = (" + cockpit.transform.position.x + "," + cockpit.transform.position.y + "," + cockpit.transform.position.z + ")");
                    F16Debug.Log("Cockpit localPosition = (" + cockpit.transform.localPosition.x + "," + cockpit.transform.localPosition.y + "," + cockpit.transform.localPosition.z + ")");

                    //this works out where we are now

                    F16Debug.Log("CockpitPivot Rotation = (" + cockpitPivot.localEulerAngles.x + "," + cockpitPivot.localEulerAngles.y + "," + cockpitPivot.localEulerAngles.z + ")");



                    F16Debug.Log("CockpitPivot Rotation = (" + cockpitPivot.localEulerAngles.x + "," + cockpitPivot.localEulerAngles.y + "," + cockpitPivot.localEulerAngles.z + ")");

                    defaultRotation = cockpitPivot.localEulerAngles;

                    //work out what current state of lever is, if open then set cockpit open

                    if (cl == 1)
                    {

                        f16CanopyAnimator.Play("Canopyinstantopen");
                    }
                    else
                    {

                        f16CanopyAnimator.Play("Canopyinstantclose");
                    }
                    landinggearcount = 0;

                    f16landinggearleverParent = PickupAllChildrensTransforms(F16Cockpit.gameObject, "landinggearBase");
                    f16landinggearleverPivot = PickupAllChildrensTransforms(F16Cockpit.gameObject, "landinggearpivot");

                    f16landinggearlever = PickupAllChildrensTransforms(f16landinggearleverParent.gameObject, "cLau_lever");

                    f16landinggearlevertrans = PickupAllChildrensTransforms(f16landinggearlever.gameObject, "landingearlever_trans");
                    LeftFWDDashPoseBoundsF16 = PickupAllChildrensTransforms(newAircraftUnit, "ConsoleLAux_posebounds");
                    ConsFLowerF16 = PickupAllChildrensTransforms(newAircraftUnit, "ConsoleFLower_posebounds");
                    CenterDashPoseBoundsf26 = PickupAllChildrensTransforms(defaultf26, "CenterDashPoseBounds");
                    CenterDashPoseBoundsf26.position = ConsFLowerF16.position;


                    f26LeftFwdPanel = PickupAllChildrensTransforms(defaultf26, "LeftFwdDash");
                    f26landinggearobject = PickupAllChildrensTransforms(f26LeftFwdPanel.gameObject, "gearLever");
                    f26landinggearint = PickupAllChildrensTransforms(f26landinggearobject.gameObject, "GearInteractable");
                    f26landinggearintlever = f26landinggearint.GetComponent<VRLever>();
                    f26landinggearleverscript = f26landinggearint.GetComponent<LandingGearLever>();
                    LandingGearRightLight = PickupAllChildrensTransforms(F16Cockpit.gameObject, "LandingGearRightLight");
                    LandingGearRightLightCyl = PickupAllChildrensTransforms(LandingGearRightLight.gameObject, "Cylinder");
                    LandingGearLeftLight = PickupAllChildrensTransforms(F16Cockpit.gameObject, "LandingGearLeftLight");
                    LandingGearLeftLightCyl = PickupAllChildrensTransforms(LandingGearLeftLight.gameObject, "Cylinder");
                    LandingGearTopLight = PickupAllChildrensTransforms(F16Cockpit.gameObject, "LandingGearTopLight");
                    LandingGearTopLightCyl = PickupAllChildrensTransforms(LandingGearTopLight.gameObject, "Cylinder");
                    LandingGearLightCylMat = LandingGearTopLightCyl.GetComponent<MeshRenderer>().sharedMaterial;




                    gearStateStart = f26landinggearintlever.currentState;
                    F16Debug.Log("F26 Landing Gear State = " + gearStateStart);


                    f16landinggearleverVRL = CreateSwitch("Landing Gear", f16landinggearlevertrans.gameObject, f16landinggearleverPivot, 15f, 2, gearStateStart, LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), false, true);
                    lglCheck = f16landinggearleverVRL.currentState;
                    F16Debug.Log("F16 Landing Gear State = " + lglCheck);
                    landinggearcount = 0;




                    //f16landinggearleverVRL.OnSetState.AddListener(f26landinggearleverscript.SetState);




                    F16Debug.Log("F26 Landing Gear State 2 = " + f26landinggearintlever.currentState);
                    F16Debug.Log("f16 Landing Gear State 2 = " + f16landinggearleverVRL.currentState);


                    f16landinggearleverVRL.OnSetState.AddListener(LandingGearPreCheck);

                    F16Debug.Log("F26 Landing Gear State 3 = " + f26landinggearintlever.currentState);
                    F16Debug.Log("f16 Landing Gear State 3 = " + f16landinggearleverVRL.currentState);

                    //how loing to wait before starting
                    landinggearwaitInterval = 0.5f;
                    //how long to take in seconds
                    landinggearcoverduration = 3f;
                    landinggearduration = 3f;


                    ///airbrake setup
                    airbrakeobj = PickupAllChildrensTransforms(defaultf26, "airbrakeParent").gameObject;
                    airbrakepiston = PickupAllChildrensTransforms(airbrakeobj, "airbrakePiston").gameObject;
                    F16Debug.Log("airbrake default rotation :" + airbrakeobj.transform.localEulerAngles.x + "," + airbrakeobj.transform.localEulerAngles.y + "," + airbrakeobj.transform.localEulerAngles.z);
                    F16Debug.Log("airbrakepiston default rotation :" + airbrakepiston.transform.localEulerAngles.x + "," + airbrakepiston.transform.localEulerAngles.y + "," + airbrakepiston.transform.localEulerAngles.z);
                    airBrakeController = airbrakeobj.GetComponent<AirBrakeController>();

                    defaultairbrakerotation = new Vector3(271.5f, 180f, 180f);



                    airbrakelefthingeupperobj = PickupAllChildrensTransforms(newAircraftUnit, "airbrakelefthingeupper");
                    airbrakelefthingelowerobj = PickupAllChildrensTransforms(newAircraftUnit, "airbrakelefthingelower");
                    airbrakerighthingeupperobj = PickupAllChildrensTransforms(newAircraftUnit, "airbrakerighthingeupper");
                    airbrakerighthingelowerobj = PickupAllChildrensTransforms(newAircraftUnit, "airbrakerighthingelower");

                    F26leftengine = PickupAllChildrensTransforms(defaultf26, "fa26-leftEngine").gameObject;
                    F26Nozzle = PickupAllChildrensTransforms(F26leftengine, "gimbalFin.000");
                    compassBlock = PickupAllChildrensTransforms(newAircraftUnit, "Compasscylinder");
                    fuelTanks = defaultf26.GetComponents<FuelTank>();




                    minuteNeedle = PickupAllChildrensTransforms(newAircraftUnit, "cRau_i_n09");
                    hourNeedle = PickupAllChildrensTransforms(newAircraftUnit, "cRau_i_n08");
                    rpmNeedle = PickupAllChildrensTransforms(newAircraftUnit, "consF_nd05");
                    f26RPMGauge = PickupAllChildrensTransforms(defaultf26, "RPMGauge").gameObject;
                    f26RPMneedle = PickupAllChildrensTransforms(f26RPMGauge, "needle1 (1)");
                    nozzleNeedle = PickupAllChildrensTransforms(newAircraftUnit, "consF_nd06");
                    nozzleNeedleDefault = nozzleNeedle.localEulerAngles.z - 180f;
                    fuelMainNeedle = PickupAllChildrensTransforms(newAircraftUnit, "fuelmainneedle");
                    fuelLeftNeedle = PickupAllChildrensTransforms(newAircraftUnit, "fuelleftneedle");
                    fuelRightNeedle = PickupAllChildrensTransforms(newAircraftUnit, "fuelrightneedle");
                    fuelUnderNeedle = PickupAllChildrensTransforms(newAircraftUnit, "fuelunderneedle");
                    fuelMNatZero = fuelMainNeedle.localEulerAngles.z - 180f;
                    fuelLNatZero = fuelLeftNeedle.localEulerAngles.z - 180f;
                    fuelrnatzero = fuelRightNeedle.localEulerAngles.z - 180f;
                    fuelunatzero = fuelUnderNeedle.localEulerAngles.z - 180f;
                    ftitneedle = PickupAllChildrensTransforms(newAircraftUnit, "consF_nd04");
                    ftitnatzero = ftitneedle.localEulerAngles.z;
                    cabinpressneedle = PickupAllChildrensTransforms(newAircraftUnit, "cRau_i_n07");
                    cabinpressatzero = cabinpressneedle.localEulerAngles.z;
                    Hydraulicsleftneed = PickupAllChildrensTransforms(newAircraftUnit, "cRau_i_n03");
                    Hydraulicsrightneed = PickupAllChildrensTransforms(newAircraftUnit, "cRau_i_n04");
                    Hydraulicsleftneedatzero = Hydraulicsleftneed.localEulerAngles.z;
                    Hydraulicsrightneedatzero = Hydraulicsrightneed.localEulerAngles.z;
                    AOAGauge = PickupAllChildrensTransforms(newAircraftUnit, "Cylinderaoa");
                    AOAGaugeatzero = AOAGauge.localEulerAngles.z;



                    //Get Wings to check if damaged
                    LeftWingObject = PickupAllChildrensTransforms(defaultf26, "wingLeftPart").gameObject;
                    LeftWingHealth = LeftWingObject.GetComponent<Health>();
                    LeftWingHealthStatus = LeftWingHealth.currentHealth;
                    F16Debug.Log("LeftWing Health = " + LeftWingHealthStatus);
                    RighttWingObject = PickupAllChildrensTransforms(defaultf26, "wingRightPart").gameObject;
                    RightWingHealth = RighttWingObject.GetComponent<Health>();
                    RightWingHealthStatus = RightWingHealth.currentHealth;
                    F16Debug.Log("RightWing Health = " + RightWingHealthStatus);

                    //Get heat of engines

                    heatemitter = F26leftengine.GetComponent<HeatEmitter>();
                    engineheat = heatemitter.heat;

                    //fix engines stuff
                    rightenginescripts = rightengineactual.GetComponent<ModuleEngine>();
                    rightenginescripts.doWarnings = false;
                    rightenginescripts.includeInTWR = false;




                    //setup fuel in tanks

                    totalfuelinaircraft = 0f;

                    foreach (var tank in fuelTanks)
                    {
                        F16Debug.Log("Tank = " + tank.name);

                        maxfuel = tank.maxFuel;
                        F16Debug.Log("Tank Max Fuel = " + tank.name + " : " + maxfuel);


                        totalfuelinaircraft = totalfuelinaircraft + maxfuel;
                        F16Debug.Log("Total Fuel = " + totalfuelinaircraft);
                        externalfueltanks = tank.subFuelTanks;
                        foreach (var subtank in externalfueltanks)
                        {
                            maxfuel = subtank.maxFuel;
                            F16Debug.Log("Tank Max Fuel = " + subtank.name + " : " + maxfuel);

                            totalfuelinaircraft = totalfuelinaircraft + maxfuel;
                            F16Debug.Log("Total Fuel = " + totalfuelinaircraft);
                        }
                    }

                    CustomInternalLightsOff();
                    AircraftLoaded = true;





                   
                    MovingActiveSwitches();
                    CockpitPanelHider();
                    EnableAllNonActiveSwitches();
                    HUDElementChanges();
                    CameraSetup();
                    //SpeedIndicatorUpdate();
                    FixCollidersandHitboxes();
                    ////setting up the landing gear animation


                    f16LazerArmintTK.OnSetState.AddListener(HelperLights);

                    F16Debug.Log("finished hide");




                    //make somethings large again
                    F16Debug.Log("Line 294");
                    //CanopyLeverCheck.OnSetState = new IntEvent();
                    CanopyLeverCheck.OnSetState.AddListener(CanopyCheckState);

                    Spawncount = 0;

                    Setuprunning = false;

                    //get mp buttons  
                    if (MPActive)
                    {
                        mpRadioButton1 = PickupAllChildrensTransforms(defaultf26, "1");

                  
                        F16Debug.Log("enabling mp radio");
                        StartCoroutine(MPRadio());
                    }

                    //setupded

                    f16DED = PickupAllChildrensTransforms(frontupperpanelgobj, "DEDDisplay");
                    f16DEDLine3R = PickupAllChildrensTransforms(f16DED.gameObject, "DEDR3");
                    f16DEDLine3RTM = f16DEDLine3R.GetComponent<TextMeshPro>();
                    f16DEDLine2L = PickupAllChildrensTransforms(f16DED.gameObject, "DEDL2");
                    f16DEDLine2LTM = f16DEDLine2L.GetComponent<TextMeshPro>();
                    f16DEDLine4L = PickupAllChildrensTransforms(f16DED.gameObject, "DEDL4");
                    f16DEDLine4LTM = f16DEDLine4L.GetComponent<TextMeshPro>();





                    f16WaypointManager = defaultf26.GetComponent<WaypointManager>();

                    // this is just here to check that the code is all loaded, the red light is turned on when the f16 fully loads in
                    f16TestLight = PickupAllChildrensTransforms(newAircraftUnit, "TestLight");
                    f16TestLightInt = f16TestLight.GetComponent<Light>();
                    f16TestLightInt.enabled = false;

                    if (lcleftpanel != null)
                    {
                        BatteryLever.SetCurrentState(1);
                    }
                    f16pitchholdintTK.OnSetState.AddListener(AutopilotPitch);
                    f16rollaltholdintTK.OnSetState.AddListener(AutopilotRoll);
                    f16hudaltitudetypeinteractablevrlever.OnSetState.AddListener(vehMaster.SetRadarAltMode);
                    AutoPilot2 = defaultf26.GetComponent<VTOLAutoPilot>();

                    f16radioparent = PickupAllChildrensTransforms(newAircraftUnit, "radioparent");
                    f16radiobuttonEnter = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16buttonEnter");
                    f26ClearWaypointButton = PickupAllChildrensTransforms(HUDDashF26.gameObject, "ClrWptButton");
                    
                   f26ClearWaypointButton.position = f16radiobuttonEnter.position;
                    
                    clrWptButVRI = f26ClearWaypointButton.GetComponent<VRInteractable>();
                    clrWptButVRI.poseBounds = null;

                }



            }
            PlaneSetupDone = true;
        }

        private void SpeedIndicatorUpdate()
        {
            f26SpeedIndicator.gameObject.SetActive(false);
            f26SpeedIndicatorComponent = f26SpeedIndicator.GetComponent<DashSpeedometer>();
            f26SpeedIndicatorComponent.maxValue = 1200;
            f26SpeedIndicatorComponent.lerpRate = 8;


            f26SpeedIndicatorComponentProfiles = f26SpeedIndicatorComponent.profiles;
            f26SpeedIndicatorComponentProfiles[0].maxSpeed = 1200;
            f26SpeedIndicatorComponentProfiles[1].maxSpeed = 1200;
            f26SpeedIndicatorComponentProfiles[2].maxSpeed = 2500;
            f26SpeedIndicatorComponentProfiles[3].maxSpeed = 1400;
            f26SpeedIndicatorComponentProfiles[4].maxSpeed = 2500;

            f26SpeedProfilesKnots = PickupAllChildrensTransforms(f26SpeedIndicator.gameObject, "knotProfile");
            f26SpeedIndicator0 = PickupAllChildrensTransforms(f26SpeedProfilesKnots.gameObject, "(0)");
            f26SpeedIndicator1 = PickupAllChildrensTransforms(f26SpeedProfilesKnots.gameObject, " (1)");
            f26SpeedIndicator2 = PickupAllChildrensTransforms(f26SpeedProfilesKnots.gameObject, " (2)");
            f26SpeedIndicator3 = PickupAllChildrensTransforms(f26SpeedProfilesKnots.gameObject, " (3)");
            f26SpeedIndicator4 = PickupAllChildrensTransforms(f26SpeedProfilesKnots.gameObject, " (4)");
            f26SpeedIndicator0Text = f26SpeedIndicator0.GetComponent<Text>();
            f26SpeedIndicator1Text = f26SpeedIndicator1.GetComponent<Text>();
            f26SpeedIndicator2Text = f26SpeedIndicator2.GetComponent<Text>();
            f26SpeedIndicator3Text = f26SpeedIndicator3.GetComponent<Text>();
            f26SpeedIndicator4Text = f26SpeedIndicator4.GetComponent<Text>();

            f26SpeedIndicator0Text.text = "0";
            f26SpeedIndicator1Text.text = "3";
            f26SpeedIndicator2Text.text = "6";
            f26SpeedIndicator3Text.text = "9";
            f26SpeedIndicator4Text.text = "12";

            f26SpeedIndicatorComponent.doCalibration = true;
            f26SpeedIndicatorComponent.calibrationSpeed = 1;

            f26SpeedIndicator.gameObject.SetActive(true);









        }

        private void CameraSetup()
        {
            mainCameraGroup = PickupAllChildrensTransforms(newAircraftUnit, "Cameras");
            rwmissilecam = PickupAllChildrensTransforms(mainCameraGroup.gameObject, "rightWingMissileCam");
            lwweaponscam = PickupAllChildrensTransforms(mainCameraGroup.gameObject, "leftWingWeaponsCam");
            underccam = PickupAllChildrensTransforms(mainCameraGroup.gameObject, "undercarriageCam");
            tGCam = PickupAllChildrensTransforms(mainCameraGroup.gameObject, "topGunCam");
            rADogfightCam = PickupAllChildrensTransforms(mainCameraGroup.gameObject, "topGunCam");
            f26ExtCamMgr = PickupAllChildrensTransforms(defaultf26, "ExternalCamManager");
            f26ExtCam = PickupAllChildrensTransforms(f26ExtCamMgr.gameObject, "ExtCam");
            f26ExtCam2 = PickupAllChildrensTransforms(f26ExtCamMgr.gameObject, "ExtCam2");
            f26ExtCam2R = PickupAllChildrensTransforms(f26ExtCamMgr.gameObject, "ExtCam2R");
            f26ExtCam3 = PickupAllChildrensTransforms(f26ExtCamMgr.gameObject, "ExtCam3");
            f26ExtCamFrontWheel = PickupAllChildrensTransforms(f26ExtCamMgr.gameObject, "ExtCamFrontWheel");
            f26ExtCam.position = rwmissilecam.position;
            f26ExtCam.rotation = rwmissilecam.rotation;
            f26ExtCam2.position = lwweaponscam.position;
            f26ExtCam2.rotation = lwweaponscam.rotation;
            f26ExtCam3.position = underccam.position;
            f26ExtCam3.rotation = underccam.rotation;
            f26ExtCam2R.position = tGCam.position;
            f26ExtCam2R.rotation = tGCam.rotation;
            f26ExtCamFrontWheel.position = rADogfightCam.position;
            f26ExtCamFrontWheel.rotation = rADogfightCam.rotation;



        }

        private void FixCollidersandHitboxes()
            {
            f16CollidersGroup = PickupAllChildrensTransforms(newAircraftUnit, "Colliders");
            f16RightWingCollider = PickupAllChildrensTransforms(f16CollidersGroup.gameObject, "rightWingCollider");
            f16RightWingColliderComponent = f16RightWingCollider.GetComponent<BoxCollider>();

            f16LeftWingCollider = PickupAllChildrensTransforms(f16CollidersGroup.gameObject, "leftWingCollider");
            f16LeftWingColliderComponent = f16LeftWingCollider.GetComponent<BoxCollider>();


            f16LeftElevonCollider = PickupAllChildrensTransforms(f16CollidersGroup.gameObject, "leftElevonCollider");
            f16LeftElevonColliderComponent = f16LeftElevonCollider.GetComponent<BoxCollider>();

            f16RightElevonCollider = PickupAllChildrensTransforms(f16CollidersGroup.gameObject, "rightElevonCollider");
            f16RightElevonColliderComponent = f16RightElevonCollider.GetComponent<BoxCollider>();
            
            f16VertStabCollider = PickupAllChildrensTransforms(f16CollidersGroup.gameObject, "vertStabCollider");
            f16VertStabColliderComponent = f16VertStabCollider.GetComponent<BoxCollider>();

            f16NoseCollider = PickupAllChildrensTransforms(f16CollidersGroup.gameObject, "noseCollider");
            f16NoseColliderComponent = f16NoseCollider.GetComponent<BoxCollider>();

            f16BodyCollider = PickupAllChildrensTransforms(f16CollidersGroup.gameObject, "bodyCollider");
            f16BodyColliderComponent = f16BodyCollider.GetComponent<BoxCollider>();


            collidersGroup = PickupAllChildrensTransforms(defaultf26, "colliders");
            colliderBody = PickupAllChildrensTransforms(collidersGroup.gameObject, "colliders (2)");
            colliderBodyColC = colliderBody.GetComponent<BoxCollider>();
            colliderBody.position = f16BodyCollider.position;
            colliderBody.rotation = f16BodyCollider.rotation;
            colliderBodyColC.size = f16BodyColliderComponent.size;

            colliderNose = PickupAllChildrensTransforms(collidersGroup.gameObject, "colliders (3)");
            colliderNoseColC = colliderNose.GetComponent<BoxCollider>();
            colliderNose.position = f16NoseCollider.position;
            colliderNose.rotation = f16NoseCollider.rotation;
            colliderNoseColC.size = f16NoseColliderComponent.size;

            colliderLeftElevon = PickupAllChildrensTransforms(Afighter2t.gameObject, "colliders (4)");
            colliderLeftElevonColC = colliderLeftElevon.GetComponent<BoxCollider>();
            colliderLeftElevon.position = f16LeftElevonCollider.position;
            colliderLeftElevon.rotation = f16LeftElevonCollider.rotation;
            colliderLeftElevonColC.size = f16LeftElevonColliderComponent.size;
                       
            colliderRightElevon = PickupAllChildrensTransforms(Afighter2t.gameObject, "colliders (7)");
            colliderRightElevonColC = colliderRightElevon.GetComponent<BoxCollider>();
            colliderRightElevon.position = f16RightElevonCollider.position;
            colliderRightElevon.rotation = f16RightElevonCollider.rotation;
            colliderRightElevonColC.size = f16RightElevonColliderComponent.size;

            colliderVertStab = PickupAllChildrensTransforms(Afighter2t.gameObject, "colliders (5)");
            colliderVertStabColC = colliderVertStab.GetComponent<BoxCollider>();
            colliderVertStab.position = f16VertStabCollider.position;
            colliderVertStab.rotation = f16VertStabCollider.rotation;
            colliderVertStabColC.size = f16VertStabColliderComponent.size;

            colliderVertStabRight = PickupAllChildrensTransforms(Afighter2t.gameObject, "colliders (6)");
            colliderVertStabRightColC = colliderVertStabRight.GetComponent<BoxCollider>();
            colliderVertStabRightColC.enabled = false;

            wingLeftCollider = PickupAllChildrensTransforms(Afighter2t.gameObject, "wingLeftCollider");
            wingLeftColliderC = wingLeftCollider.GetComponent<BoxCollider>();
            wingLeftCollider.position = f16LeftWingCollider.position;
            wingLeftCollider.rotation = f16LeftWingCollider.rotation;
            wingLeftColliderC.size = f16LeftWingColliderComponent.size;

            wingRightCollider = PickupAllChildrensTransforms(Afighter2t.gameObject, "wingRightCollider");
            wingRightColliderC = wingRightCollider.GetComponent<BoxCollider>();
            wingRightCollider.position = f16RightWingCollider.position;
            wingRightCollider.rotation = f16RightWingCollider.rotation;
            wingRightColliderC.size = f16RightWingColliderComponent.size;

            wingTipFlexLeft= PickupAllChildrensTransforms(Afighter2t.gameObject, "wingTipFlexLeft");
            wingTipLeftCollider = PickupAllChildrensTransforms(wingTipFlexLeft.gameObject, "wingLeftCollider (1)");
            wingTipLeftColliderlC = wingTipLeftCollider.GetComponent<BoxCollider>();
            wingTipLeftColliderlC.enabled = false;

            wingLeftOuterCollider = PickupAllChildrensTransforms(Afighter2t.gameObject, "wingLeftCollider (1)");
            wingLeftOuterColliderC = wingLeftOuterCollider.GetComponent<BoxCollider>();
            wingLeftOuterColliderC.enabled = false;

            wingTipFlexRight = PickupAllChildrensTransforms(Afighter2t.gameObject, "wingTipFlexRight");
            wingTipRightCollider = PickupAllChildrensTransforms(wingTipFlexRight.gameObject, "wingRightCollider (1)");
            wingTipRightColliderlC = wingTipRightCollider.GetComponent<BoxCollider>();
            wingTipRightColliderlC.enabled = false;

            wingRightOuterCollider = PickupAllChildrensTransforms(Afighter2t.gameObject, "wingRightCollider (1)");
            wingRightOuterColliderC = wingRightOuterCollider.GetComponent<BoxCollider>();
            wingRightOuterColliderC.enabled = false;

            //hitboxes

            hitboxesGroup = PickupAllChildrensTransforms(defaultf26, "hitboxes");
            hitboxBody = PickupAllChildrensTransforms(hitboxesGroup.gameObject, "hitboxBody");
            hitboxBodyColC = hitboxBody.GetComponent<BoxCollider>();
            hitboxBody.position = f16BodyCollider.position;
            hitboxBody.rotation = f16BodyCollider.rotation;
            hitboxBodyColC.size = f16BodyColliderComponent.size;

            hitboxNose = PickupAllChildrensTransforms(hitboxesGroup.gameObject, "hitboxCockpit");
            hitboxNoseColC = hitboxNose.GetComponent<BoxCollider>();
            hitboxNose.position = f16NoseCollider.position;
            hitboxNose.rotation = f16NoseCollider.rotation;
            hitboxNoseColC.size = f16NoseColliderComponent.size;

            hitboxLeftElevon = PickupAllChildrensTransforms(Afighter2t.gameObject, "hitboxElevonLeft");
            hitboxLeftElevonColC = hitboxLeftElevon.GetComponent<BoxCollider>();
            hitboxLeftElevon.position = f16LeftElevonCollider.position;
            hitboxLeftElevon.rotation = f16LeftElevonCollider.rotation;
            hitboxLeftElevonColC.size = f16LeftElevonColliderComponent.size;

            hitboxRightElevon = PickupAllChildrensTransforms(Afighter2t.gameObject, "hitboxElevonRight");
            hitboxRightElevonColC = hitboxRightElevon.GetComponent<BoxCollider>();
            hitboxRightElevon.position = f16RightElevonCollider.position;
            hitboxRightElevon.rotation = f16RightElevonCollider.rotation;
            hitboxRightElevonColC.size = f16RightElevonColliderComponent.size;


            hitboxVertStabLeft = PickupAllChildrensTransforms(Afighter2t.gameObject, "vertStabLeft_part");
            hitboxVertStab = PickupAllChildrensTransforms(hitboxVertStabLeft.gameObject, "vertStabHitbox");

            hitboxVertStabColC = hitboxVertStab.GetComponent<BoxCollider>();
            hitboxVertStab.position = f16VertStabCollider.position;
            hitboxVertStab.rotation = f16VertStabCollider.rotation;
            hitboxVertStabColC.size = f16VertStabColliderComponent.size;

            hitboxVertStabRightP = PickupAllChildrensTransforms(Afighter2t.gameObject, "vertStabRight_part");
            hitboxVertStabRight = PickupAllChildrensTransforms(hitboxVertStabRightP.gameObject, "vertStabHitbox");
            hitboxVertStabRightColC = hitboxVertStabRight.GetComponent<BoxCollider>();
            hitboxVertStabRightColC.enabled = false;

            wingLefthitbox = PickupAllChildrensTransforms(Afighter2t.gameObject, "hitboxWingLeft");
            wingLefthitboxC = wingLefthitbox.GetComponent<BoxCollider>();
            wingLefthitbox.position = f16LeftWingCollider.position;
            wingLefthitbox.rotation = f16LeftWingCollider.rotation;
            wingLefthitboxC.size = f16LeftWingColliderComponent.size;

            wingRighthitbox = PickupAllChildrensTransforms(Afighter2t.gameObject, "hitboxWingRight");
            wingRighthitboxC = wingRighthitbox.GetComponent<BoxCollider>();
            wingRighthitbox.position = f16RightWingCollider.position;
            wingRighthitbox.rotation = f16RightWingCollider.rotation;
            wingRighthitboxC.size = f16RightWingColliderComponent.size;

            wingTipFlexLeft = PickupAllChildrensTransforms(Afighter2t.gameObject, "wingTipFlexLeft");
            wingTipLefthitbox = PickupAllChildrensTransforms(wingTipFlexLeft.gameObject, "hitboxTipLeft");
            wingTipLefthitboxlC = wingTipLefthitbox.GetComponent<BoxCollider>();
            wingTipLefthitboxlC.enabled = false;

            wingTipFlexRight = PickupAllChildrensTransforms(Afighter2t.gameObject, "wingTipFlexRight");
            wingTipRighthitbox = PickupAllChildrensTransforms(wingTipFlexRight.gameObject, "hitboxTipRight");
            wingTipRighthitboxlC = wingTipRighthitbox.GetComponent<BoxCollider>();
            wingTipRighthitboxlC.enabled = false;

            //engines

            f16EngineCollider = PickupAllChildrensTransforms(f16CollidersGroup.gameObject, "engineCollider");
            f16EngineColliderComponent = f16EngineCollider.GetComponent<CapsuleCollider>();

            engineLeftHitbox = PickupAllChildrensTransforms(leftengineactual, "hitbox_engine");
            engineLeftHitboxCollider = engineLeftHitbox.GetComponent<CapsuleCollider>();
            engineLeftHitbox.position = f16EngineCollider.position;
            engineLeftHitbox.rotation = f16EngineCollider.rotation;
            engineLeftHitboxCollider.radius = f16EngineColliderComponent.radius;
            engineLeftHitboxCollider.height = f16EngineColliderComponent.height;
            engineLeftHitboxCollider.enabled = false;


            engineRightHitbox = PickupAllChildrensTransforms(rightengineactual, "hitbox_engine");
            engineRightHitboxCollider = engineRightHitbox.GetComponent<CapsuleCollider>();
            engineRightHitboxCollider.enabled = false;

        }

        private void AutopilotPitch(int switchstate)
        {
            if (switchstate == 1)
            {
                AutoPilot2.AllOff();
                return;
            }
            else if (switchstate == 0)
            {
                AutoPilot2.ToggleAltitudeHold();
                    return;
            }
            else if (switchstate == 2)
            {
               
                return;
            }
        }

        private void AutopilotRoll(int switchstate)
        {
            if (f16rollaltholdintTK.currentState == 1) { return; }
            if (switchstate == 1)
            {
                return;
            }
            else if (switchstate == 0)
            {
                AutoPilot2.ToggleHeadingHold();
                return;
            }
            else if (switchstate == 2)
            {
                AutoPilot2.ToggleNav();
                return;
            }
        }

        private IEnumerator MPRadio()
        {
            F16Debug.Log("MP Radio Start");
            mpradiobutton2 = PickupAllChildrensTransforms(defaultf26, "2");
            mpradiobutton3 = PickupAllChildrensTransforms(defaultf26, "3");
            mpradiobutton4 = PickupAllChildrensTransforms(defaultf26, "4");
            mpradiobutton5 = PickupAllChildrensTransforms(defaultf26, "5");
            mpradiobutton6 = PickupAllChildrensTransforms(defaultf26, "6");
            mpradiobutton7 = PickupAllChildrensTransforms(defaultf26, "7");
            mpradiobutton8 = PickupAllChildrensTransforms(defaultf26, "8");
            mpradiobutton9 = PickupAllChildrensTransforms(defaultf26, "9");
            mpradiobutton0 = PickupAllChildrensTransforms(defaultf26, "0");
            mpradiobuttonClr = PickupAllChildrensTransforms(defaultf26, "Clr");
            mpradionewDisplay = PickupAllChildrensTransforms(defaultf26, "Display(Clone)");
            mpradionewDisplayall = PickupAllChildrensTransforms(mpradionewDisplay.gameObject, "Otherstuff");

            f16radioparent = PickupAllChildrensTransforms(newAircraftUnit, "radioparent");
            f16radiobutton1 = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16button1");

            f16radiobutton2 = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16button2");
            f16radiobutton3 = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16button3");
            f16radiobutton4 = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16button4");
            f16radiobutton5 = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16button5");
            f16radiobutton6 = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16button6");
            f16radiobutton7 = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16button7");
            f16radiobutton8 = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16button8");
            f16radiobutton9 = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16button9");
            f16radiobutton0 = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16button0");
            f16radiobuttonClr = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16buttonClr");
            f16radionewDisplay = PickupAllChildrensTransforms(f16radioparent.gameObject, "f16newDisplay");

            mpRadioButton1.position = f16radiobutton1.position;
            mpradiobutton2.position = f16radiobutton2.position;
            mpradiobutton3.position = f16radiobutton3.position;
            mpradiobutton4.position = f16radiobutton4.position;
            mpradiobutton5.position = f16radiobutton5.position;
            mpradiobutton6.position = f16radiobutton6.position;
            mpradiobutton7.position = f16radiobutton7.position;
            mpradiobutton8.position = f16radiobutton8.position;
            mpradiobutton9.position = f16radiobutton9.position;
            mpradiobutton0.position = f16radiobutton0.position;
            mpradiobuttonClr.position = f16radiobuttonClr.position;
            mpradionewDisplay.position = f16radionewDisplay.position;

            disableMesh(mpRadioButton1.gameObject);
            disableVTT(mpRadioButton1.gameObject);
            mpradiobutton1vr = mpRadioButton1.GetComponentInChildren<VRInteractable>();
            mpradiobutton1vr.poseBounds = HUDDashPoseBoundsF26.GetComponent<PoseBounds>();

            disableMesh(mpradiobutton2.gameObject);
            disableVTT(mpradiobutton2.gameObject);
            mpradiobutton2vr = mpradiobutton2.GetComponentInChildren<VRInteractable>();
            mpradiobutton2vr.poseBounds = HUDDashPoseBoundsF26.GetComponent<PoseBounds>();

            disableMesh(mpradiobutton3.gameObject);
            disableVTT(mpradiobutton3.gameObject);
            mpradiobutton3vr = mpradiobutton3.GetComponentInChildren<VRInteractable>();
            mpradiobutton3vr.poseBounds = HUDDashPoseBoundsF26.GetComponent<PoseBounds>();

            disableMesh(mpradiobutton4.gameObject);
            disableVTT(mpradiobutton4.gameObject);
            mpradiobutton4vr = mpradiobutton4.GetComponentInChildren<VRInteractable>();
            mpradiobutton4vr.poseBounds = HUDDashPoseBoundsF26.GetComponent<PoseBounds>();

            disableMesh(mpradiobutton5.gameObject);
            disableVTT(mpradiobutton5.gameObject);
            mpradiobutton5vr = mpradiobutton5.GetComponentInChildren<VRInteractable>();
            mpradiobutton5vr.poseBounds = HUDDashPoseBoundsF26.GetComponent<PoseBounds>();

            disableMesh(mpradiobutton6.gameObject);
            disableVTT(mpradiobutton6.gameObject);
            mpradiobutton6vr = mpradiobutton6.GetComponentInChildren<VRInteractable>();
            mpradiobutton6vr.poseBounds = HUDDashPoseBoundsF26.GetComponent<PoseBounds>();

            disableMesh(mpradiobutton7.gameObject);
            disableVTT(mpradiobutton7.gameObject);
            mpradiobutton7vr = mpradiobutton7.GetComponentInChildren<VRInteractable>();
            mpradiobutton7vr.poseBounds = HUDDashPoseBoundsF26.GetComponent<PoseBounds>();

            disableMesh(mpradiobutton8.gameObject);
            disableVTT(mpradiobutton8.gameObject);
            mpradiobutton8vr = mpradiobutton8.GetComponentInChildren<VRInteractable>();
            mpradiobutton8vr.poseBounds = HUDDashPoseBoundsF26.GetComponent<PoseBounds>();

            disableMesh(mpradiobutton9.gameObject);
            disableVTT(mpradiobutton9.gameObject);
            mpradiobutton9vr = mpradiobutton9.GetComponentInChildren<VRInteractable>();
            mpradiobutton9vr.poseBounds = HUDDashPoseBoundsF26.GetComponent<PoseBounds>();

            disableMesh(mpradiobutton0.gameObject);
            disableVTT(mpradiobutton0.gameObject);
            mpradiobutton0vr = mpradiobutton0.GetComponentInChildren<VRInteractable>();
            mpradiobutton0vr.poseBounds = HUDDashPoseBoundsF26.GetComponent<PoseBounds>();

            disableMesh(mpradiobuttonClr.gameObject);
            disableVTT(mpradiobuttonClr.gameObject);
            mpradiobuttonclrvr = mpradiobuttonClr.GetComponentInChildren<VRInteractable>();
            mpradiobuttonclrvr.poseBounds = HUDDashPoseBoundsF26.GetComponent<PoseBounds>();

            disableMesh(mpradionewDisplay.gameObject);
            disableImages(mpradionewDisplay.gameObject);
            yield return null;
        }

        private void CockpitPanelHider()
        {
            F16Debug.Log("cph0 ");
            //fuel Dump panel
            fueldumppanel = f26LeftPanel.Find("panelEnd (3)");

            F16Debug.Log("cph1 : " + fueldumppanel.name);
            fueldumppanel1 = fueldumppanel.Find("panelEnd (1)");
            F16Debug.Log("cph2");
            fueldumppanel2 = fueldumppanel.Find("panelMidsection");
            F16Debug.Log("cph3");
            disableMesh(fueldumppanel.gameObject);
            disableVTT(fueldumppanel.gameObject);
            disableSprites(fueldumppanel.gameObject);
            F16Debug.Log("cph4");
            disableMesh(fueldumppanel1.gameObject);
            disableVTT(fueldumppanel1.gameObject);
            disableSprites(fueldumppanel1.gameObject);
            F16Debug.Log("cph5");
            disableMesh(fueldumppanel2.gameObject);
            disableVTT(fueldumppanel2.gameObject);
            disableSprites(fueldumppanel2.gameObject);
            
            // cmpanel
            cmpanel = f26LeftPanel.Find("Countermeasures");
            cmpanelparent = cmpanel.Find("panelEnd (1)");
            cmpanel1 = cmpanelparent.Find("panelEnd (1)");
            cmpanel2 = cmpanelparent.Find("panelMidsection");
            disableMesh(cmpanelparent.gameObject);
            disableVTT(cmpanelparent.gameObject);
            disableSprites(cmpanelparent.gameObject);

            F16Debug.Log("cph6");
            disableMesh(cmpanel1.gameObject);
            disableVTT(cmpanel1.gameObject);
            disableSprites(cmpanel1.gameObject);

            F16Debug.Log("cph7");
            disableMesh(cmpanel2.gameObject);
            disableVTT(cmpanel2.gameObject);
            disableSprites(cmpanel2.gameObject);

            // FlightAssistPanelpanel
            FlightAssistPanelpanel = f26LeftPanel.Find("FlightAssistPanel");
            FlightAssistPanelpanelparent = FlightAssistPanelpanel.Find("panelEnd (1)");
            FlightAssistPanelpanel1 = FlightAssistPanelpanelparent.Find("panelEnd (1)");
            FlightAssistPanelpanel2 = FlightAssistPanelpanelparent.Find("panelMidsection");
            FlighAssistLines1 = PickupAllChildrensTransforms(FlightAssistPanelpanel.gameObject, "lrRectangle (1)");
            FlightAssistLines2 = PickupAllChildrensTransforms(FlightAssistPanelpanel.gameObject, "lrRectangle (2)");
            FlightAssistLines3 = PickupAllChildrensTransforms(FlightAssistPanelpanel.gameObject, "lrRectangle (3)");
            FlightAssistPitchAssistSwitch = PickupAllChildrensTransforms(FlightAssistPanelpanel.gameObject, "PitchAssistSwitch");
            FlightAssistPitchAssistSwitchInt = PickupAllChildrensTransforms(FlightAssistPitchAssistSwitch.gameObject, "PitchSASInteractable");
            FlightAssistPitchAssistLever = FlightAssistPitchAssistSwitchInt.GetComponent<VRLever>();
            //FlightAssistPitchAssistLever.RemoteSetState(0);
            //FlightAssistPitchAssistLever.LockTo(0);



            //FlighAssistLines1.localScale = new Vector3(0f, 0f, 0f);
            //FlightAssistLines2.localScale = new Vector3(0f, 0f, 0f);
            //FlightAssistLines3.localScale = new Vector3(0f, 0f, 0f);
            FlighAssistLines1.gameObject.SetActive(false);
            FlightAssistLines2.gameObject.SetActive(false);
            FlightAssistLines3.gameObject.SetActive(false);

            disableMesh(FlightAssistPanelpanelparent.gameObject);
            disableVTT(FlightAssistPanelpanelparent.gameObject);
            disableSprites(FlightAssistPanelpanelparent.gameObject);

            F16Debug.Log("cph8");
            disableMesh(FlightAssistPanelpanel1.gameObject);
            disableVTT(FlightAssistPanelpanel1.gameObject);
            disableSprites(FlightAssistPanelpanel1.gameObject);

            F16Debug.Log("cph9");
            disableMesh(FlightAssistPanelpanel2.gameObject);
            disableVTT(FlightAssistPanelpanel2.gameObject);
            disableSprites(FlightAssistPanelpanel2.gameObject);

            //masterCaution switch
            f16mastercautionswitch = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "masterCautionSwitch");
            f26MasterCaution = PickupAllChildrensTransforms(HUDDashF26.gameObject, "MasterCaution");
            f26MasterCaution.position = f16mastercautionswitch.position;
            f26MasterCaution.rotation = f16mastercautionswitch.rotation;
            f26mastercautionswitchint = PickupAllChildrensTransforms(f26MasterCaution.gameObject, "MasterCautionInteractable");
            f26MasterCautionI = f26mastercautionswitchint.GetComponent<VRInteractable>();
            f26MasterCautionI.poseBounds = throttlef26IVR.poseBounds;


            // Fuelportswitchpanel
            f16refuelport = PickupAllChildrensTransforms(newAircraftUnit.gameObject, "F16FuelPort");
            f26refuelport = PickupAllChildrensTransforms(defaultf26, "refuelTransform");
            f26refuelport.position = f16refuelport.position;

            f16fuelportswitch = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "airrefuelswitch_normalswitch");
            FuelPortSwitchlpanel = f26LeftPanel.Find("FuelPortSwitch");
            FuelPortSwitchlpanelswitch = PickupAllChildrensTransforms(FuelPortSwitchlpanel.gameObject, "radioSwitch");
            f16fuelportswitchlever = PickupAllChildrensTransforms(f16fuelportswitch.gameObject, "radioSwitch");
            FuelPortSwitchpanelparent = FuelPortSwitchlpanel.Find("panelEnd (1)");
            FuelPortSwitchpanel1 = FuelPortSwitchpanelparent.Find("panelEnd (1)");
            FuelPortSwitchpanel2 = FuelPortSwitchpanelparent.Find("panelMidsection");
            FuelPortSwitchpanelswitchbase = PickupAllChildrensTransforms(FuelPortSwitchlpanel.gameObject, "m_radioSwitchBase");
            FuelPortSwitchlpanelswitch.gameObject.SetActive(false);
            FuelPortOCLabel = PickupAllChildrensTransforms(FuelPortSwitchlpanel.gameObject, "fuelPortOpenCloseLabel");
            FuelPortSwitchLabel = PickupAllChildrensTransforms(FuelPortSwitchlpanel.gameObject, "fuelPortSwitchLabel");
            //FuelPortOCLabelVTT = FuelPortOCLabel.GetComponent<VTText>();
            //FuelPortOCLabelVTT.enabled = false;
            disableMesh(FuelPortOCLabel.gameObject);
            disableMesh(FuelPortSwitchLabel.gameObject);
            //FuelPortOCLabel.localScale = new Vector3(0f, 0f, 0f);
            //FuelPortSwitchLabel.localScale = new Vector3(0f, 0f, 0f);
            FuelPortOCLabel.gameObject.SetActive(false);
            FuelPortSwitchLabel.gameObject.SetActive(false);
            FuelPortSwitchLever = PickupAllChildrensTransforms(f16fuelportswitch.gameObject, "radioSwitchInteractable");
            FuelPortSwitchLeverIK = CreateSwitch("Fuel Port", FuelPortSwitchLever.gameObject, f16fuelportswitchlever, 30f,2,0, null,false, false);
            FuelPortSwitchLeverIK.OnSetState.AddListener(port.SetOpenState);

            disableMesh(FuelPortSwitchpanelparent.gameObject);
            disableVTT(FuelPortSwitchpanelparent.gameObject);
            disableSprites(FuelPortSwitchpanelparent.gameObject);
            F16Debug.Log("cph10");
            disableMesh(FuelPortSwitchpanel1.gameObject);
            disableVTT(FuelPortSwitchpanel1.gameObject);
            disableSprites(FuelPortSwitchpanel1.gameObject);
            F16Debug.Log("cph11");
            disableMesh(FuelPortSwitchpanel2.gameObject);
            disableVTT(FuelPortSwitchpanel2.gameObject);
            disableSprites(FuelPortSwitchpanel2.gameObject);
            disableVTT(FuelPortSwitchlpanel.gameObject);
            disableMesh(FuelPortSwitchpanelswitchbase.gameObject);

            // RadioDashpanel
            RadioDashpanel = f26LeftPanel.Find("RadioDash");
            RadioDashpanelparent = RadioDashpanel.Find("panelEnd (1)");
            RadioDashpanel1 = RadioDashpanelparent.Find("panelEnd (1)");
            RadioDashpanel2 = RadioDashpanelparent.Find("panelMidsection");
            disableMesh(RadioDashpanelparent.gameObject);
            disableVTT(RadioDashpanelparent.gameObject);
            disableSprites(RadioDashpanelparent.gameObject);

            F16Debug.Log("cph12");
            disableMesh(RadioDashpanel1.gameObject);
            disableVTT(RadioDashpanel1.gameObject);
            disableSprites(RadioDashpanel1.gameObject);

            F16Debug.Log("cph13");
            disableMesh(RadioDashpanel2.gameObject);
            disableVTT(RadioDashpanel2.gameObject);
            disableSprites(RadioDashpanel2.gameObject);

            // Basicpanel1panel
            Basicpanel1panel = f26LeftPanel.Find("panelEnd (1)");
            
            Basicpanel1panel1 = Basicpanel1panel.Find("panelEnd (1)");
            Basicpanel1panel2 = Basicpanel1panel.Find("panelMidsection");
            disableMesh(Basicpanel1panel.gameObject);
            disableVTT(Basicpanel1panel.gameObject);
            disableSprites(Basicpanel1panel.gameObject);
            F16Debug.Log("cph14");
            disableMesh(Basicpanel1panel1.gameObject);
            disableVTT(Basicpanel1panel1.gameObject);
            disableSprites(Basicpanel1panel1.gameObject);
            F16Debug.Log("cph15");
            disableMesh(Basicpanel1panel2.gameObject);
            disableVTT(Basicpanel1panel2.gameObject);
            disableSprites(Basicpanel1panel2.gameObject);

            // Basicpanel3panel
            Basicpanel3panel = f26LeftPanel.Find("panelEnd (3)");
            
            Basicpanel3panel1 = Basicpanel3panel.Find("panelEnd (1)");
            Basicpanel3panel2 = Basicpanel3panel.Find("panelMidsection");
            disableMesh(Basicpanel3panel2.gameObject);
            F16Debug.Log("cph16");
            disableMesh(Basicpanel3panel.gameObject);
            F16Debug.Log("cph17");
            disableMesh(Basicpanel3panel1.gameObject);

            // Basicpanel4panel
            Basicpanel4panel = f26LeftPanel.Find("panelEnd (4)");

            Basicpanel4panel1 = Basicpanel4panel.Find("panelEnd (1)");
            Basicpanel4panel2 = Basicpanel4panel.Find("panelMidsection");
            disableMesh(Basicpanel4panel2.gameObject);
            F16Debug.Log("cph18");
            disableMesh(Basicpanel4panel.gameObject);
            F16Debug.Log("cph19");
            disableMesh(Basicpanel4panel1.gameObject);


            //RIGHT PANELS
            //blank panel
            Basicpanel4panelR = f26RightPanel.Find("panelEnd (4)");

            Basicpanel4panelR1 = Basicpanel4panelR.Find("panelEnd (1)");
            Basicpanel4panelR2 = Basicpanel4panelR.Find("panelMidsection");
            disableMesh(Basicpanel4panelR2.gameObject);
            F16Debug.Log("cph20");
            disableMesh(Basicpanel4panelR.gameObject);
            F16Debug.Log("cph21");
            disableMesh(Basicpanel4panelR1.gameObject);

            //brakeandwing panel
            Basicpanel3panelR = f26RightPanel.Find("panelEnd (3)");

            Basicpanel3panelR1 = Basicpanel3panelR.Find("panelEnd (1)");
            Basicpanel3panelR2 = Basicpanel3panelR.Find("panelMidsection");
            disableMesh(Basicpanel3panelR2.gameObject);
            F16Debug.Log("cph22");
            disableMesh(Basicpanel3panelR.gameObject);
            F16Debug.Log("cph23");
            disableMesh(Basicpanel3panelR1.gameObject);

            //commspanel
            Basicpanel2panelR = f26RightPanel.Find("panelEnd (2)");

            Basicpanel2panelR1 = Basicpanel2panelR.Find("panelEnd (1)");
            Basicpanel2panelR2 = Basicpanel2panelR.Find("panelMidsection");
            disableMesh(Basicpanel2panelR2.gameObject);
            F16Debug.Log("cph24");
            disableMesh(Basicpanel2panelR.gameObject);
            F16Debug.Log("cph25");
            disableMesh(Basicpanel2panelR1.gameObject);

            //RFD
            Basicpanel4panelRF = f26RightFwdPanel.Find("panelEnd (4)");

            Basicpanel4panelRF1 = Basicpanel4panelRF.Find("panelEnd (1)");
            Basicpanel4panelRF2 = Basicpanel4panelRF.Find("panelMidsection");
            disableMesh(Basicpanel4panelRF2.gameObject);
            F16Debug.Log("cph26");
            disableMesh(Basicpanel4panelRF.gameObject);
            F16Debug.Log("cph27");
            disableMesh(Basicpanel4panelRF1.gameObject);

            Basicpanel3panelRF = f26RightFwdPanel.Find("panelEnd (3)");

            Basicpanel3panelRF1 = Basicpanel3panelRF.Find("panelEnd (1)");

            Basicpanel3panelRF2 = Basicpanel3panelRF.Find("panelMidsection");
            disableMesh(Basicpanel3panelRF2.gameObject);
            F16Debug.Log("cph28");
            disableMesh(Basicpanel3panelRF.gameObject);
            F16Debug.Log("cph29");
            disableMesh(Basicpanel3panelRF1.gameObject);


            //LFD
            Basicpanel4panelLF = f26LeftFwdPanel.Find("panelEnd (3)");

            Basicpanel4panelLF1 = Basicpanel4panelLF.Find("panelEnd (1)");
            Basicpanel4panelLF2 = Basicpanel4panelLF.Find("panelMidsection");
            disableMesh(Basicpanel4panelLF2.gameObject);
            F16Debug.Log("cph28");
            disableMesh(Basicpanel4panelLF.gameObject);
            F16Debug.Log("cph29");
            disableMesh(Basicpanel4panelLF1.gameObject);

            


            //throttlef26IG.lockTransform = f26throttleintt;

           
            disableMesh(CanopyLeverObject.gameObject);
            disableVTT(CanopyLeverObject.gameObject);
            enableMesh(CanopyLeverObjectswitchlever.gameObject);

            //Change Main Dash

            MiniMFDRight = PickupAllChildrensTransforms(f26mainDash.gameObject, "MiniMFDRight");
            MiniMFDRightFT = PickupAllChildrensTransforms(MiniMFDRight.gameObject, "FuelText");
            MiniMFDRightIT = PickupAllChildrensTransforms(MiniMFDRight.gameObject, "InfoText");
            MiniMFDRightFDB = PickupAllChildrensTransforms(MiniMFDRight.gameObject, "fuelDrainButton");
            MiniMFDRightPower = PickupAllChildrensTransforms(MiniMFDRight.gameObject, "powButtonMMFDRight");
            MiniMFDRightPowerVRI = MiniMFDRightPower.GetComponent<VRInteractable>();
                        MiniMFDRightFDBVRI = MiniMFDRightFDB.GetComponent<VRInteractable>();
            MiniMFDRightPowerVRI.poseBounds = null;
            MiniMFDRightFDBVRI.poseBounds = null;

            MiniMFDLeft = PickupAllChildrensTransforms(f26mainDash.gameObject, "MiniMFDLeft");
            MiniMFDLeftFDPage = PickupAllChildrensTransforms(MiniMFDLeft.gameObject, "FuelDrainPage");
            MiniMFDLeftFDPageComp = MiniMFDLeftFDPage.GetComponent<MMFDFuelDrainPage>();
            


            MFD MiniMFDRightMFD = MiniMFDRight.GetComponent<MFD>();





            MiniMFDRight.gameObject.SetActiveRecursively(false);
            disableMesh(MiniMFDRight.gameObject);
            disableSprites(MiniMFDRight.gameObject);
            disableImages(MiniMFDRight.gameObject);
            disableVTT(MiniMFDRightFT.gameObject);
            disableVTT(MiniMFDRightIT.gameObject);
            disableVTT(MiniMFDRight.gameObject);

            AfterburnerIndicator = PickupAllChildrensTransforms(f26mainDash.gameObject, "AfterburnerIndicator");
            disableMesh(AfterburnerIndicator.gameObject);
            //AfterburnerIndicator.localScale = new Vector3(0f, 0f, 0f);
            AfterburnerIndicator.gameObject.SetActive(false);
            disableImages(AfterburnerIndicator.gameObject);

            MissileIndicator = PickupAllChildrensTransforms(f26mainDash.gameObject, "MissileIndicator");
            disableMesh(MissileIndicator.gameObject);
            disableImages(MissileIndicator.gameObject);

            //MissileIndicator.localScale = new Vector3(0f, 0f, 0f);

            LaunchIndicator = PickupAllChildrensTransforms(f26mainDash.gameObject, "LaunchIndicator");
            disableMesh(LaunchIndicator.gameObject);
            disableImages(LaunchIndicator.gameObject);

            //LaunchIndicator.localScale = new Vector3(0f, 0f, 0f);


        }
        private void MovingActiveSwitches()
        {
            //get cockpit elements
            //f16
            //f26
            DashCanvast = defaultF26Transform.Find("DashCanvas");
            f26mainDash = PickupAllChildrensTransforms(DashCanvast.gameObject, "Dash");
            APAltNum = PickupAllChildrensTransforms(f26mainDash.gameObject, "apAltNum");
            APAltNum.gameObject.SetActive(true);
            disableText(APAltNum.gameObject);
            APAltNum.gameObject.SetActive(false);
            APSpeedAdjusterInt = PickupAllChildrensTransforms(f26mainDash.gameObject, "APSpeedAdjustInteractable");
            APSpeedAdjusterIntVR = APSpeedAdjusterInt.GetComponent<VRInteractable>();
            APSpeedAdjusterIntVR.poseBounds = null;


            f26RWR = PickupAllChildrensTransforms(f26mainDash.gameObject, "MiniMFDLeft");
            f26FuelFlowGauge = PickupAllChildrensTransforms(f26mainDash.gameObject, "FuelFlowGauge");
            f26MFDLeft = PickupAllChildrensTransforms(f26mainDash.gameObject, "MFD1");
            f26MFDRight = PickupAllChildrensTransforms(f26mainDash.gameObject, "MFD2");
            

            f26masterArmSwitch = PickupAllChildrensTransforms(f26mainDash.gameObject, "MasterArmSwitch");
            f26coverSwitchBase2 = PickupAllChildrensTransforms(f26masterArmSwitch.gameObject, "coverSwitchBase2");
            f26radioSwitchBase = PickupAllChildrensTransforms(f26coverSwitchBase2.gameObject, "radioSwitchBase");
            f26masterarmswitchParent = PickupAllChildrensTransforms(f26radioSwitchBase.gameObject, "switchParent");
            f26masterarmradioswitch = PickupAllChildrensTransforms(f26masterarmswitchParent.gameObject, "radioSwitch");
            f26masterarmradioswitchI = PickupAllChildrensTransforms(f26masterarmradioswitch.gameObject, "masterArmSwitchInteractable");
            f26masterarmcoverswitch = PickupAllChildrensTransforms(f26coverSwitchBase2.gameObject, "coverSwitchParent");
            f26masterarmcoverswitch2 = PickupAllChildrensTransforms(f26coverSwitchBase2.gameObject, "coverSwitch2");
            f26masterarmcoverswitch2cover = PickupAllChildrensTransforms(f26coverSwitchBase2.gameObject, "coverSwitchInteractable_masterArm");
            f26masterarmcoverswitch2coverlever = f26masterarmcoverswitch2cover.GetComponent<VRLever>();
            f26masterarmcoverswitch2coverlever.LockTo(0);
            //f26masterarmradioswitch.gameObject.AddComponent<VRLever>();


            f26masterarmradioswitchmeshfilter = f26masterarmradioswitch.GetComponent<MeshFilter>();
            f26masterarmradioswitchmesh = f26masterarmradioswitchmeshfilter.mesh;
            disableMesh(f26masterArmSwitch.gameObject);
            disableVTT(f26masterArmSwitch.gameObject);
            disableSprites(f26masterArmSwitch.gameObject);
            enableMesh(f26masterarmradioswitch.gameObject);
            f26masterArmSwitchlines = PickupAllChildrensTransforms(f26masterArmSwitch.gameObject, "lrRectangle");
            //f26masterArmSwitchlines.localScale = new Vector3(0f,0f,0f);
            f26masterArmSwitchlines.gameObject.SetActive(false);
            aoaindexer = PickupAllChildrensTransforms(newAircraftUnit.gameObject, "aoaIndexer");
            aoaRedLight = PickupAllChildrensTransforms(aoaindexer.gameObject, "aoaRedLight");
            aoaGreenLight = PickupAllChildrensTransforms(aoaindexer.gameObject, "aoaGreenLight");
            aoaYellowLight = PickupAllChildrensTransforms(aoaindexer.gameObject, "aoaYellowLight");
            aoaRedLight_lights = aoaRedLight.GetComponentsInChildren(typeof(Light));
            aoaGreenLight_lights = aoaGreenLight.GetComponentsInChildren(typeof(Light));
            aoaYellowLight_lights = aoaYellowLight.GetComponentsInChildren(typeof(Light));

            //Throttle
            Afighter2t = defaultF26Transform.Find("aFighter2");
            ThrottleTrack = Afighter2t.Find("throttleTrack");
            disableMesh(ThrottleTrack.gameObject);
            ThrottleParent = Afighter2t.Find("ThrottleParent");
            disableMesh(ThrottleParent.gameObject);
            f16throttlepivot = PickupAllChildrensTransforms(F16Cockpit.gameObject, "Throttlepivot");
            F16Debug.Log("f16 throttle angle : " + f16throttlepivot.localEulerAngles.x);

            f16throttle = PickupAllChildrensTransforms(f16throttlepivot.gameObject, "throttle");
            f16throttletf = PickupAllChildrensTransforms(f16throttle.gameObject, "throttletff16");
            ThrottleParent.position = f16throttletf.position;
            ThrottleTrack.position = f16throttletf.position;
            f26throttleintt = PickupAllChildrensTransforms(ThrottleParent.gameObject, "throttleInteractable");
            throttlef26I = f26throttleintt.GetComponent<VRThrottle>();
            throttlef26I.transform.position = f16throttletf.position;
            //throttlef26I.maxOffset = 0.5f;
            throttlef26IG = f26throttleintt.GetComponent<VRIntGlovePoser>();
            throttlef26IG.lockTransform = f16throttletf;
            throttlef26I.OnSetThrottle.AddListener(ThrottleAnimatorSet);
            throttlef26IVR = throttlef26I.GetComponent<VRInteractable>();
            

            //CanopySwitch
            f16canopyswitchtransform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "cockpitswitch");
            CanopyLeverObjectbase = PickupAllChildrensTransforms(CanopyLeverObject.gameObject, "flapsLeverBase");
            CanopyLeverObjectswitch = PickupAllChildrensTransforms(CanopyLeverObjectbase.gameObject, "switchParent");
            CanopyLeverObjectswitch.transform.position = f16canopyswitchtransform.position;
            CanopyLeverObjectswitch.transform.rotation = f16canopyswitchtransform.rotation;
            
            
            
            CanopyLeverObjectswitchlever = PickupAllChildrensTransforms(CanopyLeverObjectswitch.gameObject, "flapLever");
            CanopyLeverObjectswitchleverI = PickupAllChildrensTransforms(CanopyLeverObjectswitch.gameObject, "CanopyInteractable");
            CanopyLeverObjectswitchleverI.transform.position = f16canopyswitchtransform.position;
            CanopyLeverObjectswitchlevermesh = CanopyLeverObjectswitchlever.GetComponent<MeshFilter>();
            CanopyLeverObjectswitchlevermesh.mesh = f26masterarmradioswitchmesh;
            CanopyLeverObjectswitchleverIVR = CanopyLeverObjectswitchleverI.GetComponent<VRInteractable>();
            CanopyLeverObjectswitchleverIVR.poseBounds = throttlef26IVR.poseBounds;
            noneposebounds = null;



            f26helmetpanel = PickupAllChildrensTransforms(defaultF26Transform.gameObject, "helmPanel");
            f26RWRModeSwitch = PickupAllChildrensTransforms(f26mainDash.gameObject, "RWRModeSwitch");
            f26ILSHSI = PickupAllChildrensTransforms(f26mainDash.gameObject, "ILS/HSI");
            f26SpeedGauge = PickupAllChildrensTransforms(f26mainDash.gameObject, "SpeedGauge");
            f26AltGauge = PickupAllChildrensTransforms(f26mainDash.gameObject, "AltitudeGauge");
            f26AttSphere = PickupAllChildrensTransforms(f26mainDash.gameObject, "AttSphereParent");
            f26AttitudeIndicatorCircle = PickupAllChildrensTransforms(f26AttSphere.gameObject, "Sphere (2)");
            disableMesh(f26AttitudeIndicatorCircle.gameObject);
            f26AttitudeIndi = PickupAllChildrensTransforms(f26mainDash.gameObject, "AttitudeIndicator");
            f26vsi = PickupAllChildrensTransforms(f26mainDash.gameObject, "VerticalSpeedIndicator");
            f26RadarPwrSwitch = PickupAllChildrensTransforms(f26mainDash.gameObject, "RadarPwrSwitch");
            HUDDashF26 = PickupAllChildrensTransforms(defaultf26, "HUDDash");
            HUDDashLocationF16 = PickupAllChildrensTransforms(newAircraftUnit, "HUDDashTransform");
            f26parkingbrakeswitchmain = PickupAllChildrensTransforms(defaultf26, "BrakeLockSwitch");
            f26parkingbrakeswitchbase = PickupAllChildrensTransforms(f26parkingbrakeswitchmain.gameObject, "switchBase (1)");
            f26parkingswitch = PickupAllChildrensTransforms(f26parkingbrakeswitchmain.gameObject, "switchParent");
            f26parkingswitchlever = PickupAllChildrensTransforms(f26parkingswitch.gameObject, "switch");
            f26parkingswitchlevermesh = f26parkingswitchlever.GetComponent<MeshFilter>();
            f26parkingswitchlevermesh.mesh = f26masterarmradioswitchmesh;
            disableMesh(f26parkingbrakeswitchmain.gameObject);
            enableMesh(f26parkingswitchlever.gameObject);
            disableVTT(f26parkingbrakeswitchmain.gameObject);
            disableSprites(f26parkingbrakeswitchmain.gameObject);

            f26leftenginestartswitchmain = PickupAllChildrensTransforms(defaultf26, "LeftEngineSwitch");
            f26rightenginestartswitchmain = PickupAllChildrensTransforms(defaultf26, "RightEngineSwitch");
            f26leftengineew = PickupAllChildrensTransforms(f26leftenginestartswitchmain.gameObject, "EWIndicator_Left");
            f26leftenginestartswitchbase = PickupAllChildrensTransforms(f26leftenginestartswitchmain.gameObject, "radioSwitchBase");
            f26leftenginestartswitch = PickupAllChildrensTransforms(f26leftenginestartswitchbase.gameObject, "switchParent");
            f26leftenginestartswitchlever = PickupAllChildrensTransforms(f26leftenginestartswitch.gameObject, "radioSwitch");
            f26leftenginestartswitchmaincover = PickupAllChildrensTransforms(f26leftenginestartswitchmain.gameObject, "coverSwitchBase2");
            f26leftenginestartswitchmaincoverparent = PickupAllChildrensTransforms(f26leftenginestartswitchmaincover.gameObject, "coverSwitchParent");
            f26leftenginestartswitchbasemount = PickupAllChildrensTransforms(f26leftenginestartswitchmain.gameObject, "m_switchBase");
            f26leftenginestartswitchlabel = PickupAllChildrensTransforms(f26leftenginestartswitchmain.gameObject, "engine1Label");
            f26leftenginestartswitchon = PickupAllChildrensTransforms(f26leftenginestartswitchmain.gameObject, "On");
            f26leftenginestartswitchoff = PickupAllChildrensTransforms(f26leftenginestartswitchmain.gameObject, "off");

            f26leftenginestartswitchmaincoverparentcoverSwitch2 = PickupAllChildrensTransforms(f26leftenginestartswitchmaincoverparent.gameObject, "coverSwitch2");
            f26leftenginestartswitchmaincoverparentcoverSwitch2I = PickupAllChildrensTransforms(f26leftenginestartswitchmaincoverparentcoverSwitch2.gameObject, "coverSwitchInteractable_leftEngine");
            f26leftenginestartswitchmaincoverparentcoverSwitch2Ilever = f26leftenginestartswitchmaincoverparentcoverSwitch2I.GetComponent<VRLever>();
            f26leftenginestartswitchmaincoverparentcoverSwitch2Ilever.LockTo(0);
            F16Debug.Log("leftenginecover : " + f26leftenginestartswitchmaincoverparentcoverSwitch2Ilever.currentState);

            //f26leftenginestartswitchlabel.localScale = new Vector3(0f, 0f, 0f);
            //f26leftenginestartswitchon.localScale = new Vector3(0f, 0f, 0f);
            //f26leftenginestartswitchoff.localScale = new Vector3(0f, 0f, 0f);

            HUDTK = PickupAllChildrensTransforms(HUDDashF26.gameObject, "HUDTintKnob");
            HUDAMI = PickupAllChildrensTransforms(HUDDashF26.gameObject, "AltitudeModeInteractable");
            ClrWptButton = PickupAllChildrensTransforms(HUDDashF26.gameObject, "ClrWptButton");
            HUDHeading = PickupAllChildrensTransforms(HUDDashF26.gameObject, "Heading");
            HUDAltitude = PickupAllChildrensTransforms(HUDDashF26.gameObject, "Altitude");
            HUDSpd = PickupAllChildrensTransforms(HUDDashF26.gameObject, "Speed");
            HUDAPOFF = PickupAllChildrensTransforms(HUDDashF26.gameObject, "APOff");
            HUDNav = PickupAllChildrensTransforms(HUDDashF26.gameObject, "Nav");
            HUDHMCSP = PickupAllChildrensTransforms(HUDDashF26.gameObject, "HMCSPower");
            HUDBRK = PickupAllChildrensTransforms(HUDDashF26.gameObject, "HUDBrightKnob");
            HUDDCK = PickupAllChildrensTransforms(HUDDashF26.gameObject, "DeclutterKnob");
            HUDMFDBK = PickupAllChildrensTransforms(HUDDashF26.gameObject, "MFDBrightnessKnob");
            HUDMFDSB = PickupAllChildrensTransforms(HUDDashF26.gameObject, "MFDSwapButton");

            HUDTK.gameObject.SetActive(false);
            HUDAMI.gameObject.SetActive(false);
            ClrWptButton.gameObject.SetActive(true);
            HUDHeading.gameObject.SetActive(false);
            HUDAltitude.gameObject.SetActive(false);
            HUDSpd.gameObject.SetActive(false);
            HUDAPOFF.gameObject.SetActive(false);
            HUDNav.gameObject.SetActive(false);
            HUDHMCSP.gameObject.SetActive(false);
            HUDBRK.gameObject.SetActive(false);
            HUDDCK.gameObject.SetActive(false);
            HUDMFDBK.gameObject.SetActive(false);
            HUDMFDSB.gameObject.SetActive(false);
            disableMesh(ClrWptButton.gameObject);
            disableVTT(ClrWptButton.gameObject);
            disableLineRender(ClrWptButton.gameObject);



            f26leftenginestartswitchlabel.gameObject.SetActive(false);
            f26leftenginestartswitchon.gameObject.SetActive(false);
            f26leftenginestartswitchoff.gameObject.SetActive(false);

            disableMesh(f26leftenginestartswitchbasemount.gameObject);
            disableMesh(f26leftenginestartswitchlabel.gameObject);
            disableVTT(f26leftenginestartswitchlabel.gameObject);
            disableMesh(f26leftenginestartswitchmaincover.gameObject);
            disableVTT(f26leftenginestartswitchmaincover.gameObject);
            disableVTT(f26leftenginestartswitchmain.gameObject);
            disableVTT(f26rightenginestartswitchmain.gameObject);

            disableMesh(f26leftenginestartswitchbase.gameObject);
            disableVTT(f26leftenginestartswitchbase.gameObject);
            disableMesh(f26leftengineew.gameObject);
            disableVTT(f26leftengineew.gameObject);


            enableMesh(f26leftenginestartswitchlever.gameObject);

            //disable helmet panel

            disableMesh(f26helmetpanel.gameObject);
            disableSprites(f26helmetpanel.gameObject);
            disableVTT(f26helmetpanel.gameObject);

            // Disable Mp3


            


            f16cockpitswitch_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "f16cockpitswitch");
            f16masterarmswitch_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "masterArm_normalswitch");

            f16extlightingmaster_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "extlightingmaster_normalswitch");
            extlightingflash_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "extlightingflash_normalswitch");
            extlightinganticollision_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "extlightinganticollision_normalswitch");
            extlightingwingtail_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "extlightingwingtail_normalswitch");
            extlightingfuselage_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "extlightingfuselage_normalswitch");
            jetfuelstart_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "jetfuelstart_normalswitch");
            CMDSchaff_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "CMDSchaff_normalswitch");
            CMDSflare_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "CMDSflare_normalswitch");
            RWRonoff_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "RWRonoff_normalswitch");
            parkingbrake_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "parkingbrake_normalswitch");
            MFDLeft_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "MFDLeft");

            MFDRight_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "MFDRight");
            RWRMFD_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "RWRMFD");
            FuelFlowMeter_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "FuelFlowMeter");
            SpeedIndicator_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "SpeedIndicator");
            AltitudeIndicator_transform = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "AltitudeIndicator");
            VSI_Indicator_trans = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "VSI_Indicator_trans");
            Attitude_Indicator_trans = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "Attitude_Indicator_trans");
            Compass_Indicator_trans = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "Compass_Indicator_trans");
            SeatAdjustertrans = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "SeatAdjuster");
            f16SeatAdjuster = PickupAllChildrensTransforms(SeatAdjustertrans.gameObject, "seatAdjust_trans");



            //move position
            F26Posebounds = PickupAllChildrensTransforms(defaultf26, "PoseBounds");
            RightDashPoseBoundsF26 = PickupAllChildrensTransforms(F26Posebounds.gameObject, "RightDashPoseBounds");
            RightDashPoseBoundsF26.position = MFDRight_transform.position;
            LeftDashPoseBoundsF26 = PickupAllChildrensTransforms(F26Posebounds.gameObject, "LeftDashPoseBounds");
            MasterArmPoseBoundsF26 = PickupAllChildrensTransforms(F26Posebounds.gameObject, "MasterArmPoseBounds");
            LeftDashPoseBoundsF26.position = MFDLeft_transform.position;
            RightFWDDashPoseBoundsF26 = PickupAllChildrensTransforms(F26Posebounds.gameObject, "RightFwdPoseBounds");
            RightFWDDashPoseBoundsF16 = PickupAllChildrensTransforms(newAircraftUnit, "ConsoleRAux_posebounds");
            RightFWDDashPoseBoundsF26.position = RightFWDDashPoseBoundsF16.position;
            RightFWDDashPoseBoundsF26.localScale = new Vector3(2f, 2f, 1f);
            LeftFWDDashPoseBoundsF26 = PickupAllChildrensTransforms(F26Posebounds.gameObject, "LeftFwdPoseBounds");
            
            LeftFWDDashPoseBoundsF26.position = LeftFWDDashPoseBoundsF16.position;
            LeftFWDDashPoseBoundsF26.localScale = new Vector3(2f, 2f, 2.5f);
            ConsoleLeftDashposeboundsF16 = PickupAllChildrensTransforms(newAircraftUnit, "ConsoleLeftDashposebounds");

            HUDDashF26.position = HUDDashLocationF16.position;
            HUDDashPoseBoundsF26 = PickupAllChildrensTransforms(defaultf26, "HudDashPoseBounds");
            HUDDashPoseBoundsF26.position = HUDDashLocationF16.position;


            f26parkingswitch.position = parkingbrake_transform.position;
            f26parkingswitch.localEulerAngles = new Vector3(135f, 0f, 0f);
            f26parkingswitchI = PickupAllChildrensTransforms(f26parkingswitch.gameObject, "BrakeLockInteractable");
            f26parkingswitchIVR = f26parkingswitchI.GetComponent<VRInteractable>();
            f26parkingswitchIVR.poseBounds = LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>();

            //seatadjuster
            f26seatadjuster = PickupAllChildrensTransforms(f26mainDash.gameObject, "acesSeatAdjuster");
            f26seatadjuster.position = SeatAdjustertrans.position;
            f26seatupi = PickupAllChildrensTransforms(f26seatadjuster.gameObject, "raiseSeatInter");
            f26seatdowni = PickupAllChildrensTransforms(f26seatadjuster.gameObject, "lowerSeatInter");
            f26seatadjustposebounds = PickupAllChildrensTransforms(F26Posebounds.gameObject, "SeatAdjustPoseBounds");
            f26seatadjustposebounds.position = f16SeatAdjuster.position;


            //master arm

            MasterArmPoseBoundsF26.position = ConsoleLeftDashposeboundsF16.position;
            f26masterarmradioswitch.position = f16masterarmswitch_transform.position;
            f26masterarmradioswitch.localEulerAngles = new Vector3(0f, 0f, 0f);



            F16Debug.Log("Switchmoves _1");
            f26LeftPanelPoseBounds = PickupAllChildrensTransforms(F26Posebounds.gameObject, "LeftPanelPoseBounds");
            f26LeftPanelPoseBoundsComp = f26LeftPanelPoseBounds.GetComponent<PoseBounds>();
            f26LeftPanel = PickupAllChildrensTransforms(defaultf26, "LeftDash");

            f16posebounds = PickupAllChildrensTransforms(F16Cockpit.gameObject, "Posebounds");
            LeftDashPoseBoundsf16 = PickupAllChildrensTransforms(f16posebounds.gameObject, "ConsoleLeftDashposebounds");
            RightDashPoseBoundsf16 = PickupAllChildrensTransforms(f16posebounds.gameObject, "ConsoleR_posebound");

            F16Debug.Log("Switchmoves _4");
            f16leftpanelposebound = PickupAllChildrensTransforms(newAircraftUnit, "ConsoleL_posebound");
            F16Debug.Log("Switchmoves _5");
            F16Debug.Log("f26 left panel position = " + f26LeftPanelPoseBounds.position.x + "," + f26LeftPanelPoseBounds.position.y + "," + f26LeftPanelPoseBounds.position.z);
            F16Debug.Log("f16 left panel position = " + f16leftpanelposebound.position.x + "," + f16leftpanelposebound.position.y + "," + f16leftpanelposebound.position.z);

            //f26LeftPanel.position = f16leftpanelposebound.position;
            f26LeftPanelPoseBounds.position = f16leftpanelposebound.position;
            f26LeftPanelPoseBounds.localScale = new Vector3(2.3f, 2.1f, 2f);



            f26leftenginestartswitchbase.position = jetfuelstart_transform.position;
            f26leftenginestartswitchbase.localEulerAngles = new Vector3(135f, 0f, 0f);
            f26leftenginestartswitchbaseI = PickupAllChildrensTransforms(f26leftenginestartswitchlever.gameObject, "leftEngineSwitchInteractable");
            f26leftenginestartswitchbaseIVR = f26leftenginestartswitchbaseI.GetComponent<VRInteractable>();
            f26leftenginestartswitchbaseIVR.poseBounds = f26LeftPanelPoseBoundsComp;
            f26leftenginestartswitchbaseLever = f26leftenginestartswitchbaseI.GetComponent<VRLever>();
            f26leftenginestartswitchbaseLever.OnSetState.AddListener(JetSwitchCheckState);


            disableImages(f26leftenginestartswitchmain.gameObject);
            disableImages(f26rightenginestartswitchmain.gameObject);
            disableVTT(f26leftenginestartswitchmain.gameObject);
            disableVTT(f26rightenginestartswitchmain.gameObject);

            //radio mp3
            f26LeftPanelRadio = PickupAllChildrensTransforms(f26LeftPanel.gameObject, "RadioDash");
            f26LeftPanelRadioLines = PickupAllChildrensTransforms(f26LeftPanelRadio.gameObject, "lrRectangle (1)");
            disableVTT(f26LeftPanelRadio.gameObject);
            disableSprites(f26LeftPanelRadio.gameObject);
            disableMesh(f26LeftPanelRadio.gameObject);
            //f26LeftPanelRadioLines.localScale = new Vector3(0f, 0f, 0f);
            f26LeftPanelRadioLines.gameObject.SetActive(false);

            //fueldump
            f26LeftPanelFDS = PickupAllChildrensTransforms(f26LeftPanel.gameObject, "FuelDumpSwitch");
            f26fdslines = PickupAllChildrensTransforms(f26LeftPanelFDS.gameObject, "lrRectangle");
            disableVTT(f26LeftPanelFDS.gameObject);
            disableMesh(f26LeftPanelFDS.gameObject);
            //f26fdslines.localScale = new Vector3(0f,0f,0f);
            f26fdslines.gameObject.SetActive(false);

            //fap
            f26LeftPanelFAP = PickupAllChildrensTransforms(f26LeftPanel.gameObject, "FlightAssistPanel");
            disableVTT(f26LeftPanelFAP.gameObject);
            disableMesh(f26LeftPanelFAP.gameObject);


            //AP AltControls

            f26APAltPanel = PickupAllChildrensTransforms(DashCanvast.gameObject, "APAltControls");
            f26APAltPanelBack = f26mainDash.Find("panelEnd (3)");
            f26APAltPanelBack2 = PickupAllChildrensTransforms(f26APAltPanelBack.gameObject, "panelEnd (1)");
            f26APAltPanelBack3 = PickupAllChildrensTransforms(f26APAltPanelBack.gameObject, "panelMidsection");
            f26APAltPanelShadow = PickupAllChildrensTransforms(f26APAltPanel.gameObject, "circleShadow");
            f26APAltPanelBack.gameObject.SetActive(false);
            f26APAltPanelBack2.gameObject.SetActive(false);
            f26APAltPanelBack3.gameObject.SetActive(false);


            disableVTT(f26APAltPanel.gameObject);
            disableMesh(f26APAltPanel.gameObject);
            disableSprites(f26APAltPanel.gameObject);
            disableMesh(f26APAltPanelBack.gameObject);
            disableMesh(f26APAltPanelBack2.gameObject);
            disableMesh(f26APAltPanelBack3.gameObject);
            disableImages(f26APAltPanelShadow.gameObject);

            //endpanelabovevsi

            vsicoverpanel = PickupAllChildrensTransforms(f26mainDash.gameObject, "panelEnd (4)");
            disableVTT(vsicoverpanel.gameObject);
            disableMesh(vsicoverpanel.gameObject);
            disableSprites(vsicoverpanel.gameObject);

            //radar power panel
            disableVTT(f26RadarPwrSwitch.gameObject);
            disableMesh(f26RadarPwrSwitch.gameObject);
            disableSprites(f26RadarPwrSwitch.gameObject);
            f26RadarPwrSwitchLines1 = PickupAllChildrensTransforms(f26RadarPwrSwitch.gameObject, "lrRectangle");
            f26RadarPwrSwitchLines2 = PickupAllChildrensTransforms(f26RadarPwrSwitch.gameObject, "lrRectangle (1)");
            f26RadarPwrSwitchLinesCS = PickupAllChildrensTransforms(f26RadarPwrSwitch.gameObject, "circleShadow");

            f26RadarPwrSwitchLines1.gameObject.SetActive(false);
            f26RadarPwrSwitchLines2.gameObject.SetActive(false);
            f26RadarPwrSwitchLinesCS.gameObject.SetActive(false);

            //rwrmodeswitch
            disableVTT(f26RWRModeSwitch.gameObject);
            disableMesh(f26RWRModeSwitch.gameObject);
            disableSprites(f26RWRModeSwitch.gameObject);
            f26RWRModeSwitchLines1 = PickupAllChildrensTransforms(f26RWRModeSwitch.gameObject, "lrRectangle");
            f26RWRModeSwitchLines2 = PickupAllChildrensTransforms(f26RWRModeSwitch.gameObject, "lrRectangle (1)");
            f26RWRModeSwitchLinesCS = PickupAllChildrensTransforms(f26RWRModeSwitch.gameObject, "circleShadow");

            f26RWRModeSwitchLines1.gameObject.SetActive(false);
            f26RWRModeSwitchLines2.gameObject.SetActive(false);
            f26RWRModeSwitchLinesCS.gameObject.SetActive(false);

            //rwrmfd

            f26RWR.position = RWRMFD_transform.position;
            f26RWR.localEulerAngles = new Vector3(-194.52f, 0f, 0f);
            f26FuelFlowGauge.position = FuelFlowMeter_transform.position;
            f26FuelFlowGauge.localEulerAngles = new Vector3(-159f, 175f, 180f);
            f26MFDLeft.position = MFDLeft_transform.position;
            f26MFDLeft.localEulerAngles = new Vector3(-194.52f, 0f, 180f);
            f26MFDRight.position = MFDRight_transform.position;
            f26MFDRight.localEulerAngles = new Vector3(-194.52f, 0f, 180f);


            f26RWR.localScale = new Vector3(0.7f, 0.7f, 1f);

            f26MFDLeft.localScale = new Vector3(65f, 65f, 75f);
            f26MFDRight.localScale = new Vector3(65f, 65f, 75f);

            //instruments

            f16SpeedIndicator = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "SpeedIndicator");
            f16AltitudeIndicator = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "AltitudeIndicator");
            f16VSIIndicator = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "VSI_Indicator_trans");
            f16AttitudeIndicator = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "Attitude_Indicator_trans");
            f16CompassIndicator = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "Compass_Indicator_trans");
            f16CMSChaff = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "CMDSchaff_normalswitch");
            f16CMSFlare = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "CMDSflare_normalswitch");
            f16AttitudeIndicatorSphere = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "Attitude_Sphere_trans");


           f26SpeedIndicator = PickupAllChildrensTransforms(f26mainDash.gameObject, "SpeedGauge");
            f26AltitudeIndicator = PickupAllChildrensTransforms(f26mainDash.gameObject, "AltitudeGauge");
            f26VSIIndicator = PickupAllChildrensTransforms(f26mainDash.gameObject, "VerticalSpeedIndicator");
            f26AttitudeIndicator = PickupAllChildrensTransforms(f26mainDash.gameObject, "AttitudeIndicator");
           
            f26CompassIndicator = PickupAllChildrensTransforms(f26mainDash.gameObject, "ILS/HSI");
            f26CMSChaff = PickupAllChildrensTransforms(f26LeftPanel.gameObject, "ChaffSwitch");
            f26CMSChaffSwitchLever = PickupAllChildrensTransforms(f26CMSChaff.gameObject, "switchParent");

            f26CMSFlare = PickupAllChildrensTransforms(f26LeftPanel.gameObject, "FlareSwitch");
            f26CMSFlareSwitchLever = PickupAllChildrensTransforms(f26CMSFlare.gameObject, "switchParent");
            F16Debug.Log("Chaff Flare 1");
            f26cmsparent = PickupAllChildrensTransforms(f26LeftPanel.gameObject, "Countermeasures");
            f26CMSChaffBase = PickupAllChildrensTransforms(f26CMSChaff.gameObject, "m_radioSwitchBase");
            f26CMSFlareBase = PickupAllChildrensTransforms(f26CMSFlare.gameObject, "m_radioSwitchBase");
            f26CMSChaffI = PickupAllChildrensTransforms(f26CMSChaff.gameObject, "ChaffInteractable");
            f26CMSFlareI = PickupAllChildrensTransforms(f26CMSFlare.gameObject, "FlareInteractable");
            f26CMSChaffInteractable = f26CMSChaffI.GetComponent<VRInteractable>();
            f26CMSFlareInteractable = f26CMSFlareI.GetComponent<VRInteractable>();
            f26CMSChaffInteractable.poseBounds = LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>();
            f26CMSFlareInteractable.poseBounds = LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>();

            f26CMSChaffOn = PickupAllChildrensTransforms(f26CMSChaff.gameObject, "chaffOnLabel");
            f26CMSChaffOff = PickupAllChildrensTransforms(f26CMSChaff.gameObject, "off");
            f26CMSFlareOn = PickupAllChildrensTransforms(f26CMSFlare.gameObject, "flareOnLabel");
            f26CMSFlareOff = PickupAllChildrensTransforms(f26CMSFlare.gameObject, "off");
            f26CMSChaffIndic = PickupAllChildrensTransforms(f26CMSChaff.gameObject, "CMIndicator (1)");
            f26CMSFlareIndic = PickupAllChildrensTransforms(f26CMSFlare.gameObject, "CMIndicator");
            f16ChaffInidicator = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "ChaffIndicator");
            f16FlareInidicator = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "FlareIndicator");
            f26CMSChaffIndicText = PickupAllChildrensTransforms(f26CMSChaffIndic.gameObject, "ChaffCountText");
            f26CMSFlareIndicText = PickupAllChildrensTransforms(f26CMSFlareIndic.gameObject, "FlareCountText");
            f26CMSChaffIndicTextVTT = f26CMSChaffIndicText.GetComponent<Text>();
            f26CMSFlareIndicTextVTT = f26CMSFlareIndicText.GetComponent<Text>();

            f26CMSChaffIndicTextVTT.fontSize = 60;
            f26CMSFlareIndicTextVTT.fontSize = 60;

            f26CMSChaffIndic.position = f16ChaffInidicator.position;
            f26CMSFlareIndic.position = f16FlareInidicator.position;
            f26CMSChaffIndic.rotation = f16ChaffInidicator.rotation;
            f26CMSFlareIndic.rotation = f16FlareInidicator.rotation;
            F16Debug.Log("Chaff Flare 2");
            disableMesh(f26cmsparent.gameObject);
            enableMesh(f26CMSFlare.gameObject);
            enableMesh(f26CMSChaff.gameObject);
            disableMesh(f26CMSChaffIndic.gameObject);
            disableMesh(f26CMSFlareIndic.gameObject);
            F16Debug.Log("Chaff Flare 3");
            disableVTT(f26cmsparent.gameObject);

            disableMesh(f26CMSChaffBase.gameObject);
            disableMesh(f26CMSFlareBase.gameObject);
            disableVTT(f26CMSChaffOn.gameObject);
            disableVTT(f26CMSChaffOff.gameObject);
            disableVTT(f26CMSFlareOn.gameObject);
            disableVTT(f26CMSFlareOff.gameObject);
            disableImages(f26CMSChaffIndic.gameObject);
            disableImages(f26CMSFlareIndic.gameObject);
            //f26CMSChaffOn.localScale = new Vector3(0f, 0f, 0f);
            //f26CMSChaffOff.localScale = new Vector3(0f, 0f, 0f);
            //f26CMSFlareOn.localScale = new Vector3(0f, 0f, 0f);
            //f26CMSFlareOff.localScale = new Vector3(0f, 0f, 0f);
            f26CMSChaffOn.gameObject.SetActiveRecursively(false);
            f26CMSChaffOff.gameObject.SetActiveRecursively(false);
            f26CMSFlareOn.gameObject.SetActiveRecursively(false);
            f26CMSFlareOff.gameObject.SetActiveRecursively(false);

            f26CMSChaffSwitchLever.position = f16CMSChaff.position;
            f26CMSChaffSwitchLever.rotation = f16CMSChaff.rotation;
            f26CMSFlareSwitchLever.rotation = f16CMSFlare.rotation;
            f26CMSFlareSwitchLever.position = f16CMSFlare.position;


            f26SpeedIndicator.position = f16SpeedIndicator.position;


            F16Debug.Log("IM1");

            f26AltitudeIndicator.position = f16AltitudeIndicator.position;
            f26VSIIndicator.position = f16VSIIndicator.position;
            F16Debug.Log("IM2");
            f26AttitudeIndicator.position = f16AttitudeIndicator.position;
            f26CompassIndicator.position = f16CompassIndicator.position;
            F16Debug.Log("IM3");
            //f26CMSChaffIndic.localPosition = new Vector3(0f, 0.1f, 0.0359f);
            //f26CMSFlareIndic.localPosition = new Vector3(0f, 0.1f, 0.0359f);


            f26AttSphere.position = f16AttitudeIndicatorSphere.position;
            f26AttSphere.rotation = f16AttitudeIndicatorSphere.rotation;
            f16SecondaryAttIndicatorTrans = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "SecondaryAttIndicator");
            f26SecondaryAttIndicator = Instantiate(f26AttSphere.gameObject, f16SecondaryAttIndicatorTrans);
            f26SecondaryAttIndicator.transform.localScale = new Vector3(0.025f,0.025f,0.025f);
            f26SecondaryAttIndicator.transform.localPosition = new Vector3(0f, 0f, 0f);
            f26SecondaryAttIndicator.transform.rotation = f16SecondaryAttIndicatorTrans.rotation;

            F16Debug.Log("IM4");
            f26SpeedIndicator.rotation = f16SpeedIndicator.rotation;
            f26AltitudeIndicator.rotation = f16AltitudeIndicator.rotation;
            F16Debug.Log("IM5");
            f26VSIIndicator.rotation = f16VSIIndicator.rotation;
            f26AttitudeIndicator.rotation = f16AttitudeIndicator.rotation;
            f26CompassIndicator.rotation = f16CompassIndicator.rotation;
            F16Debug.Log("IM51");
            f26CMSChaffSwitchLever.rotation = f16CMSChaff.rotation;
            f26CMSFlareSwitchLever.rotation = f16CMSFlare.rotation;
            F16Debug.Log("IM");

            

            //joystick
            F16Debug.Log("Joystick");

            f16controlstick = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "cont_stick");
            f26sidestickobjects = PickupAllChildrensTransforms(defaultf26.gameObject, "SideStickObjects");
            f26controlstick = PickupAllChildrensTransforms(f26sidestickobjects.gameObject, "joyYaw.001");
            f26controlstickparent = PickupAllChildrensTransforms(f26sidestickobjects.gameObject, "joyParent");

            F16Debug.Log("Joystick1");

            f26controlstickmesh = f26controlstick.GetComponent<MeshFilter>();
            if (f26controlstickmesh == null)
            {
                F16Debug.Log("f26csmes = null");
            }
            F16Debug.Log("Joystick2");

            f16controlstickmesh = f16controlstick.GetComponent<MeshFilter>();
            if (f16controlstickmesh == null)
            {
                F16Debug.Log("f16csmes = null");
            }

            F16Debug.Log("Joystick3");


            f26controlstickmeshitem = f26controlstickmesh.mesh;
            F16Debug.Log("Joystick4");

            f16controlstickmeshitem = f16controlstickmesh.sharedMesh;
            f26controlstickmesh.sharedMesh = f16controlstickmeshitem;

            f16controlstickmeshr = f16controlstick.GetComponent<MeshRenderer>();
            f26controlstickmeshr = f26controlstick.GetComponent<MeshRenderer>();
            f26controlstickmeshr.sharedMaterials = f16controlstickmeshr.sharedMaterials;

            f26controlstick.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            f26controlstick.localEulerAngles = new Vector3(105f, 0f, 90f);
            disableMesh(f16controlstick.gameObject);
            if (f16controlstickmeshitem == null)
            {
                F16Debug.Log("f16csmeshi = null");
            }
            if (f26controlstickmeshitem == null)
            {
                F16Debug.Log("f26csmeshi = null");
            }


            f26controlstickparent.position = f16controlstick.position;
            disableMesh(f26sidestickobjects.gameObject);
            enableMesh(f26controlstick.gameObject);

            f26controlint = PickupAllChildrensTransforms(f26controlstickparent.gameObject, "joyInteractable");
            f16contstickint = PickupAllChildrensTransforms(f16controlstick.gameObject, "constick_trans");
            f26controlint.position = f16contstickint.position;

            //instrument switches

            F16Debug.Log("Switchmoves _2");
            
            F16Debug.Log("Switchmoves _3");
            
            F26Posebounds = PickupAllChildrensTransforms(defaultf26, "PoseBounds");
            F16Debug.Log("Switchmoves _6");
            f26RightPanelPoseBounds = PickupAllChildrensTransforms(defaultf26, "RightPanelPoseBounds");
            f26RightPanelPoseBoundsComp = f26RightPanelPoseBounds.GetComponent<PoseBounds>();
            f26RightPanel = PickupAllChildrensTransforms(defaultf26, "RightDash");
            F16Debug.Log("Switchmoves _2");
            f16rightpanelposebound = PickupAllChildrensTransforms(newAircraftUnit, "ConsoleR_posebound");
            F16Debug.Log("Switchmoves _5");
            
            //f26LeftPanel.position = f16leftpanelposebound.position;
            f26RightPanelPoseBounds.position = f16rightpanelposebound.position;
            f26RightPanelPoseBounds.localScale = new Vector3(2.4f, 2.4f, 2f);
            f26RightPanelPoseBoundsComp.transform.localScale = new Vector3(2.4f, 2.9f, 2.1f);

            
            f26RightFwdPanel = PickupAllChildrensTransforms(defaultf26, "RightFwdDash");

            F16Debug.Log("after move f26 left panel position = " + f26LeftPanelPoseBounds.position.x + "," + f26LeftPanelPoseBounds.position.y + "," + f26LeftPanelPoseBounds.position.z);



            F16Debug.Log("Switchmoves _6");
            //Battery Switch
            MainBatterySwitchF26 = PickupAllChildrensTransforms(defaultf26, "MainBatterySwitch");
            MainBatterySwitchF26I = PickupAllChildrensTransforms(MainBatterySwitchF26.gameObject, "mainBattSwitchInteractable");
            MainBatterySwitchF26IVR = MainBatterySwitchF26I.GetComponent<VRInteractable>();
            MainBatterySwitchF26IVR.poseBounds = f26LeftPanelPoseBoundsComp;

            F16Debug.Log("Switchmoves _7");
            
            F16Debug.Log("Switchmoves _8");
            F16ElectricMainSwitch = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "elecmainpower_normalswitch");
            F16Debug.Log("Switchmoves _9");
            F26ElectricMainSwitchLever = PickupAllChildrensTransforms(MainBatterySwitchF26.gameObject, "radioSwitch");
            F26ElectricMainSwitchParent = PickupAllChildrensTransforms(MainBatterySwitchF26.gameObject, "switchParent");
            disableMesh(MainBatterySwitchF26.gameObject);
            disableVTT(MainBatterySwitchF26.gameObject);
            enableMesh(F26ElectricMainSwitchLever.gameObject);


            F16Debug.Log("Switchmoves _10");
            F26ElectricMainSwitchParent.position = F16ElectricMainSwitch.position;
            F26ElectricMainSwitchParent.localEulerAngles = new Vector3(30f, 0f, 0f);
            // Check State of main power so it switches on the APU straight after
            BatteryLever = F26ElectricMainSwitchLever.GetComponentInChildren<VRLever>();
            BatteryLeverCheck = BatteryLever.currentState;

            F16Debug.Log("Batt Switch State = " + BatteryLeverCheck);
            APUPart = PickupAllChildrensTransforms(defaultf26, "apu");
            APUauxunit = APUPart.GetComponent<AuxilliaryPowerUnit>();
            

            BatteryLever.OnSetState.AddListener(BattSwitchCheckState);

            //hide the rectangles
            f26hudTintKnob = PickupAllChildrensTransforms(HUDDashF26.gameObject, "HUDTintKnob");
            f26hudBrightKnob = PickupAllChildrensTransforms(HUDDashF26.gameObject, "HUDBrightKnob");
            f26HMCSPower = PickupAllChildrensTransforms(HUDDashF26.gameObject, "HMCSPower");
            f26HUDPower = PickupAllChildrensTransforms(HUDDashF26.gameObject, "HUDPower");
            f26DeclutterKnob = PickupAllChildrensTransforms(HUDDashF26.gameObject, "DeclutterKnob");
            f26lightspanel = PickupAllChildrensTransforms(f26LeftPanel.gameObject, "LightsPanel");

            f26commspanel = PickupAllChildrensTransforms(f26RightPanel.gameObject, "CommsPanel");


            lines1 = PickupAllChildrensTransforms(f26RightFwdPanel.gameObject, "lrRectangle");
            lines2 = PickupAllChildrensTransforms(lines1.gameObject, "lrRectangle (1)");
            lines3 = f26RightFwdPanel.Find("lrRectangle (1)");
            lines4 = PickupAllChildrensTransforms(f26RightFwdPanel.gameObject, "lrRectangle (2)");
            lines5 = PickupAllChildrensTransforms(CanopyLeverObject, "lrRectangle (3)");
            lines6 = PickupAllChildrensTransforms(f26masterArmSwitch.gameObject, "lrRectangle");
            lines7 = PickupAllChildrensTransforms(f26hudTintKnob.gameObject, "lrRectangle");
            lines8 = PickupAllChildrensTransforms(f26commspanel.gameObject, "lrRectangle");
            lines9 = PickupAllChildrensTransforms(f26hudBrightKnob.gameObject, "lrRectangle");
            lines10 = PickupAllChildrensTransforms(HUDDashF26.gameObject, "lrRectangle");
            lines11 = PickupAllChildrensTransforms(f26HUDPower.gameObject, "lrRectangle");
            lines12 = PickupAllChildrensTransforms(f26HMCSPower.gameObject, "lrRectangle");
            lines13 = PickupAllChildrensTransforms(f26DeclutterKnob.gameObject, "lrRectangle");
            lines14 = PickupAllChildrensTransforms(f26commspanel.gameObject, "lrRectangle (1)");
            lines15 = PickupAllChildrensTransforms(HUDDashF26.gameObject, "lrRectangle (1)");
            lines16 = PickupAllChildrensTransforms(f26lightspanel.gameObject, "lrRectangle (1)");
            lines17 = PickupAllChildrensTransforms(f26commspanel.gameObject, "lrRectangle (2)");
            lines18 = PickupAllChildrensTransforms(HUDDashF26.gameObject, "lrRectangle (2)");
            lines19 = PickupAllChildrensTransforms(f26lightspanel.gameObject, "lrRectangle (2)");


            scaletozero = new Vector3(0f, 0f, 0f);
            lines1.gameObject.SetActive(false);
            lines2.gameObject.SetActive(false);
            F16Debug.Log("line2");

            lines3.gameObject.SetActive(false);
            F16Debug.Log("line3");

            lines4.gameObject.SetActive(false);
            F16Debug.Log("line4");

            lines5.gameObject.SetActive(false);
            F16Debug.Log("line5");

            lines6.gameObject.SetActive(false);
            F16Debug.Log("line6");

            lines7.gameObject.SetActive(false);
            F16Debug.Log("line7");

            lines8.gameObject.SetActive(false);
            F16Debug.Log("line8");

            lines9.gameObject.SetActive(false);
            F16Debug.Log("line9");

            lines10.gameObject.SetActive(false);
            F16Debug.Log("line10");

            lines11.gameObject.SetActive(false);
            F16Debug.Log("line11");

            lines12.gameObject.SetActive(false);
            F16Debug.Log("line12");

            lines13.gameObject.SetActive(false);
            F16Debug.Log("line13");

            lines14.gameObject.SetActive(false);
            F16Debug.Log("line14");
            if (lines15 != null)
            {
                lines15.gameObject.SetActive(false);
            }
                F16Debug.Log("line15");

            lines16.gameObject.SetActive(false);
            F16Debug.Log("line16");

            lines17.gameObject.SetActive(false);
            F16Debug.Log("line17");

            if (lines18 != null)
            {
                lines18.gameObject.SetActive(false);
            }
                F16Debug.Log("line18");

            if (lines19 != null)
            {
                lines19.gameObject.SetActive(false);
            }

            //hide other switch

            cathook = PickupAllChildrensTransforms(f26LeftFwdPanel.gameObject,"CatapultHookSwitch");
            landinghook = PickupAllChildrensTransforms(f26LeftFwdPanel.gameObject, "HookSwitch");
            
            f26landinggearpanel = PickupAllChildrensTransforms(f26LeftFwdPanel.gameObject, "GearSwitch");
            f26landinggearpanellights = PickupAllChildrensTransforms(f26landinggearpanel.gameObject, "StatusLights");
            

            f26flapslever = PickupAllChildrensTransforms(f26LeftFwdPanel.gameObject, "FlapsLever");
            f26CenterConsole = PickupAllChildrensTransforms(DashCanvast.gameObject, "CenterConsole");
            f26CenterConsolelines = PickupAllChildrensTransforms(f26CenterConsole.gameObject, "lrRectangle");
            f26jettisonAllHolder = PickupAllChildrensTransforms(f26CenterConsole.gameObject, "JettisonButton");
            f26JettisonAllButton = PickupAllChildrensTransforms(f26jettisonAllHolder.gameObject, "roundButtonBase");
            f16jettisonbutton = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "emerjettstores_button");


            disableMesh(cathook.gameObject);
            disableMesh(landinghook.gameObject);
            disableMesh(f26landinggearpanel.gameObject);
            disableMesh(f26flapslever.gameObject);
            disableMesh(f26CenterConsole.gameObject);
            disableMesh(f26landinggearpanellights.gameObject);
            disableImages(f26landinggearpanellights.gameObject);
            f26CenterConsolelines.gameObject.SetActive(false);

            disableVTT(cathook.gameObject);
            disableVTT(landinghook.gameObject);
            disableVTT(f26landinggearpanel.gameObject);
            disableVTT(f26flapslever.gameObject);
            disableVTT(f26CenterConsole.gameObject);
            disableVTT(f26JettisonAllButton.gameObject);
            disableSprites(f26landinggearpanel.gameObject);


            enableMesh(f26JettisonAllButton.gameObject);

            landinghookswitch = PickupAllChildrensTransforms(landinghook.gameObject, "switch");
            enableMesh(landinghookswitch.gameObject);
            f16landinghookt = PickupAllChildrensTransforms(leftauxpanelgobj, "landinghook_normalswitch");
            landinghookswitch.position = f16landinghookt.position;
            landinghookswitch.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            landinghookswitchmesh = landinghookswitch.GetComponent<MeshFilter>();
            landinghookswitchmesh.mesh = f26masterarmradioswitchmesh;


            f26JettisonAllButton.position = f16jettisonbutton.position;
            f26JettisonAllButton.rotation = f16jettisonbutton.rotation;
            f26jettisonallbuttonint = PickupAllChildrensTransforms(f26JettisonAllButton.gameObject, "MasterJettisonButtonInteractable");
            f26jettisonallbuttoni = f26jettisonallbuttonint.GetComponent<VRInteractable>();
            f26jettisonallbuttoni.poseBounds = null;

            f26jettisonAllCoverSwitchParent = PickupAllChildrensTransforms(f26jettisonAllHolder.gameObject, "coverSwitchBase2");
            f26JettisonAllCoverSwitch = PickupAllChildrensTransforms(f26jettisonAllCoverSwitchParent.gameObject, "coverSwitch2");
            f26JettisonAllCoverSwitchI = PickupAllChildrensTransforms(f26JettisonAllCoverSwitch.gameObject, "coverSwitchInteractable_jettisonButton");
            f26JettisonAllCoverSwitchILever = f26JettisonAllCoverSwitchI.GetComponent<VRLever>();
            f26JettisonAllCoverSwitchILever.LockTo(0);


            //light switches
            f26landinglights = PickupAllChildrensTransforms(f26lightspanel.gameObject, "LandingLightSwitch");
            f26landinglightslvr = PickupAllChildrensTransforms(f26landinglights.gameObject, "switchParent");

            extLightsLabels = PickupAllChildrensTransforms(f26lightspanel.gameObject, "extLightsLabels");
            extLabel = PickupAllChildrensTransforms(f26lightspanel.gameObject, "extLabel");
            f26landinglighti = PickupAllChildrensTransforms(f26landinglights.gameObject, "LandingLightInteractable");
            f16landinglightt = PickupAllChildrensTransforms(leftauxpanelgobj, "landingLight_switch");
            f26landinglightslvr.position = f16landinglightt.position;
            f26landinglighti.localEulerAngles = new Vector3(-75f,180f,-180f);
            f26landinglightiVR = f26landinglighti.GetComponent<VRInteractable>();
            f26landinglightiVRLever = f26landinglighti.GetComponent<VRLever>();
            f26landinglightiVRLever.OnSetState.AddListener(SwitchLandingLightsOn);




            f26landinglightiVR.poseBounds = LeftFWDDashPoseBoundsF26.GetComponent<PoseBounds>();
            disableMesh(f26landinglights.gameObject);

            f26strobelight = PickupAllChildrensTransforms(f26lightspanel.gameObject, "StrobeLightSwitch");
            f26strobelightParent = PickupAllChildrensTransforms(f26strobelight.gameObject, "switchParent");
            disableMesh(f26strobelightParent.gameObject);

            f16anticollisionlightt = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "extlightingflash_normalswitch");
            f26strobelightParent.position = f16anticollisionlightt.position;
            f26strobelightbase = PickupAllChildrensTransforms(f26strobelight.gameObject, "m_switchBase");
            disableMesh(f26strobelightbase.gameObject);

            f26navlight = PickupAllChildrensTransforms(f26lightspanel.gameObject, "NavLightSwitch");
            f26navlightParent = PickupAllChildrensTransforms(f26navlight.gameObject, "switchParent");
            f16navlightt = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "extlightinganticollision_normalswitch");
            f26navlightParent.position = f16navlightt.position;
            f26navlight.gameObject.SetActiveRecursively(false);

            f26instlight = PickupAllChildrensTransforms(f26lightspanel.gameObject, "InstLightSwitch");
            f26instlight.gameObject.SetActive(false);
            f16instlightswitch = PickupAllChildrensTransforms(rightPanelgObj, "internalinstlight_knob");
            f26instlightonlabel = PickupAllChildrensTransforms(f26instlight.gameObject, "on");
            f26instlightofflabel = PickupAllChildrensTransforms(f26instlight.gameObject, "off");
            f26instlightbase = PickupAllChildrensTransforms(f26instlight.gameObject, "m_radioSwitchBase");
            f26instlightswitch = PickupAllChildrensTransforms(f26instlight.gameObject, "radioSwitchBase");
            f26instlightswitchi = PickupAllChildrensTransforms(f26instlightswitch.gameObject, "InsturmentLightInteractable");
            f26instlightswitchivr = f26instlightswitchi.GetComponent<VRInteractable>();

            f26instlightswitchivr.poseBounds = f26RightPanelPoseBoundsComp;

            //f26instlightonlabel.localScale = new Vector3(0f, 0f, 0f);
            //f26instlightofflabel.localScale = new Vector3(0f, 0f, 0f);
            f26instlightonlabel.gameObject.SetActive(false);
            f26instlightofflabel.gameObject.SetActive(false);


            disableVTT(f26instlightonlabel.gameObject);
            disableVTT(f26instlightofflabel.gameObject);
            disableVTT(f26lightspanel.gameObject);
            disableMesh(f26instlightbase.gameObject);
            f26instlightswitch.position = f16instlightswitch.position;
            disableVTT(extLightsLabels.gameObject);
            //extLightsLabels.localScale = new Vector3(0f, 0f, 0f);
            extLightsLabels.gameObject.SetActive(false);
            disableVTT(extLabel.gameObject);
            //extLabel.localScale = new Vector3(0f, 0f, 0f);
            extLabel.gameObject.SetActive(false);

            f26interiorlight = PickupAllChildrensTransforms(f26lightspanel.gameObject, "InteriorLightSwitch");
            f26interiorlightlabel = PickupAllChildrensTransforms(f26lightspanel.gameObject, "lightsLabel");
            f26interiorlightoff = PickupAllChildrensTransforms(f26interiorlight.gameObject, "off");
            f26interiorlightbase = PickupAllChildrensTransforms(f26interiorlight.gameObject, "m_radioSwitchBase");
            f26interiorlightswitch = PickupAllChildrensTransforms(f26interiorlight.gameObject, "radioSwitchBase");
            f16interiorlightswitch = PickupAllChildrensTransforms(rightPanelgObj, "internalconsoleslight_knob");
            //f26interiorlightswitch.position = f16interiorlightswitch.position;
            
            f26interiorlightlab = PickupAllChildrensTransforms(f26interiorlight.gameObject, "interLightLabel");
            f26interiorlightswitchi = PickupAllChildrensTransforms(f26interiorlightswitch.gameObject, "InteriorLightInteractable");
            f26interiorlightswitchivr = f26interiorlightswitchi.GetComponent<VRInteractable>();
            f26interiorlightswitchivr.poseBounds = f26RightPanelPoseBoundsComp;
            f26interiorlightlab.gameObject.SetActive(false);
            f26interiorlightoff.gameObject.SetActive(false);
            f26interiorlightlabel.gameObject.SetActive(false);
            f26interiorlight.gameObject.SetActive(false);
            //f26interiorlightlab.localScale = new Vector3(0f, 0f, 0f);
            //f26interiorlightoff.localScale = new Vector3(0f, 0f, 0f);
            //f26interiorlightlabel.localScale = new Vector3(0f, 0f, 0f);


            disableMesh(f26interiorlightbase.gameObject);
            disableVTT(f26interiorlightoff.gameObject);
            disableVTT(f26interiorlightlab.gameObject);
            disableVTT(f26interiorlightlabel.gameObject);


            f26navlightbase = PickupAllChildrensTransforms(f26navlight.gameObject, "m_radioSwitchBase");
            f26brightknob = PickupAllChildrensTransforms(f26lightspanel.gameObject, "LabelBrightnessKnob");
            disableMesh(f26brightknob.gameObject);
            disableImages(f26brightknob.gameObject);
            disableText(f26brightknob.gameObject);
            disableVTT(f26brightknob.gameObject);
            disableVRI(f26brightknob.gameObject);

            F16Debug.Log("light_test1");
            f26brightknob.gameObject.SetActive(false);
            F16Debug.Log("light_test2");
            disableMesh(f26navlightbase.gameObject);
            F16Debug.Log("light_test3");
            disableVTT(f26lightspanel.gameObject);
            F16Debug.Log("light_test4");

            //radioswitches
            disableMesh(f26commspanel.gameObject);
            f26CommsVolumeKnob = PickupAllChildrensTransforms(f26commspanel.gameObject, "CommsVolumeKnob");
            f26CommsMicKnob = PickupAllChildrensTransforms(f26commspanel.gameObject, "MicKnob");
            //enableMesh(f26CommsVolumeKnob.gameObject);
            f26CommsMicKnobswitch = PickupAllChildrensTransforms(f26CommsMicKnob.gameObject, "knobParent");
            //enableMesh(f26CommsMicKnobswitch.gameObject);
                F16Debug.Log("radios1");
            f16commspowerswitch = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "audio1comm1_fulltwisty");
            f16audio1comm1parent = PickupAllChildrensTransforms(f16commspowerswitch.gameObject, "knobTF");
            f16audio1comm1int = PickupAllChildrensTransforms(f16commspowerswitch.gameObject, "rotatorknob4Interactable");
            f16audio1comm1intTK = CreateClickKnob("Audio 1 Comm 1", f16audio1comm1int.gameObject, 1, f16audio1comm1parent, 70f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, false);
            MFDCommsMenu = PickupAllChildrensTransforms(f26mainDash.gameObject, "MFDCommsMenu");
            MFDCommsMenuIK = MFDCommsMenu.GetComponent<MFDCommsPage>();

            f16audio1comm1intTK.OnSetState.AddListener(MFDCommsMenuIK.SetRecognition);

            f16commsuhfvolume = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "uhfvolume_smallfulltwisty");
            f26CommsVolumeKnob.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
            f26CommsMicKnobswitch.position = f16commspowerswitch.position;
            //f26CommsMicKnobswitch.rotation = f16commspowerswitch.rotation;
            f26CommsVolumeKnob.position = f16commsuhfvolume.position;
            f26CommsVolumeKnobIVR = f26CommsVolumeKnob.GetComponent<VRInteractable>();
            F16Debug.Log("radios2");
            //f26CommsVolumeKnobIVR.poseBounds = f26LeftPanelPoseBoundsComp;
            f26CommsMicKnobswitchI = PickupAllChildrensTransforms(f26CommsMicKnob.gameObject, "MicPowerInteractable");
            //f26CommsMicKnobswitchI.position = f16commspowerswitch.position;
            f26CommsMicKnobswitchIVR = f26CommsMicKnobswitchI.GetComponent<VRInteractable>();
            f26CommsMicKnobswitchIVR.poseBounds = f26LeftPanelPoseBoundsComp;

            //hud power
            F16Debug.Log("hudpower1");
            f26hudpower = PickupAllChildrensTransforms(HUDDashF26.gameObject, "HUDPower");
            f26hudpoweri = PickupAllChildrensTransforms(f26hudpower.gameObject, "hudPowerInteractable");
            f16hudpower = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "HUDPower_switch");
            f26hudpoweri.position = f16hudpower.position;
            f26hudpoweri.rotation = f16hudpower.rotation;

            disableMesh(f26hudpower.gameObject);
            disableVTT(f26hudpower.gameObject);

            f26hmcspower = PickupAllChildrensTransforms(HUDDashF26.gameObject, "HMCSPower");
            f26hmcspowerradioswitch = PickupAllChildrensTransforms(f26hmcspower.gameObject, "radioSwitch");
            f26hmcspowerint = PickupAllChildrensTransforms(f26hmcspower.gameObject, "hmcsPowerInteractable");
            F16Debug.Log("hmcs1");
            
            f16hmcspower = PickupAllChildrensTransforms(leftauxpanelgobj.gameObject, "HMCSDial");
            f16hmcspowerknobparent = PickupAllChildrensTransforms(f16hmcspower.gameObject, "knobTF");
            f16hmcspowerknobint = PickupAllChildrensTransforms(f16hmcspower.gameObject, "rotatorknob2Interactable");
            f26hmcspowerintTK = CreateClickKnob("HMCS Power", f16hmcspowerknobint.gameObject, 2, f16hmcspowerknobparent, 209f, 0, LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), true, true);
                        f26helmet = PickupAllChildrensTransforms(defaultf26, "hqh");
f26helmetcont = f26helmet.GetComponent<HelmetController>();
            f26hmcspowerintTK.OnSetState.AddListener(f26helmetcont.SetPower);

            f26hmcspowerradioswitch.position = f16hmcspower.position;
            //f26hmcspowerradioswitch.localScale = new Vector3(0f, 0f, 0f);
            f26hmcspowerradioswitch.gameObject.SetActive(false);
            //f26hmcspower.rotation = f16hmcspower.rotation;
            disableMesh(f26hmcspower.gameObject);
            disableVTT(f26hmcspower.gameObject);
            Destroy(f26hmcspowerint.GetComponent<VRInteractable>());



            

            disableVTT(f26hmcspower.gameObject);
            F16Debug.Log("radar1");
            f26RadarPwrSwitchKnob = PickupAllChildrensTransforms(f26RadarPwrSwitch.gameObject, "knobParent");
            f26RadarPwrSwitch.gameObject.SetActive(false);
            f16radarpowert = PickupAllChildrensTransforms(rightPanelgObj.gameObject, "avionicsinst");
            f26RadarPwrSwitchKnob.position = f16radarpowert.position;
            f26RadarPwrSwitchKnob.rotation = f16radarpowert.rotation;
            F16Debug.Log("radar2");
            f26RadarPwrSwitchi = PickupAllChildrensTransforms(f26RadarPwrSwitch.gameObject, "RadarPowerInteractable");
            f26RadarPwrSwitchi.position = f16radarpowert.position;
            f26RadarPwrSwitchi.rotation = f16radarpowert.rotation;
            f26RadarPwrSwitchiVR = f26RadarPwrSwitchi.GetComponent<VRInteractable>();
            f26RadarPwrSwitchiVR.poseBounds = f26RightPanelPoseBoundsComp;
            F16Debug.Log("radar3");

            //radar
            
            f16radarPowerSwitchParent = PickupAllChildrensTransforms(f16radarpowert.gameObject, "knobTF");
            f16radarPowerSwitchInteractable = PickupAllChildrensTransforms(f16radarpowert.gameObject, "rotatorknob10Interactable");
            f16radarPowerswitchivr = CreateClickKnob("Radar Power INS (X)", f16radarPowerSwitchInteractable.gameObject, 2, f16radarPowerSwitchParent, 120f, 0,f26RightPanelPoseBoundsComp , true, true);
            f16radarPowerswitchvri = f16radarPowerSwitchInteractable.GetComponent<VRInteractable>();

            

            //instruments Lights
            f16instrumentLightSwitch = PickupAllChildrensTransforms(rightPanelgObj.gameObject, "instbright");
            f16instrumentLightSwitchParent = PickupAllChildrensTransforms(f16instrumentLightSwitch.gameObject, "knobTF");
            f16instrumentLightSwitchInteractable = PickupAllChildrensTransforms(f16instrumentLightSwitch.gameObject, "rotatorknob4Interactable");
            f16instrumentLightSwitchivr = CreateClickKnob("Instrument Lights Switch", f16instrumentLightSwitchInteractable.gameObject, 2, f16instrumentLightSwitchParent, 120f, 0, f26RightPanelPoseBoundsComp, true, true);
            f16instrumentLightSwitchvri = f16radarPowerSwitchInteractable.GetComponent<VRInteractable>();
            f26labelLightPower = PickupAllChildrensTransforms(defaultf26, "LabelLightPower");
            f26labelLightPowerVTT = f26labelLightPower.GetComponent<VTTextIllumSwitcher>();

            f16instrumentLightSwitchivr.OnSetState.AddListener(InternalLightsCheckState);



            F16Debug.Log("rwr1");
            f16rwrmodeswitch = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "RWR_normalswitch");
            f16rwrmodeswitchParent = PickupAllChildrensTransforms(f16rwrmodeswitch.gameObject, "radioSwitch");
            radioSwitchInteractable = PickupAllChildrensTransforms(f16rwrmodeswitchParent.gameObject, "radioSwitchInteractable");
            

            newrwrmodeswitchivr = CreateSwitch("RWR Mode", radioSwitchInteractable.gameObject, f16rwrmodeswitch, 30f,3,0,LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), false, true);
            newrwrmodeswitchvri = radioSwitchInteractable.GetComponent<VRInteractable>();

            //ext light switch

            extstrobeswitch = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "extlightingflash_normalswitch");
            extstrobeswitchParent = PickupAllChildrensTransforms(extstrobeswitch.gameObject, "radioSwitch");
            extstrobeswitchInteractable = PickupAllChildrensTransforms(extstrobeswitchParent.gameObject, "radioSwitchInteractable");
            extstrobeswitchlr = CreateSwitch("Strobe Lights", extstrobeswitchInteractable.gameObject, extstrobeswitchParent, 40f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);
            extstrobeswitchvri = extstrobeswitchInteractable.GetComponent<VRInteractable>();
            
            strobeLightsP = PickupAllChildrensTransforms(f26lightspanel.gameObject, "StrobeLights");
            StrobeLightCont = strobeLightsP.GetComponent<StrobeLightController>();

            extstrobeswitchlr.OnSetState.AddListener(StrobeLightCont.SetStrobePower);

            extnaviswitch = PickupAllChildrensTransforms(F16CockpitActiveSwitches.gameObject, "extlightinganticollision_normalswitch");
            extnaviswitchParent = PickupAllChildrensTransforms(extnaviswitch.gameObject, "radioSwitch");
            extnaviswitchInteractable = PickupAllChildrensTransforms(extnaviswitchParent.gameObject, "radioSwitchInteractable");
            extnaviswitchlr = CreateSwitch("Navigation Lights", extnaviswitchInteractable.gameObject, extnaviswitchParent, 40f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);
            extnaviswitchvri = extnaviswitchInteractable.GetComponent<VRInteractable>();

            LeftnaviLightsP = PickupAllChildrensTransforms(f26lightspanel.gameObject, "LeftNavPower");
            LeftnaviLightCont = LeftnaviLightsP.GetComponent<ObjectPowerUnit>();
            RightnaviLightsP = PickupAllChildrensTransforms(f26lightspanel.gameObject, "RightNavPower");
            RightnaviLightCont = RightnaviLightsP.GetComponent<ObjectPowerUnit>();
            RearnaviLightsP = PickupAllChildrensTransforms(f26lightspanel.gameObject, "RearNavPower");
            RearnaviLightCont = RearnaviLightsP.GetComponent<ObjectPowerUnit>();
           


            extnaviswitchlr.OnSetState.AddListener(LeftnaviLightCont.SetConnection);
            extnaviswitchlr.OnSetState.AddListener(RightnaviLightCont.SetConnection);
            extnaviswitchlr.OnSetState.AddListener(RearnaviLightCont.SetConnection);
            extnaviswitchlr.OnSetState.AddListener(IntakeLights);


            //internal lamp

            InternalLampTrans = PickupAllChildrensTransforms(F16Cockpit.gameObject, "consR_lamp");
            InternalLampLightTrans = PickupAllChildrensTransforms(InternalLampTrans.gameObject, "LampLight");
            InternalLampLight = InternalLampLightTrans.GetComponent<Light>();

            InternalLampTransrenderermaterials = InternalLampTrans.GetComponent<MeshRenderer>().materials;
            foreach (Material materialitem in InternalLampTransrenderermaterials)
            {
                F16Debug.Log("Material Name = " + materialitem.name);
                if (materialitem.name == "l_refl (Instance)")
                {
                    InternalLamprenderermaterial = materialitem;

                }
            }

            f16LampDial = PickupAllChildrensTransforms(rightPanelgObj.gameObject, "internalconsoleslight_knob");
            f16LampDialparent = PickupAllChildrensTransforms(f16LampDial.gameObject, "knobTF");
            f16LampDialknobint = PickupAllChildrensTransforms(f16LampDial.gameObject, "rotatorknob4Interactable");
            f16LampDialintTK = CreateClickKnob("Flood Lamp", f16LampDialknobint.gameObject, 2, f16LampDialparent, 45f, 0, f26RightPanelPoseBoundsComp, true, true);

            f16LampDialintTK.OnSetState.AddListener(FloodLamp);


            f26RWR = PickupAllChildrensTransforms(defaultf26, "RWR");
            f26dashrwr = f26RWR.GetComponent<DashRWR>();


            F16Debug.Log("rwr3");

            
            
            newrwrmodeswitchvri.poseBounds = LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>();
            newrwrmodeswitchivr.OnSetState.AddListener(f26dashrwr.SetMasterMode);


           

            CanopyLightParent = PickupAllChildrensTransforms(newAircraftUnit, "CanopyLight");
            CanopyLights = CanopyLightParent.GetComponentsInChildren(typeof(Light));
            if (cl == 0)
            {
                foreach (Light lights in CanopyLights) { lights.enabled = false; }
                    }
            else
            {
                foreach (Light lights in CanopyLights) { lights.enabled = true; }
            }

            
        }

        private void EnableAllNonActiveSwitches()
        {
            //fake switches
            f16normalswitches = PickupAllChildrensTransforms(newAircraftUnit.gameObject, "Normalswitches");
            f16cmd01parent = PickupAllChildrensTransforms(f16normalswitches.gameObject, "cmds_01_normalswitch");
            f16cmd01parentmeshswitch = PickupAllChildrensTransforms(f16cmd01parent.gameObject, "radioSwitch");
            f16cmd01interactable = PickupAllChildrensTransforms(f16cmd01parentmeshswitch.gameObject, "radioSwitchInteractable");
                        f16cmd01interactablevrlever = CreateSwitch("CMD 01 Switch (X)", f16cmd01interactable.gameObject, f16cmd01parentmeshswitch, 35f, 2, 0, LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), false, true);

            f16cmd02xparent = PickupAllChildrensTransforms(f16normalswitches.gameObject, "cmds_02x_normalswitchBase");
            f16cmd02xparentmeshswitch = PickupAllChildrensTransforms(f16cmd02xparent.gameObject, "radioSwitch");
            f16cmd02xinteractable = PickupAllChildrensTransforms(f16cmd02xparentmeshswitch.gameObject, "radioSwitchInteractable");
                        f16cmd02xinteractablevrlever = CreateSwitch("CMD 02 Switch (X)", f16cmd02xinteractable.gameObject, f16cmd02xparentmeshswitch, 35f, 2, 0, LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), false, true);

            f16displayselect = PickupAllChildrensTransforms(f16normalswitches.gameObject, "Displayselect_normalswitch");
            f16displayselectmeshswitch = PickupAllChildrensTransforms(f16displayselect.gameObject, "radioSwitch");
            f16displayselectinteractable = PickupAllChildrensTransforms(f16displayselectmeshswitch.gameObject, "radioSwitchInteractable");
            f16displayselect2interactablevrlever = CreateSwitch("Display Select (X)", f16displayselectinteractable.gameObject, f16displayselectmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16ecmdim = PickupAllChildrensTransforms(f16normalswitches.gameObject, "ecmdim_normalswitch");
            f16ecmdimmeshswitch = PickupAllChildrensTransforms(f16ecmdim.gameObject, "radioSwitch");
            f16ecmdiminteractable = PickupAllChildrensTransforms(f16ecmdimmeshswitch.gameObject, "radioSwitchInteractable");
            f16ecmdiminteractablevrlever = CreateSwitch("ECM DIM (X)", f16ecmdiminteractable.gameObject, f16ecmdimmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16ecmopr = PickupAllChildrensTransforms(f16normalswitches.gameObject, "ecmopr_normalswitch");
            f16ecmoprmeshswitch = PickupAllChildrensTransforms(f16ecmopr.gameObject, "radioSwitch");
            f16ecmoprinteractable = PickupAllChildrensTransforms(f16ecmoprmeshswitch.gameObject, "radioSwitchInteractable");
            f16ecmoprinteractablevrlever = CreateSwitch("ECM OPR (X)", f16ecmoprinteractable.gameObject, f16ecmoprmeshswitch, 35f, 3, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);
            
            f16ecmxmit = PickupAllChildrensTransforms(f16normalswitches.gameObject, "ecmxmit_normalswitch");
            f16ecmxmitmeshswitch = PickupAllChildrensTransforms(f16ecmxmit.gameObject, "radioSwitch");
            f16ecmxmitinteractable = PickupAllChildrensTransforms(f16ecmxmitmeshswitch.gameObject, "radioSwitchInteractable");
            f16ecmxmitinteractablevrlever = CreateSwitch("ECM XMIT (X)", f16ecmxmitinteractable.gameObject, f16ecmxmitmeshswitch, 15f, 3, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16ecmbit = PickupAllChildrensTransforms(f16normalswitches.gameObject, "ecmbit_normalswitch");
            f16ecmbitmeshswitch = PickupAllChildrensTransforms(f16ecmbit.gameObject, "radioSwitch");
            f16ecmbitinteractable = PickupAllChildrensTransforms(f16ecmbitmeshswitch.gameObject, "radioSwitchInteractable");
            f16ecmbitinteractablevrlever = CreateSwitch("ECM BIT (X)", f16ecmbitinteractable.gameObject, f16ecmbitmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16audiomic = PickupAllChildrensTransforms(f16normalswitches.gameObject, "audiomic_normalswitch");
            f16audiomicmeshswitch = PickupAllChildrensTransforms(f16audiomic.gameObject, "radioSwitch");
            f16audiomicinteractable = PickupAllChildrensTransforms(f16audiomicmeshswitch.gameObject, "radioSwitchInteractable");
            f16audiomicinteractablevrlever = CreateSwitch("Audio Mic (X)", f16audiomicinteractable.gameObject, f16audiomicmeshswitch, 35f, 3, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16radiotone = PickupAllChildrensTransforms(f16normalswitches.gameObject, "radiotone_normalswitch");
            f16radiotonemeshswitch = PickupAllChildrensTransforms(f16radiotone.gameObject, "radioSwitch");
            f16radiotoneinteractable = PickupAllChildrensTransforms(f16radiotonemeshswitch.gameObject, "radioSwitchInteractable");
            f16radiotoneinteractablevrlever = CreateSwitch("Radio Tone (X)", f16radiotoneinteractable.gameObject, f16radiotonemeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16radiosquelch = PickupAllChildrensTransforms(f16normalswitches.gameObject, "radiosquelch_normalswitch");
            f16radiosquelchmeshswitch = PickupAllChildrensTransforms(f16radiosquelch.gameObject, "radioSwitch");
            f16radiosquelchinteractable = PickupAllChildrensTransforms(f16radiosquelchmeshswitch.gameObject, "radioSwitchInteractable");
            f16radiosquelchinteractablevrlever = CreateSwitch("Radio Squelch (X)", f16radiosquelchinteractable.gameObject, f16radiosquelchmeshswitch, 35f, 3, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16manualpitch = PickupAllChildrensTransforms(f16normalswitches.gameObject, "manualpitch_normalswitch");
            f16manualpitchmeshswitch = PickupAllChildrensTransforms(f16manualpitch.gameObject, "radioSwitch");
            f16manualpitchinteractable = PickupAllChildrensTransforms(f16manualpitchmeshswitch.gameObject, "radioSwitchInteractable");
            f16manualpitchinteractablevrlever = CreateSwitch("Manual Pitch (X)", f16manualpitchinteractable.gameObject, f16manualpitchmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16engcont = PickupAllChildrensTransforms(f16normalswitches.gameObject, "engcont_normalswitch");
            f16engcontmeshswitch = PickupAllChildrensTransforms(f16engcont.gameObject, "radioSwitch");
            f16engcontinteractable = PickupAllChildrensTransforms(f16engcontmeshswitch.gameObject, "radioSwitchInteractable");
            f16engcontinteractablevrlever = CreateSwitch("Engine Control (X)", f16engcontinteractable.gameObject, f16engcontmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16jetstartab = PickupAllChildrensTransforms(f16normalswitches.gameObject, "jetstartab_normalswitch");
            f16jetstartabmeshswitch = PickupAllChildrensTransforms(f16jetstartab.gameObject, "radioSwitch");
            f16jetstartabinteractable = PickupAllChildrensTransforms(f16jetstartabmeshswitch.gameObject, "radioSwitchInteractable");
            f16jetstartabinteractablevrlever = CreateSwitch("Jet AB (X)", f16jetstartabinteractable.gameObject, f16jetstartabmeshswitch, 45f, 3, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16epumain = PickupAllChildrensTransforms(f16normalswitches.gameObject, "epumain_normalswitch");
            f16epumainmeshswitch = PickupAllChildrensTransforms(f16epumain.gameObject, "radioSwitch");
            f16epumaininteractable = PickupAllChildrensTransforms(f16epumainmeshswitch.gameObject, "radioSwitchInteractable");
            f16epumaininteractablevrlever = CreateSwitch("EPU Main (X)", f16epumaininteractable.gameObject, f16epumainmeshswitch, 35f, 3, 1, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16maxpower = PickupAllChildrensTransforms(f16normalswitches.gameObject, "maxpower_normalswitch");
            f16maxpowermeshswitch = PickupAllChildrensTransforms(f16maxpower.gameObject, "radioSwitch");
            f16maxpowerinteractable = PickupAllChildrensTransforms(f16maxpowermeshswitch.gameObject, "radioSwitchInteractable");
            f16maxpowerinteractablevrlever = CreateSwitch("Max Power (X)", f16maxpowerinteractable.gameObject, f16maxpowermeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16fueltankinternal = PickupAllChildrensTransforms(f16normalswitches.gameObject, "fueltankinternal_normalswitch");
            f16fueltankinternalmeshswitch = PickupAllChildrensTransforms(f16fueltankinternal.gameObject, "radioSwitch");
            f16fueltankinternalinteractable = PickupAllChildrensTransforms(f16fueltankinternalmeshswitch.gameObject, "radioSwitchInteractable");
            f16fueltankinternalinteractablevrlever = CreateSwitch("Fuel Tank (X)", f16fueltankinternalinteractable.gameObject, f16fueltankinternalmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16fueltankmaster = PickupAllChildrensTransforms(f16normalswitches.gameObject, "fueltankmaster_normalswitch");
            f16fueltankmastermeshswitch = PickupAllChildrensTransforms(f16fueltankmaster.gameObject, "radioSwitch");
            f16fueltankmasterinteractable = PickupAllChildrensTransforms(f16fueltankmastermeshswitch.gameObject, "radioSwitchInteractable");
            f16fueltankmasterinteractablevrlever = CreateSwitch("Fuel Tank Master (X)", f16fueltankmasterinteractable.gameObject, f16fueltankmastermeshswitch, 35f, 2, 1, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16auxcommm4code = PickupAllChildrensTransforms(f16normalswitches.gameObject, "auxcommm4code_normalswitch");
            f16auxcommm4codemeshswitch = PickupAllChildrensTransforms(f16auxcommm4code.gameObject, "radioSwitch");
            f16auxcommm4codeinteractable = PickupAllChildrensTransforms(f16auxcommm4codemeshswitch.gameObject, "radioSwitchInteractable");
            f16auxcommm4codeinteractablevrlever = CreateSwitch("AUX Comm M-4 (X)", f16auxcommm4codeinteractable.gameObject, f16auxcommm4codemeshswitch, 35f, 3, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16auxtacan = PickupAllChildrensTransforms(f16normalswitches.gameObject, "auxtacan_normalswitch");
            f16auxtacanmeshswitch = PickupAllChildrensTransforms(f16auxtacan.gameObject, "radioSwitch");
            f16auxtacaninteractable = PickupAllChildrensTransforms(f16auxtacanmeshswitch.gameObject, "radioSwitchInteractable");
            f16auxtacaninteractablevrlever = CreateSwitch("AUX Tacan (X)", f16auxtacaninteractable.gameObject, f16auxtacanmeshswitch, 35f, 3, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16auxrfmodemonitor = PickupAllChildrensTransforms(f16normalswitches.gameObject, "auxrfmodemonitor_normalswitch");
            f16auxrfmodemonitormeshswitch = PickupAllChildrensTransforms(f16auxrfmodemonitor.gameObject, "radioSwitch");
            f16auxrfmodemonitorinteractable = PickupAllChildrensTransforms(f16auxrfmodemonitormeshswitch.gameObject, "radioSwitchInteractable");
            f16auxrfmodemonitorinteractablevrlever = CreateSwitch("AUX RF Mode (X)", f16auxrfmodemonitorinteractable.gameObject, f16auxrfmodemonitormeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16trimapdisc = PickupAllChildrensTransforms(f16normalswitches.gameObject, "trimapdisc_normalswitch");
            f16trimapdiscmeshswitch = PickupAllChildrensTransforms(f16trimapdisc.gameObject, "radioSwitch");
            f16trimapdiscinteractable = PickupAllChildrensTransforms(f16trimapdiscmeshswitch.gameObject, "radioSwitchInteractable");
            f16trimapdiscinteractablevrlever = CreateSwitch("Tri Map Disc(X)", f16trimapdiscinteractable.gameObject, f16trimapdiscmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16fltbit = PickupAllChildrensTransforms(f16normalswitches.gameObject, "fltbit_normalswitch");
            f16fltbitmeshswitch = PickupAllChildrensTransforms(f16fltbit.gameObject, "radioSwitch");
            f16fltbitinteractable = PickupAllChildrensTransforms(f16fltbitmeshswitch.gameObject, "radioSwitchInteractable");
            f16fltbitinteractablevrlever = CreateSwitch("Radio Tone (X)", f16fltbitinteractable.gameObject, f16fltbitmeshswitch, 35f, 3, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16auxrfmodereply = PickupAllChildrensTransforms(f16normalswitches.gameObject, "auxrfmodereply_normalswitch");
            f16auxrfmodereplymeshswitch = PickupAllChildrensTransforms(f16auxrfmodereply.gameObject, "radioSwitch");
            f16auxrfmodereplyinteractable = PickupAllChildrensTransforms(f16auxrfmodereplymeshswitch.gameObject, "radioSwitchInteractable");
            f16auxrfmodereplyinteractablevrlever = CreateSwitch("Radio Tone (X)", f16auxrfmodereplyinteractable.gameObject, f16auxrfmodereplymeshswitch, 35f, 3, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16flcsreset = PickupAllChildrensTransforms(f16normalswitches.gameObject, "flcsreset_normalswitch");
            f16flcsresetmeshswitch = PickupAllChildrensTransforms(f16flcsreset.gameObject, "radioSwitch");
            f16flcsresetinteractable = PickupAllChildrensTransforms(f16flcsresetmeshswitch.gameObject, "radioSwitchInteractable");
            f16flcsresetinteractablevrlever = CreateSwitch("FLC Reset (X)", f16flcsresetinteractable.gameObject, f16flcsresetmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16flcsleflaps = PickupAllChildrensTransforms(f16normalswitches.gameObject, "flcsleflaps_normalswitch");
            f16flcsleflapsmeshswitch = PickupAllChildrensTransforms(f16flcsleflaps.gameObject, "radioSwitch");
            f16flcsleflapsinteractable = PickupAllChildrensTransforms(f16flcsleflapsmeshswitch.gameObject, "radioSwitchInteractable");
            f16flcsleflapsinteractablevrlever = CreateSwitch("FLC LE Flaps (X)", f16flcsleflapsinteractable.gameObject, f16flcsleflapsmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16fltdigibackup = PickupAllChildrensTransforms(f16normalswitches.gameObject, "fltdigibackup_normalswitch");
            f16fltdigibackupmeshswitch = PickupAllChildrensTransforms(f16fltdigibackup.gameObject, "radioSwitch");
            f16fltdigibackupinteractable = PickupAllChildrensTransforms(f16fltdigibackupmeshswitch.gameObject, "radioSwitchInteractable");
            f16fltdigibackupinteractablevrlever = CreateSwitch("FLT Digital Backup (X)", f16fltdigibackupinteractable.gameObject, f16fltdigibackupmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16fltaltflaps = PickupAllChildrensTransforms(f16normalswitches.gameObject, "fltaltflaps_normalswitch");
            f16fltaltflapsmeshswitch = PickupAllChildrensTransforms(f16fltaltflaps.gameObject, "radioSwitch");
            f16fltaltflapsinteractable = PickupAllChildrensTransforms(f16fltaltflapsmeshswitch.gameObject, "radioSwitchInteractable");
            f16fltaltflapsinteractablevrlever = CreateSwitch("FLT Alt Flaps (X)", f16fltaltflapsinteractable.gameObject, f16fltaltflapsmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16fltmanualflyup = PickupAllChildrensTransforms(f16normalswitches.gameObject, "fltmanualflyup_normalswitch");
            f16fltmanualflyupmeshswitch = PickupAllChildrensTransforms(f16fltmanualflyup.gameObject, "radioSwitch");
            f16fltmanualflyupinteractable = PickupAllChildrensTransforms(f16fltmanualflyupmeshswitch.gameObject, "radioSwitchInteractable");
            f16fltmanualflyupinteractablevrlever = CreateSwitch("FLT Manual Flyup (X)", f16fltmanualflyupinteractable.gameObject, f16fltmanualflyupmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16testtest = PickupAllChildrensTransforms(f16normalswitches.gameObject, "testtest_normalswitch");
            f16testtestmeshswitch = PickupAllChildrensTransforms(f16testtest.gameObject, "radioSwitch");
            f16testtestinteractable = PickupAllChildrensTransforms(f16testtestmeshswitch.gameObject, "radioSwitchInteractable");
            f16testtestinteractablevrlever = CreateSwitch("Test Test (X)", f16testtestinteractable.gameObject, f16testtestmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16testprobeheat = PickupAllChildrensTransforms(f16normalswitches.gameObject, "testprobeheat_normalswitch");
            f16testprobeheatmeshswitch = PickupAllChildrensTransforms(f16testprobeheat.gameObject, "radioSwitch");
            f16testprobeheatinteractable = PickupAllChildrensTransforms(f16testprobeheatmeshswitch.gameObject, "radioSwitchInteractable");
            f16testprobeheatinteractablevrlever = CreateSwitch("Test Probe Heat (X)", f16testprobeheatinteractable.gameObject, f16testprobeheatmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16testepugen = PickupAllChildrensTransforms(f16normalswitches.gameObject, "testepugen_normalswitch");
            f16testepugenmeshswitch = PickupAllChildrensTransforms(f16testepugen.gameObject, "radioSwitch");
            f16testepugeninteractable = PickupAllChildrensTransforms(f16testepugenmeshswitch.gameObject, "radioSwitchInteractable");
            f16testepugeninteractablevrlever = CreateSwitch("EPU Gen (X)", f16testepugeninteractable.gameObject, f16testepugenmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16testQXY = PickupAllChildrensTransforms(f16normalswitches.gameObject, "testQXY_normalswitch");
            f16testQXYmeshswitch = PickupAllChildrensTransforms(f16testQXY.gameObject, "radioSwitch");
            f16testQXYinteractable = PickupAllChildrensTransforms(f16testQXYmeshswitch.gameObject, "radioSwitchInteractable");
            f16testQXYinteractablevrlever = CreateSwitch("Oxy Qty (X)", f16testQXYinteractable.gameObject, f16testQXYmeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16extlightingmaster = PickupAllChildrensTransforms(f16normalswitches.gameObject, "extlightingmaster_normalswitch");
            f16extlightingmastermeshswitch = PickupAllChildrensTransforms(f16extlightingmaster.gameObject, "radioSwitch");
            f16extlightingmasterinteractable = PickupAllChildrensTransforms(f16extlightingmastermeshswitch.gameObject, "radioSwitchInteractable");
            f16extlightingmasterinteractablevrlever = CreateSwitch("Ext Lighting Master (X)", f16extlightingmasterinteractable.gameObject, f16extlightingmastermeshswitch, 35f, 2, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16voicemessage = PickupAllChildrensTransforms(f16normalswitches.gameObject, "voicemessage_normalswitch");
            f16voicemessagemeshswitch = PickupAllChildrensTransforms(f16voicemessage.gameObject, "radioSwitch");
            f16voicemessageinteractable = PickupAllChildrensTransforms(f16voicemessagemeshswitch.gameObject, "radioSwitchInteractable");
            f16voicemessageinteractablevrlever = CreateSwitch("Voice Message (X)", f16voicemessageinteractable.gameObject, f16voicemessagemeshswitch, 35f, 2, 0, f26RightPanelPoseBoundsComp, false, true);

            f16zeroizeoep = PickupAllChildrensTransforms(f16normalswitches.gameObject, "zeroizeoep_normalswitch");
            f16zeroizeoepmeshswitch = PickupAllChildrensTransforms(f16zeroizeoep.gameObject, "radioSwitch");
            f16zeroizeoepinteractable = PickupAllChildrensTransforms(f16zeroizeoepmeshswitch.gameObject, "radioSwitchInteractable");
            f16zeroizeoepinteractablevrlever = CreateSwitch("Zeroize (X)", f16zeroizeoepinteractable.gameObject, f16zeroizeoepmeshswitch, 35f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16malindlts = PickupAllChildrensTransforms(f16normalswitches.gameObject, "malindlts_normalswitch");
            f16malindltsmeshswitch = PickupAllChildrensTransforms(f16malindlts.gameObject, "radioSwitch");
            f16malindltsinteractable = PickupAllChildrensTransforms(f16malindltsmeshswitch.gameObject, "radioSwitchInteractable");
            f16malindltsinteractablevrlever = CreateSwitch("Mal Ind Lts (X)", f16malindltsinteractable.gameObject, f16malindltsmeshswitch, 35f, 2, 0, f26RightPanelPoseBoundsComp, false, true);

            f16brightnesshud = PickupAllChildrensTransforms(f16normalswitches.gameObject, "brightnesshud_normalswitch");
            f16brightnesshudmeshswitch = PickupAllChildrensTransforms(f16brightnesshud.gameObject, "radioSwitch");
            f16brightnesshudinteractable = PickupAllChildrensTransforms(f16brightnesshudmeshswitch.gameObject, "radioSwitchInteractable");
            f16brightnesshudinteractablevrlever = CreateSwitch("Brightness HUD (X)", f16brightnesshudinteractable.gameObject, f16brightnesshudmeshswitch, 35f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16hudaltitudetype = PickupAllChildrensTransforms(f16normalswitches.gameObject, "hudaltitudetype_normalswitch");
            f16hudaltitudetypemeshswitch = PickupAllChildrensTransforms(f16hudaltitudetype.gameObject, "radioSwitch");
            f16hudaltitudetypeinteractable = PickupAllChildrensTransforms(f16hudaltitudetypemeshswitch.gameObject, "radioSwitchInteractable");
            f16hudaltitudetypeinteractablevrlever = CreateSwitch("HUD Altitude", f16hudaltitudetypeinteractable.gameObject, f16hudaltitudetypemeshswitch, 25f, 2, 0, f26RightPanelPoseBoundsComp, false, true);

            f16hudspeedtype = PickupAllChildrensTransforms(f16normalswitches.gameObject, "hudspeedtype_normalswitch");
            f16hudspeedtypemeshswitch = PickupAllChildrensTransforms(f16hudspeedtype.gameObject, "radioSwitch");
            f16hudspeedtypeinteractable = PickupAllChildrensTransforms(f16hudspeedtypemeshswitch.gameObject, "radioSwitchInteractable");
            f16hudspeedtypeinteractablevrlever = CreateSwitch("HUD Speed Type (X)", f16hudspeedtypeinteractable.gameObject, f16hudspeedtypemeshswitch, 35f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16wvah = PickupAllChildrensTransforms(f16normalswitches.gameObject, "wvah_normalswitch");
            f16wvahmeshswitch = PickupAllChildrensTransforms(f16wvah.gameObject, "radioSwitch");
            f16wvahinteractable = PickupAllChildrensTransforms(f16wvahmeshswitch.gameObject, "radioSwitchInteractable");
            f16wvahinteractablevrlever = CreateSwitch("WVAH (X)", f16wvahinteractable.gameObject, f16wvahmeshswitch, 45f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16attpm = PickupAllChildrensTransforms(f16normalswitches.gameObject, "attpm_normalswitch");
            f16attpmmeshswitch = PickupAllChildrensTransforms(f16attpm.gameObject, "radioSwitch");
            f16attpminteractable = PickupAllChildrensTransforms(f16attpmmeshswitch.gameObject, "radioSwitchInteractable");
            f16attpminteractablevrlever = CreateSwitch("Att PM (X)", f16attpminteractable.gameObject, f16attpmmeshswitch, 45f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16deddata = PickupAllChildrensTransforms(f16normalswitches.gameObject, "deddata_normalswitch");
            f16deddatameshswitch = PickupAllChildrensTransforms(f16deddata.gameObject, "radioSwitch");
            f16deddatainteractable = PickupAllChildrensTransforms(f16deddatameshswitch.gameObject, "radioSwitchInteractable");
            f16deddatainteractablevrlever = CreateSwitch("DED Data (X)", f16deddatainteractable.gameObject, f16deddatameshswitch, 45f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16hudstby = PickupAllChildrensTransforms(f16normalswitches.gameObject, "hudstby_normalswitch");
            f16hudstbymeshswitch = PickupAllChildrensTransforms(f16hudstby.gameObject, "radioSwitch");
            f16hudstbyinteractable = PickupAllChildrensTransforms(f16hudstbymeshswitch.gameObject, "radioSwitchInteractable");
            f16hudstbyinteractablevrlever = CreateSwitch("Radio Tone (X)", f16hudstbyinteractable.gameObject, f16hudstbymeshswitch, 30f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16sensorpwrradar = PickupAllChildrensTransforms(f16normalswitches.gameObject, "sensorpwrradar_normalswitch");
            f16sensorpwrradarmeshswitch = PickupAllChildrensTransforms(f16sensorpwrradar.gameObject, "radioSwitch");
            f16sensorpwrradarinteractable = PickupAllChildrensTransforms(f16sensorpwrradarmeshswitch.gameObject, "radioSwitchInteractable");
            f16sensorpwrradarinteractablevrlever = CreateSwitch("Sensor PWR Radar", f16sensorpwrradarinteractable.gameObject, f16sensorpwrradarmeshswitch, 45f, 3, 0, f26RightPanelPoseBoundsComp, false, true);
            f16sensorpwrradarinteractablevrlever.OnSetState.AddListener(f26uiradarmfd.SetRadarPower);

             f16sensorpwrfcr = PickupAllChildrensTransforms(f16normalswitches.gameObject, "sensorpwrfcr_normalswitch");
            f16sensorpwrfcrmeshswitch = PickupAllChildrensTransforms(f16sensorpwrfcr.gameObject, "radioSwitch");
            f16sensorpwrfcrinteractable = PickupAllChildrensTransforms(f16sensorpwrfcrmeshswitch.gameObject, "radioSwitchInteractable");
            f16sensorpwrfcrinteractablevrlever = CreateSwitch("Sensor PWR FCR (X)", f16sensorpwrfcrinteractable.gameObject, f16sensorpwrfcrmeshswitch, 35f, 2, 0, f26RightPanelPoseBoundsComp, false, true);

            f16sensorpwrrhdpt = PickupAllChildrensTransforms(f16normalswitches.gameObject, "sensorpwrrhdpt_normalswitch");
            f16sensorpwrrhdptmeshswitch = PickupAllChildrensTransforms(f16sensorpwrrhdpt.gameObject, "radioSwitch");
            f16sensorpwrrhdptinteractable = PickupAllChildrensTransforms(f16sensorpwrrhdptmeshswitch.gameObject, "radioSwitchInteractable");
            f16sensorpwrrhdptinteractablevrlever = CreateSwitch("Right HDPT  (X)", f16sensorpwrrhdptinteractable.gameObject, f16sensorpwrrhdptmeshswitch, 35f, 2, 0, f26RightPanelPoseBoundsComp, false, true);

            f16nuclearconsent = PickupAllChildrensTransforms(f16normalswitches.gameObject, "nuclearconsent_normalswitch");
            f16nuclearconsentmeshswitch = PickupAllChildrensTransforms(f16nuclearconsent.gameObject, "radioSwitch");
            f16nuclearconsentinteractable = PickupAllChildrensTransforms(f16nuclearconsentmeshswitch.gameObject, "radioSwitchInteractable");
            f16nuclearconsentinteractablevrlever = CreateSwitch("Nuclear Consent (X)", f16nuclearconsentinteractable.gameObject, f16nuclearconsentmeshswitch, 45f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16engineantiice = PickupAllChildrensTransforms(f16normalswitches.gameObject, "engineantiice_normalswitch");
            f16engineantiicemeshswitch = PickupAllChildrensTransforms(f16engineantiice.gameObject, "radioSwitch");
            f16engineantiiceinteractable = PickupAllChildrensTransforms(f16engineantiicemeshswitch.gameObject, "radioSwitchInteractable");
            f16engineantiiceinteractablevrlever = CreateSwitch("Engine Anti-Ice (X)", f16engineantiiceinteractable.gameObject, f16engineantiicemeshswitch, 30f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16iffselect = PickupAllChildrensTransforms(f16normalswitches.gameObject, "iffselect_normalswitch");
            f16iffselectmeshswitch = PickupAllChildrensTransforms(f16iffselect.gameObject, "radioSwitch");
            f16iffselectinteractable = PickupAllChildrensTransforms(f16iffselectmeshswitch.gameObject, "radioSwitchInteractable");
            f16iffselectinteractablevrlever = CreateSwitch("IFF Select (X)", f16iffselectinteractable.gameObject, f16iffselectmeshswitch, 35f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16mfdpower = PickupAllChildrensTransforms(f16normalswitches.gameObject, "mfdpower_normalswitch");
            f16mfdpowermeshswitch = PickupAllChildrensTransforms(f16mfdpower.gameObject, "radioSwitch");
            f16mfdpowerinteractable = PickupAllChildrensTransforms(f16mfdpowermeshswitch.gameObject, "radioSwitchInteractable");
            f16mfdpowerinteractablevrlever = CreateSwitch("MFD Power (X)", f16mfdpowerinteractable.gameObject, f16mfdpowermeshswitch, 35f, 2, 0, f26RightPanelPoseBoundsComp, false, true);

            f16ststapower = PickupAllChildrensTransforms(f16normalswitches.gameObject, "ststapower_normalswitch");
            f16ststapowermeshswitch = PickupAllChildrensTransforms(f16ststapower.gameObject, "radioSwitch");
            f16ststapowerinteractable = PickupAllChildrensTransforms(f16ststapowermeshswitch.gameObject, "radioSwitchInteractable");
            f16ststapowerinteractablevrlever = CreateSwitch("ST STA (X)", f16ststapowerinteractable.gameObject, f16ststapowermeshswitch, 35f, 2, 0, f26RightPanelPoseBoundsComp, false, true);

            f16mmcpower = PickupAllChildrensTransforms(f16normalswitches.gameObject, "mmcpower_normalswitch");
            f16mmcpowermeshswitch = PickupAllChildrensTransforms(f16mmcpower.gameObject, "radioSwitch");
            f16mmcpowerinteractable = PickupAllChildrensTransforms(f16mmcpowermeshswitch.gameObject, "radioSwitchInteractable");
            f16mmcpowerinteractablevrlever = CreateSwitch("MMC Power (X)", f16mmcpowerinteractable.gameObject, f16mmcpowermeshswitch, 35f, 2, 0, f26RightPanelPoseBoundsComp, false, true);

            f16ufcpower = PickupAllChildrensTransforms(f16normalswitches.gameObject, "ufcpower_normalswitch");
            f16ufcpowermeshswitch = PickupAllChildrensTransforms(f16ufcpower.gameObject, "radioSwitch");
            f16ufcpowerinteractable = PickupAllChildrensTransforms(f16ufcpowermeshswitch.gameObject, "radioSwitchInteractable");
            f16ufcpowerinteractablevrlever = CreateSwitch("UFC (X)", f16ufcpowerinteractable.gameObject, f16ufcpowermeshswitch, 35f, 2, 0, f26RightPanelPoseBoundsComp, false, true);

            f16avionicspowerdl = PickupAllChildrensTransforms(f16normalswitches.gameObject, "avionicspowerdl_normalswitch");
            f16avionicspowerdlmeshswitch = PickupAllChildrensTransforms(f16avionicspowerdl.gameObject, "radioSwitch");
            f16avionicspowerdlinteractable = PickupAllChildrensTransforms(f16avionicspowerdlmeshswitch.gameObject, "radioSwitchInteractable");
            f16avionicspowerdlinteractablevrlever = CreateSwitch("DL (X)", f16avionicspowerdlinteractable.gameObject, f16avionicspowerdlmeshswitch, 35f, 2, 0, f26RightPanelPoseBoundsComp, false, true);

            f16uhfselect = PickupAllChildrensTransforms(f16normalswitches.gameObject, "uhfselect_normalswitch");
            f16uhfselectmeshswitch = PickupAllChildrensTransforms(f16uhfselect.gameObject, "radioSwitch");
            f16uhfselectinteractable = PickupAllChildrensTransforms(f16uhfselectmeshswitch.gameObject, "radioSwitchInteractable");
            f16uhfselectinteractablevrlever = CreateSwitch("UHF Select (X)", f16uhfselectinteractable.gameObject, f16uhfselectmeshswitch, 45f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16plaincrad1 = PickupAllChildrensTransforms(f16normalswitches.gameObject, "plaincrad1_normalswitch");
            f16plaincrad1meshswitch = PickupAllChildrensTransforms(f16plaincrad1.gameObject, "radioSwitch");
            f16plaincrad1interactable = PickupAllChildrensTransforms(f16plaincrad1meshswitch.gameObject, "radioSwitchInteractable");
            f16plaincrad1interactablevrlever = CreateSwitch("CRAD (X)", f16plaincrad1interactable.gameObject, f16plaincrad1meshswitch, 35f, 2, 0, f26RightPanelPoseBoundsComp, false, true);

            f16teststep = PickupAllChildrensTransforms(f16normalswitches.gameObject, "teststep_normalswitch");
            f16teststepmeshswitch = PickupAllChildrensTransforms(f16teststep.gameObject, "radioSwitch");
            f16teststepinteractable = PickupAllChildrensTransforms(f16teststepmeshswitch.gameObject, "radioSwitchInteractable");
            f16teststepinteractablevrlever = CreateSwitch("Test Step (X)", f16teststepinteractable.gameObject, f16teststepmeshswitch, 35f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16extlightingwingtail = PickupAllChildrensTransforms(f16normalswitches.gameObject, "extlightingwingtail_normalswitch");
            f16extlightingwingtailmeshswitch = PickupAllChildrensTransforms(f16extlightingwingtail.gameObject, "radioSwitch");
            f16extlightingwingtailinteractable = PickupAllChildrensTransforms(f16extlightingwingtailmeshswitch.gameObject, "radioSwitchInteractable");
            f16extlightingwingtailinteractablevrlever = CreateSwitch("Wing Tail Lights (X)", f16extlightingwingtailinteractable.gameObject, f16extlightingwingtailmeshswitch, 45f, 3, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16extlightingfuselage = PickupAllChildrensTransforms(f16normalswitches.gameObject, "extlightingfuselage_normalswitch");
            f16extlightingfuselagemeshswitch = PickupAllChildrensTransforms(f16extlightingfuselage.gameObject, "radioSwitch");
            f16extlightingfuselageinteractable = PickupAllChildrensTransforms(f16extlightingfuselagemeshswitch.gameObject, "radioSwitchInteractable");
            f16extlightingfuselageinteractablevrlever = CreateSwitch("Fuselage Lights (X)", f16extlightingfuselageinteractable.gameObject, f16extlightingfuselagemeshswitch, 45f, 3, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), false, true);

            f16extfuelTransfer = PickupAllChildrensTransforms(f16normalswitches.gameObject, "extfuelTransfer_normalswitch");
            f16extfuelTransfermeshswitch = PickupAllChildrensTransforms(f16extfuelTransfer.gameObject, "radioSwitch");
            f16extfuelTransferinteractable = PickupAllChildrensTransforms(f16extfuelTransfermeshswitch.gameObject, "radioSwitchInteractable");
            f16extfuelTransferinteractablevrlever = CreateSwitch("EXT Fuel Transfer (X)", f16extfuelTransferinteractable.gameObject, f16extfuelTransfermeshswitch, 35f, 2, 0, CenterDashPoseBoundsf26.GetComponent<PoseBounds>(), false, true);

            f16avionicspowergps = PickupAllChildrensTransforms(f16normalswitches.gameObject, "avionicspowergps_normalswitch");
            f16avionicspowergpsmeshswitch = PickupAllChildrensTransforms(f16avionicspowergps.gameObject, "radioSwitch");
            f16avionicspowergpsinteractable = PickupAllChildrensTransforms(f16avionicspowergpsmeshswitch.gameObject, "radioSwitchInteractable");
            f16avionicspowergpsinteractablevrlever = CreateSwitch("GPS Power (X)", f16avionicspowergpsinteractable.gameObject, f16avionicspowergpsmeshswitch, 35f, 3, 0, f26RightPanelPoseBoundsComp, false, true);

            f16CMDSMode = PickupAllChildrensTransforms(leftauxpanelgobj.gameObject, "CMDSprgmmode_pointerknob");
            f16CMDSModeparent = PickupAllChildrensTransforms(f16CMDSMode.gameObject, "knobTF");
            f16CMDSModeknobint = PickupAllChildrensTransforms(f16CMDSMode.gameObject, "rotatorknob3Interactable");
            f16CMDSModeintTK = CreateClickKnob("CMD Program Mode (X)", f16CMDSModeknobint.gameObject, 6, f16CMDSModeparent, 167f, 0, LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), true, true);

            f16JMRSwitch = PickupAllChildrensTransforms(f16normalswitches.gameObject, "JMR_normalswitch");
            f16JMRSwitchparent = PickupAllChildrensTransforms(f16JMRSwitch.gameObject, "radioSwitch");
            f16JMRSwitchint = PickupAllChildrensTransforms(f16JMRSwitchparent.gameObject, "radioSwitchInteractable");
            f16JMRModeintTK = CreateSwitch("Jammer (X)", f16JMRSwitchint.gameObject, f16JMRSwitch, 30f, 2, 0, LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), false, true);

            f16NWSSwitch = PickupAllChildrensTransforms(f16normalswitches.gameObject, "NWS_normalswitch");
            f16NWSSwitchparent = PickupAllChildrensTransforms(f16NWSSwitch.gameObject, "radioSwitch");
            f16NWSSwitchint = PickupAllChildrensTransforms(f16NWSSwitchparent.gameObject, "radioSwitchInteractable");
            f16NWSModeintTK = CreateSwitch("NWS Switch (X)", f16NWSSwitchint.gameObject, f16NWSSwitch, 30f, 2, 0, LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), false, true);
            f16NWSModeintTK.OnSetState.AddListener(AutoPilotSpeed);

            f16StoresSwitch = PickupAllChildrensTransforms(leftauxpanelgobj.gameObject, "storesconfig_normalswitchBase");
            f16StoresSwitchparent = PickupAllChildrensTransforms(f16StoresSwitch.gameObject, "radioSwitch");
            f16StoresSwitchint = PickupAllChildrensTransforms(f16StoresSwitchparent.gameObject, "radioSwitchInteractable");
            f16StoresModeintTK = CreateSwitch("Stores Config (X)", f16StoresSwitchint.gameObject, f16StoresSwitchparent, 30f, 2, 0, LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), false, true);

            f16gndjettenableSwitch = PickupAllChildrensTransforms(leftauxpanelgobj.gameObject, "gndjettenable_normalswitchBase");
            f16gndjettenableSwitchparent = PickupAllChildrensTransforms(f16gndjettenableSwitch.gameObject, "radioSwitch");
            f16gndjettenableSwitchint = PickupAllChildrensTransforms(f16gndjettenableSwitchparent.gameObject, "radioSwitchInteractable");
            f16gndjettenableintTK = CreateSwitch("GND Jettison (X)", f16gndjettenableSwitchint.gameObject, f16gndjettenableSwitchparent, 30f, 2, 0, LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), false, true);

            f16brakeschan1Switch = PickupAllChildrensTransforms(leftauxpanelgobj.gameObject, "brakeschan1_normalswitchBase");
            f16brakeschan1Switchparent = PickupAllChildrensTransforms(f16brakeschan1Switch.gameObject, "radioSwitch");
            f16brakeschan1Switchint = PickupAllChildrensTransforms(f16brakeschan1Switchparent.gameObject, "radioSwitchInteractable");
            f16brakeschan1intTK = CreateSwitch("Brakes Channel (X)", f16brakeschan1Switchint.gameObject, f16brakeschan1Switchparent, 30f, 2, 0, LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), false, true);

            f16pitchholdSwitch = PickupAllChildrensTransforms(frontupperpanelgobj.gameObject, "pitchhold_normalswitchBase");
            f16pitchholdSwitchparent = PickupAllChildrensTransforms(f16pitchholdSwitch.gameObject, "radioSwitch");
            f16pitchholdSwitchint = PickupAllChildrensTransforms(f16pitchholdSwitchparent.gameObject, "radioSwitchInteractable");
            f16pitchholdintTK = CreateSwitch("Pitch Hold (X)", f16pitchholdSwitchint.gameObject, f16pitchholdSwitchparent, 40f, 3, 1, ConsoleLeftDashposeboundsF16.GetComponent<PoseBounds>(), false, true);

            f16rollaltholdSwitch = PickupAllChildrensTransforms(frontupperpanelgobj.gameObject, "rollalthold_normalswitchBase");
            f16rollaltholdSwitchparent = PickupAllChildrensTransforms(f16rollaltholdSwitch.gameObject, "radioSwitch");
            f16rollaltholdSwitchint = PickupAllChildrensTransforms(f16rollaltholdSwitchparent.gameObject, "radioSwitchInteractable");
            f16rollaltholdintTK = CreateSwitch("Roll Hold (X)", f16rollaltholdSwitchint.gameObject, f16rollaltholdSwitchparent, 40f, 3, 1, ConsoleLeftDashposeboundsF16.GetComponent<PoseBounds>(), false, true);

            f16LazerArmSwitch = PickupAllChildrensTransforms(frontupperpanelgobj.gameObject, "LazerArm_normalswitch");
            f16LazerArmSwitchparent = PickupAllChildrensTransforms(f16LazerArmSwitch.gameObject, "radioSwitch");
            f16LazerArmSwitchint = PickupAllChildrensTransforms(f16LazerArmSwitchparent.gameObject, "radioSwitchInteractable");
            f16LazerArmintTK = CreateSwitch("Lazer Arm (Helper)", f16LazerArmSwitchint.gameObject, f16LazerArmSwitchparent, 40f, 2, 0, ConsoleLeftDashposeboundsF16.GetComponent<PoseBounds>(), false, true);

            f16RFQuietSwitch = PickupAllChildrensTransforms(frontupperpanelgobj.gameObject, "RFQuiet_normalswitch");
            f16RFQuietSwitchparent = PickupAllChildrensTransforms(f16RFQuietSwitch.gameObject, "radioSwitch");
            f16RFQuietSwitchint = PickupAllChildrensTransforms(f16RFQuietSwitchparent.gameObject, "radioSwitchInteractable");
            f16RFQuietintTK = CreateSwitch("Lazer Arm (X)", f16RFQuietSwitchint.gameObject, f16RFQuietSwitchparent, 40f, 2, 0, ConsoleLeftDashposeboundsF16.GetComponent<PoseBounds>(), false, true);

            f16CMDSBit = PickupAllChildrensTransforms(leftauxpanelgobj.gameObject, "CMDSprgmbit_fulltwisty");
            f16CMDSBitparent = PickupAllChildrensTransforms(f16CMDSBit.gameObject, "knobTF");
            f16CMDSBitknobint = PickupAllChildrensTransforms(f16CMDSBit.gameObject, "rotatorknob2Interactable");
            f16CMDSBitintTK = CreateClickKnob("CMD Bit (X)", f16CMDSBitknobint.gameObject, 5, f16CMDSBitparent, 180f, 0, LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), true, true);

            f16PointerKnobs = PickupAllChildrensTransforms(F16Cockpit.gameObject, "Pointerknob");
            f16UHFmainboch = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "UHFmainboch_pointerknob");
            f16UHFmainbochparent = PickupAllChildrensTransforms(f16UHFmainboch.gameObject, "knobTF");
            f16UHFmainbochint = PickupAllChildrensTransforms(f16UHFmainboch.gameObject, "rotatorknob11Interactable");
            f16UHFmainbochintTK = CreateClickKnob("UHF Main Boch (X)", f16UHFmainbochint.gameObject, 4, f16UHFmainbochparent, 125f, 0, LeftFWDDashPoseBoundsF16.GetComponent<PoseBounds>(), true, true);

            f16UHFpreset = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "UHFpreset_pointerknob");
            f16UHFpresetparent = PickupAllChildrensTransforms(f16UHFpreset.gameObject, "knobTF");
            f16UHFpresetint = PickupAllChildrensTransforms(f16UHFpreset.gameObject, "rotatorknob11Interactable");
            f16UHFpresetintTK = CreateClickKnob("UHF Preset (X)", f16UHFpresetint.gameObject, 3, f16UHFpresetparent, 100f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, true);

            f16audio1Comm2Squelch = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "audio1comm2squelch_pointerknob");
            f16audio1Comm2Squelchparent = PickupAllChildrensTransforms(f16audio1Comm2Squelch.gameObject, "knobTF");
            f16audio1Comm2Squelchint = PickupAllChildrensTransforms(f16audio1Comm2Squelch.gameObject, "rotatorknob10Interactable");
            f16audio1Comm2SquelchintTK = CreateClickKnob("Audio Comm 2 Squelch (X)", f16audio1Comm2Squelchint.gameObject, 3, f16audio1Comm2Squelchparent, 100f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, true);

            f16audio1Comm1Squelch = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "audio1comm1squelch_pointerknob");
            f16audio1Comm1Squelchparent = PickupAllChildrensTransforms(f16audio1Comm1Squelch.gameObject, "knobTF");
            f16audio1Comm1Squelchint = PickupAllChildrensTransforms(f16audio1Comm1Squelch.gameObject, "rotatorknob10Interactable");
            f16audio1Comm1SquelchintTK = CreateClickKnob("Audio Comm 1 Squelch (X)", f16audio1Comm1Squelchint.gameObject, 3, f16audio1Comm1Squelchparent, 100f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, true);

            f16extfuelQty = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "extfuelQty");
            f16extfuelQtyparent = PickupAllChildrensTransforms(f16extfuelQty.gameObject, "knobTF");
            f16extfuelQtyint = PickupAllChildrensTransforms(f16extfuelQty.gameObject, "rotatorknob9Interactable");
            f16extfuelQtyintTK = CreateClickKnob("Ext Fuel Qty (X)", f16extfuelQtyint.gameObject, 5, f16extfuelQtyparent, 180f, 0, null, true, true);

            f16NavMode = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "NavMode_knob");
            f16NavModeparent = PickupAllChildrensTransforms(f16NavMode.gameObject, "knobTF");
            f16NavModeint = PickupAllChildrensTransforms(f16NavMode.gameObject, "rotatorknob9Interactable");
            f16NavModeintTK = CreateClickKnob("Nav Mode (X)", f16NavModeint.gameObject, 2, f16NavModeparent, 90f, 0, null, true, true);

            f16NavInstrHeading = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "NavInstrHeading_knob");
            f16NavInstrHeadingparent = PickupAllChildrensTransforms(f16NavInstrHeading.gameObject, "knobTF");
            f16NavInstrHeadingint = PickupAllChildrensTransforms(f16NavInstrHeading.gameObject, "rotatorknob4Interactable");
            f16NavInstrHeadingintTK = CreateClickKnob("Heading", f16NavInstrHeadingint.gameObject, 360, f16NavInstrHeadingparent, 180f, 0, null, true, true);

            f16SmallTwisty = PickupAllChildrensTransforms(F16Cockpit.gameObject, "Smalltwisty");
            audio1SecureVoice = PickupAllChildrensTransforms(f16SmallTwisty.gameObject, "audio1securevoice_smallfulltwisty");
            audio1SecureVoiceparent = PickupAllChildrensTransforms(audio1SecureVoice.gameObject, "knobTF");
            audio1SecureVoiceint = PickupAllChildrensTransforms(audio1SecureVoice.gameObject, "rotatorknob4Interactable");
            audio1SecureVoiceintTK = CreateClickKnob("Audio 1 Secure Voice (X)", audio1SecureVoiceint.gameObject, 2, audio1SecureVoiceparent, 120f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, true);

            f16audio1MSL = PickupAllChildrensTransforms(f16SmallTwisty.gameObject, "audio1msl_smallfulltwisty");
            f16audio1MSLparent = PickupAllChildrensTransforms(f16audio1MSL.gameObject, "knobTF");
            f16audio1MSLint = PickupAllChildrensTransforms(f16audio1MSL.gameObject, "rotatorknob8Interactable");
            f16audio1MSLintTK = CreateSmoothKnob("Audio 1 MSL (X)", f16audio1MSLint.gameObject, f16audio1MSLparent, 120f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true);

            f16audio1threat = PickupAllChildrensTransforms(f16SmallTwisty.gameObject, "audio1threat_smallfulltwisty");
            f16audio1threatparent = PickupAllChildrensTransforms(f16audio1threat.gameObject, "knobTF");
            f16audio1threatint = PickupAllChildrensTransforms(f16audio1threat.gameObject, "rotatorknob8Interactable");
            f16audio1threatintTK = CreateSmoothKnob("Audio 1 Threat (X)", f16audio1threatint.gameObject, f16audio1threatparent, 100f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true);

            f16audio1tf = PickupAllChildrensTransforms(f16SmallTwisty.gameObject, "audio1tf_smallfulltwisty");
            f16audio1tfparent = PickupAllChildrensTransforms(f16audio1tf.gameObject, "knobTF");
            f16audio1tfint = PickupAllChildrensTransforms(f16audio1tf.gameObject, "rotatorknob4Interactable");
            f16audio1tfintTK = CreateSmoothKnob("Audio 1 TF (X)", f16audio1tfint.gameObject, f16audio1tfparent, 100f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true);

            f16FullTwisty = PickupAllChildrensTransforms(F16Cockpit.gameObject, "Fulltwisty");
            f16trimyawtrim = PickupAllChildrensTransforms(f16FullTwisty.gameObject, "trimyawtrim_fulltwisty");
            f16trimyawtrimparent = PickupAllChildrensTransforms(f16trimyawtrim.gameObject, "knobTF");
            f16trimyawtrimint = PickupAllChildrensTransforms(f16trimyawtrim.gameObject, "rotatorknob4Interactable");
            f16trimyawtrimintTK = CreateSmoothKnob("Yaw Trim (X)", f16trimyawtrimint.gameObject, f16trimyawtrimparent, 180f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true);

            f16extlightsaerialrefuel = PickupAllChildrensTransforms(f16FullTwisty.gameObject, "extlightsaerialrefuel_fulltwisty");
            f16extlightsaerialrefuelparent = PickupAllChildrensTransforms(f16extlightsaerialrefuel.gameObject, "knobTF");
            f16extlightsaerialrefuelint = PickupAllChildrensTransforms(f16extlightsaerialrefuel.gameObject, "rotatorknob6Interactable");
            f16extlightsaerialrefuelintTK = CreateSmoothKnob("Ext Aerial Refuel Lights (X)", f16extlightsaerialrefuelint.gameObject, f16extlightsaerialrefuelparent, 100f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true);

            f16audiointercom = PickupAllChildrensTransforms(f16FullTwisty.gameObject, "audiointercom_fulltwisty");
            f16audiointercomparent = PickupAllChildrensTransforms(f16audiointercom.gameObject, "knobTF");
            f16audiointercomint = PickupAllChildrensTransforms(f16audiointercom.gameObject, "rotatorknob2Interactable");
            f16audiointercomintTK = CreateSmoothKnob("Audio Intercom (X)", f16audiointercomint.gameObject, f16audiointercomparent, 100f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true);

            f16audiotacan = PickupAllChildrensTransforms(f16FullTwisty.gameObject, "audiotacan_fulltwisty");
            f16audiotacanparent = PickupAllChildrensTransforms(f16audiotacan.gameObject, "knobTF");
            f16audiotacanint = PickupAllChildrensTransforms(f16audiotacan.gameObject, "rotatorknob2Interactable");
            f16audiotacanintTK = CreateSmoothKnob("Ext Aerial Refuel Lights (X)", f16audiotacanint.gameObject, f16audiotacanparent, 100f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true);

            f16audioils = PickupAllChildrensTransforms(f16FullTwisty.gameObject, "audioils_fulltwisty");
            f16audioilsparent = PickupAllChildrensTransforms(f16audioils.gameObject, "knobTF");
            f16audioilsint = PickupAllChildrensTransforms(f16audioils.gameObject, "rotatorknob2Interactable");
            f16audioilsintTK = CreateSmoothKnob("Audio ILS (X)", f16audioilsint.gameObject, f16audioilsparent, 100f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true);

            f16audio1comm2 = PickupAllChildrensTransforms(f16FullTwisty.gameObject, "audio1comm2_fulltwisty");
            f16audio1comm2parent = PickupAllChildrensTransforms(f16audio1comm2.gameObject, "knobTF");
            f16audio1comm2int = PickupAllChildrensTransforms(f16audio1comm2.gameObject, "rotatorknob4Interactable");
            f16audio1comm2intTK = CreateSmoothKnob("Audio 1 Comm 2 (X)", f16audio1comm2int.gameObject, f16audio1comm2parent, 100f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true);

            f16uhfNumberChanger1 = PickupAllChildrensTransforms(f16FullTwisty.gameObject, "uhfnumberchanger1_fulltwisty");
            f16uhfNumberChanger1parent = PickupAllChildrensTransforms(f16uhfNumberChanger1.gameObject, "knobTF");
            f16uhfNumberChanger1int = PickupAllChildrensTransforms(f16uhfNumberChanger1.gameObject, "rotatorknob4Interactable");
            f16uhfNumberChanger1intTK = CreateClickKnob("UHF Freq 100 Bit (X)", f16uhfNumberChanger1int.gameObject, 10, f16uhfNumberChanger1parent, 200f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, true);

            f16uhfNumberChanger2 = PickupAllChildrensTransforms(f16FullTwisty.gameObject, "uhfnumberchanger2_fulltwisty");
            f16uhfNumberChanger2parent = PickupAllChildrensTransforms(f16uhfNumberChanger2.gameObject, "knobTF");
            f16uhfNumberChanger2int = PickupAllChildrensTransforms(f16uhfNumberChanger2.gameObject, "rotatorknob4Interactable");
            f16uhfNumberChanger2intTK = CreateClickKnob("UHF Freq 10 Bit (X)", f16uhfNumberChanger2int.gameObject, 10, f16uhfNumberChanger2parent, 200f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, true);

            f16uhfNumberChanger3 = PickupAllChildrensTransforms(f16FullTwisty.gameObject, "uhfnumberchanger3_fulltwisty");
            f16uhfNumberChanger3parent = PickupAllChildrensTransforms(f16uhfNumberChanger3.gameObject, "knobTF");
            f16uhfNumberChanger3int = PickupAllChildrensTransforms(f16uhfNumberChanger3.gameObject, "rotatorknob4Interactable");
            f16uhfNumberChanger3intTK = CreateClickKnob("UHF Freq 1 Bit (X)", f16uhfNumberChanger3int.gameObject, 10, f16uhfNumberChanger3parent, 200f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, true);

            f16uhfNumberChanger4 = PickupAllChildrensTransforms(f16FullTwisty.gameObject, "uhfnumberchanger4_fulltwisty");
            f16uhfNumberChanger4parent = PickupAllChildrensTransforms(f16uhfNumberChanger4.gameObject, "knobTF");
            f16uhfNumberChanger4int = PickupAllChildrensTransforms(f16uhfNumberChanger4.gameObject, "rotatorknob4Interactable");
            f16uhfNumberChanger4intTK = CreateClickKnob("UHF Freq 10th Bit (X)", f16uhfNumberChanger4int.gameObject, 10, f16uhfNumberChanger4parent, 200f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, true);

            f16uhfNumberChanger5 = PickupAllChildrensTransforms(f16FullTwisty.gameObject, "uhfnumberchanger5_fulltwisty");
            f16uhfNumberChanger5parent = PickupAllChildrensTransforms(f16uhfNumberChanger5.gameObject, "knobTF");
            f16uhfNumberChanger5int = PickupAllChildrensTransforms(f16uhfNumberChanger5.gameObject, "rotatorknob4Interactable");
            f16uhfNumberChanger5intTK = CreateClickKnob("UHF Freq 100th Bit (X)", f16uhfNumberChanger5int.gameObject, 10, f16uhfNumberChanger5parent, 200f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, true);

            f16uhftext1trans = PickupAllChildrensTransforms(f16uhfNumberChanger1.gameObject, "uhftext1");
            f16uhftext1text = f16uhftext1trans.GetComponent<TextMeshPro>();
            f16uhftext1text.text = "0";
            f16uhfNumberChanger1intTK.OnSetState.AddListener(ChangeUHFText1);

            f16uhftext2trans = PickupAllChildrensTransforms(f16uhfNumberChanger2.gameObject, "uhftext2");
            f16uhftext2text = f16uhftext2trans.GetComponent<TextMeshPro>();
            f16uhftext2text.text = "0";
            f16uhfNumberChanger2intTK.OnSetState.AddListener(ChangeUHFText2);

            f16uhftext3trans = PickupAllChildrensTransforms(f16uhfNumberChanger3.gameObject, "uhftext3");
            f16uhftext3text = f16uhftext3trans.GetComponent<TextMeshPro>();
            f16uhftext3text.text = "0";
            f16uhfNumberChanger3intTK.OnSetState.AddListener(ChangeUHFText3);

            f16uhftext4trans = PickupAllChildrensTransforms(f16uhfNumberChanger4.gameObject, "uhftext4");
            f16uhftext4text = f16uhftext4trans.GetComponent<TextMeshPro>();
            f16uhftext4text.text = "0";
            f16uhfNumberChanger4intTK.OnSetState.AddListener(ChangeUHFText4);

            f16uhftext5trans = PickupAllChildrensTransforms(f16uhfNumberChanger5.gameObject, "uhftext5");
            f16uhftext5text = f16uhftext5trans.GetComponent<TextMeshPro>();
            f16uhftext5text.text = "0";
            f16uhfNumberChanger5intTK.OnSetState.AddListener(ChangeUHFText5);

            f16fuelengfeed = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "fuelengfeed_pointerknob");
            f16fuelengfeedparent = PickupAllChildrensTransforms(f16fuelengfeed.gameObject, "knobTF");
            f16fuelengfeedint = PickupAllChildrensTransforms(f16fuelengfeed.gameObject, "rotatorknob3Interactable");
            f16fuelengfeedintTK = CreateClickKnob("Fuel Engine Feed (X)", f16fuelengfeedint.gameObject, 4, f16fuelengfeedparent, 120f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, true);

            f16fuelengfeed = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "fuelengfeed_pointerknob");
            f16fuelengfeedparent = PickupAllChildrensTransforms(f16fuelengfeed.gameObject, "knobTF");
            f16fuelengfeedint = PickupAllChildrensTransforms(f16fuelengfeed.gameObject, "rotatorknob3Interactable");
            f16fuelengfeedintTK = CreateClickKnob("Fuel Engine Feed (X)", f16fuelengfeedint.gameObject, 4, f16fuelengfeedparent, 120f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, true);

            f16auxCNI = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "auxCNI_pointerknob");
            f16auxCNIparent = PickupAllChildrensTransforms(f16auxCNI.gameObject, "knobTF");
            f16auxCNIint = PickupAllChildrensTransforms(f16auxCNI.gameObject, "rotatorknob5Interactable");
            f16auxCNIintTK = CreateClickKnob("Aux CNI (X)", f16auxCNIint.gameObject,2, f16auxCNIparent, 58f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, true);

            f16auxcommmaster = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "auxcommmaster_pointerknob");
            f16auxcommmasterparent = PickupAllChildrensTransforms(f16auxcommmaster.gameObject, "knobTF");
            f16auxcommmasterint = PickupAllChildrensTransforms(f16auxcommmaster.gameObject, "rotatorknob3Interactable");
            f16auxcommmasterintTK = CreateClickKnob("Aux Comm Master (X)", f16auxcommmasterint.gameObject, 4, f16auxcommmasterparent, 145f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, false);

            f16extlightsform = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "extlightsform_pointerknob");
            f16extlightsformparent = PickupAllChildrensTransforms(f16extlightsform.gameObject, "knobTF");
            f16extlightsformint = PickupAllChildrensTransforms(f16extlightsform.gameObject, "rotatorknob4Interactable");
            f16extlightsformintTK = CreateSmoothKnob("External Formation Lights (X)", f16extlightsformint.gameObject, f16extlightsformparent, 120f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true);

            f16AVTRdisplayselect = PickupAllChildrensTransforms(f16PointerKnobs.gameObject, "AVTRdisplayselect_pointerknob");
            f16AVTRdisplayselectparent = PickupAllChildrensTransforms(f16AVTRdisplayselect.gameObject, "knobTF");
            f16AVTRdisplayselectint = PickupAllChildrensTransforms(f16AVTRdisplayselect.gameObject, "rotatorknob10Interactable");
            f16AVTRdisplayselectintTK = CreateClickKnob("AVTR Display Select (X)", f16AVTRdisplayselectint.gameObject, 4, f16AVTRdisplayselectparent, 120f, 0, LeftDashPoseBoundsf16.GetComponent<PoseBounds>(), true, false);

            f16GsuitTD = PickupAllChildrensTransforms(rightPanelgObj.gameObject, "gsuittd");
            f16GsuitTDparent = PickupAllChildrensTransforms(f16GsuitTD.gameObject, "knobTF");
            f16GsuitTDknobint = PickupAllChildrensTransforms(f16GsuitTD.gameObject, "rotatorknob3Interactable");
            f16GsuitTDintTK = CreateClickKnob("G-Suit TD (X)", f16GsuitTDknobint.gameObject, 3, f16GsuitTDparent, 90f, 0, f26RightPanelPoseBoundsComp, true, false);

            f16GSuitPull = PickupAllChildrensTransforms(rightPanelgObj.gameObject, "gsuitpull");
            f16GSuitPullparent = PickupAllChildrensTransforms(f16GSuitPull.gameObject, "knobTF");
            f16GSuitPullknobint = PickupAllChildrensTransforms(f16GSuitPull.gameObject, "rotatorknob3Interactable");
            f16GSuitPullintTK = CreateClickKnob("G Suit Pull (X)", f16GSuitPullknobint.gameObject, 7, f16GSuitPullparent, 360f, 0, f26RightPanelPoseBoundsComp, true, false);

            f16GSuitmode = PickupAllChildrensTransforms(rightPanelgObj.gameObject, "gsuitmode");
            f16GSuitmodeparent = PickupAllChildrensTransforms(f16GSuitmode.gameObject, "knobTF");
            f16GSuitmodeknobint = PickupAllChildrensTransforms(f16GSuitmode.gameObject, "rotatorknob3Interactable");
            f16GSuitmodeintTK = CreateClickKnob("G Suit Mode (X)", f16GSuitmodeknobint.gameObject, 4, f16GSuitmodeparent, 220f, 0, f26RightPanelPoseBoundsComp, true, false);

            f16GSuitVolume = PickupAllChildrensTransforms(rightPanelgObj.gameObject, "gsuittvolume");
            f16GSuitVolumeparent = PickupAllChildrensTransforms(f16GSuitVolume.gameObject, "knobTF");
            f16GSuitVolumeknobint = PickupAllChildrensTransforms(f16GSuitVolume.gameObject, "rotatorknob4Interactable");
            f16GSuitVolumeintTK = CreateSmoothKnob("G Suit Volume (X)", f16GSuitVolumeknobint.gameObject, f16GSuitVolumeparent, 200f, 0, f26RightPanelPoseBoundsComp, true);

            f16tempauto = PickupAllChildrensTransforms(rightPanelgObj.gameObject, "tempauto");
            f16tempautoparent = PickupAllChildrensTransforms(f16tempauto.gameObject, "knobTF");
            f16tempautoknobint = PickupAllChildrensTransforms(f16tempauto.gameObject, "rotatorknob11Interactable");
            f16tempautointTK = CreateClickKnob("Air Con Temp (X)", f16tempautoknobint.gameObject, 6, f16tempautoparent, 360f, 0, f26RightPanelPoseBoundsComp, true, false);

            f16airsource = PickupAllChildrensTransforms(rightPanelgObj.gameObject, "airsource");
            f16airsourceparent = PickupAllChildrensTransforms(f16airsource.gameObject, "knobTF");
            f16airsourceknobint = PickupAllChildrensTransforms(f16airsource.gameObject, "rotatorknob3Interactable");
            f16airsourceintTK = CreateClickKnob("Air Source (X)", f16airsourceknobint.gameObject, 4, f16airsourceparent, 120f, 0, f26RightPanelPoseBoundsComp, true, false);

            f16dedbright = PickupAllChildrensTransforms(rightPanelgObj.gameObject, "dedbright");
            f16dedbrightparent = PickupAllChildrensTransforms(f16dedbright.gameObject, "knobTF");
            f16dedbrightknobint = PickupAllChildrensTransforms(f16dedbright.gameObject, "rotatorknob4Interactable");
            f16dedbrightintTK = CreateClickKnob("DED Brightness", f16dedbrightknobint.gameObject,2, f16dedbrightparent, 90f, 0, f26RightPanelPoseBoundsComp, true,false);
            f16dedbrightintTK.OnSetState.AddListener(DEDPower);

            f16consolesbright = PickupAllChildrensTransforms(rightPanelgObj.gameObject, "consolesbright");
            f16consolesbrightparent = PickupAllChildrensTransforms(f16consolesbright.gameObject, "knobTF");
            f16consolesbrightknobint = PickupAllChildrensTransforms(f16consolesbright.gameObject, "rotatorknob4Interactable");
            f16consolesbrightintTK = CreateSmoothKnob("Consoles Brightness (X)", f16consolesbrightknobint.gameObject, f16consolesbrightparent, 120f, 0, f26RightPanelPoseBoundsComp, true);

            f16DriftSwitch = PickupAllChildrensTransforms(f16normalswitches.gameObject, "DriftSwitch");
            f16DriftSwitchparent = PickupAllChildrensTransforms(f16DriftSwitch.gameObject, "radioSwitch");
            f16DriftSwitchint = PickupAllChildrensTransforms(f16DriftSwitchparent.gameObject, "radioSwitchInteractable");
            f16DriftSwitchintTK = CreateSwitch("DriftSwitch (X)", f16DriftSwitchint.gameObject, f16DriftSwitchparent, 30f, 3, 0, null, false, false);

            f16RTNSEQ = PickupAllChildrensTransforms(f16normalswitches.gameObject, "RTNSEQ");
            f16RTNSEQparent = PickupAllChildrensTransforms(f16RTNSEQ.gameObject, "radioSwitch");
            f16RTNSEQint = PickupAllChildrensTransforms(f16RTNSEQparent.gameObject, "radioSwitchInteractable");
            f16RTNSEQintTK = CreateSwitch("RTN SEQ (X)", f16RTNSEQint.gameObject, f16RTNSEQparent, 30f, 2, 0, null, false, true);

            f16FLIRGain = PickupAllChildrensTransforms(f16normalswitches.gameObject, "FLIRGain");
            f16FLIRGainparent = PickupAllChildrensTransforms(f16FLIRGain.gameObject, "radioSwitch");
            f16FLIRGainint = PickupAllChildrensTransforms(f16FLIRGainparent.gameObject, "radioSwitchInteractable");
            f16FLIRGainintTK = CreateSwitch("Stores Config (X)", f16FLIRGainint.gameObject, f16FLIRGainparent, 30f, 3, 0, null, false, true);

        }

        

        private void ChangeUHFText1(int dialposition)
        {
            f16uhftext1text.text = dialposition.ToString();
        }
        private void ChangeUHFText2(int dialposition)
        {
            f16uhftext2text.text = dialposition.ToString();
        }
        private void ChangeUHFText3(int dialposition)
        {
            f16uhftext3text.text = dialposition.ToString();
        }
        private void ChangeUHFText4(int dialposition)
        {
            f16uhftext4text.text = dialposition.ToString();
        }
        private void ChangeUHFText5(int dialposition)
        {
            f16uhftext5text.text = dialposition.ToString();
        }


        private void FloodLamp(int flcc)
        {
            if (f16LampDialintTK.currentState == 1)
            {
                panelLightColorOn = new Color(1f, 1f, 1f, 1f);
                InternalLamprenderermaterial.SetColor("_EmissionColor", panelLightColorOn * 400);
                InternalLamprenderermaterial.EnableKeyword("_EMISSION");
                InternalLampLight.enabled = true;
                return;
            }

            else
            {
                InternalLamprenderermaterial.DisableKeyword("_EMISSION");
                InternalLampLight.enabled = false;
                
                return;
            }


        }
        // testing only
        private void AutoPilotSpeed(int switchState)
        {
                AutoPilot2.ToggleSpeedHold();
            

        }

        private void SwitchLandingLightsOn(int landingLightSwitchState)
        {
            landingLightLamps1 = PickupAllChildrensTransforms(frontlandinglightsf16transform.gameObject, "landingLightLower");
            landingLightLamps2 = PickupAllChildrensTransforms(frontlandinglightsf16transform.gameObject, "landingLightUpper");



            if (landingLightSwitchState == 1)
            {
                

                enableMesh(landingLightLamps1.gameObject);
                enableMesh(landingLightLamps2.gameObject);
            }
            else
            {
                disableMesh(landingLightLamps1.gameObject);
                disableMesh(landingLightLamps2.gameObject);
            }

        }

        private void HUDElementChanges()
        {
            parenttransform = PickupAllChildrensTransforms(defaultf26, "HUDCanvas");
            parentransformobj = parenttransform.gameObject;

            f16HudFontTf = PickupAllChildrensTransforms(newAircraftUnit, "GlassGaugeFont");
            f16HudFont = f16HudFontTf.GetComponent<Text>();
            f26CMSChaffIndicTextVTT.font = f16HudFont.font;
            f26CMSFlareIndicTextVTT.font = f16HudFont.font;
            f26CMSChaffIndicTextVTT.fontSize = 72;
            f26CMSFlareIndicTextVTT.fontSize = 72;

            F16Debug.Log("f16 Hud font : " + f16HudFont.font.name);



            HUDCanvasElements = parenttransform.GetComponentsInChildren(typeof(Text),true);

            foreach (Text HUDCanvasItems in HUDCanvasElements)
            {
                
                F16Debug.Log("Hud Item : " + HUDCanvasItems.name + ", Hud Item font: " + HUDCanvasItems.font.name);
                HUDCanvasItems.font = f16HudFont.font;
                HUDCanvasItems.fontSize = Convert.ToInt32( HUDCanvasItems.fontSize*1);
                F16Debug.Log("Hud Item After : " + HUDCanvasItems.name + ", Hud Item font: " + HUDCanvasItems.font.name);

            }

            f26MFDLeftTextElements = f26MFDLeft.GetComponentsInChildren(typeof(Text),true);
            f26MFDRightTextElements = f26MFDRight.GetComponentsInChildren(typeof(Text), true);
            f26MiniMFDLeftTextElements = MiniMFDLeft.GetComponentsInChildren(typeof(Text), true);

            foreach (Text HUDCanvasItems in f26MFDLeftTextElements)
            {
                if (!HUDCanvasItems.IsActive())
                {
                   
                }
                else
                {
                    F16Debug.Log("Hud Item : " + HUDCanvasItems.name + ", Hud Item font: " + HUDCanvasItems.font.name);
                    HUDCanvasItems.font = f16HudFont.font;
                    HUDCanvasItems.fontSize = Convert.ToInt32(HUDCanvasItems.fontSize * 1);
                    F16Debug.Log("Hud Item After : " + HUDCanvasItems.name + ", Hud Item font: " + HUDCanvasItems.font.name);
                }
            }
            foreach (Text HUDCanvasItems in f26MFDRightTextElements)
            {
                if (!HUDCanvasItems.IsActive())
                {
                    
                }
                else
                {
                    F16Debug.Log("Hud Item : " + HUDCanvasItems.name + ", Hud Item font: " + HUDCanvasItems.font.name);
                    HUDCanvasItems.font = f16HudFont.font;
                    HUDCanvasItems.fontSize = Convert.ToInt32(HUDCanvasItems.fontSize * 1);
                    F16Debug.Log("Hud Item After : " + HUDCanvasItems.name + ", Hud Item font: " + HUDCanvasItems.font.name);

                }
            }
                foreach (Text HUDCanvasItems in f26MiniMFDLeftTextElements)
            {
                HUDCanvasItems.gameObject.SetActive(true);
                F16Debug.Log("Hud Item : " + HUDCanvasItems.name + ", Hud Item font: " + HUDCanvasItems.font.name);
                HUDCanvasItems.font = f16HudFont.font;
                HUDCanvasItems.fontSize = Convert.ToInt32(HUDCanvasItems.fontSize * 1);
                F16Debug.Log("Hud Item After : " + HUDCanvasItems.name + ", Hud Item font: " + HUDCanvasItems.font.name);

            }


            //AltitudeLadder = PickupAllChildrensTransforms(parentransformobj, "AltMask2");
            //AltitudeLadder.localScale = new Vector3(1f, 1f, 1f);
            //AltitudeLadder.localPosition = new Vector3(303f, -162f, 0f);
            //AltitudeBox = PickupAllChildrensTransforms(parentransformobj, "AltBox");
            //AltitudeBox.localPosition = new Vector3(314f, -166f, 0f);
            //AltitudeModeBox = PickupAllChildrensTransforms(parentransformobj, "AltModeBox");
            //AltitudeModeBox.localPosition = new Vector3(218f, -166f, 0f);
            AirspeedTransform = PickupAllChildrensTransforms(parentransformobj, "AirSpeed");
            MachTransform = PickupAllChildrensTransforms(parentransformobj, "MachMeter");
            GmeterTransform = PickupAllChildrensTransforms(parentransformobj, "GMeter");
            HeadingtextTransform = PickupAllChildrensTransforms(parentransformobj, "Heading");
            weaponsublabelTransform = PickupAllChildrensTransforms(parentransformobj, "SubLabel");
            weaponInfoTransform = PickupAllChildrensTransforms(parentransformobj, "WeaponInfo");
            weaponlabelTransform = PickupAllChildrensTransforms(weaponInfoTransform.gameObject, "Label");
            weaponlabelTransformtext = weaponlabelTransform.GetComponent<Text>();
            weaponlabelTransformtext.enabled = false;
            weaponAmmocountlabelTransform = PickupAllChildrensTransforms(parentransformobj, "AmmoCount");
            alphaTransform = PickupAllChildrensTransforms(parentransformobj, "AlphaMeter");
            alphaTransform.gameObject.SetActive(false);
            verticalvelTransform = PickupAllChildrensTransforms(parentransformobj, "VerticalVel");
            verticalvelTransform.gameObject.SetActive(false);

            AirspeedTransform.localPosition = new Vector3(-377.5f, -105.75f, -61.5f);
            F16Debug.Log("HEC1");
            MachTransform.localPosition = new Vector3(-267.75f, -217.75f, 0f);
            F16Debug.Log("HEC2");
            GmeterTransform.localPosition = new Vector3(-261.75f, 29f, 44.25f);
            F16Debug.Log("HEC3");
            HeadingtextTransform.localPosition = new Vector3(0.85f, -317.0518f, 0.5f);
            F16Debug.Log("HEC4");
            F16Debug.Log("HEC5");
            weaponsublabelTransform.localPosition = new Vector3(-251.4f, -282.201f, 0f);
            F16Debug.Log("HEC6");
            weaponAmmocountlabelTransform.localPosition = new Vector3(-251.4f, -282.201f, 0f);
        }

        private IEnumerator UpdateInstruments()
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (!AircraftLoaded) { yield break; }
            //F16Debug.Log("ui1");
            instrumentsupdateflag = true;
            //F16Debug.Log("ui2");

            StartCoroutine(Controlsurfacemovers());
            //F16Debug.Log("ui3");
            StartCoroutine(updateAOAGauge());
            //F16Debug.Log("ui4");
            instrumentsupdateflag = false;


            yield return null;
        }
       
    private IEnumerator updaterightHydraulics()
{
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (airbrakeobj == null) { yield break; }
            if (engineheat == 0) { yield break; }
            if (!AircraftLoaded) { yield break; }
            yield return new WaitForSecondsRealtime(20f);
            if (RightWingHealthStatus == 0)
            {
                AngleRightHydraulics = new Vector3(-135f, 0f, 29f);
                Hydraulicsrightneed.localEulerAngles = AngleRightHydraulics;
                F16Debug.Log("RightWing Destroyed = " + RightWingHealthStatus);
                yield break;
            }
            if (RightWingHealthStatus < 50)
            {
                AngleRightHydraulics = new Vector3(-135f, 0f, 139f);
                Hydraulicsrightneed.localEulerAngles = AngleRightHydraulics;
                F16Debug.Log("RightWing Damaged = " + RightWingHealthStatus);
                yield break;
            }
            else
            {
                AngleRightHydraulics = new Vector3(-135f, 0f, 265f);
                Hydraulicsrightneed.localEulerAngles = AngleRightHydraulics;
                F16Debug.Log("RightWing Normal = " + RightWingHealthStatus);
                yield break;
            }



        }

       

        private IEnumerator refuelIndexerlights(RefuelPort port)
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (airbrakeobj == null) { yield break; }
            if (!AircraftLoaded) { yield break; }

            F16Debug.Log("Starting RFI");
            if(!port.open)
            {
                F16Debug.Log("Starting RFI port null");

                refuelDisconnectLight_light.enabled = true;
                refuelReadyLight_light.enabled = false;
                refuelLatchedLight_light.enabled = false;
                yield break;
            }
            if (port.currentRefuelPlane == null)
            {
                F16Debug.Log("Starting RFI plane null");

                refuelDisconnectLight_light.enabled = false;
                refuelReadyLight_light.enabled = true;
                refuelLatchedLight_light.enabled = false;
                yield break;

            }
            refuelDisconnectLight_light.enabled = false;
            refuelReadyLight_light.enabled = false;
            refuelLatchedLight_light.enabled = true;

            yield break;
        }

        private IEnumerator updateleftHydraulics()
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (airbrakeobj == null) { yield break; }
            if (engineheat == 0) { yield break; }
            if (!AircraftLoaded) { yield break; }
            F16Debug.Log("Checking Wing Status ");
            yield return new WaitForSecondsRealtime(20f);
            if (LeftWingHealthStatus == 0)
            {
                AngleLeftHydraulics = new Vector3(-135f, 0f, 29f);
                Hydraulicsleftneed.localEulerAngles = AngleLeftHydraulics;
                F16Debug.Log("LeftWing Destroyed = " + LeftWingHealthStatus);
                yield break;
            }
            if (LeftWingHealthStatus < 50)
            {
                AngleLeftHydraulics = new Vector3(-135f, 0f, 139f);
                Hydraulicsleftneed.localEulerAngles = AngleLeftHydraulics;
                F16Debug.Log("LeftWing Damaged = " + LeftWingHealthStatus);
                yield break;
            }
            else
            {
                AngleLeftHydraulics = new Vector3(-135f, 0f, 265f);
                Hydraulicsleftneed.localEulerAngles = AngleLeftHydraulics;
                F16Debug.Log("LeftWing Normal = " + LeftWingHealthStatus);
                yield break;
            }

            

        }



        private IEnumerator CheckForPlaneRespawnMPtimer()
        {
            //F16Debug.Log("mploaded = " + mploaded);
            if (mploaded == false || mploaded == null) { yield break; }
            if (leftEngineVar.maxThrust == 177f) { yield break; }
            for (; ; )
            {
                F16Debug.Log("CheckForPlaneRespawnMPtimer start");
                Setuprunning = true;
                CheckForPlaneRespawnMP();

                yield return new WaitForSecondsRealtime(5f);
             

                F16Debug.Log("CheckForPlaneRespawnMP returned");

                Setuprunning = false;
            }
        }

        void CheckForPlaneRespawnMP()
        {
           /* currentTime = DateTime.Now;

            timeNow = currentTime.ToString("HH:mm:ss\\Z");
            F16Debug.Log(timeNow + " : CFPR Step1 : " + Spawncount);
            

            f26playerobject = VTOLAPI.GetPlayersVehicleGameObject();
            if (f26playerobject == null) { return; }

            f26playerobjectBody = PickupAllChildrensTransforms(f26playerobject,"body");
            F16Debug.Log("CFPR Step3");
            f26playerobjectBodyMesh = f26playerobjectBody.GetComponent<MeshFilter>();
            F16Debug.Log("CFPR Step4 Body Mesh Name = " + f26playerobjectBodyMesh.sharedMesh.name);

            if (f26playerobjectBodyMesh.sharedMesh.name == "body_livery" )
            {
                F16Debug.Log("mp spawn check");

                                {
                    waitVar = 0.3f;
                    F16Debug.Log("StartCoroutine(InitWaiter());");
                    StartCoroutine(InitWaiter());


                }
            }
            F16Debug.Log("not body_livery");

            return;*/

        }

        private IEnumerator updateAOAGauge()
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            yield return new WaitForSecondsRealtime(2f);
            if(!AircraftInfo.AircraftSelected) { yield break; }
            if (!AircraftLoaded) { yield break; }
            if (airbrakeobj == null) { yield break; }
            if (attitude.airspeed <5f) { yield break; }



            
            aoavalue = attitude.aoa;


            F16Debug.Log("aoavalue " + aoavalue );

            if (aoavalue < 11)
            {
                foreach (Light currenteleclight in aoaYellowLight_lights)
                {
                    currenteleclight.enabled = true;
                }
                F16Debug.Log("aoayellowlight = true");
                foreach (Light currenteleclight in aoaRedLight_lights)
                {
                    currenteleclight.enabled = false;
                }
                F16Debug.Log("aoaredlight = false");
                foreach (Light currenteleclight in aoaGreenLight_lights)
                {
                    currenteleclight.enabled = false;
                }
                F16Debug.Log("aoaGreenlight = false");
            }
            if (aoavalue > 11 && aoavalue < 15)
            {
                foreach (Light currenteleclight in aoaYellowLight_lights)
                {
                    currenteleclight.enabled = false;
                }
                F16Debug.Log("aoayellowlight = false" );
                foreach (Light currenteleclight in aoaRedLight_lights)
                {
                    currenteleclight.enabled = false;
                }
                F16Debug.Log("aoaredlight = false");
                foreach (Light currenteleclight in aoaGreenLight_lights)
                {
                    currenteleclight.enabled = true;
                }
                F16Debug.Log("aoaGreenlight = true");

            }

            if (aoavalue >15)
            {
                foreach (Light currenteleclight in aoaYellowLight_lights)
                {
                    currenteleclight.enabled = false;
                }
                F16Debug.Log("aoayellowlight = false");
                foreach (Light currenteleclight in aoaRedLight_lights)
                {
                    currenteleclight.enabled = true;
                }
                F16Debug.Log("aoaredlight = true");
                foreach (Light currenteleclight in aoaGreenLight_lights)
                {
                    currenteleclight.enabled = false;
                }
                F16Debug.Log("aoaGreenlight = false");

            }

            F16Debug.Log("AOA = " + aoavalue);
           
            AOAGaugeAngle = (aoavalue*(-26.5f/10)) - 15;
            AOAGauge.localEulerAngles = new Vector3(-90f, 0f, AOAGaugeAngle);
        }


        private IEnumerator updateHeat()
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (!AircraftLoaded) { yield break; }
            if (airbrakeobj == null || VTOLAPI.currentScene == VTOLScenes.VehicleConfiguration) { yield break; }
            yield return new WaitForSecondsRealtime(15f);
            engineheat = heatemitter.heat;


            F16Debug.Log("Engine Heat = " + engineheat);
            realengineheat = engineheat * 0.36f;
            ftitneedleangle = (realengineheat * 0.28f) + ftitnatzero;
            ftitneedle.localEulerAngles = new Vector3(-15f, 180f, ftitneedleangle);
        }


        private IEnumerator updateCockpitPressure()
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (!AircraftLoaded) { yield break; }
            if (airbrakeobj == null || VTOLAPI.currentScene == VTOLScenes.VehicleConfiguration) { yield break; }
            yield return new WaitForSecondsRealtime(20f);
            F16Debug.Log("Altitude ASL = " + attitude.altitudeASL);

            

           if (attitude.altitudeASL < 7000f)
            { cockpitPressure = 8f; }
            else
            {
                cockpitPressure = (float) Math.Sqrt(attitude.altitudeASL *3.33 )*1.5f / 1000 + 8f;
            }
            if (attitude.altitudeASL < 2000f) { cockpitPressure = attitude.altitudeASL * 3.33f / 1000; }

                F16Debug.Log("Cockpit Press = " + cockpitPressure);


            cabinpressneedleangle = (cockpitPressure * (61 / 10)) + cabinpressatzero;
            cabinpressneedle.localEulerAngles = new Vector3(-45f, -180f, cabinpressneedleangle);

        }


        private IEnumerator updateRPM()

        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (!AircraftLoaded) { yield break; }

            if (f26RPMneedle == null || VTOLAPI.currentScene == VTOLScenes.VehicleConfiguration) { yield break; }
            yield return new WaitForSecondsRealtime(2f);

            F16Debug.Log("RPM Updater 1");
            currentRPM = f26RPMneedle.localEulerAngles.y;
            maxRPM = 180f;
            F16Debug.Log("RPM Updater 2 -" + currentRPM );

            f16RPMAngle = (currentRPM - 85f) * 1.2f;


            rpmNeedle.localEulerAngles = new Vector3(-15f, -180f, f16RPMAngle);

            }

        private IEnumerator nozzleposition()

        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (!AircraftLoaded) { yield break; }

            if (F26Nozzle == null || VTOLAPI.currentScene == VTOLScenes.VehicleConfiguration) { yield break; }
            yield return new WaitForSecondsRealtime(5f);

            F16Debug.Log("Nozzle Updater 1");
            currentNozzleAngle = F26Nozzle.localEulerAngles.x;
            if (currentNozzleAngle < 10f) { currentNozzleAngle = 360 - currentNozzleAngle; }

            F16Debug.Log("Nozzle Updater 2 - " + currentNozzleAngle);

            currentNozzleAngleDifference = currentNozzleAngle - 349.4f;

            Nozzlepercentage = 1-(currentNozzleAngleDifference / 10.7f);

            F16Debug.Log("Nozzle Percentage - " + Nozzlepercentage);



            F16Debug.Log("Nozzle needle default Angle - " + nozzleNeedleDefault);
            f16NozzleinstrumentAngle = nozzleNeedleDefault + (Nozzlepercentage * 250);
            F16Debug.Log("Nozzle Instrument Angle - " + f16NozzleinstrumentAngle);

            


            nozzleNeedle.localEulerAngles = new Vector3(-165f, -1.525f, f16NozzleinstrumentAngle);



        }


        private void HelperLights(int switchState)
        {
            if (switchState == 0)
            {
                disableMesh(HelpLightsHolder.gameObject);
            }
            else

            {
                enableMesh(HelpLightsHolder.gameObject);
            }
        }


        private IEnumerator updateFuel()
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (!AircraftLoaded) { yield break; }
            yield return new WaitForSecondsRealtime(20f);
            if (VTOLAPI.currentScene == VTOLScenes.VehicleConfiguration || BatteryLever.currentState == 0 || BatteryLever == null) { yield break; }
            foreach (var tank in fuelTanks)
            {
                if (tank == null) { yield break; }
                F16Debug.Log("Tank = " + tank.name);
                F16Debug.Log("Main Tank Fuel Fraction  = " + tank.fuelFraction);



                currentfuelvalue = tank.fuelFraction * tank.maxFuel;
                F16Debug.Log("Main Tank Needle Zero angle  = " + fuelMNatZero);


                mainneedleangle = (currentfuelvalue * 0.058f) + fuelMNatZero;
                F16Debug.Log("Main Tank Needle  angle  = " + mainneedleangle);


                fuelMainNeedle.localEulerAngles = new Vector3 (-135f, -1.525f, mainneedleangle);


                F16Debug.Log("Main Tank Current Fuel = " + tank.name + " : " + currentfuelvalue);

               
                externalfueltanks = tank.subFuelTanks;
                i = 0;
                foreach (var subtank in externalfueltanks)
                {
                    currentfuelvalue = subtank.fuelFraction * subtank.maxFuel;
                    F16Debug.Log("Tank Current Fuel = " + subtank.name + " : " + currentfuelvalue);


                    switch (i)
                    {
                        case 0:
                            F16Debug.Log("Left Tank Needle Zero angle  = " + fuelLNatZero);

                            leftneedleangle = (currentfuelvalue * 0.058f) + fuelLNatZero;
                            F16Debug.Log("Left Tank Needle angle  = " + leftneedleangle);
                            fuelLeftNeedle.localEulerAngles = new Vector3(-135f, -1.525f, leftneedleangle);
                            break;
                        case 1:
                            rightneedleangle = (currentfuelvalue * 0.058f) + fuelrnatzero;

                            F16Debug.Log("Right Tank Needle Zero angle  = " + fuelrnatzero);
                            fuelRightNeedle.localEulerAngles = new Vector3(-135f, -1.525f, rightneedleangle);
                            F16Debug.Log("Right Tank Needle angle  = " + rightneedleangle);
                            break;
                        case 2:
                            underneedleangle = (currentfuelvalue * 0.058f) + fuelunatzero;
                            F16Debug.Log("Under Tank Needle Zero angle  = " + fuelunatzero);
                            fuelUnderNeedle.localEulerAngles = new Vector3(-135f, -1.525f, underneedleangle);
                            F16Debug.Log("Under Tank Needle angle  = " + rightneedleangle);
                            break;
                    }
                    i++;
                }
            }


            yield return null;
        }

        // Function not needed at the moment so removing it, but possibly useful in future
        /* 
        private IEnumerator DragatSpeed()
        {
            if (VTOLAPI.currentScene == VTOLScenes.VehicleConfiguration || BatteryLever.currentState == 0) { yield break; }

            Altitude = attitude.altitudeASL;
            F16Debug.Log("Altitude = " + Altitude);
            vector = sd.rb.worldCenterOfMass + sd.rb.transform.TransformVector(sd.offsetFromCoM);
            MachInternal = MeasurementManager.SpeedToMach(sd.rb.GetPointVelocity(vector).magnitude, Altitude);
            F16Debug.Log("Mach = " + MachInternal);
            

            if (MachInternal < 0.77f && MachInternal > 0.375f)
            {
                
                sd.area = 0.15f;

            }
           else if (MachInternal > 1f)
                {
                sd.area = 0.15f;

            }
           else
            {
                //sd.area = (0.3064f * (MachNumber * MachNumber)) - (0.2335f * MachNumber) + 0.0275f + (Altitude / 150000f);
                //sd.area = (0.3064f * (MachNumber * MachNumber)) - (0.2335f * MachNumber) + 0.0275f;
                 sd.area = 0.15f;
                }
            F16Debug.Log("SimpleDragArea = " + sd.area);
            
            DragOutput =  0.5f * AerodynamicsController.fetch.AtmosDensityAtPosition(defaultf26.transform.position) * AerodynamicsController.fetch.DragMultiplierAtSpeed(sd.rb.GetPointVelocity(vector).magnitude, defaultf26.transform.position);

           

            F16Debug.Log("Drag Multiplier = " + DragOutput+ ", TotalDrag = " + DragOutput * sd.area + ", Mach = "+ MachNumber);
            
        }
        */


        private IEnumerator updateCompass()
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (!AircraftLoaded) { yield break; }
            yield return new WaitForSecondsRealtime(2f);

            if (airbrakeobj == null) { yield break; }
            if (!PlaneSetupDone) { yield break; }
            currentHeading = attitude.heading;

            
            
                F16Debug.Log("Updating compass");
                
               

                positionToMoveCompassNeedleTo = 360f - currentHeading + 6.54f ;
                F16Debug.Log("got compass and heading");

                compassBlock.localEulerAngles = new Vector3(-81.57101f, -82.692f, positionToMoveCompassNeedleTo);
                


            
            yield return null;
        }

        private void DEDPower(int DEDswitch)
        {
            if (BatteryLever.currentState == 1 & DEDswitch == 1)
            {
                f16DED.gameObject.SetActive(true);
                return;
            }
            f16DED.gameObject.SetActive(false);



        }

        private IEnumerator DEDElements()
        {
            //F16Debug.unityLogger.logEnabled = F16Debugbool;
            F16Debug.Log("ded1 ");
            if (!AircraftLoaded) { yield break; }
            if (f16DEDLine3RTM != null)
            {
                F16Debug.Log("ded2 ");
                f16DEDLine4LTM.text = "VS = " + attitude.verticalSpeed.ToString().Substring(0, 4) + "M/S";
                
            }
            F16Debug.Log("ded3 ");
            if (MPActive == true)
            {
                F16Debug.Log("ded4 ");
                F16Debug.Log("UHF: ");

                MPRadioFrequencyDED();

            }
            
            else
            {
                if (f16uhftext1text == null) { yield break; }
                F16Debug.Log("ded5 ");
                noMPDEDRadioText = f16uhftext1text.text + f16uhftext2text.text + f16uhftext3text.text + "." + f16uhftext4text.text + f16uhftext5text.text;
                F16Debug.Log("ded6 ");
                f16DEDLine2LTM.text = "UHF: " + noMPDEDRadioText + " HZ";
                F16Debug.Log("ded7 ");
            }
            yield return null;
        }

        private void MPRadioFrequencyDED()
        {
            f16DEDLine2LTM.text = "UHF: " + CUSTOM_API.currentFreq + " HZ";
        }

        private IEnumerator updateClock()
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            yield return new WaitForSecondsRealtime(60f);
            if (!AircraftLoaded) { yield break; }
            if (airbrakeobj == null) { yield break; }
            if (!PlaneSetupDone) { yield break; }
            currentTime = DateTime.Now;

            timeNow = currentTime.ToString("HH:mm:ss\\Z");
            currentHour = currentTime.Hour;
            currentMinute = currentTime.Minute;
            if (f16DEDLine3RTM != null) {
                F16Debug.Log("found text mesh");
                f16DEDLine3RTM.text = timeNow;
                
            }
            



            if (currentMinute % 2 == 0)
            {

                if (f16DEDLine3RTM != null)
                {
                    F16Debug.Log("found text mesh");
                    f16DEDLine3RTM.text = timeNow;
                }
                positionToMoveMinuteNeedleTo = (currentMinute * 6) + 90;
                positionToMoveHourNeedleTo = (currentHour * 30) - 90;

                minuteNeedle.localEulerAngles = new Vector3 (-135,0,positionToMoveMinuteNeedleTo);
                hourNeedle.localEulerAngles = new Vector3(-45, 180, positionToMoveHourNeedleTo);

                
            }
            yield return null;
        }

        public IEnumerator Timeout()
        {
            yield return new WaitForSecondsRealtime(0.5f);

        }

        

        //this function allows me to find all elements with a name containing string and return that list
        public List<GameObject> Namecontains(string searchfortext, Transform Objectsearchinginside)
        {
            F16Debug.Log("Started NameContains for " + Objectsearchinginside.ToString() + " = " + searchfortext);

            if (Objectsearchinginside.name == searchfortext)
            {
                
                nameofthing = Objectsearchinginside.name;
                F16Debug.Log("Adding name to list: " + nameofthing);
                ListOfObjectsWithName.Add(Objectsearchinginside.gameObject);
                F16Debug.Log("next step");
                F16Debug.Log("Added name to list: " + Objectsearchinginside.name);
            }
            // now search in its children, grandchildren etc.
            foreach (Transform childelement in Objectsearchinginside)
            {
                F16Debug.Log("Started NameContains for grandchildren: " + childelement.ToString() + " = " + searchfortext);
                Namecontains(searchfortext, childelement);
                
            }
            return ListOfObjectsWithName;
        }

        private void ElecPowerLightsOn()
        {
            F16Debug.Log("Elec Powe Lights On");

            allElecPowerLights = PickupAllChildrensTransforms(newAircraftUnit, "ElectricsStartupLights").gameObject;
            allElecPowerLightsArrayOfLights = allElecPowerLights.GetComponentsInChildren(typeof(Light));

            foreach (Light currenteleclight in allElecPowerLightsArrayOfLights)
            {
                currenteleclight.enabled = true;
            }

        }

        private void ElecPowerLightsOff()
        {
            F16Debug.Log("Elec Powe Lights On");

            allElecPowerLights = PickupAllChildrensTransforms(newAircraftUnit, "ElectricsStartupLights").gameObject;
            allElecPowerLightsArrayOfLights = allElecPowerLights.GetComponentsInChildren(typeof(Light));

            foreach (Light currenteleclight in allElecPowerLightsArrayOfLights)
            {
                currenteleclight.enabled = false;
            }

        }


        private void IntakeLights(int nlo)
        {
            if (nlo == 1)
            {
                IntakeLightLeftLightComp.enabled = true;
                F16Debug.Log("IL1");
                IntakeLightRightLightComp.enabled = true;
                F16Debug.Log("IL2");
                tailLightComp.enabled = true;
                F16Debug.Log("IL3");
                tailLightCompRendererMaterial.EnableKeyword("_EMISSION");
                F16Debug.Log("IL4");
            }
            else
            {
                IntakeLightLeftLightComp.enabled = false;
                F16Debug.Log("IL5");
                IntakeLightRightLightComp.enabled = false;
                F16Debug.Log("IL6");
                tailLightComp.enabled = false;
                F16Debug.Log("IL7");
                tailLightCompRendererMaterial.DisableKeyword("_EMISSION");
                F16Debug.Log("IL8");
            }
        }

        private void InternalLightsCheckState(int ilcst)
        {
            //FlightLogger.Log("Internal Lights Check Triggered");
            if (ilcst == 1)
            {
                F16Debug.Log("Internal Lights  Check State = 1");
                //FlightLogger.Log("Internal Lights Check State = 1");
                CustomInternalLightsOn();
            }
            else
            {

                F16Debug.Log("Internal Lights  Check State = 0");
                //FlightLogger.Log("Internal Lights Check State = 0");

                CustomInternalLightsOff();
            }

        }

        private void CustomInternalLightsOn()
        {
            F16Debug.Log("Turn Internal Lights On");
            //foreach (Light currentlight in allinstrumentslights)
            //{
            //    currentlight.enabled = true;
            //}
            panelLightColorOn = new Color(0.45f, 1f, 0f, 1f);
            leftPanelRendererMaterial.color = panelLightColorOn;
            rightpanelrenderermaterial.color = panelLightColorOn;
            rightauxpanelrenderermaterial.color = panelLightColorOn;
            frontcentrepanelrenderermaterial.color = panelLightColorOn;
            frontupperpanelrenderermaterial.color = panelLightColorOn;
            leftauxpanelrenderermaterial.color = panelLightColorOn;
            frontsightpanelrenderermaterial.color = panelLightColorOn;
            rightAuxInstrumentsHydraulics.SetColor("_EmissionColor", panelLightColorOn * 2);
            rightAuxInstrumentsHydraulics.EnableKeyword("_EMISSION");
            rightAuxInstrumentsFuel.SetColor("_EmissionColor", panelLightColorOn * 2);
            rightAuxInstrumentsFuel.EnableKeyword("_EMISSION");
            rightAuxInstrumentsOxygen.SetColor("_EmissionColor", panelLightColorOn * 2);
            rightAuxInstrumentsOxygen.EnableKeyword("_EMISSION");
            rightAuxInstrumentsClock.SetColor("_EmissionColor", panelLightColorOn * 2);
            rightAuxInstrumentsClock.EnableKeyword("_EMISSION");
            rightAuxInstrumentsCPressure.SetColor("_EmissionColor", panelLightColorOn * 2);
            rightAuxInstrumentsCPressure.EnableKeyword("_EMISSION");
            rightAuxInstrumentsEPUFuel.SetColor("_EmissionColor", panelLightColorOn * 2);
            rightAuxInstrumentsEPUFuel.EnableKeyword("_EMISSION");
            rightUpperInstrumentsRPM.SetColor("_EmissionColor", panelLightColorOn);
            rightUpperInstrumentsRPM.EnableKeyword("_EMISSION");
            rightUpperInstrumentsFTIT.SetColor("_EmissionColor", panelLightColorOn);
            rightUpperInstrumentsFTIT.EnableKeyword("_EMISSION");
            rightUpperInstrumentsOil.SetColor("_EmissionColor", panelLightColorOn);
            rightUpperInstrumentsOil.EnableKeyword("_EMISSION");
            rightUpperInstrumentsAtt2.SetColor("_EmissionColor", panelLightColorOn);
            rightUpperInstrumentsAtt2.EnableKeyword("_EMISSION");
            Compasscylindermaterial.SetColor("_EmissionColor", panelLightColorOn);
            Compasscylindermaterial.EnableKeyword("_EMISSION");
            AOAcylindermaterial.SetColor("_EmissionColor", panelLightColorOn);
            AOAcylindermaterial.EnableKeyword("_EMISSION");
            rightUpperInstrumentsNozzle.SetColor("_EmissionColor", panelLightColorOn);
            rightUpperInstrumentsNozzle.EnableKeyword("_EMISSION");
            frontPanelICFMat.SetColor("_EmissionColor", panelLightColorOn);
            frontPanelICFMat.EnableKeyword("_EMISSION");
            contr4KnobMaterial.SetColor("_EmissionColor", panelLightColorOn);
            contr4KnobMaterial.EnableKeyword("_EMISSION");
            contr1KnobMaterial.SetColor("_EmissionColor", panelLightColorOn);
            contr1KnobMaterial.EnableKeyword("_EMISSION");
            controlKnobMaterial.SetColor("_EmissionColor", panelLightColorOn);
            controlKnobMaterial.EnableKeyword("_EMISSION");
            contr2KnobMaterial.SetColor("_EmissionColor", panelLightColorOn);
            contr2KnobMaterial.EnableKeyword("_EMISSION");
        }

        private void CustomInternalLightsOff()
        {
            F16Debug.Log("Turn Internal Lights Off");
            //foreach (Light currentlight in allinstrumentslights)
            //{
            //    currentlight.enabled = false;
            //}

            panelLightColorOff = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            leftPanelRendererMaterial.color = panelLightColorOff;
            F16Debug.Log("Turn Internal Lights Off 1");
            rightpanelrenderermaterial.color = panelLightColorOff;
            rightauxpanelrenderermaterial.color = panelLightColorOff;
            frontcentrepanelrenderermaterial.color = panelLightColorOff;
            frontupperpanelrenderermaterial.color = panelLightColorOff;
            F16Debug.Log("Turn Internal Lights Off2");
            leftauxpanelrenderermaterial.color = panelLightColorOff;
            F16Debug.Log("Turn Internal Lights Off21");
            frontsightpanelrenderermaterial.color = panelLightColorOff;
            F16Debug.Log("Turn Internal Lights Off22");
            rightAuxInstrumentsHydraulics.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off3");
            rightAuxInstrumentsFuel.DisableKeyword("_EMISSION");
            rightAuxInstrumentsOxygen.DisableKeyword("_EMISSION");
            rightAuxInstrumentsClock.DisableKeyword("_EMISSION");
            rightAuxInstrumentsCPressure.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off4");
            rightAuxInstrumentsEPUFuel.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off4_1");
            rightUpperInstrumentsRPM.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off4_2");
            rightUpperInstrumentsFTIT.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off51");
            rightUpperInstrumentsOil.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off52");

            rightUpperInstrumentsAtt2.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off53");

            Compasscylindermaterial.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off54");

            AOAcylindermaterial.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off55");

            rightUpperInstrumentsNozzle.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off56");
            frontPanelICFMat.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off57");
            contr4KnobMaterial.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off58");
            contr1KnobMaterial.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off59");
            controlKnobMaterial.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off60");
            contr2KnobMaterial.DisableKeyword("_EMISSION");
            F16Debug.Log("Turn Internal Lights Off61");

        }

        private IEnumerator AirbrakeCheck()
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (!PlaneSetupDone) { yield break; }
            if (airbrakeobj == null) { yield break; }
            float Mach = MeasurementManager.SpeedToMach(attitude.airspeed, attitude.altitudeASL);
            if (Mach <0.75f && Mach >0.5f)
            {

                airBrakeController.brakeDragArea = 9f ;
            }
            else if (Mach < 0.5f && Mach > 0.38f)
            {

                airBrakeController.brakeDragArea = 86602 * (float)Math.Pow(Convert.ToDouble(Mach), 13.232);
            }
            else
            {
                airBrakeController.brakeDragArea = 0.15f;
            }

            yield break;
        }

        private IEnumerator AltitudePowerAdjustment()
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (!PlaneSetupDone) { yield break; }
            yield return new WaitForSecondsRealtime(5f);
            if (airbrakeobj == null) { yield break; }
            spdMultiplier = 1f;
            if (attitude.altitudeASL < 6000f)
            {
                engMultiplier = 1f;
            }
            else if (attitude.altitudeASL < 8000f)
            {
                engMultiplier = 0.93f;
            }
            else if (attitude.altitudeASL >= 8000f)
            {
                engMultiplier = 0.9f;
                if (attitude.airspeed >= 305)
                    {
                    spdMultiplier = 1+(((attitude.airspeed - 305)*0.25f)/400);
                    F16Debug.Log("SPD Multiplier =" + spdMultiplier );
                        }
            }

            leftEngineVar.maxThrust = 120f * engMultiplier * spdMultiplier;
            rightEngineVar.maxThrust = 0f * engMultiplier;

            F16Debug.Log("currentLeftThrust =" + leftEngineVar.maxThrust + ", currentRightThrust = " + rightEngineVar.maxThrust);

            yield break;
        }

        private void ThrottleAnimatorSet(float throttle)
        {

            F16Debug.Log("throttle: " + throttle);
            
            newf16throttleangle = -115 + (50 * throttle);
            f16throttlepivot.localEulerAngles = new Vector3(newf16throttleangle,0,0);
            

        }

        private IEnumerator ThrottleIAnimator()
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (airbrakeobj == null) { yield break; }
            if (!PlaneSetupDone) { yield break; }
            throttlef26I.transform.position = f16throttletf.position;
            yield break;
        }
        private void JetSwitchCheckState(int jsst)

        {
            if (jsst == 0)
            {

                APUauxunit.SetPower(0);

            }
            else
            {

                if (jsst == 1)
                {
                    APUauxunit.SetPower(1);
                    ElecPowerLightsOff();
                }
            }



        }

        private void BattSwitchCheckState(int bsst)

        {
            if (bsst == 1)
            {
                F16Debug.Log("Batt Switch State = 1");
                //APUauxunit.SetPower(1);
                ElecPowerLightsOn();

            }
            else
            {

                if (bsst == 0)
                {
                    F16Debug.Log("Batt Switch  State = 0");
                    //APUauxunit.SetPower(0);
                    ElecPowerLightsOff();
                }
            }



        }

        public static VRTwistKnobInt CreateClickKnob(string knobName, GameObject interactable, int states,Transform knobTf, float twistRange, int initialState, PoseBounds posebounds, bool smallKnob, bool springy)
        {
            interactable.SetActive(false);
            VRInteractable knobInt = interactable.AddComponent<VRInteractable>();
            VRTwistKnobInt knob = interactable.AddComponent<VRTwistKnobInt>();

            knobInt.interactableName = knobName;
            knobInt.radius = 0.015f;
            knobInt.button = VRInteractable.Buttons.Trigger;
            knobInt.poseBounds = posebounds;
            

            knob.useCtrlrZ = true;
                       knob.quicksavePersistent = true;
            knob.knobTransform = knobTf;
            knob.initialState = initialState;
            knob.twistRange = twistRange;
            knob.smallKnob = smallKnob;
            knob.springy = springy;
                        knob.states = states;
            
            


            knob.OnSetState = new IntEvent();
            interactable.SetActive(true);

            return knob;
        }

        public static VRTwistKnob CreateSmoothKnob(string knobName, GameObject interactable, Transform knobTf, float twistRange, int startValue, PoseBounds posebounds, bool smallKnob)
        {
            interactable.SetActive(false);
            VRInteractable knobInt = interactable.AddComponent<VRInteractable>();
            VRTwistKnob knob = interactable.AddComponent<VRTwistKnob>();

            knobInt.interactableName = knobName;
            knobInt.radius = 0.02f;
            knobInt.button = VRInteractable.Buttons.Trigger;
            knobInt.poseBounds = posebounds;


            knob.quicksavePersistent = true;
            knob.knobTransform = knobTf;
            knob.startValue = startValue;
            knob.twistRange = twistRange;
            knob.smallKnob = smallKnob;
            

            knob.OnSetState = new FloatEvent();
            interactable.SetActive(true);

            return knob;
        }

        public static VRLever CreateSwitch(string switchName, GameObject interactable, Transform switchTf, float angleLimit, int states, int initState, PoseBounds posebounds, bool smallKnob, bool springy)
        {
            interactable.SetActive(false);
            VRInteractable leverInt = interactable.AddComponent<VRInteractable>();
            VRLever lever = interactable.AddComponent<VRLever>();

            leverInt.interactableName = switchName;
            leverInt.radius = 0.04f;
            leverInt.button = VRInteractable.Buttons.Trigger;
            leverInt.poseBounds = posebounds;

            lever.quicksavePersistent = true;
            lever.leverTransform = switchTf;
            lever.angleLimit = angleLimit;
            lever.initialState = initState;
            lever.states = states;
            lever.springy = springy;
            lever.fireEventOnStart = true;
            lever.OnSetState = new IntEvent();
            interactable.SetActive(true);

            return lever;
        }

        private void FlapLeverCheckState(int flst)
        {
            if (flst == 1)
            {
                F16Debug.Log("Flaps Switch State = 1");
                landingflapposition = 10f;


            }
            else
            {

                if (flst == 0)
                {
                    F16Debug.Log("Flaps Switch State = 0");
                    landingflapposition = 0f;
                }
                else
                {


                    F16Debug.Log("Flaps Switch State = 2");
                    landingflapposition = 20f;

                }
            }



        }

        private void LandingGearPreCheck(int lgc)
        {
            F16Debug.Log("lgc = " + lgc);
            if (landinggearcount == 0)
            {
                if (lgc == 1) {
                    LandingGearLightCylMat.DisableKeyword("_EMISSION");
                }
                landinggearcount = 1;
                return;
            }

            LandingGearCheckState(lgc);
            f26landinggearintlever.RemoteSetState(lgc);

        }

        private void LandingGearCheckState(int lgcst)
        {
            F16Debug.Log("Landing Gear Check State1");
            F16Debug.Log("lgcst = " + lgcst);
            if (f16landinggearleverVRL.currentState == 1)
            {
                F16Debug.Log("Landing Gear Check State = 1");
                LandingFlapsLeverObject = PickupAllChildrensTransforms(defaultf26, "FlapsLever").gameObject;
                VRLever FlapsLeverCheck = LandingFlapsLeverObject.GetComponentInChildren<VRLever>();
                FlapsLeverCheck.RemoteSetState(0);
                F16Debug.Log("F26 Landing Gear State 4 = " + f26landinggearintlever.currentState);
                F16Debug.Log("f16 Landing Gear State 4 = " + f16landinggearleverVRL.currentState);
                LandingGearRaiseTimeMover();
                LandingGearLightCylMat.DisableKeyword("_EMISSION");

                F16Debug.Log("F26 Landing Gear State 5 = " + f26landinggearintlever.currentState);
                F16Debug.Log("f16 Landing Gear State 5 = " + f16landinggearleverVRL.currentState);
            }
            else
            {
                F16Debug.Log("Landing Gear count = " + landinggearcount);
                F16Debug.Log("Landing Gear Check State = 0");
                
                LandingFlapsLeverObject = PickupAllChildrensTransforms(defaultf26, "FlapsLever").gameObject;
                VRLever FlapsLeverCheck = LandingFlapsLeverObject.GetComponentInChildren<VRLever>();
                FlapsLeverCheck.RemoteSetState(1);
                F16Debug.Log("F26 Landing Gear State 6 = " + f26landinggearintlever.currentState);
                F16Debug.Log("f16 Landing Gear State 6 = " + f16landinggearleverVRL.currentState);
                LandingGearLowerTimeMover();
                LandingGearLightCylMat.EnableKeyword("_EMISSION");

            }

        }

        public void LandingGearLowerTimeMover()
        {
            // we cant call the IENumerator directly so we call this first
            StartCoroutine(LandingGearCoverLowerRotation());
        }

        public void LandingGearRaiseTimeMover()
        {
            // we cant call the IENumerator directly so we call this first
            StartCoroutine(LandingGearRaiseRotation());
        }

        private IEnumerator LandingGearRaiseRotation()
        {
            //this sets the angles and things to rotate
            float counter = 0;
            F16Debug.Log("Starting landing gear Rot7: " + counter);

            
            f16leftgeardown = new Vector3(30.5f, 0, 0);
            f16rightgeardown = new Vector3(-30.5f, 0, 0);
            f16frontgeardown = new Vector3(0, 0, 0);
            f16frontgearleverdown = new Vector3(0, 0, 0);
            f16leftgearcoverdown = new Vector3(10, 0, 0);
            f16rightgearcoverdown = new Vector3(-100, 0, 0);
            f16frontgearcoverdown = new Vector3(0, 0, 0);
            f16leftwheelpivotindown = new Vector3(0, 0, 0);
            f16rightwheelpivotindown = new Vector3(0, 0, 0);
            f16frontwheelpivotindown = new Vector3(0, 0, -100);

            F16Debug.Log("Default Angles = Created");
            f16leftgearup = new Vector3(30.5f,0f, -95f);
            f16rightgearup = new Vector3(-30.5f, 0f, -95f);
            f16frontgearup = new Vector3(0, 0, 108f);
            f16frontgearleverup = new Vector3(0, 140, 0);
            f16leftgearcoverup = new Vector3(-90, 0, 0);
            f16rightgearcoverup = new Vector3(0, 0, 0);
            f16frontgearcoverup = new Vector3(90, 0, 0);
            f16leftwheelpivotinup = new Vector3(0, 0, 77.6f);
            f16rightwheelpivotinup = new Vector3(0, 0, -104.1f);
            f16frontwheelpivotinup = new Vector3(20, 90, -90);


            F16Debug.Log("New Rotation created");

            //FlightLogger.Log("Canopy Rotation Starting Point ");

            //simple Lerp rotation around a point over time
            while (counter < landinggearduration)
            {

                F16Debug.Log("Starting Covers Rot8: " + counter);
                counter += Time.deltaTime;
                f16leftgear.transform.localEulerAngles = Vector3.Lerp(f16leftgeardown, f16leftgearup, counter / landinggearduration);
                f16rightgear.transform.localEulerAngles = Vector3.Lerp(f16rightgeardown, f16rightgearup, counter / landinggearduration);
                f16frontgear.transform.localEulerAngles = Vector3.Lerp(f16frontgeardown, f16frontgearup, counter / landinggearduration);
                f16frontgearlever.transform.localEulerAngles = Vector3.Lerp(f16frontgearleverdown, f16frontgearleverup, counter / landinggearduration);
                f16leftwheelpivotin.transform.localEulerAngles = Vector3.Lerp(f16leftwheelpivotindown, f16leftwheelpivotinup, counter / landinggearduration);
                f16rightwheelpivotin.transform.localEulerAngles = Vector3.Lerp(f16rightwheelpivotindown, f16rightwheelpivotinup, counter / landinggearduration);
                f16frontwheelpivotin.transform.localEulerAngles = Vector3.Lerp(f16frontwheelpivotindown, f16frontwheelpivotinup, counter / landinggearduration);
                

                yield return null;
            }
            StartCoroutine(LandingGearCoverRaiseRotation());

        }
        private IEnumerator LandingGearCoverRaiseRotation()
        {
            //this sets the angles and things to rotate
            float counter = 0;
            F16Debug.Log("Starting landing gear cover Rot7: " + counter);


            F16Debug.Log("New Rotation created");

            FlightLogger.Log("lg Rotation Starting Point ");

            //simple Lerp rotation around a point over time
            while (counter < landinggearduration)
            {

                F16Debug.Log("Starting Covers Rot8: " + counter);
                counter += Time.deltaTime;
                f16leftgearcover.transform.localEulerAngles = Vector3.Lerp(f16leftgearcoverdown, f16leftgearcoverup, counter / landinggearcoverduration);
                f16rightgearcover.transform.localEulerAngles = Vector3.Lerp(f16rightgearcoverdown, f16rightgearcoverup, counter / landinggearcoverduration);
                f16frontgearcover.transform.localEulerAngles = Vector3.Lerp(f16frontgearcoverdown, f16frontgearcoverup, counter / landinggearcoverduration);

                yield return null;
            }

        }

        private IEnumerator LandingGearLowerRotation()
        {
            //this sets the angles and things to rotate
            float counter = 0;
            F16Debug.Log("Starting landing gear lower Rot7: " + counter);


            


            F16Debug.Log("New Rotation created");

            //FlightLogger.Log("lg Rotation Starting Point ");

            //simple Lerp rotation around a point over time
            while (counter < landinggearduration)
            {

                F16Debug.Log("Starting Covers Rot8: " + counter);
                counter += Time.deltaTime;
                f16leftgear.transform.localEulerAngles = Vector3.Lerp(f16leftgearup, f16leftgeardown, counter / landinggearduration);
                f16rightgear.transform.localEulerAngles = Vector3.Lerp(f16rightgearup, f16rightgeardown, counter / landinggearduration);
                f16frontgear.transform.localEulerAngles = Vector3.Lerp(f16frontgearup, f16frontgeardown, counter / landinggearduration);
                f16frontgearlever.transform.localEulerAngles = Vector3.Lerp(f16frontgearleverup, f16frontgearleverdown,  counter / landinggearduration);
                f16leftwheelpivotin.transform.localEulerAngles = Vector3.Lerp(f16leftwheelpivotinup, f16leftwheelpivotindown, counter / landinggearduration);
                f16rightwheelpivotin.transform.localEulerAngles = Vector3.Lerp(f16rightwheelpivotinup, f16rightwheelpivotindown, counter / landinggearduration);
                f16frontwheelpivotin.transform.localEulerAngles = Vector3.Lerp(f16frontwheelpivotinup, f16frontwheelpivotindown, counter / landinggearduration);


                yield return null;
            }
            

        }
        private IEnumerator LandingGearCoverLowerRotation()
        {
            //this sets the angles and things to rotate
            float counter = 0;
            F16Debug.Log("Starting landing gear cover lower Rot7: " + counter);
            f16leftgeardown = new Vector3(30.5f, 0, 0);
            f16rightgeardown = new Vector3(-30.5f, 0, 0);
            f16frontgeardown = new Vector3(0, 0, 0);
            f16frontgearleverdown = new Vector3(0, 0, 0);
            f16leftgearcoverdown = new Vector3(10, 0, 0);
            f16rightgearcoverdown = new Vector3(-100, 0, 0);
            f16frontgearcoverdown = new Vector3(0, 0, 0);
            f16leftwheelpivotindown = new Vector3(0, 0, 0);
            f16rightwheelpivotindown = new Vector3(0, 0, 0);
            f16frontwheelpivotindown = new Vector3(0, 0, -100);

            F16Debug.Log("Default Angles = Created");
            f16leftgearup = new Vector3(30.5f, 0f, -95f);
            f16rightgearup = new Vector3(-30.5f, 0f, -95f);
            f16frontgearup = new Vector3(0, 0, 108f);
            f16frontgearleverup = new Vector3(0, 140, 0);
            f16leftgearcoverup = new Vector3(-90, 0, 0);
            f16rightgearcoverup = new Vector3(0, 0, 0);
            f16frontgearcoverup = new Vector3(90, 0, 0);
            f16leftwheelpivotinup = new Vector3(0, 0, 77.6f);
            f16rightwheelpivotinup = new Vector3(0, 0, -104.1f);
            f16frontwheelpivotinup = new Vector3(20, 90, -90);

            F16Debug.Log("New Rotation created");

            //FlightLogger.Log("Gear Rotation Starting Point ");

            //simple Lerp rotation around a point over time
            while (counter < landinggearduration)
            {

                F16Debug.Log("Starting Covers Rot8: " + counter);
                counter += Time.deltaTime;
                f16leftgearcover.transform.localEulerAngles = Vector3.Lerp(f16leftgearcoverup, f16leftgearcoverdown, counter / landinggearcoverduration);
                f16rightgearcover.transform.localEulerAngles = Vector3.Lerp(f16rightgearcoverup, f16rightgearcoverdown, counter / landinggearcoverduration);
                f16frontgearcover.transform.localEulerAngles = Vector3.Lerp(f16frontgearcoverup, f16frontgearcoverdown, counter / landinggearcoverduration);

                yield return null;
            }
            StartCoroutine(LandingGearLowerRotation());
        }




        private void CanopyCheckState(int st)
        {
            //FlightLogger.Log("Canopy Check Triggered");
            if (st == 1)
            {
                F16Debug.Log("Canopy Switch State = 1");
                foreach (Light light in CanopyLights)
                {
                    light.enabled = true;

                }
                //FlightLogger.Log("Canopy Check Switch State = 1");
                NewOpenCanopyAnimation();
            }
            else
            {
                
                    F16Debug.Log("Canopy Switch State = 0");
                //FlightLogger.Log("Canopy Check Switch State = 0");
                foreach (Light light in CanopyLights)
                {
                    light.enabled = false;

                }
                NewCloseCanopyAnimation();
            }



        }

        public void NewOpenCanopyAnimation()
        {
            f16CanopyAnimator.Play("Canopyopen");
        }

        public void NewCloseCanopyAnimation()
        {
            f16CanopyAnimator.Play("Canopyclose");
        }


        public void CockpitRaiseTimeMover()
        {
            // we cant call the IENumerator directly so we call this first
            StartCoroutine(CockpitRaiseRotation());
        }

        private IEnumerator CockpitRaiseRotation()
        {
            //this sets the angles and things to rotate
            if (isActive)
                yield break;
            F16Debug.Log("Starting Cockpit Rot1");
            isActive = true;
            F16Debug.Log("Starting Cockpit Rot2");
            outputofcalc = cockpitPivot.eulerAngles + targetRotationopen;
            FlightLogger.Log("Canopy Lower Rotation Starting, Angle to reach = " + outputofcalc.x + "," + outputofcalc.y + "," + outputofcalc.z);


            yield return StartCoroutine(Rotatecockpit(cockpitPivot.eulerAngles + targetRotationopen)); // open the door
            F16Debug.Log("Starting Cockpit Rot3");
            
            F16Debug.Log("Starting Cockpit Rot4");
            isActive = false;
            
        }

        public void CockpitLowerTimeMover()
        {
            // we cant call the IENumerator directly so we call this first
            StartCoroutine(CockpitLowerRotation());
        }

        private IEnumerator CockpitLowerRotation()
        {
            //this sets the angles and things to rotate
            if (isActive)
                yield break;
            F16Debug.Log("Starting Cockpit Rot1");
            isActive = true;
            F16Debug.Log("Starting Cockpit Rot2");
            outputofcalc = cockpitPivot.eulerAngles - targetRotationopen;
            //FlightLogger.Log("Canopy Lower Rotation Starting, Angle to reach = " + outputofcalc.x + ","+ outputofcalc.y+","+ outputofcalc.z);
            yield return StartCoroutine(Rotatecockpit(cockpitPivot.eulerAngles - targetRotationopen)); // open the door
            F16Debug.Log("Starting Cockpit Rot3");
            

            F16Debug.Log("Starting Cockpit Rot4");
            isActive = false;

        }

        private IEnumerator Rotatecockpit(Vector3 newRotation) // cockpit rotation
        {
            float counter = 0;
            F16Debug.Log("Starting Cockpit Rot7: " + counter);

            Vector3 defaultAngles = cockpitPivot.eulerAngles;
            F16Debug.Log("Default Angles = (" + defaultAngles.x + "," + defaultAngles.y + "," + defaultAngles.z + ")");
            
            F16Debug.Log("New Rotation = (" + newRotation.x + "," + newRotation.y + "," + newRotation.z + ")");

            //FlightLogger.Log("Canopy Rotation Starting Point = " + defaultAngles.x + "," + defaultAngles.y + "," + defaultAngles.z + " : Canopy End point = " + newRotation.x + "," + newRotation.y + "," + newRotation.z + " : Will take = " + canopyduration + "s");


            //simple Lerp rotation around a point over time
            while (counter < canopyduration)
            {
                
                F16Debug.Log("Starting Cockpit Rot8: " + counter);
                counter += Time.deltaTime;
                cockpitPivot.eulerAngles = Vector3.Lerp(defaultAngles, newRotation, counter / canopyduration);
                yield return null;
            }

            }

        public void disableVTT(GameObject parent)
        {

            VTText[] VTTs = parent.GetComponentsInChildren<VTText>(true);

            foreach (VTText vtttohide in VTTs)
            {
                F16Debug.Log("Hiding VTT: " + vtttohide.ToString());
                vtttohide.enabled = false;

            }

        }


        public void disableSprites(GameObject parent)
        {

            SpriteRenderer[] Sprites = parent.GetComponentsInChildren<SpriteRenderer>(true);

            foreach (SpriteRenderer spritestohide in Sprites)
            {
                F16Debug.Log("Hiding sprites: " + spritestohide.ToString());
                spritestohide.enabled = false;

            }

        }

        public void disableImages(GameObject parent)
        {

            Image[] images = parent.GetComponentsInChildren<Image>(true);

            foreach (Image imagestohide in images)
            {
                F16Debug.Log("Hiding images: " + imagestohide.ToString());
                imagestohide.enabled = false;

            }

        }

        public void disableMesh(GameObject parent)
        {

            MeshRenderer[] meshes = parent.GetComponentsInChildren<MeshRenderer>(true);

            foreach (MeshRenderer meshtohide in meshes)
            {
                F16Debug.Log("Hiding: " + meshtohide.ToString());
                meshtohide.enabled = false;

            }

        }

        public void enableMesh(GameObject parent)
        {
            MeshRenderer[] meshes = parent.GetComponentsInChildren<MeshRenderer>(true);
            
            foreach (MeshRenderer meshtounhide in meshes)
            {
                meshtounhide.enabled = true;
                F16Debug.Log("Unhiding: " + meshtounhide.name);
            }

        }

        public void disableText(GameObject parent)
        {

            Text[] textbits = parent.GetComponentsInChildren<Text>(true);

            foreach (Text textitem in textbits)
            {
                F16Debug.Log("Hiding text: " + textitem.ToString());
                textitem.enabled = false;

            }

        }

        public void disableVRI(GameObject parent)
        {

            VRInteractable[] vribits = parent.GetComponentsInChildren<VRInteractable>(true);

            foreach (VRInteractable vriitem in vribits)
            {
                F16Debug.Log("Hiding vri: " + vriitem.ToString());
                vriitem.radius = 0f;
                vriitem.useRect = false;


            }

        }

        public void disableLineRender(GameObject parent)
        {

            UILineRenderer [] uilrbits = parent.GetComponentsInChildren<UILineRenderer>(true);

            foreach (UILineRenderer uilritem in uilrbits)
            {
                F16Debug.Log("Hiding uilr: " + uilritem.ToString());
                uilritem.enabled = false;
            }

        }

        public ParticleSystem PickupAllChildrensParticleEffects(GameObject go, string namewanted)
        {
            Transform[] allChildren = go.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                F16Debug.Log("Getting child: " + child.gameObject.name);


                if (child.gameObject.name != namewanted)
                {

                }
                else
                {
                    F16Debug.Log("Getting components");

                    GameObject childobj = child.gameObject;

                    //this just lists all the components in the system for the one we were looking for to help with fixing
                    allComponents = childobj.GetComponents(typeof(ParticleSystem));
                    i = 0;
                    foreach (ParticleSystem component in allComponents)
                    {
                        ++i;
                        F16Debug.Log(childobj.name + " Particle Systems " + i + ": " + component.name);
                        F16Debug.Log("Duration of " + component.name + " = " + component.main.duration);
                        return component;
                    }




                }



            }
            return null;
        }

        public Light PickupAllChildrensLight(GameObject go, string namewanted)
        {
            Light[] allChildren = go.GetComponentsInChildren<Light>(true);
            foreach (Light child in allChildren)
            {
                F16Debug.Log("Getting child: " + child.gameObject.name);


                if (child.gameObject.name != namewanted)
                {

                }
                else
                {
                    F16Debug.Log("Getting components");

                    GameObject childobj = child.gameObject;

                    //this just lists all the components in the system for the one we were looking for to help with fixing
                    allComponents = childobj.GetComponents(typeof(Light));
                    i = 0;
                    foreach (Light component in allComponents)
                    {
                        ++i;
                        F16Debug.Log(childobj.name + " Particle Systems " + i + ": " + component.name);

                        return component;
                    }




                }



            }
            return null;
        }



        public SpriteRenderer PickupAllChildrensSpriteRenderer(GameObject go, string namewanted)
        {
            SpriteRenderer[] allChildren = go.GetComponentsInChildren<SpriteRenderer>(true);
            foreach (SpriteRenderer child in allChildren)
            {
                F16Debug.Log("Getting child: " + child.gameObject.name);


                if (child.gameObject.name != namewanted)
                {

                }
                else
                {
                    F16Debug.Log("Getting components");

                    GameObject childobj = child.gameObject;

                    //this just lists all the components in the system for the one we were looking for to help with fixing
                    allComponents = childobj.GetComponents(typeof(SpriteRenderer));
                    i = 0;
                    foreach (SpriteRenderer component in allComponents)
                    {
                        ++i;
                        F16Debug.Log(childobj.name + " Particle Systems " + i + ": " + component.name);

                        return component;
                    }




                }



            }
            return null;
        }


        public Text PickupAllChildrensText(GameObject go, string namewanted)
        {
            Text[] allChildren = go.GetComponentsInChildren<Text>(true);
            foreach (Text child in allChildren)
            {
                F16Debug.Log("Getting child: " + child.gameObject.name);


                if (child.gameObject.name != namewanted)
                {

                }
                else
                {
                    F16Debug.Log("Getting components");

                    GameObject childobj = child.gameObject;

                    //this just lists all the components in the system for the one we were looking for to help with fixing
                    allComponents = childobj.GetComponents(typeof(Text));
                    i = 0;
                    foreach (Text component in allComponents)
                    {
                        ++i;
                        F16Debug.Log(childobj.name + " Text " + i + ": " + component.name);
                        
                        return component;
                    }




                }



            }
            return null;
        }

        public Transform PickupAllChildrensTransforms(GameObject go, string namewanted)
        {
            F16Debug.Log("Running PickupAllChildrensTransforms for : " + go +" , " + namewanted);
            Transform[] allChildren = go.GetComponentsInChildren<Transform>(true);
            foreach (Transform child in allChildren)
            {
                F16Debug.Log("Getting child: " + child.gameObject.name);


                if (child.gameObject.name != namewanted)
                {

                }
                else
                {
                    F16Debug.Log("Getting components of children");

                    GameObject childobj = child.gameObject;

                    //this just lists all the components in the system for the one we were looking for to help with fixing
                    allComponents = childobj.GetComponents(typeof(Transform));
                    i = 0;
                    foreach (Transform component in allComponents)
                    {
                        ++i;
                        F16Debug.Log(childobj.name + " Text " + i + ": " + component.name);

                        return component;
                    }




                }



            }
            return null;
        }

        private IEnumerator BrakesOpener(Vector3 newRotationlu, Vector3 newRotationll, Vector3 newRotationru, Vector3 newRotationrl) // cockpit rotation
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (airbrakeflag) { } else { 
            float counter = 0;
            float brakeduration = 1.5f;
            F16Debug.Log("Starting AirBrake Rot7: " + counter);

            Vector3 defaultAngles = new Vector3(0f,0f,0f);
            F16Debug.Log("Default Airbrake Angles = (" + defaultAngles.x + "," + defaultAngles.y + "," + defaultAngles.z + ")");

            

            //simple Lerp rotation around a point over time
            while (counter < brakeduration)
            {
                F16Debug.Log("Starting Break Open : " + counter);
                counter += Time.deltaTime;
                airbrakelefthingeupperobj.transform.localEulerAngles = Vector3.Lerp(defaultAngles, newRotationlu, counter / brakeduration);
                airbrakelefthingelowerobj.transform.localEulerAngles = Vector3.Lerp(defaultAngles, newRotationll, counter / brakeduration);
                airbrakerighthingeupperobj.transform.localEulerAngles = Vector3.Lerp(defaultAngles, newRotationru, counter / brakeduration);
                airbrakerighthingelowerobj.transform.localEulerAngles = Vector3.Lerp(defaultAngles, newRotationrl, counter / brakeduration);
                airbrakeflag = true;
                yield return null;
            }
        }
        }


        private IEnumerator BrakesCloser(Vector3 newRotationlu, Vector3 newRotationll, Vector3 newRotationru, Vector3 newRotationrl) // cockpit rotation
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (!airbrakeflag) { }
            else
            {
                float counter = 0;
                float brakeduration = 1.5f;
                F16Debug.Log("Starting AirBrake Rot7: " + counter);

                Vector3 defaultlowerAngles = new Vector3(0f, 0f, -43f);
                Vector3 defaultupperAngles = new Vector3(0f, 0f, 43f);
               


                //simple Lerp rotation around a point over time
                while (counter < brakeduration)
                {
                    F16Debug.Log("Starting Brake Close : " + counter);
                    counter += Time.deltaTime;
                    airbrakelefthingeupperobj.transform.localEulerAngles = Vector3.Lerp(defaultupperAngles, newRotationlu, counter / brakeduration);
                    airbrakelefthingelowerobj.transform.localEulerAngles = Vector3.Lerp(defaultlowerAngles, newRotationll, counter / brakeduration);
                    airbrakerighthingeupperobj.transform.localEulerAngles = Vector3.Lerp(defaultupperAngles, newRotationru, counter / brakeduration);
                    airbrakerighthingelowerobj.transform.localEulerAngles = Vector3.Lerp(defaultlowerAngles, newRotationrl, counter / brakeduration);
                    airbrakeflag = false;
                    yield return null;
                }
            }
        }

        private void wheels()
        {
            F16Debug.Log("wheels_1");
            GameObject faFrontGear = PickupAllChildrensTransforms(defaultf26, "FrontGear").gameObject;
            GameObject faLeftGear = PickupAllChildrensTransforms(defaultf26, "LeftGear").gameObject;
            GameObject faRightGear = PickupAllChildrensTransforms(defaultf26, "RightGear").gameObject;
            F16Debug.Log("wheels_2");
            f16leftgear = PickupAllChildrensTransforms(newAircraftUnit, "LeftLGmainpivot").gameObject;
            f16rightgear = PickupAllChildrensTransforms(newAircraftUnit, "RightLGmainpivot").gameObject;
            f16frontgear = PickupAllChildrensTransforms(newAircraftUnit, "FrontLGPivot").gameObject;
            f16frontgearlever = PickupAllChildrensTransforms(newAircraftUnit, "PivotforFGbacklever").gameObject;
            F16Debug.Log("wheels_3");
            f16leftgearcover = PickupAllChildrensTransforms(newAircraftUnit, "LeftMainLGCoverPivot").gameObject;
            f16rightgearcover = PickupAllChildrensTransforms(newAircraftUnit, "RightMainLGCoverPivot").gameObject;
            f16frontgearcover = PickupAllChildrensTransforms(newAircraftUnit, "frontLGcoverpivot").gameObject;
            F16Debug.Log("wheels_4");
            f16leftwheelpivotin = PickupAllChildrensTransforms(newAircraftUnit, "wheelturninpivotleft").gameObject;
            f16rightwheelpivotin = PickupAllChildrensTransforms(newAircraftUnit, "wheelturninpivotright").gameObject;
            f16frontwheelpivotin = PickupAllChildrensTransforms(newAircraftUnit, "PivotforFLGWheelTurn").gameObject;


            F16Debug.Log("wheels_5");
            gearAnim = faFrontGear.transform.parent.gameObject.GetComponent<GearAnimator>();
            Transform frontwheelpivot = PickupAllChildrensTransforms(newAircraftUnit, "frontwheelpivot");
            Transform leftwheelpivot = PickupAllChildrensTransforms(newAircraftUnit, "leftwheelpivot");
            Transform rightwheelpivot = PickupAllChildrensTransforms(newAircraftUnit, "rightwheelpivot");

            F16Debug.Log("wheels_6");
            //Wheel animations
            Transform f16FrontWheel = PickupAllChildrensTransforms(newAircraftUnit, "Whel_Lg_Front");
            SuspensionWheelAnimator faFrontWheelController = faFrontGear.GetComponent<SuspensionWheelAnimator>();
            faFrontWheelController.wheelTransform = frontwheelpivot;
            faFrontWheelController.axis = new Vector3(0, 0, 1);
            this.wheelAxisTraverse = Traverse.Create(faFrontWheelController);

            this.wheelAxisTraverse.Field("origLocalRot").SetValue(frontwheelpivot.localRotation);
            this.wheelAxisTraverse.Field("localAxis").SetValue((Quaternion)this.wheelAxisTraverse.Field("origLocalRot").GetValue() * new Vector3(0, 0, 1));

            Transform f16LeftWheel = PickupAllChildrensTransforms(newAircraftUnit, "Left_Whell");
            SuspensionWheelAnimator faLeftController = faLeftGear.GetComponent<SuspensionWheelAnimator>();
            faLeftController.wheelTransform = leftwheelpivot;
            faLeftController.axis = new Vector3(0, 0, 1);
            Traverse leftWheelAxisTravserse = Traverse.Create(faLeftController);

            leftWheelAxisTravserse.Field("origLocalRot").SetValue(leftwheelpivot.localRotation);
            leftWheelAxisTravserse.Field("localAxis").SetValue((Quaternion)leftWheelAxisTravserse.Field("origLocalRot").GetValue() * new Vector3(0, 0, 1));

            Transform f16RightWheel = PickupAllChildrensTransforms(newAircraftUnit, "Whell_Right");
            SuspensionWheelAnimator faRightController = faRightGear.GetComponent<SuspensionWheelAnimator>();
            faRightController.wheelTransform = rightwheelpivot;
            faRightController.axis = new Vector3(0, 0, 1);
            Traverse rightWheelAxisTraverse = Traverse.Create(faRightController);

            rightWheelAxisTraverse.Field("origLocalRot").SetValue(rightwheelpivot.localRotation);
            rightWheelAxisTraverse.Field("localAxis").SetValue((Quaternion)rightWheelAxisTraverse.Field("origLocalRot").GetValue() * new Vector3(0, 0, 1));

            //Rotates the gears to the appropiate place when spawned in
            switch (gearAnim.state)
            {
                case GearAnimator.GearStates.Extended:

                    F16Debug.Log("wheels_extended");
                    f16leftgear.transform.localEulerAngles = new Vector3(30.5f, 0, 0);
                    f16rightgear.transform.localEulerAngles = new Vector3(-30.5f, 0, 0);
                    f16frontgear.transform.localEulerAngles = new Vector3(0, 0, 0);
                    f16frontgearlever.transform.localEulerAngles = new Vector3(0, 0, 0);
                    f16leftgearcover.transform.localEulerAngles = new Vector3(10, 0, 0);
                    f16rightgearcover.transform.localEulerAngles = new Vector3(-100, 0, 0);
                    f16frontgearcover.transform.localEulerAngles = new Vector3(0, 0, 0);
                    f16leftwheelpivotin.transform.localEulerAngles = new Vector3(0, 0, 0);
                    f16rightwheelpivotin.transform.localEulerAngles = new Vector3(0, 0, 0);
                    f16frontwheelpivotin.transform.localEulerAngles = new Vector3(0, 0, -100);

                    break;
                case GearAnimator.GearStates.Retracted:
                    F16Debug.Log("wheels_retracted");
                    f16leftgear.transform.localEulerAngles = new Vector3(30.5f, 0, -95);
                    f16rightgear.transform.localEulerAngles = new Vector3(-30.5f, 0, -95);
                    f16frontgear.transform.localEulerAngles = new Vector3(0, 0, 108);
                    f16frontgearlever.transform.localEulerAngles = new Vector3(0, 140, 0);
                    f16leftgearcover.transform.localEulerAngles = new Vector3(-90, 0, 0);
                    f16rightgearcover.transform.localEulerAngles = new Vector3(0, 0, 0);
                    f16frontgearcover.transform.localEulerAngles = new Vector3(90, 0, 0);
                    f16leftwheelpivotin.transform.localEulerAngles = new Vector3(0, 0,77.6f);
                    f16rightwheelpivotin.transform.localEulerAngles = new Vector3(0, 0, -104.1f);
                    f16frontwheelpivotin.transform.localEulerAngles = new Vector3(20, 90, -90);
                    break;
                default:
                    F16Debug.Log("Gear animator switch statement got to default somehow");
                    break;
            }


            }

        private void lights()
        {
            //get all lights from f26

            F16Debug.Log("lights_1");
           
            tailnavlightsf26 = PickupAllChildrensTransforms(defaultf26, "TailNavLight");
            leftNavLightredf26 = PickupAllChildrensTransforms(defaultf26, "LeftFwdLight");
            LeftRedStrobeLightf26 = PickupAllChildrensTransforms(defaultf26, "LeftRedStrobeLight");
            leftNavLightRearWhitef26 = PickupAllChildrensTransforms(defaultf26, "LeftRearLight");
            LeftStrobeLightWhitef26 = PickupAllChildrensTransforms(defaultf26, "LeftStrobeLight");
            rightNavLightGreenf26 = PickupAllChildrensTransforms(defaultf26, "RightFwdNavLight");
            rightNavLightRearWhitef26 = PickupAllChildrensTransforms(defaultf26, "RightRearNavLight");
            RightRedStrobeLightf26 = PickupAllChildrensTransforms(defaultf26, "RightRedStrobeLight");
            RightStrobeLightWhitef26 = PickupAllChildrensTransforms(defaultf26, "RightStrobeLight");


            frontlandinglightsf26 = PickupAllChildrensTransforms(defaultf26, "LandingLightGearDownEnabler");

            F16Debug.Log("lights_2");
            //get all f16 light locations in model
            frontlandinglightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "frontlandinglightsf16transform");
           rightwingtoplightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "rightwingtoplightsf16transform");
            leftwingtoplightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "leftwingtoplightsf16transform");
            rightwingbottomlightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "rightwingbottomlightsf16transform");
            leftwingbottomlightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "leftwingbottomlightsf16transform");
            rightintakelightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "rightintakelightsf16transform");
            leftintakelightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "leftintakelightsf16transform");
            taillightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "taillightsf16transform");
            
            rearfuselageleftlightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "rearfuselageleftlightsf16transform");
            rearfuselagerightlightsf16transform = PickupAllChildrensTransforms(newAircraftUnit, "rearfuselagerightlightsf16transform");

            F16Debug.Log("lights_3");

            List<Transform> LightList = new List<Transform>();
            LightList.Add(frontlandinglightsf26);
            
            LightList.Add(leftNavLightredf26);
            LightList.Add(LeftRedStrobeLightf26);
            LightList.Add(leftNavLightRearWhitef26);
            LightList.Add(LeftStrobeLightWhitef26);
            LightList.Add(rightNavLightGreenf26);
            LightList.Add(rightNavLightRearWhitef26);
            LightList.Add(RightRedStrobeLightf26);
            LightList.Add(RightStrobeLightWhitef26);
            LightList.Add(frontlandinglightsf16transform);
            LightList.Add(rightwingtoplightsf16transform);
            LightList.Add(leftwingtoplightsf16transform);
            LightList.Add(rightwingbottomlightsf16transform);
            LightList.Add(leftwingbottomlightsf16transform);
            LightList.Add(rightintakelightsf16transform);
            LightList.Add(leftintakelightsf16transform);
            LightList.Add(taillightsf16transform);

                        foreach (Transform lightitem in LightList)

            {
                if (lightitem == null) { F16Debug.Log("This item could not be found = " + lightitem.name); } else { F16Debug.Log("This item found = " + lightitem.name); }
                Light lightComponent = lightitem.GetComponent<Light>();
                SpriteRenderer lightSprite = lightitem.GetComponent<SpriteRenderer>();
                if (lightComponent != null) { lightComponent.enabled = true; }
                if (lightSprite != null) { lightSprite.enabled = true; }


                if (lightitem.name == "TailNavLight") { lightSprite.enabled = false; lightComponent.enabled = false; }
            }


            //place all lights on f16 transforms
            frontlandinglightsf26.transform.position = frontlandinglightsf16transform.position;
            frontlandinglightsf26.transform.rotation = frontlandinglightsf16transform.rotation;


            F16Debug.Log("lights_4");
            leftNavLightredf26.position = leftintakelightsf16transform.position;
            LeftRedStrobeLightf26.position = leftwingbottomlightsf16transform.position;
            leftNavLightRearWhitef26.position = rearfuselageleftlightsf16transform.position;
            LeftStrobeLightWhitef26.position = rearfuselageleftlightsf16transform.position; //needs to be red

            F16Debug.Log("lights_5");
            rightNavLightGreenf26.position = rightintakelightsf16transform.position;
            rightNavLightRearWhitef26.position = rearfuselagerightlightsf16transform.position;
            RightRedStrobeLightf26.position = rightwingtoplightsf16transform.position; //needs to be green
            RightStrobeLightWhitef26.position = rightwingbottomlightsf16transform.position; //needs to be green
            F16Debug.Log("lights_6");

            Color color0 = Color.red;

            

            //change this white light to red
            LeftStrobeLightWhitef26obj = LeftStrobeLightWhitef26.gameObject;
            Light lsf26 = LeftStrobeLightWhitef26obj.GetComponent<Light>();
            lsf26.color = color0;


      

            Color color1 = Color.green;

            F16Debug.Log("lights_7");
            //change this red light to green
            RightRedStrobeLightf26obj = RightRedStrobeLightf26.gameObject;
            Light rrsf26 = RightRedStrobeLightf26obj.GetComponent<Light>();
            F16Debug.Log("lights_8");

            rrsf26.color = color1;

            //change this white light to green
            RightStrobeLightWhitef26obj = RightStrobeLightWhitef26.gameObject;
            Light rsw26 = RightStrobeLightWhitef26obj.GetComponent<Light>();

            rsw26.color = color1;




            IntakeLightLeft = PickupAllChildrensTransforms(leftintakelightsf16transform.gameObject, "leftIntakeLight");
            IntakeLightRight = PickupAllChildrensTransforms(rightintakelightsf16transform.gameObject, "rightIntakeLight");
            tailLight = PickupAllChildrensTransforms(taillightsf16transform.gameObject, "tailLight");

            IntakeLightLeftLightComp = IntakeLightLeft.GetComponent<Light>();
            IntakeLightRightLightComp = IntakeLightRight.GetComponent<Light>();
            tailLightComp = tailLight.GetComponent<Light>();

            tailLightCylinder = PickupAllChildrensTransforms(taillightsf16transform.gameObject, "Cylinder");
            tailLightCompRendererMaterials = tailLightCylinder.GetComponent<MeshRenderer>().materials;
            foreach (Material materialitem in tailLightCompRendererMaterials)
            {
                F16Debug.Log("Material Name = " + materialitem.name);
                if (materialitem.name == "taillight (Instance)")
                {
                    tailLightCompRendererMaterial = materialitem;

                }
            }


        }

        private void HardpointChecker()
        {
            scene = VTOLAPI.currentScene;
            switch (scene)
            {
                case VTOLScenes.VehicleConfiguration:

                    // get root objects in scene
                    List<GameObject> rootObjects = new List<GameObject>();
                    Scene scene = SceneManager.GetActiveScene();
                    scene.GetRootGameObjects(rootObjects);

                    // iterate root objects and do something
                    for (int i = 0; i < rootObjects.Count; ++i)
                    {
                        GameObject gameObject = rootObjects[i];
                        F16Debug.Log(i + ") " + gameObject);
                    }

                    GameObject f26loadoutscreen = GameObject.Find("FA26-LoadoutConfigurator(Clone)");
                    if (f26loadoutscreen != null)
                    {
                        F16Debug.Log("Found Configurator");
                        lc = f26loadoutscreen.GetComponent<LoadoutConfigurator>();
                        lcleftpanel = PickupAllChildrensTransforms(f26loadoutscreen, "left");
                        lcleftpaneltitle = PickupAllChildrensTransforms(lcleftpanel.gameObject, "title");
                        lcleftpaneltitletext = lcleftpaneltitle.GetComponent<Text>();
                        lcleftpaneltitletext.text = "F-16C";
                        

                        lcmainpanel = PickupAllChildrensTransforms(f26loadoutscreen, "main").gameObject;
                        lchp0 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo");
                        lchp1 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (1)");
                        lchp2 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (2)");
                        lchp3 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (3)");
                        lchp4 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (4)");
                        lchp5 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (5)");
                        lchp6 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (6)");
                        lchp7 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (7)");

                        lchp8 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (8)");
                        lchp9 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (9)");
                        lchp10 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (10)");
                        lchp11 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (11)");
                        lchp12 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (12)");
                        lchp13 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (13)");
                        lchp14 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (14)");
                        lchp15 = PickupAllChildrensTransforms(lcmainpanel, "HardpointInfo (15)");

                       
                        
                        


                        disableVRI(lchp15.gameObject);
                        disableLineRender(lchp4.gameObject);
                        disableLineRender(lchp5.gameObject);
                        disableLineRender(lchp6.gameObject);
                        disableLineRender(lchp7.gameObject);
                        disableLineRender(lchp15.gameObject);
                        disableMesh(lchp4.gameObject);
                        disableMesh(lchp5.gameObject);
                        disableMesh(lchp6.gameObject);
                        disableMesh(lchp7.gameObject);
                        disableMesh(lchp15.gameObject);
                        disableText(lchp4.gameObject);
                        disableText(lchp5.gameObject);
                        disableText(lchp6.gameObject);
                        disableText(lchp7.gameObject);
                        disableText(lchp15.gameObject);



                        lcimage = PickupAllChildrensTransforms(lcmainpanel, "vtImage");
                        lcimagetex = lcimage.GetComponent<RawImage>();

                        lc.Detach(4);
                        lc.Detach(5);
                        lc.Detach(6);
                        lc.Detach(7);
                        lc.Detach(15);
                        lc.Attach("fa26_gun", 0);

                        lc.UpdateNodes();
                        // this code allows you to make hardpoints unusable
                        List<int> LockedHP = new List<int>();
                        LockedHP.Add(5);
                        LockedHP.Add(6);
                        LockedHP.Add(15);
                        LockedHP.Add(4);
                        LockedHP.Add(7);
                        LockedHP.Add(0);


                        F16Debug.Log("List Collected = " + LockedHP);

                        foreach (int lockedhpnum in LockedHP) {
                            lc.lockedHardpoints.Add(lockedhpnum); }


                        f26LoadoutScreenTransform = f26loadoutscreen.transform;

                        break;
                    }
                    else { F16Debug.Log("Not Found Configurator"); break; }


            }
        }

        private void VariableSetting()
        {
            //this area is used for all the user defined variables, if you need to edit it to make a new aircraft you will find it here

            //obvious this is aircraft weight in m tonnes
            aircraftWeightInMetricTonnes = 8.573f;
            //max aircraft fuel in kg
            maxaircraftfuelinkg = 3200f;

           



        }


        private IEnumerator Controlsurfacemovers()
        {
            if (!AircraftInfo.AircraftSelected) { yield break; }
            if (airbrakeobj == null) { yield break; }
            F16Debug.Log("CSM_1");
            if (!AircraftLoaded) { yield break; }




            currentgvalue = attitude.currentInstantaneousG;
            yawvalue = attitude.roll;

            //left aileron and tailerons
           
                f26aileronleftdeltax = f26aileronleftatrest.x - aileronleft.localEulerAngles.x;
                f26aileronleftdeltay = f26aileronleftatrest.y - aileronleft.localEulerAngles.y;
                f26aileronleftdeltaz = f26aileronleftatrest.z - aileronleft.localEulerAngles.z;
                F16Debug.Log("CSM_2");
                f26elevonleftdeltax = f26elevonleftatrest.x - elevonleft.localEulerAngles.x;
                f26elevonleftdeltay = f26elevonleftatrest.y - elevonleft.localEulerAngles.y;
                f26elevonleftdeltaz = f26elevonleftatrest.z - elevonleft.localEulerAngles.z;


               

                newaileronleftpositionz = (-0.25f * f26aileronleftdeltay) + f16aileronlefthingeatrest.z - landingflapposition;
                moveaileronlefthinge.z = newaileronleftpositionz;
                newtaileronleftpositionz = (-1f * f26elevonleftdeltax) + f16taileronlefthingeatrest.z;
                movetaileronlefthinge.z = newtaileronleftpositionz;
            F16Debug.Log("CSM_3");

            aileronlefthinge.transform.localEulerAngles = moveaileronlefthinge;
                taileronlefthinge.transform.localEulerAngles = movetaileronlefthinge;

                //right aileron and tailerons
              
                f26aileronrightdeltax = f26aileronrightatrest.x - aileronright.localEulerAngles.x;
                f26aileronrightdeltay = f26aileronrightatrest.y - aileronright.localEulerAngles.y;
                f26aileronrightdeltaz = f26aileronrightatrest.z - aileronright.localEulerAngles.z;
                f26elevonrightdeltax = f26elevonrightatrest.x - elevonright.localEulerAngles.x;
                f26elevonrightdeltay = f26elevonrightatrest.y - elevonright.localEulerAngles.y;
                f26elevonrightdeltaz = f26elevonrightatrest.z - elevonright.localEulerAngles.z;


                
                newaileronrightpositionz = (0.25f * f26aileronrightdeltay) + f16aileronrighthingeatrest.z - landingflapposition;
                moveaileronrighthinge.z = newaileronrightpositionz;
                newtaileronrightpositionz = (1f * f26elevonrightdeltax) + f16taileronrighthingeatrest.z;
                movetaileronrighthinge.z = newtaileronrightpositionz;

                
                aileronrighthinge.transform.localEulerAngles = moveaileronrighthinge;
                taileronrighthinge.transform.localEulerAngles = movetaileronrighthinge;
            F16Debug.Log("CSM_4");
            //rudder controls

            //well having read up on the f16 it barely uses rudder so I am not implementing -  screw it. 




            // make slats move if the vehicle is pulling nose



            if (currentgvalue < 3.0f )
                {
                //F16Debug.Log("g > 3.0");
                F16Debug.Log("CSM_6");

                newlefleftslatpositionz = -2f + f16leflefthingeatrest.z;
                newlefrightslatpositionz = -2f + f16lefrighthingeatrest.z;

                moveleftlefhinge.z = newlefleftslatpositionz;
                moverightlefhinge.z = newlefleftslatpositionz;

                leflaplefthinge.transform.localEulerAngles = moveleftlefhinge;
                leflaprighthinge.transform.localEulerAngles = moverightlefhinge;

            }
                else
                {
                    
                    newlefleftslatpositionz = 10f + f16leflefthingeatrest.z;
                    newlefrightslatpositionz = 10f + f16lefrighthingeatrest.z;


                    moveleftlefhinge.z = newlefleftslatpositionz;
                    moverightlefhinge.z = newlefleftslatpositionz;

                    leflaplefthinge.transform.localEulerAngles = moveleftlefhinge;
                    leflaprighthinge.transform.localEulerAngles = moverightlefhinge;
                    yield return new WaitForSeconds(3f);
                


                     

                

                }


            //airbrakes


            //F16Debug.Log("CSM_7");

            if (airbrakepiston.transform.localEulerAngles.x <75f || airbrakepiston.transform.localEulerAngles.x > 90f)
            {

                //airbrakelefthingeupperobj.transform.localEulerAngles = new Vector3(0f,0f,43f);
                //airbrakelefthingelowerobj.transform.localEulerAngles = new Vector3(0f, 0f, -43f);
                //airbrakerighthingeupperobj.transform.localEulerAngles = new Vector3(0f, 0f, 43f);
                //airbrakerighthingelowerobj.transform.localEulerAngles = new Vector3(0f, 0f, -43f);

                airbrakelefthingeupperangle = new Vector3(0f, 0f, 43f);
                airbrakelefthingelowerangle = new Vector3(0f, 0f, -43f);
                airbrakerighthingeupperangle = new Vector3(0f, 0f, 43f);
                airbrakerighthingelowerangle = new Vector3(0f, 0f, -43f);
                yield return StartCoroutine(BrakesOpener(airbrakelefthingeupperangle, airbrakelefthingelowerangle, airbrakerighthingeupperangle, airbrakerighthingelowerangle));

            } else
            {
                airbrakelefthingeupperangle = new Vector3(0f, 0f, 0f);
                airbrakelefthingelowerangle = new Vector3(0f, 0f, 0f);
                airbrakerighthingeupperangle = new Vector3(0f, 0f, 0f);
                airbrakerighthingelowerangle = new Vector3(0f, 0f, 0f);
                yield return StartCoroutine(BrakesCloser(airbrakelefthingeupperangle, airbrakelefthingelowerangle, airbrakerighthingeupperangle, airbrakerighthingelowerangle));

                
            }




            //F16Debug.Log("CSM_8");

                yield return new WaitForSeconds(2f);
            

        }

        

    }
}
[HarmonyPatch(typeof(LoadoutConfigurator), "EquipCompatibilityMask")]

public static class Patch0
{
    public static bool Prefix(HPEquippable equip)
    {

        VTOLVehicles cv = VTOLAPI.GetPlayersVehicleEnum();
        if (!AircraftSwap.AircraftInfo.AircraftSelected)
            return true;
        switch (cv)
        {
            case VTOLVehicles.FA26B:
                AircraftSwap.F16Debug.Log("Section 11");
                // this creates a dictionary of all the wepaons and where they can be mounted, just alter the second string per weapon according to the wepaon you want.
                Dictionary<string, string> allowedhardpointbyweapon = new Dictionary<string, string>();

                //unlimited version 
                allowedhardpointbyweapon.Add("fa26-cft", "");
                allowedhardpointbyweapon.Add("fa26_agm89x1", "1,11,12,10");
                allowedhardpointbyweapon.Add("fa26_agm161", "11,12");
                allowedhardpointbyweapon.Add("fa26_aim9x2", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_aim9x3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_cagm-6", "1,11,12,10");
                allowedhardpointbyweapon.Add("fa26_cbu97x1", "1,10,11,12");
                allowedhardpointbyweapon.Add("fa26_droptank", "11,12");
                allowedhardpointbyweapon.Add("fa26_droptankXL", "13");
                allowedhardpointbyweapon.Add("fa26_gbu12x1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_gbu12x2", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_gbu12x3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_gbu38x1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_gbu38x2", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_gbu38x3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_gbu39x4uFront", "");
                allowedhardpointbyweapon.Add("fa26_gbu39x4uRear", "");
                allowedhardpointbyweapon.Add("fa26_gun", "0");
                allowedhardpointbyweapon.Add("fa26_harmx1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_harmx1dpMount", "");
                allowedhardpointbyweapon.Add("fa26_iris-t-x1", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("fa26_iris-t-x2", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_iris-t-x3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_maverickx1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_maverickx3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_mk82HDx1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_mk82HDx2", "11,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_mk82HDx3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_mk82x2", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_mk82x3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_mk83x1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_sidearmx1", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("fa26_sidearmx2", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_sidearmx3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_tgp", "14");
                allowedhardpointbyweapon.Add("cagm-6", "11,12");
                allowedhardpointbyweapon.Add("cbu97x1", "1,10");
                allowedhardpointbyweapon.Add("gbu38x1", "1,10");
                allowedhardpointbyweapon.Add("gbu38x2", "1,10");
                allowedhardpointbyweapon.Add("gbu38x3", "1,10");
                allowedhardpointbyweapon.Add("gbu39x3", "1,10");
                allowedhardpointbyweapon.Add("gbu39x4u", "");
                allowedhardpointbyweapon.Add("h70-4x4", "1,11,10,12");
                allowedhardpointbyweapon.Add("h70-x7", "1,11,10,12");
                allowedhardpointbyweapon.Add("h70-x19", "1,11,10,12");
                allowedhardpointbyweapon.Add("hellfirex4", "1,11,10,12");
                allowedhardpointbyweapon.Add("iris-t-x1", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("iris-t-x2", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("iris-t-x3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("m230", "");
                allowedhardpointbyweapon.Add("marmx1", "1,2,9,10,3,8,11,12");
                allowedhardpointbyweapon.Add("maverickx1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("maverickx3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("mk82HDx1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("mk82HDx2", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("mk82HDx3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("mk82x1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("mk82x2", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("mk82x3", "1,1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("sidearmx1", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("sidearmx2", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("sidearmx3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("sidewinderx1", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("sidewinderx2", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("sidewinderx3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("af_aim9", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("af_amraam", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("af_amraamRail", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("af_amraamRailx2", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("af_dropTank", "13");
                allowedhardpointbyweapon.Add("af_maverickx1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("af_maverickx3", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("af_mk82", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("af_tgp", "14");
                allowedhardpointbyweapon.Add("h70-x7ld", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("h70-x7ld-under", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("h70-x14ld-under", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("h70-x14ld", "1,10,3,8,11,12");
                //scl version

                /*
                allowedhardpointbyweapon.Add("fa26-cft", "");
                allowedhardpointbyweapon.Add("fa26_agm89x1", "1,11,12,10");
                allowedhardpointbyweapon.Add("fa26_agm161", "11,12");
                allowedhardpointbyweapon.Add("fa26_aim9x2", "");
                allowedhardpointbyweapon.Add("fa26_aim9x3", "");
                allowedhardpointbyweapon.Add("fa26_cagm-6", "1,11,12,10");
                allowedhardpointbyweapon.Add("fa26_cbu97x1", "1,10,11,12");
                allowedhardpointbyweapon.Add("fa26_droptank", "11,12");
                allowedhardpointbyweapon.Add("fa26_droptankXL", "13");
                allowedhardpointbyweapon.Add("fa26_gbu12x1", "1,11,10,12");
                allowedhardpointbyweapon.Add("fa26_gbu12x2", "1,11,10,12");
                allowedhardpointbyweapon.Add("fa26_gbu12x3", "1,11,10,12");
                allowedhardpointbyweapon.Add("fa26_gbu38x1", "1,10");
                allowedhardpointbyweapon.Add("fa26_gbu38x2", "1,10");
                allowedhardpointbyweapon.Add("fa26_gbu38x3", "1,10");
                allowedhardpointbyweapon.Add("fa26_gbu39x4uFront", "");
                allowedhardpointbyweapon.Add("fa26_gbu39x4uRear", "");
                allowedhardpointbyweapon.Add("fa26_gun", "0");
                allowedhardpointbyweapon.Add("fa26_harmx1", "1,10,3,8");
                allowedhardpointbyweapon.Add("fa26_harmx1dpMount", "");
                allowedhardpointbyweapon.Add("fa26_iris-t-x1", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("fa26_iris-t-x2", "");
                allowedhardpointbyweapon.Add("fa26_iris-t-x3", "");
                allowedhardpointbyweapon.Add("fa26_maverickx1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("fa26_maverickx3", "");
                allowedhardpointbyweapon.Add("fa26_mk82HDx1", "1,11,10,12");
                allowedhardpointbyweapon.Add("fa26_mk82HDx2", "1,11,10,12");
                allowedhardpointbyweapon.Add("fa26_mk82HDx3", "1,11,10,12");
                allowedhardpointbyweapon.Add("fa26_mk82x2", "1,11,10,12");
                allowedhardpointbyweapon.Add("fa26_mk82x3", "1,11,10,12");
                allowedhardpointbyweapon.Add("fa26_mk83x1", "1,11,10,12");
                allowedhardpointbyweapon.Add("fa26_sidearmx1", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("fa26_sidearmx2", "");
                allowedhardpointbyweapon.Add("fa26_sidearmx3", "");
                allowedhardpointbyweapon.Add("fa26_tgp", "14");
                allowedhardpointbyweapon.Add("cagm-6", "11,12");
                allowedhardpointbyweapon.Add("cbu97x1", "1,10");
                allowedhardpointbyweapon.Add("gbu38x1", "1,10");
                allowedhardpointbyweapon.Add("gbu38x2", "1,10");
                allowedhardpointbyweapon.Add("gbu38x3", "1,10");
                allowedhardpointbyweapon.Add("gbu39x3", "1,10");
                allowedhardpointbyweapon.Add("gbu39x4u", "");
                allowedhardpointbyweapon.Add("h70-4x4", "1,11,10,12");
                allowedhardpointbyweapon.Add("h70-x7", "1,11,10,12");
                allowedhardpointbyweapon.Add("h70-x19", "1,11,10,12");
                allowedhardpointbyweapon.Add("hellfirex4", "");
                allowedhardpointbyweapon.Add("iris-t-x1", "1,2,3,8,9,10");
                allowedhardpointbyweapon.Add("iris-t-x2", "");
                allowedhardpointbyweapon.Add("iris-t-x3", "");
                allowedhardpointbyweapon.Add("m230", "");
                allowedhardpointbyweapon.Add("marmx1", "");
                allowedhardpointbyweapon.Add("maverickx1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("maverickx3", "");
                allowedhardpointbyweapon.Add("mk82HDx1", "1,11,10,12");
                allowedhardpointbyweapon.Add("mk82HDx2", "1,11,10,12");
                allowedhardpointbyweapon.Add("mk82HDx3", "1,11,10,12");
                allowedhardpointbyweapon.Add("mk82x1", "1,11,10,12");
                allowedhardpointbyweapon.Add("mk82x2", "1,11,10,12");
                allowedhardpointbyweapon.Add("mk82x3", "1,11,10,12");
                allowedhardpointbyweapon.Add("sidearmx1", "1,2,3,8,9,10");
                allowedhardpointbyweapon.Add("sidearmx2", "1,10");
                allowedhardpointbyweapon.Add("sidearmx3", "");
                allowedhardpointbyweapon.Add("sidewinderx1", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("sidewinderx2", "");
                allowedhardpointbyweapon.Add("sidewinderx3", "");
                allowedhardpointbyweapon.Add("af_aim9", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("af_amraam", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("af_amraamRail", "1,2,3,8,9,10,11,12");
                allowedhardpointbyweapon.Add("af_amraamRailx2", "");
                allowedhardpointbyweapon.Add("af_dropTank", "13");
                allowedhardpointbyweapon.Add("af_maverickx1", "1,10,3,8,11,12");
                allowedhardpointbyweapon.Add("af_maverickx3", "");
                allowedhardpointbyweapon.Add("af_mk82", "1,11,10,12");
                allowedhardpointbyweapon.Add("af_tgp", "14");
                allowedhardpointbyweapon.Add("h70-x7ld", "1,11,10,12");
                allowedhardpointbyweapon.Add("h70-x7ld-under", "1,11,10,12");
                allowedhardpointbyweapon.Add("h70-x14ld-under", "1,11,10,12");
                allowedhardpointbyweapon.Add("h70-x14ld", "1,11,10,12");
                */

                AircraftSwap.F16Debug.Log("Equipment: " + equip.name + ", Allowed on" + equip.allowedHardpoints);



                if (allowedhardpointbyweapon.ContainsKey(equip.name))
                {
                    equip.allowedHardpoints = (string)allowedhardpointbyweapon[equip.name];
                    AircraftSwap.F16Debug.Log("Equipment: " + equip.name + ", Allowed on" + equip.allowedHardpoints);

                }
                else
                {
                    AircraftSwap.F16Debug.Log("Equipment: " + equip.name + ", not in dictionary");
                }

                return true;
            default:
                return true;
        }
        
    }
}



[HarmonyPatch(typeof(PlayerVehicleSetup), "SetupForFlight")]
public static class Patch1
{
    public static bool Prefix(PlayerVehicleSetup __instance)
    {
        //__instance.gameObject.GetComponent<WeaponManager>().resourcePath = "hpequips/" + LimitEquip.path;
        return true;
    }
}

[HarmonyPatch(typeof(SMSInternalWeaponAnimator), "UpdateCurrentProfile")]
public static class Patch2
{
    public static bool Prefix(SMSInternalWeaponAnimator __instance)
    {
        if (!AircraftSwap.AircraftInfo.AircraftSelected)
            return true;
        if (__instance == null)
            AircraftSwap.F16Debug.Log("__instance is null");
        return Traverse.Create(__instance).Field("currProfile").GetValue() != null;
    }
}
[HarmonyPatch(typeof(MeshCombiner2), "Start")]
class StartPatch
{

    public static bool Prefix(MeshCombiner2 __instance)
    {
        AircraftSwap.F16Debug.Log("Meshcombiner patch");
        if (!AircraftSwap.AircraftInfo.AircraftSelected)
            return true;
        if (__instance.gameObject.GetComponentInParent<Actor>() != null)
            return false;
        else return true;
    }
}



[HarmonyPatch(typeof(Wing), "Awake")]
public static class Patch6
{
    
    private static string nameofwing;


    public static bool Prefix(Wing __instance)
    {
        VTOLVehicles cv = VTOLAPI.GetPlayersVehicleEnum();
        if (!AircraftSwap.AircraftInfo.AircraftSelected)
            return true;
        switch (cv)
        {
            case VTOLVehicles.FA26B:
                nameofwing = __instance.name;
        //F16Debug.Log("Wing checked: " + nameofwing);

                switch (nameofwing)
                {
                    case "wingLeftAero":
                    case "wingRightAero":
                        __instance.liftCoefficient = 0.2814f;
                        __instance.liftArea = 2.0f;
                        __instance.dragCoefficient = 0.158f;
                        return true;
                    case "wingLeftFoldAero":
                    case "wingRightFoldAero":
                        __instance.liftCoefficient = 0f;
                        __instance.liftArea = 0f;
                        __instance.dragCoefficient = 0f;
                        return true;
                    case "bodyLiftAero":
                        __instance.liftCoefficient = 0.0673f;
                        __instance.liftArea = 0.8f;
                        __instance.dragCoefficient = 0.006f;
                        return true;
                    case "rightElevonAero":
                    case "leftElevonAero":
                        __instance.liftCoefficient = 0.26f;
                        __instance.liftArea = 0.9f;
                        __instance.dragCoefficient = 0.009f;
                        return true;
                    case "rudderLeftAero":
                    case "rudderRightAero":
                        __instance.liftCoefficient = 0.2f;
                        //__instance.liftArea = 0.5f;
                        //    __instance.dragCoefficient = 0.013f;
                        return true;
                    case "leftVertStabAero":
                    case "rightVertStabAero":
                        __instance.liftCoefficient = 0.15f;
                        //    __instance.liftArea = 1f;
                        __instance.dragCoefficient = 0.005f;
                        return true;
                    case "aileronLeftAero":
                    case "aileronRightAero":
                        __instance.liftCoefficient = 0.09f;
                        __instance.liftArea = 0.75f;
                        __instance.dragCoefficient = 0.005f;
                        return true;

                    default:

                        return true;


                }
            default:
                return true;

        }


    }
}

[HarmonyPatch(typeof(SimpleDrag), "CalculateDragForceMagnitude")]
public static class Patch7
{
    
    public static void Postfix(float __result, float spd)
    {
        VTOLVehicles cv = VTOLAPI.GetPlayersVehicleEnum();
        if (!AircraftSwap.AircraftInfo.AircraftSelected)
            return;
        switch (cv)
        {
            case VTOLVehicles.FA26B:
                //F16Debug.Log("Speed of SD = " + spd);
                if (spd < 240f || spd > 370f)
                {
                    //F16Debug.Log("SD Patch fallback ");
                    //F16Debug.Log("SD Value = " + __result + ", " + spd);
                    return;
                }
                else
                {
                    float topdrag = __result * 1f;
                    //F16Debug.Log("SD Value = " + __result);
                    //F16Debug.Log("SD Value after Correction= " + topdrag);
                    __result = topdrag;
                    //F16Debug.Log("SD Value = " + __result + ", " + spd);

                    //F16Debug.Log("SD Patch recalc ");
                    return;
                }
            default:
                return;
        }

       
    }
}


[HarmonyPatch(typeof(AerodynamicsController), "DragMultiplierAtSpeed", new Type[] {typeof(float), typeof(float)})]
public static class Patch8
{

    public static bool Prefix(ref float __result, AerodynamicsController __instance, float speed, float altitude)
    {
        VTOLVehicles cv = VTOLAPI.GetPlayersVehicleEnum();
        if (!AircraftSwap.AircraftInfo.AircraftSelected)
            return true;
        switch (cv)
        {
            case VTOLVehicles.FA26B:
                float t = MeasurementManager.SpeedToMach(speed, altitude);
                //F16Debug.Log("Mach = " + t);
                float dragvalue = __instance.defaultDragMachCurve.Evaluate(t);
                //F16Debug.Log("Drag Value = " + dragvalue + ", " + t);

                if (t <= 0.375)
                {
                    __result = dragvalue * 1.2f;
                    //F16Debug.Log("New Drag Value = " + __result + ", " + t);
                    return false;
                }
                else if (t <= 0.77f)
                {

                    __result = dragvalue * 1.05f;
                    //F16Debug.Log("New Drag Value = " + __result + ", " + t);
                    return false;
                }
                else if (t <= 0.82)
                {
                    __result = dragvalue * 1f;
                    //F16Debug.Log("New Drag Value = " + __result + ", " + t);
                    return false;
                }
                else if (t < 0.88)
                {
                    __result = dragvalue * 0.05f;
                    //F16Debug.Log("New Drag Value = " + __result + ", " + t);
                    return false;
                }

                else if (t < 0.94)
                {
                    __result = dragvalue * 1.45f;
                    //F16Debug.Log("New Drag Value = " + __result + ", " + t);
                    return false;
                }
                else if (t < 1.08)
                {
                    if (altitude <= 1600)
                    {
                        __result = dragvalue * 0.85f;
                        //F16Debug.Log("New Drag Value = " + __result + ", " + t);
                    }
                    else if (altitude <= 4000)
                    {
                        __result = dragvalue * 0.67f * 1.2f;
                        //F16Debug.Log("New Drag Value = " + __result + ", " + t);

                    }
                    else if (altitude <= 10000)
                    {
                        __result = dragvalue * 0.67f * 1.2f;
                        //F16Debug.Log("New Drag Value = " + __result + ", " + t);

                    }
                    return false;

                }
                else if (t < 2)
                {
                    if (altitude <= 1600)
                    {
                        __result = dragvalue * 0.8f;
                        //F16Debug.Log("New Drag Value = " + __result + ", " + t);
                    }
                    else if (altitude <= 4000)
                    {
                        __result = dragvalue * 0.87f * 1.2f;
                        //F16Debug.Log("New Drag Value = " + __result + ", " + t);

                    }
                    else if (altitude <= 10000)
                    {
                        __result = dragvalue * 0.87f * 1.2f;
                        //F16Debug.Log("New Drag Value = " + __result + ", " + t);
                    }
                    return false;
                }

                else
                {
                    __result = dragvalue; //good for any
                    //F16Debug.Log("New Drag Value = " + __result + ", " + t);
                    return false;
                }
            default:
                return true;

        }


    }
}

[HarmonyPatch(typeof(LoadoutConfigurator), "CalculateTotalThrust")]
public static class Patch9
{

    private static bool Prefix(LoadoutConfigurator __instance)
    {
        VTOLVehicles cv = VTOLAPI.GetPlayersVehicleEnum();
        if (!AircraftSwap.AircraftInfo.AircraftSelected)
            return true;
        switch (cv)
        {
            case VTOLVehicles.FA26B:
                foreach (ModuleEngine moduleEngine in __instance.wm.GetComponentsInChildren<ModuleEngine>())
                {

                    //F16Debug.Log("Adjusting Thrust for LC");
                    moduleEngine.maxThrust = 40f;
                    moduleEngine.abThrustMult = 1.8f;


                }
                return true;
            default:
                return true;
        }
        return true;

    }

}
/*
[HarmonyPatch(typeof(VehicleSelectUI), nameof(VehicleSelectUI.UpdateUI))]
 
public static class Patch_VehicleUI

{

    private static Texture2D theonesynthsenthowdoiloadimagesagain;

    public static IEnumerator LoadPlaneImage()
    {
        F16Debug.Log("Loading f16 image 1");
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(Directory.GetCurrentDirectory() + @"\VTOLVR_ModLoader\mods\f16_Viper_Unlimited\av42c.png");
        F16Debug.Log("Loading f16 image 2");
        yield return www.SendWebRequest();

        if (www.responseCode != 200)
        {
            F16Debug.Log("WWW Response code isn't 200, it's " + www.responseCode + "\n" + www.error);
        }
        else
        {
            F16Debug.Log("Loading plane image.");
            theonesynthsenthowdoiloadimagesagain = ((DownloadHandlerTexture)www.downloadHandler).texture;
            F16Debug.Log("Loaded plane image.");
        }
    }

    public static bool Prefix(VehicleSelectUI __instance, PlayerVehicle v)
    {
        if (v.vehicleName != "F/A-26B")
        {
            F16Debug.Log(v.vehicleName + " isn't it");
            return true;
        }
        F16Debug.Log("Loading f16 titles 1");
        __instance.vehicleName.text = "F-16C Fighting Falcon";
        F16Debug.Log("Loading f16 titles 2");
        __instance.vehicleDescription.text = "The F-16C Viper has been the goto airframe of choice for 30 years. This new 2030 variant includes higher payloads and increased weapons systems.";
        F16Debug.Log("Loading f16 titles 3");
        LoadPlaneImage();
        

        F16Debug.Log("Loading f16 titles 4");
        __instance.vehicleImage.texture = theonesynthsenthowdoiloadimagesagain;
        return false;
    }

    
    
}
*/
