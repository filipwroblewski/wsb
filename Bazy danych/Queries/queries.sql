/*
------------------------ SELEKCJA I PROJEKCJA
*/

/*1. Wyświetl tytuły filmów wyprodukowanych w roku 1998 lub w roku 1999*/
SELECT tytul FROM filmy WHERE rok_produkcji=1998 OR rok_produkcji=1999

/*2. Wyświetl tytuły i ceny wypożyczenia filmów, których cena wypożyczenia
przekracza 9 zł. Wynik uporządkuj rosnąco według ceny wypożyczenia.*/
SELECT tytul, cena FROM filmy WHERE cena>9 ORDER BY cena

/*3. Wyświetl nazwiska wszystkich klientów o imieniu ‘Jan’.*/
SELECT nazwisko FROM klienci WHERE imie='Jan'

/*4. Wyświetl imiona i nazwiska wszystkich klientów, których imię liczy więcej
znaków niż nazwisko.*/
SELECT imie, nazwisko FROM klienci WHERE LENGTH(imie) > LENGTH(nazwisko)

/*5. Wyświetl nazwiska wszystkich aktorów o imionach: ‘Arnold’, ’Tom’ i ‘Jodie’.
Wynik uporządkuj rosnąco według nazwisk.*/
SELECT nazwisko FROM aktorzy WHERE imie='Arnold'  OR imie='Tom' OR imie='Jodie' ORDER BY nazwisko

/*6. Wyświetl identyfikatory wszystkich filmów, których kopie są aktualnie
dostępne w wypożyczalni. Wyeliminuj duplikaty. Wynik uporządkuj rosnąco w
kolejności identyfikatorów filmów.*/
SELECT DISTINCT id_filmu FROM kopie WHERE czy_dostepna='T' ORDER BY id_filmu

/*7. Wyświetl identyfikatory wszystkich kopii, które zostały wypożyczone pomiędzy
‘2005-07-15’ a ‘2005-07-22’. Wyeliminuj duplikaty. Wynik uporządkuj rosnąco
w kolejności identyfikatorów kopii.*/
SELECT DISTINCT id_kopii FROM wypozyczenia WHERE data_wypozyczenia BETWEEN '2005-07-15' AND '2005-07-22' ORDER BY id_kopii

/*8. Wyświetl identyfikatory i czas trwania wypożyczenia (w dniach) wszystkich
kopii, które zostały wypożyczone na okres dłuższy niż 1 dzień.*/
SELECT id_kopii, (data_zwrotu-data_wypozyczenia) AS "czas trwania" FROM wypozyczenia WHERE data_zwrotu-data_wypozyczenia>1

/*9. Wyświetl dane wszystkich aktorów według następującego formatu: pierwsza
litera imienia, kropka, spacja, nazwisko.*/
SELECT SUBSTRING(imie, 1, 1) || '. ' || nazwisko FROM aktorzy

/*10. Wyświetl tytuły wszystkich filmów uporządkowane w kolejności od
najkrótszego do najdłuższego tytułu.*/
SELECT tytul FROM filmy ORDER BY length(tytul)

/*11. Wyświetl tytuły i ceny wypożyczenia trzech najnowszych filmów.*/
SELECT tytul, cena FROM filmy ORDER BY rok_produkcji DESC LIMIT 3

/*12. Dla każdego klienta wyświetl: pełne imię, pierwszą literę imienia, ostatnią literę
imienia. Nagłówki kolumn powinny posiadać takie brzmienie, jak podano
poniżej.*/
SELECT imie, SUBSTRING(imie, 1, 1) as "pierwsza", SUBSTRING(imie, LENGTH(imie), LENGTH(imie)) AS "ostatnia" FROM klienci

/*13. Wyświetl te imiona klientów, których pierwsza i ostatnia litera imienia są
identyczne. Ignoruj wielkość porównywanych znaków. Wyeliminuj duplikaty.*/
SELECT imie FROM klienci WHERE LOWER(SUBSTRING(imie, 1, 1)) = LOWER(SUBSTRING(imie, LENGTH(imie), LENGTH(imie)))

