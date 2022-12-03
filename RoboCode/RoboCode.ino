/*http://www.instructables.com/id/Quick-Start-to-Nodemcu-ESP8266-on-Arduino-IDE */

/*kart icin:
 * http://arduino.esp8266.com/stable/package_esp8266com_index.json
 */

# include <ESP8266WiFi.h>

const char* ssid = "Connectify-Kuasar";
const char* password = "robocodekuasar";

int motorPinleri[] = { 16 , 5 , 4 , 0 };
const int solMot_ileri = motorPinleri[0];
const int solMot_geri = motorPinleri[1];
const int sagMot_ileri = motorPinleri[2];
const int sagMot_geri = motorPinleri[3];

WiFiServer server(80);

void setup() {
    Serial.begin(115200);
    delay(10);
    for(int i = 0 ; i < 4 ; i++) {
        pinMode(motorPinleri[i] , OUTPUT);
    }
    for(int i = 0 ; i < 4 ; i++) {
        digitalWrite(motorPinleri[i] , LOW);
    }
    // Connect to WiFi network
    Serial.println();
    Serial.println();
    Serial.print("Connecting to ");
    Serial.println(ssid);

    WiFi.begin(ssid , password);

    while(WiFi.status() != WL_CONNECTED) {
        delay(500);
        Serial.print(".");
    }
    Serial.println("");
    Serial.println("WiFi connected");

    // Start the server
    server.begin();
    Serial.println("Server started");

    // Print the IP address
    Serial.print("Use this URL to connect: ");
    Serial.print("http://");
    Serial.print(WiFi.localIP());
    Serial.println("/");

}

void loop() {
    // Check if a client has connected
    WiFiClient client = server.available();
    if(!client) {
        return;
    }

    // Wait until the client sends some data
    Serial.println("new client");
    while(!client.available()) {
        delay(1);
    }

    // Read the first line of the request
    String request = client.readStringUntil('\r');
   // Serial.println(request);
   // client.println(request);
    client.flush();

    String numCode = request.substring(5 , 8);
    switch(numCode.substring(0 , 1).toInt()) {
        case 1:
            client.print(String(numCode.substring(1 , 3).toInt())+"-");
            client.println("forward");
            digitalWrite(solMot_ileri , HIGH);
            digitalWrite(sagMot_ileri , HIGH);
            digitalWrite(solMot_geri , LOW);
            digitalWrite(sagMot_geri , LOW);

            delay(numCode.substring(1 , 3).toInt() * 1000);
            Serial.println("case 1");
            for(int i = 0 ; i < 4 ; i++) {
                digitalWrite(motorPinleri[i] , LOW);
            }
            break;
        case 2:
            client.print(String(numCode.substring(1 , 3).toInt()+"-"));
            client.println("back");
            delay(50);
            digitalWrite(solMot_ileri , LOW);
            digitalWrite(sagMot_ileri , LOW);
            digitalWrite(solMot_geri , HIGH);
            digitalWrite(sagMot_geri , HIGH);

            delay(numCode.substring(1 , 3).toInt() * 1000);
            Serial.println("case 2");
            for(int i = 0 ; i < 4 ; i++) {
                digitalWrite(motorPinleri[i] , LOW);
            }
            break;
        case 3:
            client.println("1 left");
            delay(50);
            digitalWrite(solMot_ileri , HIGH);
            digitalWrite(sagMot_ileri , LOW);
            digitalWrite(solMot_geri , LOW);
            digitalWrite(sagMot_geri , HIGH);
            delay(1000);
            Serial.println("case 3");
            for(int i = 0 ; i < 4 ; i++) {
                digitalWrite(motorPinleri[i] , LOW);
            }

            break;
        case 4:
            client.println("1 right");
            delay(50);
            digitalWrite(solMot_ileri , LOW);
            digitalWrite(sagMot_ileri , HIGH);
            digitalWrite(solMot_geri , HIGH);
            digitalWrite(sagMot_geri , LOW);
            delay(1000);
            Serial.println("case 4");
            for(int i = 0 ; i < 4 ; i++) {
                digitalWrite(motorPinleri[i] , LOW);
            }

            break;
        case 0:
            client.println("stop");
            delay(50);
            digitalWrite(solMot_ileri , LOW);
            digitalWrite(sagMot_ileri , LOW);
            digitalWrite(solMot_geri , LOW);
            digitalWrite(sagMot_geri , LOW);
            Serial.println("case 0");
            break;

        default:

            break;
    }






    // Set ledPin according to the request
    //digitalWrite(ledPin, value);

    // Return the response
    /*  client.println("HTTP/1.1 200 OK");
      client.println("Content-Type: text/html");
      client.println(""); //  do not forget this one
      client.println("<!DOCTYPE HTML>");
      client.println("<html>");

      client.print("Led pin is now: ");

      if(value == HIGH) {
        client.print("On");
      } else {
        client.print("Off");
      }
      client.println("<br><br>");
      client.println("<a href=\"/LED=ON\"\"><button>Turn On </button></a>");
      client.println("<a href=\"/LED=OFF\"\"><button>Turn Off </button></a><br />");  

      client.print(request);
      client.println("</html>");*/

    delay(1);
    Serial.println("Client disonnected");
    Serial.println("");

}

