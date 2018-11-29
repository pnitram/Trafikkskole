CREATE TABLE users
(
userId INT NOT NULL AUTO_INCREMENT,
firstName VARCHAR (30) NOT NULL,
lastName VARCHAR (30) NOT NULL,
email VARCHAR (50) NOT NULL,
password VARCHAR(50) NOT NULL,
lastScore INT DEFAULT 0 NOT NULL,
highScore INT DEFAULT 0 NOT NULL,
isAdmin INT DEFAULT 0 NOT NULL,
updateDate  DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
CONSTRAINT USER_PK PRIMARY KEY (userId)
);
 
CREATE TABLE questionsAndAnswers
(
questionsId INT NOT NULL AUTO_INCREMENT,
question VARCHAR (350) NOT NULL,
answerAlt1 VARCHAR (350) NOT NULL,
answerAlt2 VARCHAR (350) NOT NULL,
answerAlt3 VARCHAR (350) NOT NULL,
answerAlt4 VARCHAR (350) NOT NULL,
isCorrectAlt1 INT NOT NULL,
isCorrectAlt2 INT NOT NULL,
isCorrectAlt3 INT NOT NULL,
isCorrectAlt4 INT NOT NULL,
multipleChoice INT NOT NULL,
isUrl INT NOT NULL,
url VARCHAR (350) NOT NULL,
CONSTRAINT QUESTION_PK PRIMARY KEY (questionsId)
);
 
INSERT INTO questionsAndAnswers (question, answerAlt1, answerAlt2, answerAlt3, answerAlt4, isCorrectAlt1, isCorrectAlt2, isCorrectAlt3, isCorrectAlt4, multipleChoice,isUrl,url)
VALUES
('Hva kan føreren bidra med for å minke forurensningen fra bilen?', 'Det er lite føreren kan bidra med', 'Kjøre på lavest mulig gir med høyt turtall', 'Bruke motorvarmer om vinteren og unngå unødig kjøring','Ha på skiboks', 0,0,0,1,0,0,"ikke url"),
 
('Blant hvilken trafikantgruppe er det flest drepte og skadde?', 'Barn og eldre', 'Fører og passasjer i bil', ' Fører og passasjerer på motorsykkel', 'Syklister og fotgjengere', 0,1,0,0,0,0,"ikke url"),
 
('Hvordan bør du akselerere for å spare drivstoff?', 'Rolig gasspådrag over tid til du når ønsket hastighet', 'Kraftig gasspådrag på hvert gir til du når ønsket hastighet', 'Kraftig gasspådrag, men gire tidlig til neste gir', 'Bestemt, men behagelig gasspådrag', 0,0,0,1,0,0,"ikke url"),
 
('Hva vil du gjøre i denne situasjonen?', 'Forsette med samme fart fordi bussen har vikeplikt', 'Øke farten før bussen svinger ut', 'Kjøre med gangfart, fordi bussen kan svinge ut, eller noen kan komme ut foran bussen', 'Stoppe helt og vente til bussen har kjørt', 0,0,1,0,0,0,"ikke url"),
 
('I hvilken rekkefølge skal det kjøres her?', 'A-B-C', 'B-C-A', 'A-C-B', 'C-B-A', 0,0,1,0,0,1,'http://bloggfiler.no/teoriprove.blogg.no/images/1679138-12-1358272069821.jpg'),
 
('Du skal gi fri vei for...', 'begravelsesfølger og prosesjoner', 'utrykingskjøretøy uten blinkende blåslys', 'taxi på holdeplass', 'tunge kjøretøy (vognetog)', 1,0,0,0,0,0,"ikke url"),
 
('Hva er riktig påstand?', 'Motorsykkel og personbil kan kjøres på motorvei', 'Motorsykkel, moped og bil kan kjøres på motorvei', 'Motorsykkel, moped og lastebil kan kjøre på motorvei', 'Kun busser, lastebiler og personbiler kan kjøre på motorvei', 1,0,0,0,0,0,"ikke url"),
 
('Hva betyr hvit sperrelinje?', 'Den angir fare ved å passere bil i kjørefeltet ved siden av', 'Den angir fare ved å skifte felt', 'Den angir at feltskifte er tilatt', 'Den angir forbud mot å skifte felt', 0,0,0,1,0,0,"ikke url"),
 
