[string[]]$Lines = Get-Content -Path $PSScriptRoot\Input.txt

function DayNine-PartOne {
    [CmdletBinding()]
    param ()
    process {
        $tailPositions = New-Object 'system.collections.generic.List[string]'

        [int] $headX = 0
        [int] $headY = 0
        [int] $tailX = 0
        [int] $tailY = 0
        
        $tailPositions.Add("$($tailX),$($tailY)");

        foreach ($line in $Lines) {
            [string[]] $cmdInput = $line -split " "
            [MoveDirection] $moveDirection = Convert-StringToMoveDirection $cmdInput[0]
            [int] $movementAmount = [int]::Parse($cmdInput[1])

            if ($moveDirection -eq [MoveDirection]::Right) {
                for ($i = 0; $i -lt $movementAmount; $i++) {
                    $headX += 1
                    [int] $potentialTailCoord = $tailX + 1

                    $xDiff = ($headX - $potentialTailCoord)
                    $yDiff = ($headY - $tailY)
                    if ($xDiff -lt 1) {
                        continue
                    }
                    if ($yDiff -ne 0) {
                        $tailY = $headY
                    }
                    $tailX = $headX - 1
                    $tailPositions.Add("$($tailX),$($tailY)")
                }
            }
            elseif ($moveDirection -eq [MoveDirection]::Left) {
                for ($i = 0; $i -lt $movementAmount; $i++) {
                    $headX -= 1
                    [int] $potentialTailCoord = $tailX - 1

                    $xDiff = ($potentialTailCoord - $headX)
                    $yDiff = ($headY - $tailY)
                    if ($xDiff -lt 1) {
                        continue
                    }
                    if ($yDiff -ne 0) {
                        $tailY = $headY
                    }
                    $tailX = $headX + 1
                    $tailPositions.Add("$($tailX),$($tailY)")
                }
            }
            elseif ($moveDirection -eq [MoveDirection]::Up) {
                for ($i = 0; $i -lt $movementAmount; $i++) {
                    $headY += 1
                    [int] $potentialTailCoord = $tailY + 1

                    $xDiff = ($headX - $tailX)
                    $yDiff = ($headY - $potentialTailCoord)
                    if ($yDiff -lt 1) {
                        continue
                    }
                    if ($xDiff -ne 0) {
                        $tailX = $headX
                    }
                    $tailY = $headY - 1
                    $tailPositions.Add("$($tailX),$($tailY)")
                }
            }
            elseif ($moveDirection -eq [MoveDirection]::Down) {
                for ($i = 0; $i -lt $movementAmount; $i++) {
                    $headY -= 1
                    [int] $potentialTailCoord = $tailY - 1

                    $xDiff = ($headX - $tailX)
                    $yDiff = ($potentialTailCoord - $headY)
                    if ($yDiff -lt 1) {
                        continue
                    }
                    if ($xDiff -ne 0) {
                        $tailX = $headX
                    }
                    $tailY = $headY + 1
                    $tailPositions.Add("$($tailX),$($tailY)")
                }
            }
        }
        [system.collections.generic.list[string]] $counts = $tailPositions | Select-Object -Unique
        foreach ($count in $counts) {
            #Write-Output $count
        }
        #Write-Output $counts.Count
    }
}

function DayNine-PartTwo {
    [CmdletBinding()]
    param ()
    process {
        Write-Output "Currently not possbile for me :("
    }
}

function Convert-StringToMoveDirection([string] $InputString) {
    switch ($InputString) {
        "R" { return [MoveDirection]::Right }
        "L" { return [MoveDirection]::Left }
        "D" { return [MoveDirection]::Down }
        "U" { return [MoveDirection]::Up }
        Default { return $null }
    }
}

enum MoveDirection {
    Right
    Left
    Down
    Up
}

DayNine-PartOne
DayNine-PartTwo