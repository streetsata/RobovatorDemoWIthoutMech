;=========================================================================================================================
; increment installer version
; Read the previuos build number. If there is none take 0 instead.
#define BuildNum Int(ReadIni(SourcePath	+ "\\BuildInfo_dbg.ini","Info","Build","0"))
; Increment the build number by one.
#expr BuildNum = BuildNum + 1
; Store the number in the ini file for the next build.
#expr WriteIni(SourcePath + "\\BuildInfo_dbg.ini","Info","Build", BuildNum)
;=========================================================================================================================
#define AppGuid "{6C1BA555-54D0-4474-A1CC-2A7AA56BCE0B}"
#define AppName "RobovatorDemo"
#define AppVersion GetFileVersion('robovatorDemo\bin\Debug\robovatorDemo.exe')
;#define AppVersion "1"
#define AppPublisher "RobovatorDemo Ltd."
#define AppPublisherUrl "http://google.com"
#define AppSupportURL "http://google.com"
#define AppUpdateUrl "http://google.com"
#define AppEulaLink "http://google.com"
#define AppPrivacyLink "http://google.com"
#define AppTermsLink "http://google.com"
#define AppURL "http://google.com"
#define AppExeName "RobovatorDemo.exe"

[Setup]
AppId={{#AppGuid}
AppName={param:appname|{#AppName}}
AppVersion={param:appversion|{#AppVersion}.{#BuildNum}}
AppPublisher={param:apppublisher|{#AppPublisher}}
AppPublisherURL={param:apppublisherurl|{#AppPublisherUrl}}
AppSupportURL={param:appsupporturl|{#AppSupportURL}}
AppUpdatesURL={param:appupdateurl|{#AppUpdateUrl}}
DefaultDirName={param:defaultdirname|{pf}\{#AppName}}
DefaultGroupName={param:defaultgroupname|{#AppName}}
OutputBaseFilename={#AppName}_{#AppVersion}.{#BuildNum}
;Compression=lzma
SolidCompression=yes
UninstallDisplayName={#AppName}
UninstallDisplayIcon={app}\icon.ico
DisableReadyPage=yes

;PrivilegesRequired=admin
;WizardImageFile=logo.bmp
;WizardSmallImageFile=small_image.bmp
;SetupIconFile=Robo{#AppExeName}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

;[Tasks]
;Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}";

[UninstallDelete]
Type: filesandordirs; Name: "{app}";

[Files]
Source: "robovatorDemo\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion
Source: "dependencies\vcredist_x86.exe"; DestDir: "{tmp}"; Flags: ignoreversion
Source: "dependencies\dotnetfx35.exe"; DestDir: "{tmp}"; Flags: ignoreversion
Source: "dependencies\K-Lite_Codec_Pack_1110_Basic.exe"; DestDir: "{tmp}"; Flags: ignoreversion



[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppExeName}";
Name: "{group}\{cm:UninstallProgram,{#AppName}}"; IconFilename: "{app}\{#AppExeName}"; Filename: "{uninstallexe}";
Name: "{commondesktop}\{#AppName}"; Filename: "{app}\{#AppExeName}"; IconFilename: "{app}\{#AppExeName}"; Check:desktopicon; 
;Tasks: desktopicon;

[Run]
Filename: "{app}\{#AppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(AppName, '&', '&&')}}"; Flags: shellexec postinstall skipifsilent

[code]
const
TMP = 0;
var 
  DesktopIconCheckBox: TCheckBox;

//=========================================================================================================================
function desktopicon(): Boolean;
begin
    Result := DesktopIconCheckBox.Checked;
end;

//=========================================================================================================================
procedure OpenURL(sender: TObject);
var resultCode: Integer;
var senderLabel:TNewStaticText;
begin
  senderLabel := TNewStaticText(sender);
  
  if (senderLabel.Caption = 'Terms Of Use') then
    ShellExecAsOriginalUser('open', '{#AppTermsLink}', '', '', SW_SHOWNORMAL, ewNoWait, resultCode)
  else if (senderLabel.Caption = 'Privacy Policy') then
    ShellExecAsOriginalUser('open', '{#AppPrivacyLink}', '', '', SW_SHOWNORMAL, ewNoWait, resultCode)
  else
    ShellExecAsOriginalUser('open', '{#AppEulaLink}', '', '', SW_SHOWNORMAL, ewNoWait, resultCode);
end;

//=========================================================================================================================
procedure InitializeWizard();
  var TOU: TNewStaticText;
  var PP: TNewStaticText;
  var EULA: TNewStaticText;
  var linkBottomMargin: Integer;
  var linkGorizontalMargin: Integer;
  var prevControlEnd: Integer;
  var ResultCode: Integer;  
begin
  linkBottomMargin := 15;
  linkGorizontalMargin := 30;
  prevControlEnd := WizardForm.WelcomeLabel1.Left;

  //TOU := TNewStaticText.Create(WizardForm.WelcomePage);
  //TOU.Caption := 'Terms Of Use';
  //TOU.Font.Color := clBlue;
  //TOU.Font.Style := TOU.Font.Style + [fsUnderline];
  //TOU.Cursor := crHand;
  //TOU.Parent := WizardForm.WelcomePage;
  //TOU.OnClick := @OpenURL;
  //TOU.Top := (WizardForm.WelcomePage.ClientHeight - TOU.Height - linkBottomMargin);  
  //TOU.Left := prevControlEnd + linkGorizontalMargin;
  //prevControlEnd := TOU.Left + TOU.Width;        

  EULA := TNewStaticText.Create(WizardForm.WelcomePage); 
  EULA.Caption := 'EULA';
  EULA.Font.Color := clBlue;
  EULA.Font.Style := EULA.Font.Style + [fsUnderline];  
  EULA.Cursor := crHand;  
  EULA.Parent := WizardForm.WelcomePage;  
  EULA.OnClick := @OpenURL;
  EULA.Top := (WizardForm.WelcomePage.ClientHeight - EULA.Height - linkBottomMargin);  
  EULA.Left := prevControlEnd;// + linkGorizontalMargin;
  prevControlEnd := EULA.Left + EULA.Width;

  PP := TNewStaticText.Create(WizardForm.WelcomePage);
  PP.Caption := 'Privacy Policy';
  PP.Font.Color := clBlue;
  PP.Font.Style := PP.Font.Style + [fsUnderline];
  PP.Cursor := crHand;
  PP.Parent := WizardForm.WelcomePage;
  PP.OnClick := @OpenURL;
  PP.Top := (WizardForm.WelcomePage.ClientHeight - PP.Height - linkBottomMargin);    
  PP.Left := prevControlEnd + linkGorizontalMargin;
  prevControlEnd := PP.Left + PP.Width;   
  
  WizardForm.WelcomeLabel2.Caption := WizardForm.WelcomeLabel2.Caption +
  + #$D#$A #$D#$A #$D#$A #$D#$A #$D#$A #$D#$A #$D#$A #$D#$A + 
  + 'By clicking "Next" you agree to install {#AppName} on your'  + #$D#$A
  + 'computer and to its EULA and Privacy Policy Below. '+ #$D#$A +
  + '';

  DesktopIconCheckBox := TCheckBox.Create(WizardForm.WelcomePage);//WizardForm.DirEdit.Owner);
  DesktopIconCheckBox.Parent := WizardForm.SelectProgramGroupPage;  
  DesktopIconCheckBox.Caption := 'Create a desktop icon';
  DesktopIconCheckBox.Visible := true;
  DesktopIconCheckBox.Checked := true;  
  DesktopIconCheckBox.Top := WizardForm.GroupEdit.Top + WizardForm.GroupEdit.Height + 25;
  DesktopIconCheckBox.Left := WizardForm.GroupEdit.Left;
  DesktopIconCheckBox.Width := WizardForm.GroupEdit.Width;
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  Params: string;
  ConfigPath: string;
  ResultCode: Integer;  
  i : Integer;
  tmpValue: string;
  lastGadgetNumber: Longint;
  iniKey: string;
  iniValue: string;
  arcStr: string;
  pfPath: string;
begin
  if (CurStep = ssInstall) then
  begin    
    //ShellExec('open',  'taskkill.exe', '/f /im sidebar.exe', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
    ExtractTemporaryFile('vcredist_x86.exe');
    Exec(ExpandConstant('{tmp}') + '\' + 'vcredist_x86.exe', '/SILENT', '', SW_SHOW, ewWaitUntilTerminated, ResultCode);
    ExtractTemporaryFile('dotnetfx35.exe');
    Exec(ExpandConstant('{tmp}') + '\' + 'dotnetfx35.exe', '/SILENT', '', SW_SHOW, ewWaitUntilTerminated, ResultCode);
    ExtractTemporaryFile('K-Lite_Codec_Pack_1110_Basic.exe');    
    Exec(ExpandConstant('{tmp}') + '\' + 'K-Lite_Codec_Pack_1110_Basic.exe', '/verysilent', '', SW_SHOW, ewWaitUntilTerminated, ResultCode);    
  end;
  if (CurStep = ssPostInstall) then
  begin   
    if (ProcessorArchitecture = paX86) then
    begin
        pfPath := ExpandConstant('{pf32}');
    end;
    if (ProcessorArchitecture = paX64) then
    begin
        pfPath := ExpandConstant('{pf64}');
    end;       
  end;     
end;
