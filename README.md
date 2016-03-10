Studentnaam: Joeri Smits

Studentnummer: 524292

‐‐‐

#Algemene beschrijving applicatie
Deze applicatie is een HTTP Proxy gebasseerd op het TCP protocol. De proxy heeft als functionaliteit dat afbeelding worden gefilterd en worden vervangen door placeholders. Daarnaast is er caching in de proxy ingebouwd. De proxy draait standaard op poort 9000 van 127.0.0.1 . Door de autheticatie vink aan te zitten in de GUI van de proxy worden de user-agent headers verwijderd.  
![alt text](https://github.com/JoeriSmits/NotS-assignment-3/blob/master/proxy_basic.png "Proxy basic")

De *client* stuurt zijn HTTP request naar de proxy, inplaats van naar het internet en dan naar de webbrowser. De proxy kan hierdoor de request aanpassen om bijvoorbeeld de `User-Agent` weg te laten. Daarna stuurt de proxy het request via het internet door naar de webserver die dan een reponse afgeeft. Deze response wordt opgevangen bij de proxy die deze response dan naar de client stuurt.  

Klasse diagram:
![alt text](https://github.com/JoeriSmits/NotS-assignment-3/blob/master/proxy_class_diagram.png "Proxy basic")

## Zorg voor een voorbeeld van een http‐request en van een http‐response.

Request:
```
GET /css/main.css HTTP/1.1
Host: joerismits.nl
Connection: keep-alive
Pragma: no-cache
Cache-Control: no-cache
Accept: text/css,*/*;q=0.1
User-Agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36
Referer: http://joerismits.nl/
Accept-Encoding: gzip, deflate, sdch
Accept-Language: nl-NL,nl;q=0.8,en-US;q=0.6,en;q=0.4
```

Response:
```
HTTP/1.1 200 OK
Date: Wed, 09 Mar 2016 21:59:22 GMT
Server: Apache
Last-Modified: Thu, 10 Sep 2015 06:12:35 GMT
Accept-Ranges: bytes
Content-Length: 720
Connection: close
Content-Type: text/css
```

Zowel de _request_ als de _response_ geven beide aan welke protocol wordt gebruikt. In dit geval is dat `HTTP/1.1`. Verder valt op dat de request net als de response per regel een key heeft met daarachter de waarde van de desbestreffende key. Deze keys zijn voor de request en response anders. 

## TCP/IP

### Beschrijving van concept in eigen woorden
TCP/IP is een verzamelnaam van de reeks netwerkprotocollen die voor een grote meerderheid van de netwerkcommunicatie tussen computers instaan. Het grootste en bekendste TCP/IP-netwerk is het internet.  

De TCP/IP-protocolstack wordt onderverdeeld in vijf lagen, met elk een eigen functionaliteit.  

| # | Laag | Protocollen/systemen |
| :---: | :---: | :---: |
| 7 | Applicatie | HTTP, FTP, DNS, RTP |
| 4 | Transport | TCP, UDP, SCTP |
| 3 | Netwerk | TCP/IP gebruikt hiervoor het Internet Protocol (IP) |
| 2 | Data Link | Ethernet, Token Ring |
| 1 | Fysiek |Fysieke media, en lijncodering, T1, E1 |

### Code voorbeeld van je eigen code
```cs
this.listener = new TcpListener(IPAddress.Any, this._listenPort);
```
### Alternatieven & adviezen
Er zijn erg veel alternatieve gemaakt op het TCP/IP principe. Ze zijn alleen allemaal verslagen door TCP/IP, daarom is TCP/IP ook veel populairder dan zijn alternatieve.

* Apple heeft gebruik gemaakt van AppleTalk gebasseerd op AFP en DDP. Ze zijn alleen na een tijd overgestapt naar transport over IP.
* IBM heeft een primitief protocol onderhouden genaamd _System Network Architecture (SNA)_. Dit liep over Synchrone Data Link Control (SBLC) voor communicatie tussen hun main services.
* Chaosnet was een _packet based protocol_ gemaakt door MIT. Dit werd gebruikt voor verbinding tussen LISP machines. Het is ontwikkeld in dezelfde tijd als PUP en IP.

### Authentieke en gezaghebbende bronnen
Remaker, P. (2015, July 13). Is there an alternative to the TCP/IP model that does not utilize the Internet Protocol (IPv4/6)? Retrieved March 09, 2016, from https://www.quora.com/Is-there-an-alternative-to-the-TCP-IP-model-that-does-not-utilize-the-Internet-Protocol-IPv4-6
Rouse, M. (2008, October). What is TCP/IP (Transmission Control Protocol/Internet Protocol)? - Definition from WhatIs.com. Retrieved March 09, 2016, from http://searchnetworking.techtarget.com/definition/TCP-IP


## Bestudeer de RFC van HTTP 1.1.

### Hoe ziet de globale opbouw van een HTTP bericht eruit? (Teken een diagram en licht de onderdelen toe)
![alt text](https://github.com/JoeriSmits/NotS-assignment-3/blob/master/proxy_HTTP.png "Proxy HTTP")

### Uit welke componenten bestaan een HTTP bericht. (Teken een diagram en licht de onderdelen toe)

### Hoe wordt de content in een bericht verpakt? (Teken een diagram en licht de onderdelen toe)

### Streaming content

## Kritische reflectie op eigen werk (optioneel,maar wel voor een 10)

### Wat kan er beter? Geef aan waarom?
Ik ben van mening dat de globale structuur van de applicatie beter kan. In de eerste opdracht (De Chat Applicatie) had ik de code, op een gedetailleerd niveau, onderverdeeld in verschillende klassen. Ik denk dat ik dat bij deze opdracht nog beter had kunnen doen, aangezien er nu redelijk veel code in één klasse staat. 
Daarnaast wilde ik ook wat meer onderzoek doen naar de _best practice_ om een proxy te maken. Je merkte dat er in de klas verschillende technieken werden gebruikt, maar het is mij nu niet duidelijk wat de voor en nadelen hiervan zijn en welke techniek de _best practice_ is.

### Wat zou je een volgende keer anders doen?
Ik wil de volgende keer eerder beginnen aan de opdracht. Het liefst, wil ik gelijk na de vorige opdracht beginnen met de volgende aangezien je die tijd nodig hebt. Ik ben denk ik net twee dagen te laat begonnen met de opdracht, waardoor ik nu met een klein tijdsprobleem zit. Hierdoor krijg ik de code niet zoals ik deze het liefst wil hebben, en moet ik de functionaliteiten meer prioriteit geven dan de code netheid.

### Hoe zou de opdracht anders moeten zijn om er meer van te leren?
Ik zou graag wat meer kennis willen hebben wat meer specifiek is aan de opdracht. Ik heb nu erg veel op internet moeten zoeken naar voorbeelden hoe mensen een proxy hebben gemaakt in C#. Hier kwamen erg weinig voorbeelden uit. Wat ik ook graag terug zou willen zien is de best practices te behandelen in de les gerelateerd aan de opdracht, en dan ook met voorbeeld code. Dit maakt het vaak stukken duidelijker hoe ik kan beginnen. Ik ben met deze opdracht namelijk best veel tijd kwijt geweest met te bedenken hoe ik moet gaan beginnen.

#Test cases

### Het bezoeken van de website server3.tezzt.nl
#### Case Handeling
Start de proxy door op de knop te klikken in de GUI. Stel de proxy in, in de web browser. Bezoek de website `server3.tezzt.nl` in de webbrowser. 
####Case verwacht gedrag
De proxy zou voor iedere HTTP Request die in de log staat een HTTP response moeten teruggeven.

### Schakel de User-Agent checkbox aan
#### Case Handeling
Start de proxy door op de knop te klikken in de GUI. Stel de proxy in, in de web browser. Druk op de checkbox knop P4. Zorg dat de checkbox knop P4 aangevinkt staat. Bezoek de website `server3.tezzt.nl`.
#### Case verwacht gedrag
Bevestig dat de `User-Agent` header is verwijderd uit het request door dubbel te klikken op het HTTP Request list item.

#Kritische reflectie op eigen beroepsproduct

###Definieer kwaliteit in je architectuur, design, implementatie.
Zoals ik al in de bovenstaande reflectie vermeldde ben ik niet tevreden met de code structuur van de applicatie. Om aan een goede code kwaliteit te voldoen vind ik dat je zo gedetailleerd klasses moet aanmaken. Dit betekend dat klasses eigenlijk zo weinig mogelijk moeten doen.

###Geef voorbeelden.
Ik heb nu één grote klasse die ClientConnection heet. Deze klasse had beter kunnen worden opgesplitst in een klasse _Request_ en een klasse _Response_. 

###Wat kan er beter, waarom?
De structuur van de code gaat er op vooruit als ik het bovenste toe pas. Je krijgt zo vaak ook kleinere methodes in de klassen, omdat je complexe taken verspreid over meerdere klassen en meerdere methoden. Zeker voor als een andere ontwikkelaar in een later scenario met mijn code door moet is dit van belang.
