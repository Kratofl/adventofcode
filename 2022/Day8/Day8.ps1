[string[]]$Lines = Get-Content -Path $PSScriptRoot\Input.txt

function DayEight-PartOne {
    [CmdletBinding()]
    param ()   
    process {
        Build-TreeMap

        [int] $treesVisible = 0

        for ($i = 0; $i -lt $TreeMap.Count; $i++) {
            [Collections.Generic.List[Int]] $treeRow = $TreeMap[$i]

            # First and last row always visible
            if (($i -eq 0) -or ($i -eq $TreeMap.Count - 1)) {
                $treesVisible += $TreeMap.Count
                continue
            }

            for ($i2 = 0; $i2 -lt $treeRow.Count; $i2++) {
                # First and last tree always visible
                if (($i2 -eq 0) -or ($i2 -eq $treeRow.Count - 1)) { 
                    $treesVisible += 1;     
                    continue
                }

                [int] $rowIdx = $i
                [int] $columnIdx = $i2
                [int] $currentTreeHeight = $treeRow[$i2]

                # Move Left
                [boolean] $higherTreeFound = $false;
                for ($i3 = $columnIdx - 1; $i3 -ge 0; $i3--) {
                    [int] $treeHeight = $TreeMap[$rowIdx][$i3]
                    if ($treeHeight -ge $currentTreeHeight) {
                        $higherTreeFound = $true;
                        break
                    }
                }
                if ($higherTreeFound -eq $false) {
                    $treesVisible += 1;
                    continue
                }

                # Move Top
                $higherTreeFound = $false;
                for ($i3 = $rowIdx - 1; $i3 -ge 0; $i3--) {
                    [int] $treeHeight = $TreeMap[$i3][$columnIdx]
                    if ($treeHeight -ge $currentTreeHeight) {
                        $higherTreeFound = $true;
                        break
                    }
                }
                if ($higherTreeFound -eq $false) {
                    $treesVisible += 1;
                    continue
                }

                # Move Right
                $higherTreeFound = $false;
                for ($i3 = $columnIdx + 1; $i3 -lt $treeRow.Count; $i3++) {
                    [int] $treeHeight = $TreeMap[$rowIdx][$i3]
                    if ($treeHeight -ge $currentTreeHeight) {
                        $higherTreeFound = $true;
                        break
                    }
                }
                if ($higherTreeFound -eq $false) {
                    $treesVisible += 1;
                    continue
                }
                
                # Move Bottom
                $higherTreeFound = $false;
                for ($i3 = $rowIdx + 1; $i3 -lt $TreeMap.Count; $i3++) {
                    [int] $treeHeight = $TreeMap[$i3][$columnIdx]
                    if ($treeHeight -ge $currentTreeHeight) {
                        $higherTreeFound = $true;
                        break
                    }
                }
                if ($higherTreeFound -eq $false) {
                    $treesVisible += 1;
                    continue
                }
            }
        }

        Write-Output $treesVisible
    }
}
function DayEight-PartTwo {
    [CmdletBinding()]
    param ()
    process {
        Collections.Generic.List[Collections.Generic.List[Int]] $TreeMap = Build-TreeMap

        [Collections.Generic.List[Int]] $scenicScore = [Collections.Generic.List[Int]]::new()

        for ($i = 0; $i -lt $TreeMap.Count; $i++) {
            [Collections.Generic.List[Int]] $treeRow = $TreeMap[$i]

            for ($i2 = 0; $i2 -lt $treeRow.Count; $i2++) {
                [int[]] $treesVisibleCount = New-Object int[] 4
                [int] $rowIdx = $i
                [int] $columnIdx = $i2
                [int] $currentTreeHeight = $treeRow[$i2]

                # Move Left
                for ($i3 = $columnIdx - 1; $i3 -ge 0; $i3--) {
                    [int] $treeHeight = $TreeMap[$rowIdx][$i3]
                    $treesVisibleCount[1] += 1
                    if ($treeHeight -ge $currentTreeHeight) {
                        break
                    }
                }

                # Move Top
                for ($i3 = $rowIdx - 1; $i3 -ge 0; $i3--) {
                    [int] $treeHeight = $TreeMap[$i3][$columnIdx]
                    $treesVisibleCount[0] += 1
                    if ($treeHeight -ge $currentTreeHeight) {
                        break
                    }
                }

                # Move Right
                for ($i3 = $columnIdx + 1; $i3 -lt $treeRow.Count; $i3++) {
                    [int] $treeHeight = $TreeMap[$rowIdx][$i3]
                    $treesVisibleCount[3] += 1
                    if ($treeHeight -ge $currentTreeHeight) {
                        break
                    }
                }
                
                # Move Bottom
                for ($i3 = $rowIdx + 1; $i3 -lt $TreeMap.Count; $i3++) {
                    [int] $treeHeight = $TreeMap[$i3][$columnIdx]
                    $treesVisibleCount[2] += 1
                    if ($treeHeight -ge $currentTreeHeight) {
                        break
                    }
                }
                $scenicScore.Add($treesVisibleCount[0] * $treesVisibleCount[1] * $treesVisibleCount[2] * $treesVisibleCount[3])
            }
        }

        Write-Output ($scenicScore | Measure-Object -maximum).maximum
    }   
}

function Build-TreeMap() {
    $treeMap = New-Object Collections.Generic.List[Collections.Generic.List[Int]]
    foreach ($line in $Lines) {
        $treeRow = New-Object Collections.Generic.List[Int]

        [char[]] $numberChars = $line
        foreach ($numberChar in $numberChars) {
            $treeRow.Add([int]::Parse($numberChar.ToString()))
        }

        $treeMap.Add($treeRow)
    }
    return $treeMap
}