#include <SPI.h>
#include <MFRC522.h>
#include <Servo.h>
#include <HCSR04.h>  

#define SS_PIN 10 
#define RST_PIN 9 

int redPin= 6;
int greenPin = 5;
int  bluePin = 4;

HCSR04 hc(8, 7);
long distance;
long randNumber;
MFRC522 rfid(SS_PIN, RST_PIN); 
Servo right;
Servo left;

MFRC522::MIFARE_Key key;

bool active = false;
byte correctUID[] = {0x04, 0xD1, 0x66, 0x4A, 0x78, 0x18, 0x90}; // correct card ID

void setup() {
  Serial.begin(9600);  
  SPI.begin();  
  rfid.PCD_Init();  
  left.attach(2);
  right.attach(3);
  Serial.println("power on - ready");
  pinMode(redPin,  OUTPUT);              
  pinMode(greenPin, OUTPUT);
  pinMode(bluePin, OUTPUT);
  setColour(255,0,0); // red - initial status
  stop(); // motors set to stop before card present
  randomSeed(analogRead(0)); // random function uses empty pin to generate random number based on picked up signal
}

void loop() {

  // --- RFID Card Check ---
  // This section now runs every time the loop() iterates IF no delay() is blocking
  if (rfid.PICC_IsNewCardPresent()) { // Check for card only if no card detected very recently
    if (rfid.PICC_ReadCardSerial()) { // Attempt to read the card details

        // Card Read successfully
        Serial.print(F("RFID Tag UID:"));
        printHex(rfid.uid.uidByte, rfid.uid.size);
        Serial.println("");

        // Check for match
        bool match = true;
        // Ensure comparison only happens up to the size of the smaller array if sizes differ
        byte compareLength = sizeof(correctUID); 
        if (rfid.uid.size != compareLength) {
            match = false; 
        } else {
            for (byte i = 0; i < compareLength; i++) {
                if (rfid.uid.uidByte[i] != correctUID[i]) {
                    match = false;
                    break;
                }
            }
        }


      if (match) {
        // --- Correct Card ---
        if (active) {
          // If running, stop
          setColour(255, 0, 0); // red - stop
          active = false;
          Serial.println("OFF");
          stop();
        } else {
          // If stopped, start
          setColour(0, 255, 0); // green - operate
          active = true;
          Serial.println("ON");
          // Movement will start on the next loop iteration's check of 'if(active)'
        }
         // NOTE: This delay blocks RFID reading for 1 second after a correct card
        delay(1000);
      } else {
        // --- Incorrect Card ---
        Serial.println("Wrong card");
         // NOTE: This blink function blocks RFID reading during the blinking
        blink(255, 0, 0, 7); // blink red - wrong card
        // Restore colour based on current state
        if (active) {
          setColour(0, 255, 0); // green - still operate
        } else {
          setColour(255, 0, 0); // red - still stop
        }
      }
      rfid.PICC_HaltA();      // Halt PICC
      rfid.PCD_StopCrypto1(); // Stop encryption (good practice)
    }
  }
  // --- End RFID Card Check ---
  
  // robot movememnt loop
  if(active) {
  getDistance(); // checking distance
  Serial.println(distance);
  delay(250); // 1/4s delay betwen each distance check
  // if obstacle is closer than 15 cm, but further than 5 cm from the sensor
  // robot slows down and new status is indicated by yellow led
  if((distance < 15) && (distance > 5)) 
  {
    forward(3);
    setColour(255,255,0); // yellow
  }
  // if distance to obstacle is 5 cm or less robot will stop, led colour will change to red, robot will use avoid method to change direction
  // then after turning on spot status led will change to green and robot will continue forward with normal speed
  else if (distance <= 5)
  {
    stop();
    setColour(255,0,0); // red
    delay(1000);
    avoid();
    setColour(0,255,0); // green
    forward(5);
  }
  // no obstacle detected robot travels at normal speed, status led - green
  else
  {
    forward(5);
    setColour(0,255,0); // green
  }
  
  }
  
}

// Routine to dump a byte array as hex values to Serial.
void printHex(byte *buffer, byte bufferSize) {
  for (byte i = 0; i < bufferSize; i++) {
    Serial.print(buffer[i] < 0x10 ? " 0" : " ");
    Serial.print(buffer[i], HEX);
  }
}
//method for moving robot forward
void forward(int speed)
{
  Serial.println("forward");
  right.write(90 + speed); // difference in speed values to make robot move in straight line
  left.write(90 - speed);
}

//method for avoiding obstacle, robot will choose to turn left or right on random to avoid obstacle
void avoid()
{
  Serial.println("avoiding obstacle");
  randNumber = random(1, 3); // generating random number 1 or 2
  if (randNumber == 1)
  {
    stop();
    delay(1000);
    Serial.println("turning left");
    left.write(95); // turning is achieved by spinning servos in the same direction as they are mounted oppsoite to each other
    right.write(95); 
    delay(800); // these values were achieved experimentaly and will equal to 90 degree turn
    stop();
    delay(1000);
  }
  else
  {
    stop();
    delay(1000);
    Serial.println("turning right");
    left.write(85);
    right.write(85);
    delay(800);
    stop();
    delay(1000);
  }
}
//method to stop thge movement of the robot
void stop()
{
  // the value of 90 will stop servo, values 91-180 will spin servo in one directrion, greater value will equal greate speed
  // values 0-89 will speen servo opposite direction, lesser values will equal to greater speed
  left.write(90); 
  right.write(90);
  Serial.println("stop");
}
//method to choose led colour by red green blue value input
void setColour(int redValue, int greenValue,  int blueValue) {
  analogWrite(redPin, redValue);
  analogWrite(greenPin,  greenValue);
  analogWrite(bluePin, blueValue);
}
//method to blink led set number of times in chosen colour
void blink(int redValue, int greenValue,  int blueValue, int times)
{
  for(int i = times; i>=0; i--)
  {
  setColour(redValue, greenValue, blueValue);
  delay(500);
  setColour(0,0,0);
  delay(500);
  Serial.println("blink");
  }
}

// reading distance from sonar sensor
long getDistance()
{
  distance = hc.dist();
  return distance;
}

