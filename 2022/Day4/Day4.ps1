[string[]]$Lines = Get-Content -Path $PSScriptRoot\Input.txt

function DayFour-PartOne {
    [CmdletBinding()]
    param ()   
    process {
        [int] $totalScore = Get-Score -ListsMustBeQual
        Write-Output $totalScore
    }
}
function DayFour-PartTwo {
    [CmdletBinding()]
    param ()
    process {
        [int] $totalScore = Get-Score
        Write-Output $totalScore
    }   
}

function Get-Score([Switch] $ListsMustBeQual) {
    [int] $totalScore = 0;

    foreach ($line in $Lines) {
        [string[]] $pair = $line -split ","

        $hashTable = @{
            firstRange = New-Object int[] 0
            secondRange = New-Object int[] 0
        }

        for ($i = 0; $i -lt $pair.Count; $i++) {
            [int[]] $numbers = $pair[$i] -split "-"
            [int] $bottomNumber = $numbers[0]
            [int] $topNumber = $numbers[1]
            [int[]] $numberRange = New-Object int[] 0

            $numberRange += $bottomNumber
            for ($i2 = $bottomNumber + 1; $i2 -lt $topNumber; $i2++) {
                $numberRange += $i2
            }
            $numberRange += $topNumber

            $hashTable[$i] = $numberRange
        }

        $firstArrayCompare = Compare-NumberRanges $hashTable[0] $hashTable[1] -CheckForEquality $ListsMustBeQual.IsPresent
        $secondArrayCompare = Compare-NumberRanges $hashTable[1] $hashTable[0] -CheckForEquality $ListsMustBeQual.IsPresent
        if ($firstArrayCompare -eq $true -or $secondArrayCompare -eq $true) {
            $totalScore += 1
        }
    }

    return $totalScore
}

function Compare-NumberRanges([int[]] $ReferenceRange, [int[]] $ToCompare, [bool] $CheckForEquality) {
    for ($i = 0; $i -lt $ReferenceRange.Count; $i++) {
        if ($CheckForEquality -eq $true) {
            if ($ToCompare -notcontains $ReferenceRange[$i]) { return $false }
        }
        else {
            if ($ToCompare -contains $ReferenceRange[$i]) { return $true }
        }
    }
    return $CheckForEquality
}