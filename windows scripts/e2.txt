@echo off
setlocal EnableDelayedExpansion

set /P new_path=Podaj sciezke przeszukiwania: 
set /P f_extension=Podaj rozszerzenie: 

if "%new_path%" EQU "" echo "Nie podano sciezki" & goto end
if not exist %new_path% echo "Bledna sciezka" & goto end

if "%f_extension%" EQU "" echo "Nie podano rozszerzenia" & goto end

if not exist ".\backup" md "backup"
if not exist ".\backup\%date%" md ".\backup\%date%"


for /r %new_path% %%a in (*.%f_extension%) do (
  set f_name=%%~na
  set f_letter=%f_name:~0,1%
  if not exist ".\backup\%date%\%f_letter%" md ".\backup\%date%\%f_letter%"
  copy "%%~fa" ".\backup\%date%\%f_letter%"
  )

:end
echo --- zakonczono dzialanie programu ---

