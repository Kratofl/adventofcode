[string[]]$Lines = Get-Content -Path $PSScriptRoot\Input.txt

function DaySix-PartOne {
    [CmdletBinding()]
    param ()   
    process {
        [int] $markerIndex = Get-MarkerIndex 4
        Write-Output $markerIndex
    }
}
function DaySix-PartTwo {
    [CmdletBinding()]
    param ()
    process {
       [int] $markerIndex = Get-MarkerIndex 14
       Write-Output $markerIndex
    }   
}

function Get-MarkerIndex([int] $PacketSize) {
    [string] $data = $Lines[0]

    for ($i = 0; $i -lt $data.Length; $i++) {
        [char[]] $packetChars = $data.Substring($i, $PacketSize)
        [char[]] $sortedPacketChars = $packetChars | Sort-Object | Get-Unique

        if ($sortedPacketChars.Count -eq $PacketSize) {
            return ($i + $PacketSize)
            break
        }
    }
    return 0
}