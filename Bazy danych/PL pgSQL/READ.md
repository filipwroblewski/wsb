# Podstawy języka PL/pgSQL
# Ćwiczenia praktyczne

## 1. Utwórz anonimowy blok PL/pgSQL o następującej zawartości: 
### Deklaracje zmiennych:
- d typu date
- u typu varchar
- b typu varchar

### Kod wykonywalny:
- do zmiennej d podstaw wynik funkcji current_date (bieżąca data)
- do zmiennej u podstaw wynik funkcji current_user (bieżący użytkownik)
- do zmiennej b podstaw wynik funkcji current_database() (bieżąca baza danych)
- wyświetl komunikat, zawierający zmienne d, u i b: `'Jest dziś <tu wstaw d>, pracujesz na bazie danych <tu wstaw b> jako użytkownik <tu wstaw u>'`
### Uruchom utworzony blok PL/pgSQL.

## 2. Napisz i wykonaj anonimowy blok PL/pgSQL, który znajdzie i wyświetli wszystkie dzielniki liczby 100 (liczby, przez które 100 dzieli się bez reszty).
### Wskazówka: do sprawdzenia, czy liczby dzielą się bez reszty wykorzystaj funkcję modulo (%):
`if 100 % x = 0 …`

## 3.  Napisz i wykonaj anonimowy blok PL/pgSQL, który wyświetli wszystkie piątki 13 do końca roku 2025.
### Wskazówka: do odczytania numeru dnia miesiąca z daty możesz wykorzystać `extract(day from d)`, a do odczytania numeru dnia tygodnia: `extract(dow from d)` (piątek = 5).

## 4. Utwórz tabelę CARS o następującej strukturze:
`create table cars (
	c_id integer,
	make varchar(20),
	model varchar(20),
	price float,
	description char(250)
);`

## 5. Napisz i wykonaj anonimowy blok PL/pgSQL, który wygeneruje 10 sztucznych rekordów i wstawi je do tabeli CARS. Dane powinny być generowane według następującego algorytmu:
- `c_id` otrzymuje kolejne wartości całkowite, począwszy od 1
- `make` i `model` samochodu wybrane losowo list: `array['porsche', 'mercedes' , 
'mercedes', 'audi', 'audi', 'audi', 'bmw', 'bmw', 'bmw', 'mercedes']` i 
`array['911','e','glc', 'a4', 'a6', 'q5', '3', '5', 'x3', 'c']`
- `price` samochodu wylosowana z przedziału 1000-100000
- `description` wypełnione tekstem `'*** wygenerowane ***'`
### Do wyznaczania wartości losowych wykorzystaj funkcję RANDOM(), która generuje wartość z przedziału <0;1).