[string[]]$lines = Get-Content -Path $PSScriptRoot\Input.txt

function Get-ElfCalories {
    $calories = New-Object int[] 0;
    [int] $currentElfCalories = 0;
    foreach ($line in $lines) {
        # Elf is done
        if ([string]::IsNullOrEmpty($line)) {
            if ($currentElfCalories -gt $mostcalories) {
                $calories += $currentElfCalories
            }
            $currentElfCalories = 0;
            continue;
        }
        $currentElfCalories += [int]$line;
    }
    return $calories;
}

function DayOne-PartOne {
    [CmdletBinding()]
    param ()   
    process {
        [int[]] $calories = Get-ElfCalories
        [int] $mostcalories = 0;
        
        foreach ($calorie in $calories) {
            if ($calorie -gt $mostcalories) {
                $mostcalories = $calorie
            }
        }
        Write-Host $mostcalories
    }   
}
function DayOne-PartTwo {
    [CmdletBinding()]
    param ()
    process {
        [int[]] $calories = Get-ElfCalories

        $sortedCalories = $calories | Sort-Object -Descending
        $selectedCalories = $sortedCalories | Select-Object -First 3 -Wait
        $output = $selectedCalories[0] + $selectedCalories[1] + $selectedCalories[2];
        Write-Host $output;
    }   
    end {}
}