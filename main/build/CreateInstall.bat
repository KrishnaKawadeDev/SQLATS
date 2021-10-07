mkdir ATSInstall
attrib -r ATSInstall\*.*
del /q ATSInstall\*.*


rem Executables
copy "..\development\Idera\BackupStatus\bin\Release\BackupStatus.exe"                               ATSInstall\*.*
copy "..\development\Idera\ConnectionCheck\bin\Release\ConnectionCheck.exe"                         ATSInstall\*.*
copy "..\development\Idera\ConnectionStringGenerator\bin\Release\ConnectionStringGenerator.exe"     ATSInstall\*.*
copy "..\development\Idera\DatabaseConfiguration\bin\Release\DatabaseConfiguration.exe"             ATSInstall\*.*
copy "..\development\Idera\DatabaseMover\bin\Release\DatabaseMover.exe"                             ATSInstall\*.*
copy "..\development\Idera\DatabaseMoverLibrary\bin\Release\DatabaseMoverLibrary.dll"               ATSInstall\*.*
copy "..\development\Idera\IndexAnalyzer\bin\Release\IndexAnalyzer.exe"                             ATSInstall\*.*
copy "..\development\Idera\InventoryReport2\bin\Release\InventoryReport.exe"                        ATSInstall\*.*
copy "..\development\Idera\JobEditor\bin\Release\JobEditor.exe"                                     ATSInstall\*.*
copy "..\development\Idera\JobMover\bin\Release\JobMover.exe"                                       ATSInstall\*.*
copy "..\development\Idera\Launchpad\bin\Release\Launchpad.exe"                                     ATSInstall\*.*
copy "..\development\Idera\LoginCopy\bin\Release\LoginCopy.exe"                                     ATSInstall\*.*
copy "..\development\Idera\MultiQuery\bin\Release\MultiQuery.exe"                                   ATSInstall\*.*
copy "..\development\Idera\ObjectSearch\bin\Release\ObjectSearch.exe"                               ATSInstall\*.*
copy "..\development\Idera\PartitionGenerator\bin\Release\PartitionGenerator.exe"                   ATSInstall\*.*
copy "..\development\Idera\PasswordChecker\bin\Release\PasswordChecker.exe"                         ATSInstall\*.*
copy "..\development\Idera\PatchAnalyzer\bin\Release\PatchAnalyzer.exe"                             ATSInstall\*.*
copy "..\development\Idera\QuickReindex\bin\Release\QuickReindex.exe"                               ATSInstall\*.*
copy "..\development\Idera\ServerConfiguration\bin\Release\ServerConfiguration.exe"                 ATSInstall\*.*
copy "..\development\Idera\ServerPing\bin\Release\ServerPing.exe"                                   ATSInstall\*.*
copy "..\development\Idera\ServerStatistics\bin\Release\ServerStatistics.exe"                       ATSInstall\*.*
copy "..\development\Idera\SpaceAnalyzer\bin\Release\SpaceAnalyzer.exe"                             ATSInstall\*.*
copy "..\development\Idera\SqlDiscovery\bin\Release\SqlDiscovery.exe"                               ATSInstall\*.*
copy "..\development\Idera\SqlSearch2\bin\Release\SqlSearch.exe"                                    ATSInstall\*.*
copy "..\development\Idera\TablePin\bin\Release\TablePin.exe"                                       ATSInstall\*.*
copy "..\development\Idera\UserClone\bin\Release\UserClone.exe"                                     ATSInstall\*.*
copy "..\development\Idera\LinkedServerMover\bin\Release\LinkedServerCopy.exe"                              ATSInstall\*.*
rem Core DLL
copy "..\development\Idera\SqlAdminToolsetCore\bin\Release\SqlAdminToolsetCore.dll"              ATSInstall\*.*
copy "..\development\Idera\SqlAdminToolsetCore\bin\Release\IderaTrialExperienceCommon.dll"              ATSInstall\*.*
copy "..\development\Idera\SqlAdminToolsetCore\bin\Release\SqlAdminToolset.config"               ATSInstall\*.*

rem Third Party DLLs
copy "..\redist\DevComponents\*.*"                                                 ATSInstall\*.*
copy "..\redist\DMO\*.*"                                                           ATSInstall\*.*
copy "..\redist\Idera\*.*"                                                         ATSInstall\*.*
copy "..\redist\Qwhale\*.*"                                                        ATSInstall\*.*
copy "..\redist\ReportViewer\*.*"                                                  ATSInstall\*.*
copy "..\redist\SMO\*.*"                                                           ATSInstall\*.*

rem Support Files
copy "..\development\Idera\PatchAnalyzer\SqlServerVersions.xml"                                ATSInstall\*.*
copy "..\development\Idera\PatchAnalyzer\SqlServerVersions.xml"                                ATSInstall\SqlServerVersions_Default.xml

rem Documentation + Help Files
copy "..\documentation\ForBuild\*.*"                                                           ATSInstall\*.*
attrib -r "ATSInstall\*.*
copy "..\documentation\Help\*.*"                                                           ATSInstall\*.*
