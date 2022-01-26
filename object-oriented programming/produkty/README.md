## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)

## General info
Zdefiniować klasę Produkt, która opisuje produkty przechowywane w systemie. Klasa powinna być napisana zgodnie z zasadami enkapsulacji (hermetyzacji) i posiadać pola prywatne:
* string nazwaProduktu;
* float cenaNetto;
* float podatek; // procent opodatkowania
* int liczbaDostepnych;
Klasa Produkt powinna mieć również następujące metody:
* konstruktor bezparametrowy nadający domyślne wartości wszystkim polom (według uznania projektanta);
* konstruktor z parametrami takimi samymi, jak pola klasy;
* wszystkie „gettery' i „settery”;
* metodę PodajCene(); bezparametrową, podającą cenę produktu wraz z podatkiem;
* metodę PodajCene(int liczba); z parametrem, podającą cenę produktu wraz z podatkiem za daną liczbę produktów;
* metodę Wartosc(); podającą cenę z podatkiem za wszystkie dostępne produkty
* metodę Wyswietl(); wyświetlającą informacje o produkcie.

Zdefiniuj klasę pochodną do klasy Produkt. Nazwij ją Komputer – klasa ta ma opisywać produkt będący komputerem.

Poza klasycznymi polami, konstruktorami i metodami należy dodać do niej kolejne pola przydatne do opisania komputera (rodzaj procesora, pamięci ROM i RAM, system operacyjny), przesłonić  metodę Wyświetl z klasy Produkt, tak aby wyświetlała także pola specyficzne dla Komputera

W metodzie Main() utwórz dwa dowolne produkty  (jeden konstruktorem bezparametrowym, a drugi konstruktorem z parametrami) oraz dwa komputery  (jeden konstruktorem bezparametrowym, a drugi konstruktorem z parametrami)) i dodaj wszystkie do listy.
Następnie w pętli foreach wyświetl informacje o wszystkich produktach z listy
	
## Technologies
Project is created with:
* C#
	
## Setup
Nie trzeba nic dodatkowo instalowac
Utworzone są 2 klasy: Produkt i Komputer(pochodna do klasy Produkt)