[string[]]$Lines = Get-Content -Path $PSScriptRoot\Input.txt

function DaySeven-PartOne {
    [CmdletBinding()]
    param ()   
    process {
        [Directory] $rootDir = Get-FileSystemTree
        
        [long] $output = Get-SmallestDirectories $rootDir
        Write-Output $output
    }
}
function DaySeven-PartTwo {
    [CmdletBinding()]
    param ()
    process {
        [Directory] $rootDir = Get-FileSystemTree

        [long] $usedSpace = $rootDir.Size
        [long] $unusedSpace = 70000000 - $usedSpace
        [long] $spaceToBeDeleted = (30000000 - $unusedSpace)
        [long[]] $matchingDirectories = Get-ChildrenToDelete $rootDir $spaceToBeDeleted
        [long] $output = [long] ($matchingDirectories | Measure-Object -Minimum).Minimum;
        Write-Output $output
    }   
}

function Get-ChildrenToDelete([Directory] $Dir, [long] $SpaceToBeDeleted) {
    [long[]] $output = New-Object long[] 0
    if ($Dir.Size -gt $SpaceToBeDeleted) {
        $output += $Dir.Size
    }
    foreach ($child in $Dir.Children) {
        $output += Get-ChildrenToDelete $child $SpaceToBeDeleted
    }

    return $output
}

function Get-SmallestDirectories([Directory] $Dir) {
    [long] $output = 0
    if ($Dir.Size -lt 100000) {
        $output += $Dir.Size
    }
    foreach ($child in $Dir.Children) {
        $output += Get-SmallestDirectories $child
    }

    return $output
}

function Get-FileSystemTree {
    [Directory] $rootDir = [Directory]::new()
    $rootDir.Name = "/"
    $rootDir.Size = 0
    $rootDir.Children = New-Object Directory[] 0
        
    [Directory] $currentDir = $rootDir
    foreach ($line in $Lines) {
        [string] $cmdLine = $line.Replace("$ ", "");
        [string[]] $cmdParams = $cmdLine -split " "
        [string] $cmdCommand = $cmdParams[0]
        [string] $cmdFirstParam = $cmdParams[1]

        if ($cmdCommand -eq "dir") {
            $test = $directories | Where-Object { $_.Name -eq $cmdFirstParam }
            if ($null -eq $test) {
                $directory = [Directory]::new()
                $directory.Name = $cmdFirstParam
                $directory.Size = 0
                $directory.Parent = $currentDir
                $directory.Children = New-Object Directory[] 0
                $currentDir.Children += $directory
            }
        }
        elseif ($cmdCommand -match "^[0-9]") {
            [long] $fileSize = [long]::Parse($cmdCommand)
            $currentDir.Size += $fileSize
                
            if ($null -ne $currentDir.Parent) {
                Update-ParentSize $currentDir.Parent $fileSize
            }
        }
        elseif ($cmdCommand -eq "cd") {
            if ($cmdFirstParam -ne "..") {
                if ($cmdFirstParam -ne "/") {
                    $currentDir = $currentDir.Children | Where-Object { $_.Name -eq $cmdFirstParam }
                }
            }
            else {
                $currentDir = $currentDir.Parent
                $currentDir.Children.IndexOf($currentDir) = $currentDir
            }
        }
    }
    return $rootDir
}
function Update-ParentSize([Directory] $Directory, [long] $Size) {
    $Directory.Size += $Size
    if ($null -ne $Directory.Parent) {
        Update-ParentSize $Directory.Parent $Size
    }
}

class Directory {
    [string] $Name
    [Directory] $Parent
    [Directory[]] $Children
    [long] $Size
}

DaySeven-PartOne
DaySeven-PartTwo