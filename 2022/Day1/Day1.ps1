[string[]]$lines = Get-Content -Path $PSScriptRoot\Input.txt

function DayOne-PartOne {
    [CmdletBinding()]
    param ()   
    process {
        [int] $mostcalories = 0;

        [int] $currentElvCalories = 0;
        foreach ($line in $lines) {
            # Elv is done
            if ([string]::IsNullOrEmpty($line)) {
                if ($currentElvCalories -gt $mostcalories) {
                    $mostcalories = $currentElvCalories
                }
                $currentElvCalories = 0;
                continue;
            }

            $currentElvCalories += [int]$line;
        }
        Write-Host $mostcalories
    }   
}
function DayOne-PartTwo {
    [CmdletBinding()]
    param ()
    process {
        $mostcalories = New-Object int[] 0;

        [int] $currentElvCalories = 0;
        foreach ($line in $lines) {
            # Elv is done
            if ([string]::IsNullOrEmpty($line)) {
                $mostcalories += $currentElvCalories
                $currentElvCalories = 0;
                continue;
            }
            $currentElvCalories += [int]$line;
        }
        $sortedCalories = $mostcalories | Sort-Object -Descending
        $selectedCalories = $sortedCalories | Select-Object -First 3 -Wait
        $output = $selectedCalories[0] + $selectedCalories[1] + $selectedCalories[2];
        Write-Host $output;
    }   
    end {}
}