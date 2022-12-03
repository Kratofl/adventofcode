[string[]]$lines = Get-Content -Path $PSScriptRoot\Input.txt
[int] $winPoints = 6;
[int] $drawPoints = 3;

function DayTwo-PartOne {
    [CmdletBinding()]
    param ()   
    process {
        [int] $totalScore = 0;
        foreach ($line in $lines) {
            [string[]] $decisions = $line -Split " "
            [Decision] $yourDecision = Convert-StringToDecision -String $decisions[1]
            [Decision] $opponentDecision = Convert-StringToDecision -String $decisions[0]
            $totalScore += Get-Score -Opponent $opponentDecision -You $yourDecision
        }
        Write-Output $totalScore
    }
}
function DayTwo-PartTwo {
    [CmdletBinding()]
    param ()
    process {
        [int] $totalScore = 0;
        foreach ($line in $lines) {
            [string[]] $decisions = $line -Split " "
            [Action] $yourAction = Convert-StringToAcion -String $decisions[1]
            [Decision] $opponentDecision = Convert-StringToDecision -String $decisions[0]

            [Decision] $yourDecision = [Decision]::Rock
            if ($yourAction -eq [Action]::Lose) {
                $yourDecision = Get-LosingDecision -Decision $opponentDecision
            }
            if ($yourAction -eq [Action]::Draw) {
                $yourDecision = $opponentDecision
            }
            if ($yourAction -eq [Action]::Win) {
                $yourDecision = Get-WinningDecision -Decision $opponentDecision
            }
            $totalScore += Get-Score -Opponent $opponentDecision -You $yourDecision
        }
        Write-Output $totalScore
    }   
}

function Get-Score {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [Decision] $Opponent,

        [Parameter(Mandatory = $true)]
        [Decision] $You
    )
    process {
        [int] $roundScore = 0;

        $roundScore += [int]$You

        if ($You -eq $Opponent) 
            { $roundScore += $drawPoints }

        if ((($You -eq [Decision]::Rock) -and ($Opponent -eq [Decision]::Scissors)) -or
            (($You -eq [Decision]::Paper) -and ($Opponent -eq [Decision]::Rock)) -or
            (($You -eq [Decision]::Scissors) -and ($Opponent -eq [Decision]::Paper))) {
            $roundScore += $winPoints;
        }

        return $roundScore
    }
}
function Get-WinningDecision {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [Decision] $Decision
    )
    process {
        if ($Decision -eq [Decision]::Scissors) {
            return [Decision]::Rock
        }
        if ($Decision -eq [Decision]::Paper) {
            return [Decision]::Scissors
        }
        if ($Decision -eq [Decision]::Rock) {
            return [Decision]::Paper
        }
        Write-Error "Wrong input: " + $Decision
    }
}
function Get-LosingDecision {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [Decision] $Decision
    )
    process {
        if ($Decision -eq [Decision]::Rock) {
            return [Decision]::Scissors
        }
        if ($Decision -eq [Decision]::Scissors) {
            return [Decision]::Paper
        }
        if ($Decision -eq [Decision]::Paper) {
            return [Decision]::Rock
        }
        Write-Error "Wrong input: " + $Decision
    }
}
function Convert-StringToDecision {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string] $String
    )
    process {
        if (($String -Match "X") -or ($String -Match "A")) {
            return [Decision]::Rock
        }
        if (($String -Match "Y") -or ($String -Match "B")) {
            return [Decision]::Paper
        }
        if (($String -Match "Z") -or ($String -Match "C")) {
            return [Decision]::Scissors
        }
        Write-Error "Wrong input: " + $String
    }
}
function Convert-StringToAcion {
    param (
        [Parameter(Mandatory = $true)]
        [string] $String
    )
    process {
        if (($String -Match "X")) {
            return [Action]::Lose
        }
        if (($String -Match "Y")) {
            return [Action]::Draw
        }
        if (($String -Match "Z")) {
            return [Action]::Win
        }
        Write-Error "Wrong input: " + $String
    }
}
enum Decision {
    Rock = 1
    Paper = 2
    Scissors = 3
}
enum Action {
    Lose = 1
    Draw = 2
    Win = 3
}

DayTwo-PartOne