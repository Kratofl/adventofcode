[string[]]$Lines = Get-Content -Path $PSScriptRoot\Input.txt

function DayFive-PartOne {
    [CmdletBinding()]
    param ()   
    process {
        $topCrates = Move-Crates
        Write-Output $topCrates
    }
}
function DayFive-PartTwo {
    [CmdletBinding()]
    param ()
    process {
        $topCrates = Move-Crates -ItsCrateMover9001
        Write-Output $topCrates
    }   
}

function Move-Crates([switch] $ItsCrateMover9001) {
    [string[]] $stacks = New-Object string[] 0

    [int] $itemNumberLineIdx = ((0..($Lines.Count - 1)) | Where-Object { [string]::IsNullOrEmpty($Lines[$_]) }) - 1
    [int] $lastPackageLineIdx = $itemNumberLineIdx - 1;
    [char[]] $stackColumnLine = ($Lines[$itemNumberLineIdx])
    [int] $amountOfStacks = [int]::Parse($stackColumnLine[$stackColumnLine.Length - 2])

    # Get Stacks
    for ($i = 0; $i -lt $amountOfStacks; $i++) {
        [string] $packets = ""

        [char] $value = "$($i + 1)"
        [int] $columnIdx = $stackColumnLine.IndexOf($value)

        for ($i2 = 0; $i2 -le $lastPackageLineIdx; $i2++) {
            [string] $packet = $Lines[$i2][$columnIdx]
            if (-not [string]::IsNullOrWhiteSpace($packet)) {
                $packets += $packet
            }
        }
        $stackArray = $packets.ToCharArray()
        [array]::Reverse($stackArray)
        $stacks += -join $stackArray;
    }

    # Packets movement
    for ($i = $itemNumberLineIdx + 2; $i -lt $Lines.Count; $i++) {
        [string[]] $commandParams = $Lines[$i] -split " "
        [int] $amountOfPackages = [int]::Parse($commandParams[1])
        [int] $fromStackIdx = [int]::Parse($commandParams[3]) - 1
        [int] $toStackIdx = [int]::Parse($commandParams[5]) - 1
        [char[]] $fromStack = $stacks[$fromStackIdx]

        [char[]] $packagesToStay = $fromStack | Select-Object -First ($fromStack.Count - $amountOfPackages)
        $stacks[$fromStackIdx] = -join $packagesToStay

        [char[]] $packagesToMove = $fromStack | Select-Object -Last $amountOfPackages

        if ($ItsCrateMover9001.IsPresent -eq $false) {
            [array]::Reverse($packagesToMove)
        }

        [string] $packagesToAdd = -join $packagesToMove
        $stacks[$toStackIdx] += $packagesToAdd
    }

    [string] $topCrates = ""
    foreach ($stack in $stacks) {
        if ([string]::IsNullOrWhiteSpace($stack)) {
            continue
        }
        $topCrates +=  $stack.Substring($stack.Length - 1)
    }
    return $topCrates
}