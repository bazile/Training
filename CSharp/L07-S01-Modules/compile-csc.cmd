@ECHO OFF
SETLOCAL

SET "cscPath=%windir%\Microsoft.NET\Framework\v4.0.30319\csc.exe"

REM Compile module ignoring warnings about not used types and fields
%cscPath% /t:module /nowarn:67,169 rare.cs

REM Compile assembly and link module to it
REM And again ignore warnings about not used types and fields
%cscPath% /out:MyAssembly.dll /t:library /addmodule:rare.netmodule /nowarn:67,169 frequent.cs
