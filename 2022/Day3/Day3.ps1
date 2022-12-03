[string[]]$Lines = Get-Content -Path $PSScriptRoot\Input.txt
[string] $Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"

function DayThree-PartOne {
    [CmdletBinding()]
    param ()   
    process {
        [int] $totalScore = 0;
        foreach ($line in $Lines) {
            [int] $mid = $line.Length / 2;
            [string[]] $parts = @($line.substring(0, $mid), $line.substring($mid));
            [string] $firstPart = $parts[0]
            [string] $secondPart = $parts[1]

            for ($i = 0; $i -lt $parts[0].Length; $i++) {
                [string] $letter = $firstPart[$i];
                [boolean] $secondPartResult = Get-LetterExistsInString $secondPart $letter
                if ($secondPartResult -eq $true) {
                    $totalScore += Get-LetterValue($firstPart[$i])
                    break;
                }
            }
        }
        Write-Output $totalScore
    }
}
function DayThree-PartTwo {
    [CmdletBinding()]
    param ()
    process {
        [int] $totalScore = 0;
        for ($i = 0; $i -lt $Lines.Length; $i++) {
            [string] $firstBackpack = $Lines[$i]
            [string] $secondBackpack = $Lines[$i + 1]
            [string] $thirdBackpack = $Lines[$i + 2]

            for ($i2 = 0; $i2 -lt $firstBackpack.Length; $i2++) {
                [string] $letter = $firstBackpack[$i2];
                [boolean] $secondBackpackResult = Get-LetterExistsInString $secondBackpack $letter
                [boolean] $thirdBackpackResult = Get-LetterExistsInString $thirdBackpack $letter

                if ($secondBackpackResult -eq $true -and $thirdBackpackResult -eq $true) {
                    $totalScore += Get-LetterValue $letter
                    $i += 2
                    break;
                }
            }
        }

        Write-Output $totalScore
    }   
}

function Get-LetterExistsInString([string] $String, [string] $Letter) {
    return ($String.IndexOf($Letter) -gt -1)
}
function Get-LetterValue([string] $Letter) {
    $output = $letters.IndexOf($Letter) + 1
    return $output
}