/*14. Wyświetl tytuły filmów, których przedostatnia litera tytułu to ‘o’.*/
SELECT tytul FROM filmy WHERE  tytul LIKE '%o_'

/*15. Dla każdego klienta wyświetl jego adres e-mail skonstruowany w następujący
sposób: imię małymi literami, kropka, nazwisko małymi literami, ‘@wsb.pl’.*/
SELECT (LOWER(imie) || '.' ||LOWER(nazwisko)|| '@wsb.pl') AS "email" FROM klienci






/*
------------------------ POLACZENIA
*/

/*16. Dla każdej kopii wyświetl jej identyfikator i tytuł zapisanego na niej filmu.
Wynik uporządkuj według identyfikatorów kopii.*/
SELECT kopie.id_kopii, filmy.tytul 
FROM kopie JOIN filmy ON kopie.id_filmu=filmy.id_filmu

/*17. Wyświetl tytuły wszystkich filmów, 
których kopie są aktualnie dostępne w
wypożyczalni. Wyeliminuj duplikaty.*/
SELECT DISTINCT filmy.tytul 
FROM filmy NATURAL JOIN kopie
WHERE kopie.czy_dostepna='T'

/*18. Wyświetl identyfikatory kopii zawierających 
filmy wyprodukowane w roku 1984.*/
SELECT kopie.id_kopii 
FROM filmy NATURAL JOIN kopie
WHERE filmy.rok_produkcji=1984

/*19. Dla każdego wypożyczenia wyświetl datę wypożyczenia, 
datę zwrotu oraz nazwisko klienta, który dokonał wypożyczenia*/
SELECT wypozyczenia.data_wypozyczenia, wypozyczenia.data_zwrotu, klienci.nazwisko
FROM wypozyczenia NATURAL JOIN klienci

/*20. Dla każdego wypożyczenia wyświetl nazwisko klienta, który dokonał
wypożyczenia oraz tytuł wypożyczonego filmu.*/
SELECT klienci.nazwisko, filmy.tytul
FROM wypozyczenia 
NATURAL JOIN klienci 
NATURAL JOIN kopie 
NATURAL JOIN filmy

/*21. Wyświetl tytuły i lata produkcji wszystkich filmów 
wypożyczonych przez klienta o nazwisku ‘Kowalski’.*/
SELECT filmy.tytul, filmy.rok_produkcji
FROM wypozyczenia 
NATURAL JOIN klienci 
NATURAL JOIN kopie 
NATURAL JOIN filmy
WHERE klienci.nazwisko='Kowalski'

/*22. Wyświetl nazwisko klienta, który dokonał 
pierwszego wypożyczenia w historii wypożyczalni.*/
SELECT klienci.nazwisko, wypozyczenia.data_wypozyczenia
FROM wypozyczenia 
NATURAL JOIN klienci 
NATURAL JOIN kopie 
NATURAL JOIN filmy
ORDER BY wypozyczenia.data_wypozyczenia
LIMIT 1

/*23. Wyświetl nazwiska aktorów, 
którzy zagrali w filmie pt. ‘Terminator’.*/
SELECT aktorzy.nazwisko
FROM aktorzy 
NATURAL JOIN obsada 
NATURAL JOIN filmy
WHERE filmy.tytul='Terminator'


/*24. Wyświetl tytuły wszystkich filmów, 
w których zagrał aktor o nazwisku ‘De Niro’.*/
SELECT filmy.tytul
FROM aktorzy 
NATURAL JOIN obsada 
NATURAL JOIN filmy
WHERE aktorzy.nazwisko='De Niro'

/*25. Wyświetl tytuł filmu, który był 
wypożyczony na najdłuższy okres czasu*/
SELECT filmy.tytul, (wypozyczenia.data_zwrotu-wypozyczenia.data_wypozyczenia) AS "czas"
FROM wypozyczenia 
NATURAL JOIN kopie 
NATURAL JOIN filmy
ORDER BY (wypozyczenia.data_zwrotu-wypozyczenia.data_wypozyczenia) DESC
LIMIT 1

