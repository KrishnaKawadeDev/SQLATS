if (%1)==() GOTO NO_BUILD

mkdir \\redhousefs-02\qabuilds\sqladmintoolset\%1

copy "..\development\Install\setup\Product Configuration 1\Release 1\DiskImages\DISK1\SQLadmintoolset.msi"  BuildOutput\*.*
copy "..\documentation\ForBuild\SQL admin toolset Release Notes.pdf"                              BuildOutput\*.*
copy "..\documentation\ForBuild\BBS - Software License Agreement.rtf"                             BuildOutput\*.*
copy "..\documentation\ForBuild\BBS - Trial Software License Agreement.rtf"                       BuildOutput\*.*

..\development\Install\CodeSigning\signtool.exe sign /d "Idera SQL admin toolset" /f ..\development\Install\CodeSigning\ideracredentials.pfx /p idera.redhouse.hq /t http://timestamp.verisign.com/scripts/timstamp.dll /du http://www.idera.com "BuildOutput\SQLadmintoolset.msi"

rem copy "BuildOutput\SQLadmintoolset.msi" \\redhousefs-02\qabuilds\sqladmintoolset\%1\*.*
rem copy "BuildOutput\*.zip" \\redhousefs-02\qabuilds\sqladmintoolset\%1\*.*

goto END

:NO_BUILD_SUFFIX
echo.
echo. BUILD ERROR: Missing incremental build suffix label. Syntax: CopyBuild 1.0.0.55
echo.
goto END


:END
echo. Build script execution is complete
