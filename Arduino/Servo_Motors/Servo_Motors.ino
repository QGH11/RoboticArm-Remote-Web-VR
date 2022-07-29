#include <Servo.h>
#include <SoftwareSerial.h>
#include <Wire.h>
#include <Adafruit_PWMServoDriver.h>

const byte rxPin = 9;
const byte txPin = 8;
SoftwareSerial BTSerial (rxPin, txPin); //RX RX

// called this way, it uses the default address 0x40
Adafruit_PWMServoDriver pwm = Adafruit_PWMServoDriver();

#define SERVO_FREQ 50 // Analog servos run at ~50 Hz updates
#define SERVOMIN 150
#define SERVOMAX 10000

// servo # counter
uint8_t claw = 0;
uint8_t clawRotation = 3;
uint8_t clawUpDown = 7;
uint8_t middle = 8;
uint8_t bttomUpDown = 13;
uint8_t bottomRotation = 15;

void setup() {
  // define pin modes fro tx, rx:
  pinMode(rxPin, INPUT);
  pinMode(txPin, OUTPUT);
  
  BTSerial.begin(9600);
  Serial.println("BTserial started at 9600");
  
  Serial.begin(9600);
  Serial.println("Serial started at 9600");

  pwm.begin();
  pwm.setPWMFreq(SERVO_FREQ);

  yield();
}

String messageBuffer = "";
String message = "";

void loop() {
  Serial.println(claw);
//     for (uint16_t degrees = 0; degrees < 180; degrees++) {
//      pwm.setPWM(0, 0, map(degrees, 0, 180, SERVOMIN, SERVOMAX));  // setPWM (channel, on, off);
//     }

  pwm.setPWM(0, 0, map(180, 0, 180, SERVOMIN, SERVOMAX));  // setPWM (channel, on, off);

//     for (uint16_t pulselen = 10000; pulselen > 150; pulselen--) {
//      pwm.setPWM(0, 0, pulselen);  // setPWM (channel, on, off) 
//     }

//  // Bluetooth connection
//  while (BTSerial.available() > 0) {
//    char data = (char) BTSerial.read();
//    messageBuffer +=data;
//    if (data == ";") {
//      message = messageBuffer;
//      messageBuffer = "";
//      Serial.print(message); // send to serial monitor
//      message = "You send " + message;
//      BTSerial.print(message); // send back to bluetooth terminal
//    }
//  }

}