/*26. Wyświetl nazwiska klientów, którzy dokonali wypożyczeń 
pomiędzy ‘2005-07-15’ a ‘2005-07-20’. Wyeliminuj duplikaty.*/
SELECT DISTINCT klienci.nazwisko
FROM wypozyczenia 
NATURAL JOIN klienci
WHERE wypozyczenia.data_wypozyczenia BETWEEN '2005-07-15' AND '2005-07-20'

/*27. Wyświetl tytuły filmów wypożyczonych pomiędzy ‘2005-07-15’ 
a ‘2005-07-25’. Wyeliminuj duplikaty.*/
SELECT DISTINCT filmy.tytul
FROM wypozyczenia 
NATURAL JOIN kopie
NATURAL JOIN filmy
WHERE wypozyczenia.data_wypozyczenia BETWEEN '2005-07-15' AND '2005-07-25'

/*28. Dla klientów, którzy noszą takie same imiona, 
jak któryś z aktorów, wyświetl: wspólne imię, nazwisko klienta, 
nazwisko aktora.*/
SELECT klienci.imie, klienci.nazwisko, aktorzy.nazwisko
FROM klienci 
JOIN aktorzy ON klienci.imie=aktorzy.imie





/*

--------------- OPERACJE MNOGOŚCIOWE

*/

/*29. Wyświetl wspólną listę nazwisk wszystkich klientów i wszystkich aktorów.
Wynik uporządkuj alfabetycznie.*/
SELECT aktorzy.nazwisko FROM aktorzy
UNION
SELECT klienci.nazwisko FROM klienci

/*30. Wyświetl tytuły filmów, w których razem zagrali aktorzy o nazwiskach ‘De
Niro’ i ‘Reno’.*/
SELECT filmy.tytul
FROM filmy
NATURAL JOIN obsada
NATURAL JOIN aktorzy
WHERE aktorzy.nazwisko='De Niro'
INTERSECT
SELECT filmy.tytul
FROM filmy
NATURAL JOIN obsada
NATURAL JOIN aktorzy
WHERE aktorzy.nazwisko='Reno'

/*31. Wyświetl tytuły tych filmów, które były wypożyczane zarówno przez klienta o
nazwisku ‘Kowalski’, jak i przez klienta o nazwisku ‘Nowak’.*/
SELECT filmy.tytul
FROM filmy
NATURAL JOIN kopie
NATURAL JOIN wypozyczenia
NATURAL JOIN klienci
WHERE klienci.nazwisko='Kowalski'
INTERSECT
SELECT filmy.tytul
FROM filmy
NATURAL JOIN kopie
NATURAL JOIN wypozyczenia
NATURAL JOIN klienci
WHERE klienci.nazwisko='Nowak'

/*32 Wyświetl tytuły tych filmów, które były wypożyczane przez klienta o nazwisku
‘Kowalski’, a zarazem nigdy nie były wypożyczane przez klienta o nazwisku
‘Nowak’.*/
SELECT filmy.tytul
FROM filmy
NATURAL JOIN kopie
NATURAL JOIN wypozyczenia
NATURAL JOIN klienci
WHERE klienci.nazwisko='Kowalski'
EXCEPT
SELECT filmy.tytul
FROM filmy
NATURAL JOIN kopie
NATURAL JOIN wypozyczenia
NATURAL JOIN klienci
WHERE klienci.nazwisko='Nowak'

/*33 Wyświetl nazwiska aktorów, którzy zagrali w filmie pt. ‘Terminator’, a
jednocześnie nie zagrali w filmie pt. ‘Ghostbusters’.*/
SELECT aktorzy.nazwisko
FROM aktorzy
NATURAL JOIN obsada
NATURAL JOIN filmy
WHERE filmy.tytul='Terminator'
EXCEPT
SELECT aktorzy.nazwisko
FROM aktorzy
NATURAL JOIN obsada
NATURAL JOIN filmy
WHERE filmy.tytul='Ghostbusters'





