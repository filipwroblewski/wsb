#!/bin/bash

function fun1 {
	echo "Witaj uzytkowniku "
	whoami
	# tutaj nazwa uzytkownika!
}

function fun2 {
	echo "Dzisiejsza data to: "
	date +%B", "%d"/"%m"/"%Y", "%I":"%M":"%S
	# nazwa dnia, dzien/miesiac/rok, godzina:minuty:sekundy
}

function fun3 {
	echo "Aktualnie znajdujesz sie w katalogu: "
	pwd
	# nazwa katalogu
}

function fun4 {
	echo "Twoj katalog domowy to: "
	echo $HOME
	# nazwa katalogu
}

function fun5 {
	echo "Aktualny stan pamieci systemu: "
	gawk {'print $2'} <<< $(free | sed '2q;d')
	# free | grep 'Mem'
	# ilosc pamieciS
}


echo $(fun1)
echo $(fun2)
echo $(fun3)
echo $(fun4)
echo $(fun5)




