int red = 13;
int yellow = 11;
int green = 12;
int button = 7;

int red2 = 4;
int green2 = 5;

int buzzer = 8;

void setup(){
    pinMode(red, OUTPUT);
    pinMode(yellow, OUTPUT);
    pinMode(green, OUTPUT);

    pinMode(button, INPUT);
    digitalWrite(green, HIGH);

    pinMode(red2, OUTPUT);
    pinMode(green2, OUTPUT);

    pinMode(buzzer, OUTPUT);
}

void loop(){
  
  changeLights();
}

void changeLights(){
  if (digitalRead(button) == HIGH){
        delay(15);
        if (digitalRead(button) == HIGH) {
            delay(1500);
            digitalWrite(green, LOW);
            digitalWrite(yellow, HIGH);
            delay(3000);
            digitalWrite(yellow, LOW);
            digitalWrite(red, HIGH);
            delay(2000);
            digitalWrite(red2, LOW);
            digitalWrite(green2, HIGH);
            digitalWrite(buzzer, HIGH);
            delay(5000);
            for(int i = 0; i <= 4; i++){
              digitalWrite(green2, LOW);
              digitalWrite(buzzer, LOW);
              delay(300);
              digitalWrite(green2, HIGH);
              digitalWrite(buzzer, HIGH);
              delay(300);
            }
            digitalWrite(buzzer, LOW);
            digitalWrite(green2, LOW);
            digitalWrite(red2, HIGH);
            delay(2500);
            digitalWrite(yellow, HIGH);
            delay(2000);
            digitalWrite(yellow, LOW);
            digitalWrite(red, LOW);
            digitalWrite(green, HIGH);
        }
  }
  else{
    digitalWrite(green, HIGH);
    digitalWrite(red2, HIGH);
  }
}