/*
-------------------- FUNKCJE GRUPOWE
*/

/*34 Dla każdego roku produkcji filmu wyświetl średnią cenę wypożyczenia.
+ posortowac wzgledem rok produkcji malejaco(desc)*/
SELECT rok_produkcji, AVG(cena) 
FROM filmy
GROUP BY rok_produkcji
ORDER BY rok_produkcji DESC

/*35 Wyświetl cenę najdroższego filmu w wypożyczalni*/
SELECT MAX(cena) AS "max" FROM filmy

/*36. Wyświetl liczbę filmów wyprodukowanych w roku 1984.*/
SELECT COUNT(id_filmu) FROM filmy WHERE rok_produkcji=1984

/*37. Ile razy wypożyczono film pt. ‘Taksowkarz?*/
SELECT COUNT(filmy.id_filmu) FROM filmy
NATURAL JOIN kopie
NATURAL JOIN wypozyczenia
WHERE filmy.tytul='Taksowkarz'

/*38. Jaki był średni czas trwania wypożyczenia filmu pt. ‘Ronin’? Wynik wyświetl z
dokładnością do jednego miejsca po przecinku.
*/
SELECT ROUND(AVG(wypozyczenia.data_zwrotu-wypozyczenia.data_wypozyczenia),1) AS "round"
FROM wypozyczenia
NATURAL JOIN kopie
NATURAL JOIN filmy
WHERE filmy.tytul='Ronin'

/*39. Wyświetl zestawienie tytułów wszystkich filmów wraz z minimalnymi,
maksymalnymi i średnimi czasami trwania ich wypożyczenia oraz z liczbą
dokonanych wypożyczeń. Wyniki liczbowe podaj z dokładnością do jednego
miejsca po przecinku. Nagłówki wyświetlanych kolumn powinny być zgodne z
podanym przykładem.*/
SELECT filmy.tytul, 
	ROUND(MIN(wypozyczenia.data_zwrotu-wypozyczenia.data_wypozyczenia),1) AS "min", 
	ROUND(MAX(wypozyczenia.data_zwrotu-wypozyczenia.data_wypozyczenia),1) AS "max", 
	round(AVG(wypozyczenia.data_zwrotu-wypozyczenia.data_wypozyczenia),1) AS "sre", 
	COUNT(wypozyczenia.data_wypozyczenia) AS "razy"
FROM wypozyczenia
NATURAL JOIN kopie
NATURAL JOIN filmy
GROUP BY filmy.tytul

/*40. Dla każdego klienta wypożyczalni wyświetl jego imię, nazwisko oraz liczbę
dokonanych wypożyczeń.*/
SELECT klienci.imie, klienci.nazwisko, COUNT(wypozyczenia.id_klienta) AS "count"
FROM klienci
NATURAL JOIN wypozyczenia
GROUP BY klienci.imie, klienci.nazwisko

/*41. Dla każdego aktora wyświetl liczbę filmów, w których zagrał. Pomiń aktorów,
którzy zagrali tylko w jednym filmie.*/
SELECT aktorzy.imie, aktorzy.nazwisko, COUNT(filmy.id_filmu) AS "count"
FROM aktorzy
NATURAL JOIN obsada
NATURAL JOIN filmy
GROUP BY aktorzy.imie, aktorzy.nazwisko
HAVING COUNT(filmy.id_filmu)>1

/*42. Dla każdego klienta wyświetl sumaryczną kwotę, jaką wydał na wypożyczanie
filmów.*/
SELECT klienci.nazwisko, SUM(filmy.cena) AS "kwota"
FROM klienci
NATURAL JOIN wypozyczenia
NATURAL JOIN kopie
NATURAL JOIN filmy
GROUP BY klienci.nazwisko





/*
--------------------------- PODZAPYTANIA
*/

