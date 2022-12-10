[string[]] $Lines = Get-Content -Path $PSScriptRoot\Input.txt

function DayTen-PartOne {
    [CmdletBinding()]
    param ()
    process {
        Write-Output ((Get-CycleNumbers 20) + (Get-CycleNumbers 60) + (Get-CycleNumbers 100) + (Get-CycleNumbers 140) + (Get-CycleNumbers 180) + (Get-CycleNumbers 220))
    }
}

function Get-CycleNumbers([int] $BreakAt) {
    $pipeLine = @{
        addValue = New-Object int[] 0
        executeAt = New-Object int[] 0
    }

    for ($i = 0; $i -lt $Lines.Count; $i++) {
        [string] $line = $Lines[$i]

        [int] $valueToAdd = 0

        [int] $processDuration = 2
        if ($line -match "noop") {
            $processDuration = 1
        }
        else {
            $valueToAdd = [int]::Parse(($line -split " ")[1])
        }

        $pipeLine.addValue += $valueToAdd

        [int] $executeAt = $pipeLine.executeAt[$pipeLine.executeAt.Count - 1] + $processDuration
        $pipeLine.executeAt += $executeAt
    }

    [int] $totalStrength = 1
    for ($i = 0; $i -lt $pipeLine.executeAt[$pipeLine.executeAt.Count - 1]; $i++) {
        if ($i -eq $BreakAt) {
            break
        }

        if ($pipeLine.executeAt[0] -eq $i) {
            $totalStrength += $pipeLine.addValue[0]
            $pipeLine.addValue = $pipeLine.addValue[1..($pipeLine.addValue.Count - 1)]
            $pipeLine.executeAt = $pipeLine.executeAt[1..($pipeLine.executeAt.Count - 1)]
            continue
        }
    }
    return ($totalStrength * $BreakAt)
}

function DayTen-PartTwo {
    [CmdletBinding()]
    param ()
    process {
        $pipeLine = @{
            addValue = New-Object int[] 0
            executeAt = New-Object int[] 0
            instructed = New-Object int[] 0
        }
        $pipeLine = Load-Pipeline

        [int] $BreakAt = 40
        [string] $row = ""
        for ($i = 0; $i -lt $pipeLine.executeAt[$pipeLine.executeAt.Count - 1]; $i++) {
            if ($i -eq $BreakAt) {
                Write-Output $row
                continue
            }
    
            if (($pipeLine.executeAt[0] -eq $i -or $pipeLine.instructed[0] -eq $i) -and $pipeLine.addValue[0] -ne 0) {        
                $row += "#"

                $pipeLine.addValue = $pipeLine.addValue[1..($pipeLine.addValue.Count - 1)]
                $pipeLine.executeAt = $pipeLine.executeAt[1..($pipeLine.executeAt.Count - 1)]
                continue
            }
            $row += "."
        }
    }
}

function Load-Pipeline {
    $pipeLine = @{
        addValue = New-Object int[] 0
        executeAt = New-Object int[] 0
        instructed = New-Object int[] 0
    }

    for ($i = 0; $i -lt $Lines.Count; $i++) {
        [string] $line = $Lines[$i]

        [int] $valueToAdd = 0

        [int] $processDuration = 2
        if ($line -match "noop") {
            $processDuration = 1
        }
        else {
            $valueToAdd = [int]::Parse(($line -split " ")[1])
        }

        $pipeLine.addValue += $valueToAdd

        [int] $instructed = $pipeLine.executeAt[$pipeLine.executeAt.Count - 1]
        $pipeLine.instructed += $instructed
        
        [int] $executeAt = $instructed + $processDuration
        $pipeLine.executeAt += $executeAt
    }

    return $pipeLine
}

DayTen-PartOne
DayTen-PartTwo