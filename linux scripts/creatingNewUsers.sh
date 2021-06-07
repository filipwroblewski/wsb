#!/bin/bash

enterData(){
	IFS=":"
	while read -ra line
	do
		((ALLUSERSFROMFILE+=1))
		((ALLGROUPSFROMFILE+=1))
		
		if [ "$(grep -c ${line[0]} /etc/passwd)" -eq "0" ]
		then
			printf "username ${line[0]} doesn't exist yet\n"
			useradd ${line[0]}
			((CREATEDUSERS+=1))
		fi
		
		if [ "$(grep -c ${line[1]} /etc/group)" -eq "0" ]
		then
			printf "groupname ${line[1]} doesn't exist yet\n"
			groupadd ${line[1]}
			((CREATEDGROUPS+=1))
		fi
	done < "$INPUTFILE"
}

[[ $(id -u) -ne 0 ]] && { printf "Skrypt wymaga uprawnien root'a!\n"; exit 1; }

ALLUSERSFROMFILE=0
ALLGROUPSFROMFILE=0
CREATEDUSERS=0
CREATEDGROUPS=0

INPUTFILE="lista_uzytkownikow.txt"
enterData

for user in "${USERSFROMFILE[@]}"
do
	echo "User=$user"
done
for group in "${GROUPSFROMFILE[@]}"
do
	echo "Group=$group"
done

echo "All users from file=$ALLUSERSFROMFILE"
echo "All groups from file=$ALLGROUPSFROMFILE"
echo "New created users=$CREATEDUSERS"
echo "New created groups=$CREATEDGROUPS"
