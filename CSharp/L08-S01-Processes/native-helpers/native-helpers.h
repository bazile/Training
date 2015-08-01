// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the NATIVEHELPERS_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// NATIVEHELPERS_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef NATIVEHELPERS_EXPORTS
#define NATIVEHELPERS_API extern "C" __declspec(dllexport)
#else
#define NATIVEHELPERS_API __declspec(dllimport)
#endif

NATIVEHELPERS_API void ShellExecuteFromExplorer(
	PCWSTR pszFile,
	PCWSTR pszParameters,
	PCWSTR pszDirectory,
	PCWSTR pszOperation,
	int nShowCmd
);
