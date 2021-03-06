;NSIS Modern User Interface
;Welcome/Finish Page Example Script
;Written by Joost Verburg

;--------------------------------
;Include Modern UI

  !include "MUI.nsh"
  !include "DotNET.nsh"
  !include LogicLib.nsh

;--------------------------------
;General

  ;Name and file
  Name "Packetmap"
  OutFile "bin\debug\PacketmapSetup-v0.1.exe"

  ;Default installation folder
  InstallDir "$PROGRAMFILES\Packetmap"

  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\Randomnoun\Packetmap" "InstallDir"


;--------------------------------
;Variables

  Var MUI_TEMP
  Var STARTMENU_FOLDER

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING
  !define DOTNET_VERSION "2.0.5"
  !define VERSION "0.1"

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_WELCOME
  ; !insertmacro MUI_PAGE_LICENSE "${NSISDIR}\Docs\Modern UI\License.txt"
  !insertmacro MUI_PAGE_LICENSE "License.txt"
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY

  ;Start Menu Folder Page Configuration
  !define MUI_STARTMENUPAGE_REGISTRY_ROOT "HKCU" 
  !define MUI_STARTMENUPAGE_REGISTRY_KEY "Software\Randomnoun\Packetmap" 
  !define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "Start Menu Folder"
  !define MUI_STARTMENUPAGE_DEFAULTFOLDER "Packetmap"
  !insertmacro MUI_PAGE_STARTMENU Application $STARTMENU_FOLDER

  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH

  !insertmacro MUI_UNPAGE_WELCOME
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  !insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "!Packetmap" SecMain
  
  ; mandatory section
  SectionIn RO

  SetOutPath "$INSTDIR"

  !insertmacro CheckDotNET

  ;ADD YOUR OWN FILES HERE...
  File bin\debug\Packetmap.exe
  File bin\debug\ScalablePictureBox.dll
  File bin\debug\Tamir.IPLib.SharpPcap.dll

  SetOutPath "$INSTDIR\data"
  File data\countries.txt
  File data\GeoIPCountryWhois.csv
  File data\matchedWithGif.csv
  
  SetOutPath "$INSTDIR\countryGif"
  File countryGif\*.png
  File countryGif\*.png
  
  ;SetOutPath "$INSTDIR\countryPoly\Africa"
  ;File countryPoly\Africa\*.txt
  ;SetOutPath "$INSTDIR\countryPoly\Asia"
  ;File countryPoly\Asia\*.txt
  ;SetOutPath "$INSTDIR\countryPoly\Australia"
  ;File countryPoly\Australia\*.txt
  ;SetOutPath "$INSTDIR\countryPoly\Europe"
  ;File countryPoly\Europe\*.txt
  ;SetOutPath "$INSTDIR\countryPoly\NorthAmerica"
  ;File countryPoly\NorthAmerica\*.txt
  ;SetOutPath "$INSTDIR\countryPoly\SouthAmerica"
  ;File countryPoly\SouthAmerica\*.txt
  
  SetOutPath "$INSTDIR\flags"
  File flags\*.gif
  
 

  ;Store installation folder
  WriteRegStr HKCU "Software\Randomnoun\Packetmap" "InstallDir" $INSTDIR

  ;Create uninstaller
  ; Write the uninstall keys for Windows
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\Packetmap" "DisplayVersion" "${VERSION}"
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\Packetmap" "DisplayName" "Packetmap ${VERSION}"
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\Packetmap" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\Packetmap" "Publisher" "Randomnoun, http://www.packetmap.org"
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\Packetmap" "HelpLink" "mailto:packetmap@packetmap.org"
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\Packetmap" "URLInfoAbout" "http://www.packetmap.org"
  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\Packetmap" "URLUpdateInfo" "http://www.packetmap.org/updateInfo/"
  WriteRegDWORD HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\Packetmap" "NoModify" 1
  WriteRegDWORD HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\Packetmap" "NoRepair" 1
  WriteUninstaller "uninstall.exe"

  WriteUninstaller "$INSTDIR\Uninstall.exe"

  !insertmacro MUI_STARTMENU_WRITE_BEGIN Application
    
    ;Create shortcuts
    CreateDirectory "$SMPROGRAMS\$STARTMENU_FOLDER"
    CreateShortCut "$SMPROGRAMS\$STARTMENU_FOLDER\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
    CreateShortCut "$SMPROGRAMS\$STARTMENU_FOLDER\Packetmap.lnk" "$INSTDIR\Packetmap.exe"
  
  !insertmacro MUI_STARTMENU_WRITE_END


SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_SecMain ${LANG_ENGLISH} "The main Packetmap programs."

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecMain} $(DESC_SecMain)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ;ADD YOUR OWN FILES HERE...
  Delete $INSTDIR\Packetmap.exe
  Delete $INSTDIR\ScalablePictureBox.dll
  Delete $INSTDIR\Tamir.IPLib.SharpPcap.dll
  Delete $INSTDIR\countryGifs\countries.txt
  Delete $INSTDIR\countryGifs\countries.csv
  Delete $INSTDIR\countryGifs\*.png
  Delete $INSTDIR\countryGifs\*.png

  Delete "$INSTDIR\Uninstall.exe"


  RMDir "$INSTDIR"

  !insertmacro MUI_STARTMENU_GETFOLDER Application $MUI_TEMP
    
  Delete "$SMPROGRAMS\$MUI_TEMP\Uninstall.lnk"
  
  ; remove uninstall registry entry
  DeleteRegKey HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Uninstall\Packetmap"
  
  ; keep settings
  ; DeleteRegKey HKEY_LOCAL_MACHINE "Software\Randomnoun\Packetmap"
  
  ;Delete empty start menu parent diretories
  StrCpy $MUI_TEMP "$SMPROGRAMS\$MUI_TEMP"
 
  startMenuDeleteLoop:
    ClearErrors
    RMDir $MUI_TEMP
    GetFullPathName $MUI_TEMP "$MUI_TEMP\.."
    
    IfErrors startMenuDeleteLoopDone
  
    StrCmp $MUI_TEMP $SMPROGRAMS startMenuDeleteLoopDone startMenuDeleteLoop
  startMenuDeleteLoopDone:

  DeleteRegKey /ifempty HKCU "Software\Randomnoun\Packetmap"

SectionEnd
