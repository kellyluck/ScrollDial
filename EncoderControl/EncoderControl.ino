/*
 * Simple rotary encoder sketch for feeding to software backend
 *
 * Based on the example code on the tutorial page below:
 *
 * Tutorial page: https://arduinogetstarted.com/tutorials/arduino-rotary-encoder
 */

/* pinout for the CYT1100 (https://www.amazon.com/dp/B07DM2YMT4):
   (top view)
     ___
  A-|   |-D
  B-|   |
  C-|___|-E

  A = CLK, port 2
  B = GND
  C = DT, port 3
  D = GND
  E = SW, port 4
*/

#include <ezButton.h>  // the library to use for SW pin

#define CLK_PIN 2
#define DT_PIN 3
#define SW_PIN 4

#define DIRECTION_CW 0   // clockwise direction
#define DIRECTION_CCW 1  // counter-clockwise direction

int counter = 0;
int direction = DIRECTION_CW;
int CLK_state;
int prev_CLK_state;

ezButton button(SW_PIN);  // create ezButton object that attach to pin 4

void setup() {
  Serial.begin(9600);

  // configure encoder pins as inputs
  pinMode(CLK_PIN, INPUT);
  pinMode(DT_PIN, INPUT);
  digitalWrite(CLK_PIN, HIGH);
  digitalWrite(DT_PIN, HIGH);
  button.setDebounceTime(50);  // set debounce time to 50 milliseconds

  // read the initial state of the rotary encoder's CLK pin
  prev_CLK_state = digitalRead(CLK_PIN);
}

void loop() {
  button.loop();  // MUST call the loop() function first
  int btnState = button.getState();

  // read the current state of the rotary encoder's CLK pin
  CLK_state = digitalRead(CLK_PIN);

  // If the state of CLK is changed, then pulse occurred
  // React to only the rising edge (from LOW to HIGH) to avoid double count
  if (CLK_state != prev_CLK_state && CLK_state == HIGH) {
    // if the DT state is HIGH
    // the encoder is rotating in counter-clockwise direction => decrease the counter
    if (digitalRead(DT_PIN) == HIGH) {
      counter--;
      direction = DIRECTION_CW;
    } else {
      // the encoder is rotating in clockwise direction => increase the counter
      counter++;
      direction = DIRECTION_CCW;
    }

    if (direction == DIRECTION_CW)
      Serial.print("CW");
    else
      Serial.print("CCW");

    Serial.print("|");
    //Serial.println(counter);
    if (btnState == 0) 
      Serial.println("Y");
    else
      Serial.println("N");
  }

  // save last CLK state
  prev_CLK_state = CLK_state;

//  if (button.isPressed()) {
//    Serial.println("The button is pressed");
//  }
}
