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
  OutFile "..\bin\debug\PacketmapSetup-pre-alpha-v0.4.exe"

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
  !define VERSION "0.4"


!define MUI_PAGE_CUSTOMFUNCTION_SHOW myShowCallback

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_WELCOME
  ; !insertmacro MUI_PAGE_LICENSE "${NSISDIR}\Docs\Modern UI\License.txt"
  !insertmacro MUI_PAGE_LICENSE "License.txt"
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
Page custom DisplayWinPcapPage

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
;Functions
Function .onInit
  ;Extract InstallOptions INI files
  ; !insertmacro MUI_INSTALLOPTIONS_EXTRACT "AdditionalTasksPage.ini"  
  !insertmacro MUI_INSTALLOPTIONS_EXTRACT "WinpcapPage.ini"  
FunctionEnd

Function DisplayWinPcapPage
  !insertmacro MUI_HEADER_TEXT "Install WinPcap?" "WinPcap is required to capture live network data. Should WinPcap be installed?"
  !insertmacro MUI_INSTALLOPTIONS_DISPLAY "WinPcapPage.ini"
FunctionEnd




;--------------------------------
;Installer Sections

Var WINPCAP_UNINSTALL ;declare variable for holding the value of a registry key

Section "!Packetmap" SecMain
  
  ; mandatory section
  SectionIn RO

  SetOutPath "$INSTDIR"

  !insertmacro CheckDotNET

  ;ADD YOUR OWN FILES HERE...
  File ..\bin\debug\Packetmap.exe
  File ..\bin\debug\ScalablePictureBox.dll
  File ..\bin\debug\Tamir.IPLib.SharpPcap.dll
  File ..\bin\debug\CSharpBULocalization.dll

  SetOutPath "$INSTDIR\locals"
  File ..\locals\default.Language
  File ..\locals\packetmap.xml
  File ..\locals\Russian.Language

  SetOutPath "$INSTDIR\data"
  File ..\data\countries.txt
  File ..\data\GeoIPCountryWhois.csv
  File ..\data\matchedWithGif.csv
  File ..\data\flagComposite.png
  File ..\data\flagComposite.txt
  
  SetOutPath "$INSTDIR\countryGif"
  File ..\countryGif\*.png
  
  ;SetOutPath "$INSTDIR\countryPoly\Africa"
  ;File ..\countryPoly\Africa\*.txt
  ;SetOutPath "$INSTDIR\countryPoly\Asia"
  ;File ..\countryPoly\Asia\*.txt
  ;SetOutPath "$INSTDIR\countryPoly\Australia"
  ;File ..\countryPoly\Australia\*.txt
  ;SetOutPath "$INSTDIR\countryPoly\Europe"
  ;File ..\countryPoly\Europe\*.txt
  ;SetOutPath "$INSTDIR\countryPoly\NorthAmerica"
  ;File ..\countryPoly\NorthAmerica\*.txt
  ;SetOutPath "$INSTDIR\countryPoly\SouthAmerica"
  ;File ..\countryPoly\SouthAmerica\*.txt
  
  ;SetOutPath "$INSTDIR\flags"
  ;File ..\flags\*.gif

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


; Install WinPcap (depending on winpcap page setting)
ReadINIStr $0 "$PLUGINSDIR\WinPcapPage.ini" "Field 4" "State"
StrCmp $0 "0" SecRequired_skip_Winpcap
; Uinstall old WinPcap first
ReadRegStr $WINPCAP_UNINSTALL HKEY_LOCAL_MACHINE "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\WinPcapInst" "UninstallString"
IfErrors lbl_winpcap_notinstalled ;if RegKey is unavailable, WinPcap is not installed
; from released version 3.1, WinPcap will uninstall an old version by itself
;ExecWait '$WINPCAP_UNINSTALL' $0
;DetailPrint "WinPcap uninstaller returned $0"
lbl_winpcap_notinstalled:
SetOutPath $INSTDIR
File "WinPcap_3_1.exe"
ExecWait '"$INSTDIR\WinPcap_3_1.exe"' $0
DetailPrint "WinPcap installer returned $0"
SecRequired_skip_Winpcap:

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
  Delete $INSTDIR\countryGif\*.png
  RMDir  "$INSTDIR\countryGif"
  Delete $INSTDIR\data\countries.txt
  Delete $INSTDIR\data\GeoIPCountryWhois.csv
  Delete $INSTDIR\data\matchedWithGif.csv
  Delete $INSTDIR\data\flagComposite.png
  Delete $INSTDIR\data\flagComposite.txt
  RMDir  "$INSTDIR\data"

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




; ============================================================================
; Callback functions
; ============================================================================
!ifdef GTK1_DIR & GTK2_DIR
;Disable GTK-Wimp for GTK1

Function .onSelChange
	Push $0
	SectionGetFlags ${SecEtherealGTK1} $0
	IntOp  $0 $0 & 1
	IntCmp $0 1 onSelChange.disableGTK2Sections
	;enable GTK2Sections
	!insertmacro EnableSection ${SecGTKWimp}
	Goto onSelChange.end
onSelChange.disableGTK2Sections:
	!insertmacro DisableSection ${SecGTKWimp}
	Goto onSelChange.end
onSelChange.end:
	Pop $0
FunctionEnd	

!else
!ifdef GTK1_DIR | GTK2_DIR
; Disable FileExtension if Ethereal isn't selected
Function .onSelChange
	Push $0
!ifdef GTK1_DIR
	SectionGetFlags ${SecEtherealGTK1} $0
	IntOp  $0 $0 & 1
	IntCmp $0 0 onSelChange.unselect
	SectionGetFlags ${SecFileExtensions} $0
	IntOp  $0 $0 & 16
	IntCmp $0 16 onSelChange.unreadonly
	Goto onSelChange.end
