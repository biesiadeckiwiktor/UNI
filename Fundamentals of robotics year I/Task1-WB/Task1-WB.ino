#include <SPI.h>
#include <MFRC522.h>
#include <Servo.h>  // Include the Servo library
#include <LiquidCrystal.h> // include the library code:

#define SS_PIN 10
#define RST_PIN 9
#define SERVO_PIN 6  // Define the pin where the servo is connected

// initialize the library by associating any needed LCD interface pin
// with the arduino pin number it is connected to
LiquidCrystal lcd(8,7,5,4,3,2);

MFRC522 rfid(SS_PIN, RST_PIN); // Instance of the class
Servo myServo; // Create a servo object

MFRC522::MIFARE_Key key;

// Door state flag, starts closed (false).
bool doorOpen = false;

void setup() {
  Serial.begin(9600);  // Initialize serial communication
  SPI.begin();  // Init SPI bus
  lcd.begin(16, 2);
  rfid.PCD_Init();  // Init RC522
  myServo.attach(SERVO_PIN);  // Attach the servo to the defined pin
  myServo.write(0);  // Start at 0 degrees (closed position)
  
  // Indicate the initial state of the door
  Serial.println("Door Closed.");
  lcd.print("Door Closed.");
}

void loop() {

  // Reset the loop if no new card is present on the sensor/reader. This saves the entire process when idle.
  if (!rfid.PICC_IsNewCardPresent())
    return;

  // Verify if the NUID has been read.
  if (!rfid.PICC_ReadCardSerial())
    return;

  MFRC522::PICC_Type piccType = rfid.PICC_GetType(rfid.uid.sak);

  Serial.print(F("RFID Tag UID:"));
  printHex(rfid.uid.uidByte, rfid.uid.size);
  Serial.println("");

  byte correctUID[] = {0x04, 0xD1, 0x66, 0x4A, 0x78, 0x18, 0x90}; 

  bool match = true;
  for (byte i = 0; i < rfid.uid.size; i++) {
    if (rfid.uid.uidByte[i] != correctUID[i]) {
      match = false;
      break;
    }
  }

  if (match) {
    // Card detected and it's correct
    if (doorOpen) {
      lcd.clear();
      // Door is open, so close it (move servo to 0 degrees)
      lcd.print("Door Closed.");
      myServo.write(0);  // Move servo back to 0 degrees (closed position)
      doorOpen = false;  // Set the door state to closed
    } else {
      lcd.clear();
      // Door is closed, so open it (move servo to 180 degrees)
      lcd.print("Door Open.");
      myServo.write(180);  // Move servo to 180 degrees (open position)
      doorOpen = true;  // Set the door state to open
      delay(3500);
      myServo.write(0);
      lcd.clear();
      lcd.print("Door Closed.");
      doorOpen = false;
    }
    delay(1000);  // Wait for a second before reading the next card
  } else {
    lcd.clear();
    lcd.print("Access Denied.");
    delay(2000);
    lcd.clear();
    lcd.print("Door Closed.");
  }
  rfid.PICC_HaltA(); // Halt PICC
}

// Routine to dump a byte array as hex values to Serial.
void printHex(byte *buffer, byte bufferSize) {
  for (byte i = 0; i < bufferSize; i++) {
    Serial.print(buffer[i] < 0x10 ? " 0" : " ");
    Serial.print(buffer[i], HEX);
  }
}