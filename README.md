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
| |Laag|Protocollen/systemen|
|:---:|:---:|:---:|
|7|Applicatie|HTTP, FTP, DNS, RTP|
|4|Transport|TCP, UDP, SCTP|
|3|Netwerk|TCP/IP gebruikt hiervoor het Internet Protocol (IP)|
|2|Data Link|Ethernet, Token Ring|
|1|Fysiek|Fysieke media, en lijncodering, T1, E1|


### Code voorbeeld van je eigen code

### Alternatieven & adviezen

### Authentieke en gezaghebbende bronnen

## Bestudeer de RFC van HTTP 1.1.

### Hoe ziet de globale opbouw van een HTTP bericht eruit? (Teken een diagram en licht de onderdelen toe)

### Uit welke componenten bestaan een HTTP bericht. (Teken een diagram en licht de onderdelen toe)

### Hoe wordt de content in een bericht verpakt? (Teken een diagram en licht de onderdelen toe)

### Streaming content

## Kritische reflectie op eigen werk (optioneel,maar wel voor een 10)

### Wat kan er beter? Geef aan waarom?

### Wat zou je een volgende keer anders doen?

### Hoe zou de opdracht anders moeten zijn om er meer van te leren?

#Test cases

###Case naam

###Case handeling

###Case verwachtgedrag

#Kritische reflectie op eigen beroepsproduct

###Definieer kwaliteit in je architectuur, design, implementatie.

###Geef voorbeelden.

###Wat kan er beter, waarom?
