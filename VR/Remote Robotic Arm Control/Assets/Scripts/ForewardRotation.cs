using UnityEngine;
using UnityEngine.UI;
using System;

public class ForewardRotation : MonoBehaviour
{
    public GameObject servo2;
    public GameObject middleStand;
    public GameObject middleUpDown;
    public GameObject clawUpDown;
    public GameObject clawRotation;
    public Slider[] sliderList = new Slider[5];
    private readonly HingeJoint[] hingeJointList = new HingeJoint[5]; /*0: servo2, 1: middleStand, 2: middleUpDownHinge, 3: clawUPDown, 4: clawRotation*/
    private readonly JointMotor[] jointMotorList = new JointMotor[5];

    // Start is called before the first frame update
    void Start()
    {
        hingeJointList[0] = servo2.GetComponent<HingeJoint>();
        hingeJointList[1] = middleStand.GetComponent<HingeJoint>();
        hingeJointList[2] = middleUpDown.GetComponent<HingeJoint>();
        hingeJointList[3] = clawUpDown.GetComponent<HingeJoint>();
        hingeJointList[4] = clawRotation.GetComponent<HingeJoint>();

        for (int i = 0; i < jointMotorList.Length; i++)
        {
            jointMotorList[i] = hingeJointList[i].motor;
        }
    }

    private void Update()
    {
        sliderList[0].onValueChanged.AddListener((value) =>
        {
            RotateHingeJoints(0, sliderList[0].value);
        });

        sliderList[1].onValueChanged.AddListener((value) =>
        {
            RotateHingeJoints(1, sliderList[1].value);
        });

        sliderList[2].onValueChanged.AddListener((value) =>
        {
            RotateHingeJoints(2, sliderList[2].value);
        });

        sliderList[3].onValueChanged.AddListener((value) =>
        {
            RotateHingeJoints(3, sliderList[3].value);
        });

        sliderList[4].onValueChanged.AddListener((value) =>
        {
            RotateHingeJoints(4, sliderList[4].value);
        });

        sliderList[5].onValueChanged.AddListener((value) =>
        {
            RotateHingeJoints(5, sliderList[5].value);
        });

        /*  print("Servo Angle: " + (int)Math.Round(servo2Hinge.angle));
          print("Slide Angle: " + sliderList[0].value);*/
        if ((int)Math.Round(hingeJointList[0].angle) == sliderList[0].value)
        {
            jointMotorList[0] = hingeJointList[0].motor;
            jointMotorList[0].targetVelocity = 0;
            hingeJointList[0].motor = jointMotorList[0];
        }

        if ((int)Math.Round(hingeJointList[1].angle) == sliderList[1].value)
        {
            jointMotorList[1] = hingeJointList[1].motor;
            jointMotorList[1].targetVelocity = 0;
            hingeJointList[1].motor = jointMotorList[1];
        }

        if ((int)Math.Round(hingeJointList[2].angle) == sliderList[2].value)
        {
            jointMotorList[2] = hingeJointList[2].motor;
            jointMotorList[2].targetVelocity = 0;
            hingeJointList[2].motor = jointMotorList[2];
        }

        if ((int)Math.Round(hingeJointList[3].angle) == sliderList[3].value)
        {
            jointMotorList[3] = hingeJointList[3].motor;
            jointMotorList[3].targetVelocity = 0;
            hingeJointList[3].motor = jointMotorList[3];
        }

        if ((int)Math.Round(hingeJointList[4].angle) == sliderList[4].value)
        {
            jointMotorList[4] = hingeJointList[0].motor;
            jointMotorList[4].targetVelocity = 0;
            hingeJointList[4].motor = jointMotorList[4];
        }

    }

    void RotateHingeJoints(int index, float targetAngle)
    {
        jointMotorList[index] = hingeJointList[index].motor;
        if (hingeJointList[index].angle < targetAngle)
        {
            jointMotorList[index].targetVelocity = 20;
        }
        else if (hingeJointList[index].angle > targetAngle) 
        {
            jointMotorList[index].targetVelocity = -20;
        }
            hingeJointList[index].motor = jointMotorList[index];
    }
}