!else
	SectionGetFlags ${SecEtherealGTK2} $0
	IntOp  $0 $0 & 1
	IntCmp $0 0 onSelChange.unselect
	SectionGetFlags ${SecFileExtensions} $0
	IntOp  $0 $0 & 16
	IntCmp $0 16 onSelChange.unreadonly
	Goto onSelChange.end	
!endif
onSelChange.unselect:	
	SectionGetFlags ${SecFileExtensions} $0
	IntOp $0 $0 & 0xFFFFFFFE
	IntOp $0 $0 | 0x10
	SectionSetFlags ${SecFileExtensions} $0
	Goto onSelChange.end
onSelChange.unreadonly:
	SectionGetFlags ${SecFileExtensions} $0
	IntOp $0 $0 & 0xFFFFFFEF
	SectionSetFlags ${SecFileExtensions} $0
	Goto onSelChange.end
onSelChange.end:
	Pop $0
FunctionEnd
!endif
!endif


!include "GetWindowsVersion.nsh"
!include WinMessages.nsh

Var NPF_START ;declare variable for holding the value of a registry key
Var WINPCAP_VERSION ;declare variable for holding the value of a registry key

Function myShowCallback

	; Get the Windows version
	Call GetWindowsVersion
	Pop $R0 ; Windows Version


	; detect if WinPcap should be installed
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 4" "Text" "Install WinPcap 3.1"
	ReadRegStr $WINPCAP_VERSION HKEY_LOCAL_MACHINE "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\WinPcapInst" "DisplayName"
	IfErrors 0 lbl_winpcap_installed ;if RegKey is available, WinPcap is already installed
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 2" "Text" "WinPcap is currently not installed"
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 2" "Flags" "DISABLED"
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 5" "Text" "(Use Add/Remove Programs first to uninstall any undetected old WinPcap versions)"
	Goto lbl_winpcap_done

lbl_winpcap_installed:
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 2" "Text" "$WINPCAP_VERSION"
	; WinPcap 2.x (including betas): the version string starts with "WinPcap 2."
	StrCpy $1 "$WINPCAP_VERSION" 10
	StrCmp $1 "WinPcap 2." lbl_winpcap_do_install
	; WinPcap 3.0 (including betas): the version string starts with "WinPcap 3.0"
	StrCpy $1 "$WINPCAP_VERSION" 11
	StrCmp $1 "WinPcap 3.0" lbl_winpcap_do_install
	; WinPcap 3.1 previous beta's; exact string match
	StrCmp "$WINPCAP_VERSION" "WinPcap 3.1 beta" lbl_winpcap_do_install
	StrCmp "$WINPCAP_VERSION" "WinPcap 3.1 beta2" lbl_winpcap_do_install
	StrCmp "$WINPCAP_VERSION" "WinPcap 3.1 beta3" lbl_winpcap_do_install
	StrCmp "$WINPCAP_VERSION" "WinPcap 3.1 beta4" lbl_winpcap_do_install

;lbl_winpcap_dont_install:
	; seems to be the current or even a newer version, so don't install
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 4" "State" "0"
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 5" "Text" "If selected, the currently installed $WINPCAP_VERSION will be uninstalled first."
	Goto lbl_winpcap_done

lbl_winpcap_do_install:
	; seems to be an old version, install newer one
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 4" "State" "1"
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 5" "Text" "The currently installed $WINPCAP_VERSION will be uninstalled first."

lbl_winpcap_done:

	; Disable NPF service setting for Win OT 
	StrCmp $R0 '95' lbl_npf_disable
	StrCmp $R0 '98' lbl_npf_disable
	StrCmp $R0 'ME' lbl_npf_disable
	ReadRegDWORD $NPF_START HKEY_LOCAL_MACHINE "SYSTEM\CurrentControlSet\Services\NPF" "Start"
	; (Winpcap may not be installed already, so no regKey is no error here)
	IfErrors lbl_npf_done ;RegKey not available, so do not set it
	IntCmp $NPF_START 2 0 lbl_npf_done lbl_npf_done
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 8" "State" "1"
	Goto lbl_npf_done
	;disable
lbl_npf_disable:
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 8" "State" "0"
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 8" "Flags" "DISABLED"
	WriteINIStr "$PLUGINSDIR\WinPcapPage.ini" "Field 9" "Flags" "DISABLED"	
lbl_npf_done:


	; if Ethereal was previously installed, unselect previously not installed icons etc.
	; detect if Ethereal is already installed -> 
	ReadRegStr $0 HKEY_LOCAL_MACHINE "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Packetmap" "UninstallString"
	IfErrors lbl_ethereal_notinstalled ;if RegKey is unavailable, Ethereal is not installed

	; only select Start Menu Group, if previously installed
	; (we use the "all users" start menu, so select it first)
	SetShellVarContext all
	IfFileExists "$SMPROGRAMS\Ethereal\Ethereal.lnk" lbl_have_startmenu
	WriteINIStr "$PLUGINSDIR\AdditionalTasksPage.ini" "Field 2" "State" "0"
lbl_have_startmenu:

	; only select Desktop Icon, if previously installed
	IfFileExists "$DESKTOP\Ethereal.lnk" lbl_have_desktopicon
	WriteINIStr "$PLUGINSDIR\AdditionalTasksPage.ini" "Field 3" "State" "0"
lbl_have_desktopicon:

	; only select Quick Launch Icon, if previously installed
	IfFileExists "$QUICKLAUNCH\Ethereal.lnk" lbl_have_quicklaunchicon
	WriteINIStr "$PLUGINSDIR\AdditionalTasksPage.ini" "Field 4" "State" "0"
lbl_have_quicklaunchicon:

lbl_ethereal_notinstalled:


FunctionEnd


