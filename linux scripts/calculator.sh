#!/bin/bash

echo "Calculator"
echo "To end your calculations and get result, type '.' in any input"

checkInput()
{
	[[ "$1" = "." ]] && { printf "You'r operations: $ALLOPERATIONS=$FULLRESULT=$((FULLRESULT))\n"; saveFile "$ALLOPERATIONS=$((FULLRESULT))"; exit 0; }
}

inputSecondNumber()
{
	echo -n "Input second number> "
	read SECONDNUM
	INPUT=$SECONDNUM
	checkInput "$INPUT"
	
	re='^[0-9]+$'
	if ! [[ $INPUT =~ $re ]]
	then
		printf "Not a number! Try again\n"
		inputSecondNumber
	fi
}

inputOperator()
{
	echo -n "Input operator ( + - * / ^ )> "
	read OPERATOR
	INPUT=$OPERATOR
	checkInput "$INPUT"

	if [ "$OPERATOR" = "+" ] || [ "$OPERATOR" = "-" ] || [ "$OPERATOR" = "*" ] || [ "$OPERATOR" = "/" ]
	then
		inputSecondNumber
		RESULT="$OPERATOR$SECONDNUM"
		#echo "$RESULT" >&2
	elif [ "$OPERATOR" = "^" ]
	then
		inputSecondNumber
		
		TMP=1
		for var in $(seq 1 1 $SECONDNUM)
		do
			#echo "$EALIERNUM" >&2
			#TMP=$((TMP*EALIERNUM))
			TMP="$TMP*$EALIERNUM"
			
		done
		#RESULT="$OPERATOR$SECONDNUM"
		
		if [ "$EALIEROPERATOR" = "+" ]
		then
			RESULT="+$TMP-$EALIERNUM"
		elif [ "$EALIEROPERATOR" = "-" ]
		then
			RESULT="-($TMP)+$EALIERNUM"
		fi
		#echo "$RESULT" >&2
		
	else
		echo "Wrong operator"
		inputOperator
	fi

		
		#if [[ "$INPUT" = "+" ]] || [[ "$INPUT" = "-" ]] || [[ "$INPUT" = "*" ]] || [[ "$INPUT" = "/" ]] || [[ "$INPUT" = "^" ]] 
		#then 
			#printf "You have to input correct value\n"
			#inputOperator
		#	WHILEVAR="done"
		#fi
	
	EALIEROPERATOR="$OPERATOR"
}

saveFile(){
	OUTPUT="$1"
	if [ "$FILENAME" = "" ]
	then
		touch "calc_output.txt"
	else
		touch "$FILENAME"
	fi
	printf "$OUTPUT\n" >> "$FILENAME"
}

echo -n "Input first number> "
read FIRSTNUM
INPUT=$FIRSTNUM
checkInput "$INPUT"

FILENAME="$1"

EALIERNUM=$FIRSTNUM
FULLRESULT=$FIRSTNUM
ALLOPERATIONS="$FIRSTNUM"
EALIEROPERATOR=""
while [ 1=1 ]
do
	inputOperator
	#inputSecondNumber

	#FIRSTNUM = $(())
	#SECONDNUM = $(())
	EALIERNUM=$SECONDNUM
	ALLOPERATIONS="$ALLOPERATIONS$OPERATOR$SECONDNUM"
	FULLRESULT="$FULLRESULT$RESULT"
	#echo "ALLOPERATIONS=$ALLOPERATIONS"
	#echo "FULLRESULT=$FULLRESULT"

done

