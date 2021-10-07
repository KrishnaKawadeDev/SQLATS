cd \development\sqladmintoolset\build

@echo off
if "%COMPUTERNAME%" == "SQLATSBLD-02" goto DOSTARTUP
echo. NOTE:  This script can only be run from the SQLATSBLD-02 machine
goto END

:DOSTARTUP
if (%1)==(dev) GOTO BUILD_DEV
if (%1)==(official) GOTO BUILD_OFFICIAL
if (%1)==(hotfix) GOTO BUILD_HOTFIX
if (%1)==(prep) GOTO BUILD_PREP
if (%1)==(doc) GOTO BUILD_DOCONLY
if (%1)==(docinstall) GOTO BUILD_DOCINSTALL
echo. BUILD ERROR: Missing or invalid command line parameter
echo.
echo. Syntax:
echo.    DOBUILD type [version]
echo.    type = dev, official, or prep
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

:BUILD_DEV
echo. Starting Development Build
set BUILDTARGET="Build.Dev"
goto DOBUILD

:BUILD_OFFICIAL
echo. Starting Official Build
set BUILDTARGET="Build.Official"
goto DOBUILD

:BUILD_HOTFIX
echo. Starting Hotfix Build
set BUILDTARGET="Build.Hotfix"
goto DOBUILD_HOTFIX

:BUILD_PREP
echo.  Starting Prep Build
echo.  Once the script is complete, you can invoke nant directly to do the custom build.
echo.  For example:  nant -f:sqladmintoolset.build Build.Dev -D:SQLadmintoolset.version=2.1.1.2
goto DOBUILD

:BUILD_DOCONLY
if (%2)==() GOTO DOCONLY_USAGE
echo.  Starting Doc Only Build
set BUILDTARGET="Build.DocOnly"
goto DOBUILD

:BUILD_DOCINSTALL
if (%2)==() GOTO DOCONLY_USAGE
echo.  Starting DocInstall Build
set BUILDTARGET="Build.DocInstallOnly"


:DOBUILD_HOTFIX
REM **********************************
REM Setup user environment so the script has the appropriate permissions
REM **********************************
p4 set p4port=perforce01.redhouse.hq:1666
p4 set p4user=build
p4 set p4tickets="c:\p4ticket\ticket.txt"

p4 set p4client=build_sqladmintoolset_main
call "C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\Tools\vsvars32.bat"
GOTO EXECUTE_BUILD


:DOBUILD
REM **********************************
REM Setup user environment so the script has the appropriate permissions
REM **********************************
p4 set p4port=perforce01.redhouse.hq:1666
p4 set p4user=build
p4 set p4tickets="c:\p4ticket\ticket.txt"

if (%2)==(1.1) GOTO BUILD_11

p4 set p4client=build_sqladmintoolset_main
call "C:\Program Files\Microsoft Visual Studio 8\VC\bin\vcvars32.bat"
set BRANCH="//sqladmintoolset/main"
p4 sync -f //sqladmintoolset/main/build/...
GOTO COMMON

:BUILD_11
REM **********************************
REM Setup 1.1 build
REM **********************************
p4 set p4client=build_sqladmintoolset_1.1
call "C:\Program Files\Microsoft Visual Studio .NET 2003\Vc7\bin\vcvars32.bat"
set BRANCH="//sqladmintoolset/Release/1.1"
p4 sync -f //sqladmintoolset/Release/1.1/build/...
GOTO COMMON

:COMMON
REM **********************************
REM Nuke the entire tree except build
REM **********************************
rd /q /s c:\development\sqladmintoolset\build\Output
rd /q /s c:\development\sqladmintoolset\build\FilesForInstall
rd /q /s c:\development\sqladmintoolset\development
rd /q /s c:\development\sqladmintoolset\documentation
rd /q /s c:\development\sqladmintoolset\redist
rd /q /s c:\development\sqladmintoolset\images

:EXECUTE_BUILD
REM **********************************
REM Execute the build script
REM **********************************
if (%1)==(prep) GOTO END
if (%1)==(doc) GOTO NANT_DOCONLY
if (%1)==(docinstall) GOTO NANT_DOCONLY

nant -f:sqladmintoolset.build -D:Perforce.Branch="%BRANCH%" %BUILDTARGET% -l:C:\development\sqladmintoolset\build\build.log -logger:NAnt.Core.MailLogger
GOTO END

:NANT_DOCONLY
nant -f:sqladmintoolset.build -D:Perforce.Branch="%BRANCH%" -D:SQLadmintoolset.version="%2" -D:Perforce.TargetLabel="sqladmintoolset_%2" %BUILDTARGET%
GOTO END

:DOCONLY_USAGE
echo. Please supply a pre-existing build version for doc only builds.

:END
echo.  Build script execution is complete
