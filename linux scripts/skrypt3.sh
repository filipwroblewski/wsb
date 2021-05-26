#!/bin/bash

# zmienna globalna
ZMIENNAGLOBALNA=0

function dzisiaj() 
{
	echo "Today's date: $(date)" >&2
}

# pobranie 2 arg i wyswietlenie na ekranie
function parametry()
{
	local Param1=$1
	local Param2=$2
	echo "Parametr1=$Param1 Parametr2=$Param2" >&2
	
	# dziala jak return
	echo "$Param2"
}

clear

# sprawdzenie czu user jest sud
# -ne -> not equal
# exit konczy dzialanie skryptu
# exit 0 - poprawne wykonanie skryptu
# exit cos_innego - niepoprawne wykonanie skryptu
# [[ $(id -u) -ne 0 ]] && { printf "Skrypt wymaga uprawnien root'a!\n"; exit 1; }

echo "Uruchomion skrypt"

# instrukcja warunkowa
if [ $1 = $2 ]
then
	echo "Parametr 1 jest taki sam jak 2"
elif [ $1 = 0 ]
then
	echo "Param 1 jest rowny 0"
else
	echo "Parametr $1 nie jest taki sam jak $2"
fi

ZMIENNAGLOBALNA=$(parametry $1 $(id -u))

# pobieranie 1st, 2nd, 3rd argumentu
printf "Argument1=$ZMIENNAGLOBALNA\nArgument2=$2\nArgument3=$3\n"
$(dzisiaj)

# for loop ; loop od 1 do 10 -> for var in {1..10}
# for var in $(seq 6 2 12)	-> od 6 do 12 z przeskokiem co 2
for var in $(seq 6 2 12)
do
	echo "Wartosc=$var"
done

for command in pwd date
do
	echo "Wartosc=$command"
	$command
done

for (( i=1; $i < 10; i++ ))
do
	echo "I=$i"
done

ZMIENNAPETLI=0
while [ $ZMIENNAPETLI -lt 10 ]
do
	echo "ZmiennaPetli=$ZMIENNAPETLI"
	ZMIENNAPETLI=$((ZMIENNAPETLI+1))
	# nazwazmiennej = $(())	-> przejscie w tryb arytmetyczny
	
done


# wejscie w interakcje z uzytkownikiem w czasie dzialania programu
ZMIENNAREAD

# echo -n 	-> wpisanie w tej samej linijce
# echo 	-> wpisanie w nowejS linijce
echo -n "Wpisz jakis tekst> "
# read ZMIENNAREAD
# echo "Wpisles:$ZMIENNAREAD"

if read -t 4 ZMIENNAREAD ; then
	echo "Wpisles:$ZMIENNAREAD"
else
	echo "No peszek!"
fi
	
	
	
	
	