/*43. Wyświetl tytuł filmu, którego wypożyczenie kosztuje najwięcej. Nie korzystaj z
operatora LIMIT.*/
SELECT filmy.tytul FROM filmy
WHERE filmy.cena=(
	SELECT MAX(filmy.cena) FROM filmy)

/*44. Wyświetl nazwisko klienta, który dokonał pierwszego wypożyczenia w historii
wypożyczalni. Nie korzystaj z operatora LIMIT.*/
SELECT klienci.nazwisko FROM klienci
NATURAL JOIN wypozyczenia
WHERE wypozyczenia.data_wypozyczenia=(
	SELECT MIN(wypozyczenia.data_wypozyczenia) FROM wypozyczenia)

/*45. Wyświetl tytuły filmów, których kopie są dostępne w wypożyczalni
(czy_dostepna=’T’). Nie korzystaj z operacji połączenia.*/
SELECT filmy.tytul FROM filmy
WHERE filmy.id_filmu in (
	SELECT kopie.id_filmu FROM kopie 
	WHERE kopie.czy_dostepna='T')

/*46. Wyświetl tytuły filmów, których wypożyczenie kosztuje więcej niż
wypożyczenie filmu o tytule ‘Frantic’.*/
SELECT filmy.tytul FROM filmy
WHERE filmy.cena > (
	SELECT filmy.cena FROM filmy 
	WHERE filmy.tytul='Frantic')

/*47. Wyświetl tytuły filmów, których wypożyczenie kosztuje więcej niż
wypożyczenie każdego filmu o tytule liczącym 6 liter.*/
SELECT filmy.tytul FROM filmy
WHERE filmy.cena > (
	SELECT MAX(filmy.cena) FROM filmy 
	WHERE filmy.tytul LIKE '______')





/*
--------------------------- POLECENIA DML
*/

/*48. Do relacji FILMY wstaw nową krotkę: id_filmu=11, tytul=’Komornik’,
rok_produkcji=2005, cena=10.5. */
INSERT INTO FILMY
(id_filmu, tytul, rok_produkcji, cena)
VALUES
(11, 'Komornik', 2005, 10.5);

SELECT * FROM FILMY;

/*49. Z relacji FILMY usuń krotki opisujące filmy nakręcone w roku 2005.*/
DELETE FROM FILMY
WHERE rok_produkcji=2005;

SELECT * FROM FILMY;

/*50. Podnieś cenę wypożyczenia wszystkich filmów nakręconych przed rokiem
1980.*/
UPDATE FILMY
SET cena = cena + 0.5
WHERE rok_produkcji < 1980;

SELECT * FROM FILMY;

/*51. Do relacji FILMY wstaw nową krotkę: id_filmu=12, tytul=’Nikofor’,
rok_produkcji=2004, cena=9.5.*/
INSERT INTO FILMY
(id_filmu, tytul, rok_produkcji, cena)
VALUES
(12, 'Nikofor', 2004, 9.5);

SELECT * FROM FILMY;

/*52. Z relacji FILMY usuń wszystkie krotki opisujące filmy, w których nie zagrał
żaden aktor.*/
DELETE FROM filmy
WHERE filmy.id_filmu NOT IN (
	SELECT DISTINCT id_filmu FROM obsada
);

SELECT * FROM filmy;

/*53. Zmień cenę wypożyczenia filmu pt. ‘Taksowkarz’ na 5 zł.*/
UPDATE filmy
SET cena = 5
WHERE tytul='Taksowkarz';

SELECT * FROM filmy;





/*
--------------------------- TWORZENIE RELACJI
*/

/*54. Wyświetl strukturę relacji FILMY.*/
SELECT column_name AS "Column", 
	data_type AS "Type", 
	character_maximum_length AS "Character length" 
FROM information_schema.columns
WHERE table_name = 'filmy';

