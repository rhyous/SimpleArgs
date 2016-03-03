# Runs every time a package is uninstalled

param($installPath, $toolsPath, $package, $project)

# $installPath is the path to the folder where the package is installed.
# $toolsPath is the path to the tools directory in the folder where the package is installed.
# $package is a reference to the package object.
# $project is a reference to the project the package was installed to.

# Variables
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

function AddLinkedFiles($path, $addLocation, $canLink) 
{ 
    write-host "path: " $path
    write-host "addLocation: " $addLocation.FullName
    write-host "canLink: " $canLink
    foreach ($item in Get-ChildItem $path)
    {
        write-host "item: " $item $item.FullName
        if (Test-Path $item.FullName -PathType Container) 
        {
            if ( $canLink) {
                $addFolder = $project.ProjectItems|Where-Object {$_.Name -eq $item}
                if (!$addFolder) {
                    $addFolder = $addLocation.ProjectItems.AddFolder($item)
                }
                write-host "addFolder: " $addFolder.FullName
                AddLinkedFiles $item.FullName $addFolder $canLink
            } else
            {
                AddLinkedFiles $item.FullName $addLocation $canLink
            }            
        } 
        else 
        {             
            write-host "Adding " $item.FullName " to " $addLocation.FullName
            $addLocation.ProjectItems.AddFromFile($item.FullName)
        }
    } 
}

write-host "Calling AddLinkedFiles"
AddLinkedFiles $srcPath $project (!$areSameDir)