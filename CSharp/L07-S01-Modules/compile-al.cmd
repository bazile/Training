@ECHO OFF
SETLOCAL

SET "cscPath=%windir%\Microsoft.NET\Framework\v4.0.30319\csc.exe"
IF EXIST "%ProgramFiles(x86)%" (
	SET "alPath=%ProgramFiles(x86)%\Microsoft SDKs\Windows\v7.0A\Bin\NETFX 4.0 Tools\al.exe"
) ELSE (
	SET "alPath=%ProgramFiles%\Microsoft SDKs\Windows\v7.0A\Bin\NETFX 4.0 Tools\al.exe"
)

REM Compile modules ignoring warnings about not used types and fields
"%cscPath%" /t:module /nowarn:67,169 rare.cs
"%cscPath%" /t:module /nowarn:67,169 frequent.cs

REM Compile assembly from modules
"%alPath%" /out:MyAssembly.dll /t:library frequent.netmodule rare.netmodule
