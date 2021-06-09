#!/bin/bash

librariesInstallation(){
	printf "Prosze czekac, trwa instalowanie potrzebnych pakietow\n"
	{
		apt update --yes
		
		apt-get install python
		apt-get install youtube-dl
		
		apt --yes install ffmpeg
	} &> /dev/null
	
}

getExtension(){
	printf "Wybierz rozszerzenie pliku wyjsciowego (mp3/mp4)> "
	read FILEEXTENSION
	
	if [ "$FILEEXTENSION" == "mp3" ]
	then
		printf "wybrales mp3\n"
		fileCut
	elif [ "$FILEEXTENSION" == "mp4" ]
	then
		fileCut
	else
		printf "Wprowadzone rozszerzenie nie jest obslugiwane.\n"
		getExtension
	fi
}

fileCut(){
	printf "Przycinanie pliku $FILEEXTENSION\n"
	{
		ffmpeg -i "$PATHTOVIDEO" -ss "$STARTVIDEO" -to "$ENDOFVIDEO" "$MAINOUTPUTFILENAME.$FILEEXTENSION"
	} &> /dev/null
	printf "Pomyslnie przycieto plik $FILEEXTENSION\n"
	#printf "$PATHTOVIDEO"
	rm -f "$PATHTOVIDEO"
	
}

getYtVideo(){
	printf "Pobieranie filmiku z serwisu YouTube ($LINKTOYTVIDEO)\n"
	youtube-dl -f 18 -q "$LINKTOYTVIDEO"
	OUTPUTFILENAME=`youtube-dl --get-filename "$LINKTOYTVIDEO"`
	CURRENTPATH=`pwd`
	PATHTOVIDEO="$CURRENTPATH/$OUTPUTFILENAME"
}

echo "Uruchomiono $0"
[[ $(id -u) -ne 0 ]] && { printf "Skrypt wymaga uprawnien root'a!\n"; exit 1; }
echo "Pomyslna weryfikacja uzytkownika jako sudo"

#instalacja wszystkich potrzebnych bibliotek
#librariesInstallation

#https://www.youtube.com/watch?v=a6RVze4Z15w
#link do filmiku na youtube, gdzie jest filmik, ktory nas interesuje
LINKTOYTVIDEO=$1

#czas od ktorego chcemy przyciac nasz filmik, podany w formacie np: 
#00:00:05
STARTVIDEO=$2

#czas do ktorego chcemy przyciac nasz filmik, podany w formacie np: 
#00:00:22
ENDOFVIDEO=$3

#nazwa naszego pliku wyjsciowego, podana bez rozszerzenia np:
#nazwaPliku
MAINOUTPUTFILENAME=$4

#przykladowe wywolanie skryptu: 
#sudo ./ytDownloader.sh https://www.youtube.com/watch?v=a6RVze4Z15w 00:00:05 00:00:22 nazwaPliku

#pobranie filmiku z serwisu youtube
getYtVideo

#wybranie rozszerzenia pliku wyjsciowego i wywolanie funkcji (fileCut) odpowiedzialnej za przycinanie pliku
getExtension




