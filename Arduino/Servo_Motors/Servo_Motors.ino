#include <Servo.h>
#include <SoftwareSerial.h>
#include <Wire.h>
#include <Adafruit_PWMServoDriver.h>

const byte txPin = 8;
const byte rxPin = 9;

SoftwareSerial BTSerial (rxPin, txPin); //RX RX

// called this way, it uses the default address 0x40
Adafruit_PWMServoDriver pwm = Adafruit_PWMServoDriver();

#define SERVO_FREQ 50 // Analog servos run at ~50 Hz updates
#define SERVOMIN 120
#define SERVOMAX 490

// servo # counter
uint8_t claw = 7;
uint8_t clawRotation = 0;
uint8_t clawUpDown = 3;
uint8_t middle = 8;
uint8_t bottomUpDown = 12;
uint8_t bottomRotation = 15;

//default motor degree
int claw_degree = 90;
int clawRotation_degree = 90;
int clawUpDown_degree = 90;
int middle_degree = 90;
int bottomUpDown_degree = 90;
int bottomRotation_degree = 90;

void setup() {
  // define pin modes fro tx, rx:
  pinMode(rxPin, INPUT);
  pinMode(txPin, OUTPUT);

  Serial.begin(9600);
  Serial.println("Serial started at 9600");
  
  BTSerial.begin(9600);
  Serial.println("BTserial started at 9600");

  BTSerial.println("Hello Bastard!");
  delay(1000);

  pwm.begin();
  pwm.setPWMFreq(SERVO_FREQ);

  yield();
}

// motor control
void moveMotor(int motorOut, int degreeTest) {
  
  // Convert to pulse width
  uint16_t pulse_width = map(degreeTest, 0, 180, SERVOMIN, SERVOMAX);
  
  //Control Motor
  pwm.setPWM(motorOut, 0, pulse_width);
}

int degreeList[6];

void loop() {

//  if (BTSerial.available()){
//    Serial.write(BTSerial.read());
//  }
//
//if (Serial.available()){
//  BTSerial.write(Serial.read());
//}

//  HC-06 Connection (Bluetooth)
 if(BTSerial.available() > 0) //When HC06 receive something
  {
    for (int i = 0; i < 6; i++) {
      degreeList[i] = BTSerial.read(); //Read from Serial Communication
      Serial.println(degreeList[i]);
    }

    claw_degree           = degreeList[0];
    clawRotation_degree   = degreeList[1];
    clawUpDown_degree     = degreeList[2];
    middle_degree         = degreeList[3];
    bottomUpDown_degree   = degreeList[4];
    bottomRotation_degree = degreeList[5];
  }

// Motor Control
  moveMotor(claw, claw_degree);
  moveMotor(clawRotation, clawRotation_degree);
  moveMotor(clawUpDown, clawUpDown_degree);
  moveMotor(middle, middle_degree);
  moveMotor(bottomUpDown, bottomUpDown_degree);
  moveMotor(bottomRotation, bottomRotation_degree);
}
