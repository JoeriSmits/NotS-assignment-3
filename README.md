Studentnaam: Joeri Smits

Studentnummer: 524292

‐‐‐

#Algemene beschrijving applicatie
Deze applicatie is een HTTP Proxy gebasseerd op het TCP protocol. De proxy heeft als functionaliteit dat afbeelding worden gefilterd en worden vervangen door placeholders. Daarnaast is er caching in de proxy ingebouwd. De proxy draait standaard op poort 9000 van 127.0.0.1 . Door de autheticatie vink aan te zitten in de GUI van de proxy worden de user-agent headers verwijderd.  
![alt text](https://github.com/JoeriSmits/NotS-assignment-3/blob/master/proxy_basic.png "Proxy basic")

De *client* stuurt zijn HTTP request naar de proxy, inplaats van naar het internet en dan naar de webbrowser. De proxy kan hierdoor de request aanpassen om bijvoorbeeld de `User-Agent` weg te laten. Daarna stuurt de proxy het request via het internet door naar de webserver die dan een reponse afgeeft. Deze response wordt opgevangen bij de proxy die deze response dan naar de client stuurt.

## Zorg voor een voorbeeld van een http‐request en van een http‐response.

(Kan je globale overeenkomsten vinden tussen een request en een response?) (Teken een diagram en licht de onderdelen toe)

## TCP/IP

### Beschrijving van concept in eigen woorden

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
