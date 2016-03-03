# Runs every time a package is uninstalled

param($installPath, $toolsPath, $package, $project)

# $installPath is the path to the folder where the package is installed.
# $toolsPath is the path to the tools directory in the folder where the package is installed.
# $package is a reference to the package object.
# $project is a reference to the project the package was installed to.

# Variables
$packages = "Packages"
$app_packages = "App_Packages"
$src = "src"
$packageName = [System.IO.Path]::GetFileName($installPath)

#logging
write-host "project: " $project.FullName
write-host "installPath: " $installPath
write-host "toolsPath: " $toolsPath
write-host "package: " $package
write-host "project: " $project


$srcPath = [System.IO.Path]::Combine($installPath, $src)
write-host "srcPath: " $srcPath

$solutionDir = [System.IO.Path]::GetDirectoryName($dte.Solution.FullName)
$projectDir = [System.IO.Path]::GetDirectoryName($project.FullName)
write-host "solutionDir: " $solutionDir
write-host "projectDir: " $projectDir

$areSameDir = $solutionDir -eq $projectDir
write-host "areSameDir: " $areSameDir


if ($areSameDir) {
    $packagesItem = $project.ProjectItems|Where-Object {$_.Name -eq $packages}    
    write-host "packageFolder: " $packagesItem.Name
    $item = $packagesItem.ProjectItems|Where-Object {$_.Name -eq [System.IO.Path]::GetFileName($installPath)}
    write-host "item: " $item.Name
    $item.Remove()
    if ($packagesItem.ProjectItems.Count -eq 0) {
        $packagesItem.Remove()
    }            
} else {
    $app_packagesItem = $project.ProjectItems|Where-Object {$_.Name -eq $app_packages}
    write-host "app_packagesItem: " $app_packagesItem.Name
    $app_packagesFolder = [System.IO.Path]::Combine($srcPath,$app_packages)
    foreach ($subDir in (Get-ChildItem $app_packagesFolder)) {
        $item = $app_packagesItem.ProjectItems|Where-Object {$_.Name -eq $subDir.Name}
        write-host "item: " $item.Name
        if ($item) {
            $item.Delete()
        }
    }
    if ($app_packagesItem.ProjectItems.Count -eq 0 -and (Get-ChildItem ([System.IO.Path]::Combine($projectDir, $app_packages))).Count -eq 0) {
        $app_packagesItem.Delete()
    }
}