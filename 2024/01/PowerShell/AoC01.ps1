$inputListLeft = @()
$inputListRight = @()
$diffSum = 0

# grab unprocessed file content. Yours will be different
$fileContent = Get-Content ".\2024\01\PowerShell\InputList.txt"

foreach ($line in $fileContent) {
    # the last line might be empty. We want to skip this line
    if ([string]::IsNullOrEmpty($line)) {
        break
    }
    Write-Output "Splitting line: $line"
    # match any number of digits at the start of the string, then three spaces, then any other number of digits
    $line -match "^(\d+)\s\s\s(\d+)$" | Out-Null
    # assign matches to the lists
    $inputListLeft += [int]$Matches[1]
    $inputListRight += [int]$Matches[2]
}

Write-Output "Sorting lists"

$inputListLeft = $inputListLeft | Sort-Object
$inputListRight = $inputListRight | Sort-Object

# lists are the same length, just pick one for .Count
for ($i = 0; $i -lt $inputListLeft.Count; $i++) {
    # use absolute value to negate left or right being larger and handling negative values
    $diff = [Math]::Abs($inputListLeft[$i] - $inputListRight[$i])
    $diffSum += $diff;
    Write-Output "Total Diff: $diffSum | Added Diff: $diff | Left Value: $($inputListLeft[$i]) | Right Value: $($inputListRight[$i])"
}

Write-Output "Total Final Diff: $diffSum"