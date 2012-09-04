@echo off
SETLOCAL ENABLEDELAYEDEXPANSION
rem for /f "delims=" %%x in ('dir /b /ad abc*') do rd /s /q "%%x"
rem for /f "delims=" %%x in ('dir /b /ad bin') do echo rd /s /q "%%x"
rem for /f "delims=" %%x in ('dir /b /ad obj') do echo rd /s /q "%%x"
rem FOR /D /R %%X IN (bin) DO echo RD /S /Q "%%X"
SET ifExist=0
for /d /r %%I in (.) do (
	rem SET binPath=%%I\nul
	rem ECHO !binPath!
	rem IF EXIST "!binPath!" echo rd /s %%I
	rem CALL :ifExistFunc !binPath!
	rem CALL :ifExistFunc %%I
	rem IF "!ifExist!"=="1" echo rd /s %%I
)
GOTO :eof

:ifExistFunc
ECHO %1
SET ifExist=0
IF EXIST %1 ECHO %1
EXIT /b
