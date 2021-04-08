@echo off

set /P new_path=Podaj sciezke: 
set /P to_find=Podaj fraze do znalezienia: 

if "%new_path%" EQU "" echo "Nie podano sciezki" & goto end
if not exist %new_path% echo "Bledna sciezka" & goto end

if "%to_find%" EQU "" echo "Nie podano frazy do wyszukania" & goto end

for /r "%new_path%" %%a in (*.txt) do (
  findstr /m "%to_find%" "%%a"
  )
rem findstr /m "%to_find%" "%new_path%*.txt"

:end
echo --- zakonczono dzialanie programu ---

rem findstr /m "abc" "d:\wsb\*.txt"