('Hva langt unna er faresituasjonen det varsles om?', '150-250 meter', '50-100 meter i tettbygd strøk', 'Faresituasjonen er der skiltet står', 'Det finnes ingen bestemte regler om dette', 1,1,0,0,1,0,"ikke url"),
 
('Hva er forskjell på gul og hvit oppmerking?', 'Gul oppmerking skiller trafikk i motsatt retning, mens hvit skiller trafikk i samme retning', 'Hvit oppmerking benyttes kun på motorvei, og gul brukes på forkjørsvei', 'Det benyttes bare gul oppmerking i Norge, mens i utlandet benyttes hvit', 'Det er ingen forskjell på gul og hvit oppmerking', 1,0,0,0,0,0,"ikke url"),
 
('Hvordan skal refleksene bak på bilen se ut?', 'Runde eller firkantede og fargen skal være rød', 'Runde og firkantede og fargen skal være oransj', 'Runde eller trekantede og fargen skal være rød', 'Runde eller trekantede og fargen skal være oransj', 1,0,0,0,0,0,"ikke url"),
 
('Hva bør minimumavstanden til forankjørende være?', 'Minst 3 sekunder', '2 sekunder på tørt føre og 4 sekunder på glatt føre', 'Minst 5 sekunder og enda lengre avstand på glatt føre', 'Alltid minst 8-10 sekunder', 0,0,1,0,0,0,"ikke url"),
 
('Hvor mye øker bremselengden, om du tredobler hastigheten?', 'Den dobles', 'Den firedobles', 'Den nidobles', 'Den tolvdobles', 0,0,1,0,0,0,"ikke url"),
 
('Hvilken rekkefølge skal det kjøres?', 'A-B-C-D', 'B-D-C-A', 'C-A-B-D', 'D-B-A-C', 0,0,1,0,0,1,"https://d24icrbeyffae7.cloudfront.net/images/179b414ee4eb0a811d47ae2f9bdb5eee9d75ab1e_NORMAL.JPG"),
 
('Du vil trekke tilhenger med din personbil. Hvor mye kan tilhengeren lovlig veie?', 'Førekort klasse B tillater ikke kjøring med tilhenger', 'Tilhenger med last kan veie halvparten av bilens totalvekt', 'Tilhenger med last kan veie dobbelt så mye som bilens egenvekt', 'Tilhengerens vekt begrenses av bilenes vognkort og av ditt førekort', 0,0,0,1,0,0,"ikke url"),
 
('Du kjører en bil og tilhenger med bremser der samlet tillatt totalvekt er 3500 kg. Hva er tillatt hastighet når dette skiltet er satt opp?', '60 km/t', '70 km/t', '80 km/t', '90 km/t', 0,0,1,0,0,0,"ikke url"),
 
('I 80 km/t kjører du forbi en bil som kjører 60 km/t. Hvor lang forbikjøringsstrekning trenger du?', 'Ca. 50m', 'Ca. 275m', 'Ca. 600m', 'Ca. 900m', 0,1,0,0,0,0,"ikke url"),
 
('Du er 23 år og har hatt lappen i fem år. Kan du være ledsager om din venn ønsker å øvelseskjøre med deg?', 'Ja', 'Ja, hvis eleven er over 18 år.','Nei', 'Ja, hvis du har ekstra speil i bilen', 1,0,0,0,0,0,"ikke url"),
 
('Hva er bremselengden når du kjører 40 km/t?', '11,1 m', '8 km', '8 m', '11,1 mm', 0,0,1,0,0,0,"ikke url"),
 
('Du bruker 4 meter på å bremse ved 20 km/t. Hvor lang blir bremselengden ved 40 km/t?', '8 meter', '10 meter', '36 meter', '32 meter', 0,0,1,0,0,0,"ikke url");
 
 
 
    INSERT INTO users(userId, firstName, lastName, email, password, isAdmin)
    VALUES (1, "Admin", "Admin", "admin@trafikal.no", "0192023A7BBD73250516F069DF18B500", 1);
 
SELECT COUNT(email) FROM users WHERE email="martin.pedersen@me.com";