/*55. Utwórz relację KSIAZKI o następującej strukturze:
	a. ID_KSIAZKI - liczba całkowita
	b. TYTUL – łańcuch znakowy, maksymalnie 30 znaków (zmienna dł.)
	c. AUTOR – łańcuch znakowy, maksymalnie 30 znaków (zmienna dł.)
	d. ROK_WYDANIA – liczba całkowita*/
CREATE TABLE ksiazki(
	id_ksiazki INTEGER,
	tytul VARCHAR(30),
	autor VARCHAR(30),
	rok_wydania INTEGER
);

/*56. Wstaw dwie nowe krotki do relacji KSIAZKI.*/
INSERT INTO ksiazki VALUES (1, 'Pan Tadeusz', 'Adam Mickiewicz', 1995);
INSERT INTO ksiazki VALUES (2, 'Krzyzacy', 'Henryk Sienkiewicz', 1990);
SELECT * FROM ksiazki;

/*57. Wyświetl strukturę relacji KSIAZKI.*/
SELECT column_name AS "Column", 
	data_type AS "Type", 
	character_maximum_length AS "Character length" 
FROM information_schema.columns
WHERE table_name = 'ksiazki';

/*58. Usuń relację KSIAZKI.*/
DROP TABLE ksiazki





/*
--------------------------- OGRANICZENIA INTEGRALNOŚCIOWE
*/

/*59. Utwórz relację OSOBY o następującej strukturze:
	a. PESEL łańcuch znakowy 11-znakowy (stała dł.)
	b. IMIE łańcuch znakowy 15-znakowy (zmienna dł.)
	c. NAZWISKO łańcuch znakowy 15-znakowy (zmienna dł.)
	d. DATA_URODZENIA data
	Ponadto, podczas tworzenia nowej relacji zdefiniuj następujące ograniczenia
	integralnościowe:
	e. PESEL musi liczyć dokładnie 11 znaków
	17
	f. pierwsze dwie cyfry numeru PESEL muszą być takie same, jak
	ostatnie dwie cyfry roku w atrybucie DATA_URODZENIA
	g. kolejne dwie cyfry numery PESEL muszą być takie same, jak numer
	miesiąca w atrybucie DATA_URODZENIA
	h. kolejne dwie cyfry numeru PESEL muszą być takie same, jak numer
	dnia w atrybucie DATA_URODZENIA
	i. atrybut PESEL jest kluczem głównym relacji
	j. atrybuty IMIĘ i NAZWISKO muszą być wypełnione (niepuste)*/
CREATE TABLE osoby(
	pesel CHAR(11) CHECK (LENGTH(pesel)=11) PRIMARY KEY,
	imie VARCHAR(15) NOT NULL,
	nazwisko VARCHAR(15) NOT NULL,
	data_urodzenia DATE,
	CHECK (SUBSTRING(pesel,1,6)=CONCAT(TO_CHAR(DATA_URODZENIA,'YY'), 
									  TO_CHAR(DATA_URODZENIA,'MM'), 
									  TO_CHAR(DATA_URODZENIA,'DD')))
);

/*60. Do relacji OSOBY wstaw następujące krotki. Czy operacje się powiodły?
Dlaczego?
a. ‘39090100001’,’Jan’,’Kowalski’,’1939-09-01’
b. ‘750218’,’Adam’,’Nowak’,’1975-02-18’
c. ‘75021800123’,’Adam’,’Nowak’,’1975-02-20’
d. ‘75021800123’,’Adam’,’Nowak’,’1975-02-18’*/
INSERT INTO osoby VALUES 
('39090100001','Jan','Kowalski','1939-09-01');
/*przeszlo*/
INSERT INTO osoby VALUES 
('750218','Adam','Nowak','1975-02-18');
/*pesel ma mniej znakow niz 11*/
INSERT INTO osoby VALUES 
('75021800123','Adam','Nowak','1975-02-20');
/*przeszlo*/
INSERT INTO osoby VALUES 
('75021800123','Adam','Nowak','1975-02-18');
/*taki pesel juz istnieje*/


