. $PSScriptRoot\Day1\Day1.ps1

function aoc {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [ValidateSet(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)]
        [int] $day,

        [Parameter(Mandatory = $true)]
        [ValidateSet(1, 2)]
        [int] $part
    )
    process {
        switch ($day) {
            1 { switch ($part) {
                1 { DayOne-PartOne }
                2 { DayOne-PartTwo }
            } }
        }
    }
    end {}
}