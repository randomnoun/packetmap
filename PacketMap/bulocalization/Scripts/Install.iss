; Copyright (c) 2007 Cuchuk Sergey Alexandrovich
; Project: BULocalization
;
; Created: 9 /08/ 2007
; Last updated: 30 July 2007
; For version: 1.5

[Setup]
AppName=BULocalization
AppVerName=BULocalization 1.5
AppPublisher=Cuchuk Sergey Alexandrovich. Cuchuk.Sergey@gmail.com
AppPublisherURL=http://www.sourceforge.net/projects/bulocalization
AppSupportURL=http://www.sourceforge.net/projects/bulocalization
AppUpdatesURL=http://www.sourceforge.net/projects/bulocalization
DefaultDirName={pf}\BULocalization
DefaultGroupName=BULocalization
AllowNoIcons=yes
LicenseFile=D:\DOCUMENTS\SharpDevelop Projects\BULocalization Project\end-user-docs\Licenses.rtf
InfoAfterFile=D:\DOCUMENTS\SharpDevelop Projects\BULocalization Project\end-user-docs\Support.rtf
OutputDir=D:\DOCUMENTS\Releases\BULocalization
OutputBaseFilename=BULocalizationSetup-win32-full
Compression=lzma
SolidCompression=yes

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\DOCUMENTS\SharpDevelop Projects\BULocalization Project\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[INI]
Filename: "{app}\BULocalization.url"; Section: "InternetShortcut"; Key: "URL"; String: "http://www.sourceforge.net/projects/bulocalization"

[Icons]
Name: "{group}\Localization"; Filename: "{app}\bin\BULocalization.exe"; WorkingDir: "{app}\bin"
Name: "{group}\Translation"; Filename: "{app}\bin\BUTranslate.exe"; WorkingDir: "{app}\bin"
Name: "{group}\Manual"; Filename: "{app}\end-user-docs\Manual.doc"
Name: "{group}\Support"; Filename: "{app}\end-user-docs\Support.rtf"
Name: "{group}\{cm:ProgramOnTheWeb,BULocalization}"; Filename: "{app}\BULocalization.url"
Name: "{group}\{cm:UninstallProgram,BULocalization}"; Filename: "{uninstallexe}"; WorkingDir: "{app}\bin"
Name: "{userdesktop}\BULocalization"; Filename: "{app}\bin\BULocalization.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\BULocalization"; Filename: "{app}\BULocalization.exe"; Tasks: quicklaunchicon

[UninstallDelete]
Type: files; Name: "{app}\BULocalization.url"