/*61. Utwórz relację FAKTURY o następującej strukturze:
a. NUMER liczba całkowita, generowana automatycznie, klucz główny
b. PESEL łańcuch znakowy 11-znakowy, klucz obcy do relacji OSOBY
c. KWOTA liczba rzeczywista 8-cyfrowa, 2 cyfry po przecinku, większa
od zera*/
CREATE TABLE faktury(
	numer SERIAL PRIMARY KEY, 
	pesel CHAR(11) CHECK(LENGTH(pesel)=11),
	kwota NUMERIC(8,2) CHECK(kwota>0),
	FOREIGN KEY(pesel) REFERENCES osoby
);

/*62. Do relacji FAKTURY wstaw następujące krotki. Czy operacje się powiodły?
Dlaczego?
a. PESEL=’39090100001’, KWOTA=123.45
b. PESEL=’39090199999’, KWOTA=678.90
c. PESEL=’39090100001’, KWOTA=1234567890
d. PESEL=‘75021800123’
e. NUMER=1, PESEL=’39090100001’, KWOTA=123.45*/
INSERT INTO faktury (pesel, kwota)
VALUES ('39090100001',123.45);
INSERT INTO faktury (pesel, kwota)
VALUES ('39090199999',678.90);
/*tego peselu nie ma w tabeli osoby*/
INSERT INTO faktury (pesel)
VALUES ('75021800123');
INSERT INTO faktury (numer, pesel, kwota)
VALUES (1, '39090100001',123.45);

/*63. Wyświetl pełną zawartość relacji FAKTURY.*/
SELECT * FROM faktury;





/*
--------------------------- DODATKOWE DO TEMATU WYZEJ ^^^
*/

/*64. Wyświetl numery faktur i figurujące na nich kwoty. W przypadku braku kwoty
faktury wyświetl 0.*/
SELECT numer, COALESCE(kwota, 0) AS kwota FROM faktury;





/*
--------------------------- MODYFIKACJA STRUKTURY RELACJI
*/

/*73. Do relacji FILMY dodaj nowy atrybut o nazwie CENA_EURO typu REAL.*/
ALTER TABLE filmy ADD COLUMN cena_euro REAL;
-- \d filmy

/*74. Zmodyfikuj wszystkie krotki relacji FILMY tak, aby atrybut CENA_EURO
zawierał wartość atrybutu CENA podzieloną przez 4.*/
UPDATE filmy SET cena_euro = (filmy.cena/4);
SELECT * FROM filmy;

/*75. W relacji FILMY zmień nazwę atrybutu CENA_EURO na EUROCENA*/
ALTER TABLE filmy RENAME COLUMN cena_euro TO eurocena;
SELECT * FROM filmy;

/*76. Z relacji FILMY usuń atrybut o nazwie EUROCENA.*/
ALTER TABLE filmy DROP COLUMN eurocena;
SELECT * FROM filmy;






/*
--------------------------- WARTOŚCI PUSTE
*/

/*77. Do relacji FILMY wprowadź nową krotkę o następujących wartościach
atrybutów: ID_FILMU=11, TYTUL=’Vabank’. Pozostałe atrybuty pozostaw
niewypełnione. */
INSERT INTO filmy (id_filmu, tytul)
VALUES (11,'Vabank');

/*78. Wyświetl tytuły wszystkich filmów, które nie posiadają żadnej wartości w
atrybucie ROK_PRODUKCJI. */
SELECT tytul FROM filmy WHERE rok_produkcji IS NULL; 

/*79. Wyświetl tytuły i ceny wszystkich filmów. W przypadku filmów, które nie
posiadają żadnej wartości w atrybucie CENA, wyświetl zero.*/
SELECT tytul, COALESCE(cena,0)  FROM filmy; 

/*80. Z relacji FILMY usuń wszystkie krotki, które nie posiadają wartości w
atrybutach ROK_PRODUKCJI i CENA*/
DELETE FROM filmy WHERE rok_produkcji IS NULL AND cena IS NULL;
SELECT * FROM filmy; 

