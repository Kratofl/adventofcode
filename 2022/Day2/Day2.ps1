[string[]]$lines = Get-Content -Path $PSScriptRoot\Input.txt

function Get-Score {
    [CmdletBinding()]
    param (
        [Parameter()]
        [string] $Opponent,

        [Parameter()]
        [string] $You
    )
    process {
        [int] $roundScore = 0;
        if ($You -Match "X") {
            $roundScore += 1;

            if (($Opponent -Match "A")) {
                $roundScore += 3;
            }
            elseif (($Opponent -Match "C")) {
                $roundScore += 6;
            }
        }
        elseif ($You -Match "Y") {
            $roundScore += 2;

            if (($Opponent -Match "B")) {
                $roundScore += 3;
            }
            elseif (($Opponent -Match "A")) {
                $roundScore += 6;
            }
        }
        elseif ($You -Match "Z") {
            $roundScore += 3;

            if (($Opponent -Match "C")) {
                $roundScore += 3;
            }
            elseif (($Opponent -Match "B")) {
                $roundScore += 6;
            }
        }
        return $roundScore
    }
}

function DayTwo-PartOne {
    [CmdletBinding()]
    param ()   
    process {
        [int] $totalScore = 0;
        foreach ($line in $lines) {
            [int] $roundScore = 0;
            [string[]] $descisions = $line -Split " "

            $totalScore += Get-Score -Opponent $descisions[0] -You $descisions[1]
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
            [int] $roundScore = 0;

            if ($line -Match "X") {
                if (($line -Match "A")) {
                    $roundScore += 3;
                }
                elseif (($line -Match "B")) {
                    $roundScore += 1;
                }
                elseif (($line -Match "C")) {
                    $roundScore += 2;
                }
            }
            elseif ($line -Match "Y") {
                $roundScore += 3;

                if (($line -Match "A")) {
                    $roundScore += 1;
                }
                elseif (($line -Match "B")) {
                    $roundScore += 2;
                }
                elseif (($line -Match "C")) {
                    $roundScore += 3;
                }
            }
            elseif ($line -Match "Z") {
                $roundScore += 6;

                if (($line -Match "A")) {
                    $roundScore += 2;
                }
                elseif (($line -Match "B")) {
                    $roundScore += 3;
                }
                elseif (($line -Match "C")) {
                    $roundScore += 1;
                }
            }

            $totalScore += $roundScore;
        }
        Write-Output $totalScore
    }   
}