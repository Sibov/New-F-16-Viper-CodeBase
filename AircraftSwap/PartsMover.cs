using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
//This code is here to allow me to move things around while testing if not needed just comment out the call in AircraftSwap, putting it here keeps the rest clean.
//The part is moved using the keyboard. This allows fine adjustment whilst building the aircraft
//g,t,f,h,v,b control the rotation axis
//up, down, left, right,k, m, control the position

//o and p control the scale of movement on the positioning by doubling or halving
//Note: This code just outputs the position of the item to the logs so you can then use that to create the offset for the part in the code. These are always local offsets



namespace AircraftSwap
{
    static class PartsMover
    {
        
        public static float Movewithkeys(Transform partname, float changeamount)
        {
            GameObject partobj = null;


            
            try
            {
                partobj = partname.gameObject;
                

                if (Input.GetKey("g"))
                {
                    Debug.Log("g key is held down");

                    Vector3 currentrotation2 = partobj.transform.localEulerAngles;
                    currentrotation2.x += 1f;
                    partobj.transform.localEulerAngles = currentrotation2;
                    Debug.Log("Rotation x = " + partname +",  " + currentrotation2.x + "," + currentrotation2.y + "," + currentrotation2.z);
                }

                if (Input.GetKey("t"))
                {
                    Debug.Log("t key is held down");

                    Vector3 currentrotation2 = partobj.transform.localEulerAngles;
                    currentrotation2.x -= 1f;
                    partobj.transform.localEulerAngles = currentrotation2;
                    Debug.Log("Rotation y = " + partname +",  " + currentrotation2.x + "," + currentrotation2.y + "," + currentrotation2.z);
                }

                if (Input.GetKey("f"))
                {
                    Debug.Log("f key is held down");

                    Vector3 currentrotation2 = partobj.transform.localEulerAngles;
                    currentrotation2.y += 1f;
                    partobj.transform.localEulerAngles = currentrotation2;
                    Debug.Log("Rotation y = " + partname +",  " + currentrotation2.x + "," + currentrotation2.y + "," + currentrotation2.z);
                  
                }

                if (Input.GetKey("h"))
                {
                    Debug.Log("h key is held down");

                    Vector3 currentrotation2 = partobj.transform.localEulerAngles;
                    currentrotation2.y -= 1f;
                    partobj.transform.localEulerAngles = currentrotation2;
                    Debug.Log("Rotation y = " + partname +",  " + currentrotation2.x + "," + currentrotation2.y + "," +currentrotation2.z);
                }

                if (Input.GetKey("v"))
                {
                    Debug.Log("v key is held down");

                    Vector3 currentrotation2 = partobj.transform.localEulerAngles;
                    currentrotation2.z += 1f;
                    partobj.transform.localEulerAngles = currentrotation2;
                    Debug.Log("Rotation z = " + partname +",  " + currentrotation2.x + "," + currentrotation2.y +"," + currentrotation2.z);
                }

                if (Input.GetKey("b"))
                {
                    Debug.Log("b key is held down");

                    Vector3 currentrotation2 = partobj.transform.localEulerAngles;
                    currentrotation2.z -= 1f;
                    partobj.transform.localEulerAngles = currentrotation2;
                    Debug.Log("Rotation z = " + partname +",  " + currentrotation2.x + "," + currentrotation2.y + "," + currentrotation2.z);
                }

                if (Input.GetKey("up"))
                {
                    Debug.Log("up arrow key is held down");

                    Vector3 currentposition1 = partobj.transform.localPosition;
                    currentposition1.z +=changeamount;
                    partobj.transform.localPosition = currentposition1;
                    Debug.Log("Position = " + partname + " : " + currentposition1.x + "," + currentposition1.y + "," + currentposition1.z + ",");
                }



                if (Input.GetKey("down"))
                {
                    Debug.Log("down arrow key is held down");
                    Vector3 currentposition1 = partobj.transform.localPosition;
                    currentposition1.z -=changeamount;
                    partobj.transform.localPosition = currentposition1;
                    Debug.Log("Position = " + partname + " : " + currentposition1.x + "," + currentposition1.y + "," + currentposition1.z + ",");

                }

                if (Input.GetKey("right"))
                {
                    Debug.Log("right arrow key is held down");
                    Vector3 currentposition1 = partobj.transform.localPosition;
                    currentposition1.x +=changeamount;
                    partobj.transform.localPosition = currentposition1;
                    Debug.Log("Position = " + partname + " : " + currentposition1.x + "," + currentposition1.y + "," + currentposition1.z + ",");
                }

                if (Input.GetKey("left"))
                {
                    Debug.Log("left arrow key is held down");
                    Vector3 currentposition1 = partobj.transform.localPosition;
                    currentposition1.x -=changeamount;
                    Debug.Log("Position = " + partname + " : " + currentposition1.x + "," + currentposition1.y + "," + currentposition1.z + ",");
                    partobj.transform.localPosition = currentposition1;

                }

                if (Input.GetKey("k"))
                {
                    Debug.Log("k is held down");
                    Vector3 currentposition1 = partobj.transform.localPosition;
                    currentposition1.y +=changeamount;
                    partobj.transform.localPosition = currentposition1;
                    Debug.Log("Position = " + partname + " : " + currentposition1.x + "," + currentposition1.y + "," + currentposition1.z + ",");
                }

                if (Input.GetKey("m"))
                {
                    Debug.Log("m key is held down");
                    Vector3 currentposition1 = partobj.transform.localPosition;
                    currentposition1.y -=changeamount;
                    partobj.transform.localPosition = currentposition1;
                    Debug.Log("Position = " + partname + " : " + currentposition1.x + "," + currentposition1.y + "," + currentposition1.z + ",");
                }

                if (Input.GetKeyDown("-"))
                {
                    Debug.Log("- key is held down");
                    Vector3 currentscale1 = partobj.transform.localScale;
                    currentscale1.x += changeamount;
                    currentscale1.y += changeamount;
                    currentscale1.z += changeamount;
                    partobj.transform.localScale = currentscale1;
                    Debug.Log("Position = " + partname + " : " + currentscale1.x + "," + currentscale1.y + "," + currentscale1.z + ",");
                }
                if (Input.GetKeyDown("="))
                {
                    Debug.Log("= key is held down");
                    Vector3 currentscale1 = partobj.transform.localScale;
                    currentscale1.x -= changeamount;
                    currentscale1.y -= changeamount;
                    currentscale1.z -= changeamount;
                    partobj.transform.localScale = currentscale1;
                    Debug.Log("Position = " + partname + " : " + currentscale1.x + "," + currentscale1.y + "," + currentscale1.z + ",");
                }




                if (Input.GetKeyDown("p"))
                {
                    Debug.Log("p key is held down");
                    changeamount = changeamount*2;
                    Debug.Log("Change amount = "+changeamount);
                    FlightLogger.Log("Change amount = " + changeamount);

                }

                if (Input.GetKeyDown("l"))
                {
                    Debug.Log("o key is held down");
                    changeamount = changeamount/2;
                    Debug.Log("Change amount = " + changeamount);
                    FlightLogger.Log("Change amount = " + changeamount);
                }

                return (float)changeamount;
            }
            catch (Exception e)
            {
                Debug.Log("Part " + partname + " not found");
                return 0.05f;
            }


            
        }

       
        }

        




    }

