@echo off
if "%COMPUTERNAME%" == "SQLATSBLD-02" goto DOSTARTUP
echo. NOTE:  This script can only be run from the SQLATSBLD machine
goto END

:DOSTARTUP

SET BUILDNUMBER=%2
SET BUILDFOLDER=%3

if (%1)==(devsfx) GOTO BUILD_DEVSFX
if (%1)==(dev) GOTO BUILD_DEV
if (%1)==(official) GOTO BUILD_OFFICIAL
if (%1)==(doc) GOTO BUILD_DOCONLY
echo. BUILD ERROR: Missing or invalid command line parameter
echo.
echo. Syntax:
echo.    DOBUILD type [version]
echo.    type = dev, official, doc
echo.    version = 1.1, 1.2
echo.
echo.    DOBUILD doc version
echo.    version = the full version to pull from the archive
echo.
echo.    DOBUILD docinstall version
echo.    version = the full version to pull from the archive
echo.
echo. Available Properties (use these for custom builds - prep option):  
echo.    SQLcm.version - force a version number (major.minor.release.build)
echo.    Build.Config - Release or Debug version (default is Release)
echo.    Perforce.TargetLabel - sync to a specific label rather than the most recent version
echo.    Perforce.Sync.Force - default is true.  set to false to avoid a forced sync
goto END

:BUILD_DEVSFX
echo. Starting Developmentsfx Build
set BUILDTARGET="Build.Devsfx"
goto DOBUILD

:BUILD_DEV
echo. Starting Development Build
set BUILDTARGET="Build.Dev"
goto DOBUILD

:BUILD_OFFICIAL
echo. Starting Official Build
set BUILDTARGET="Build.Official"
goto DOBUILD

:BUILD_DOCONLY
if (%2)==() GOTO DOCONLY_USAGE
echo.  Starting Doc Only Build
set BUILDTARGET="Build.DocOnly"
goto DOBUILD


:DOBUILD
REM **********************************
REM Setup user environment so the script has the appropriate permissions
REM **********************************
REM For SQLATSBLD machine C:\Program Files\Microsoft Visual Studio 10.0\VC\bin\vcvars32.bat
REM For SQLATSBLD-02 machine C:\Program Files (x86)\Microsoft Visual Studio 9.0\Common7\Tools\vsvars32.bat
call "C:\Program Files (x86)\Microsoft Visual Studio 9.0\Common7\Tools\vsvars32.bat"

echo.
REM echo. Deleting development, documentation and install directories
REM rd /q /s C:\SQLAdminToolsetSMO2012\SQLAdminToolset\main\build\Output
REM rd /q /s C:\SQLAdminToolsetSMO2012\SQLAdminToolset\main\build\FilesForInstall
REM rd /q /s C:\SQLAdminToolsetSMO2012\SQLAdminToolset\main\development
REM rd /q /s C:\SQLAdminToolsetSMO2012\SQLAdminToolset\main\documentation
REM rd /q /s C:\SQLAdminToolsetSMO2012\SQLAdminToolset\main\redist
REM rd /q /s C:\SQLAdminToolsetSMO2012\SQLAdminToolset\main\images

echo.
REM echo. Fetching the lastest from GitHub
REM "C:\git\bin\git.exe" checkout smo-2012
REM "C:\git\bin\git.exe" pull origin smo-2012

:EXECUTE_BUILD
REM **********************************
REM Execute the build script
REM **********************************
if (%1)==(doc) GOTO NANT_DOCONLY

"c:\program files\nant\bin\nant" -f:sqladmintoolsetgit.build %BUILDTARGET% -D:SQLadmintoolset.buildfolder=%BUILDFOLDER% -D:SQLadmintoolset.buildnumber=%BUILDNUMBER% -l:"%WORKSPACE%\build.log" -logger:NAnt.Core.MailLogger
GOTO END

:NANT_DOCONLY
"c:\program files\nant\bin\nant" -f:sqladmintoolset.build -D:SQLadmintoolset.version="%2" %BUILDTARGET%
GOTO END

:DOCONLY_USAGE
echo. Please supply a pre-existing build version for doc only builds.

:END
echo.  Build script execution is complete
