# Usage:
#   SetVersion -Path <CSPROJ_PATH> [<PROPERTY>=<VALUE>]...
param(
    [Parameter(Mandatory=$true,HelpMessage="Path to the target .csproj file.")][String]$Path="",
    [Parameter(ValueFromRemainingArguments=$true)][String[]]$PropertySetters
)

# Resolve Path
$Path = [System.IO.Path]::GetFullPath([System.IO.Path]::Combine($(Get-Location), $Path))

"Reading '$Path'"

# Read XML file
[xml]$CONTENT = Get-Content -Path "$Path"

# doing this prevents failure when there are multiple PropertyGroup nodes:
$TARGET_NODE = $CONTENT.SelectSingleNode("//Project/PropertyGroup")

foreach ($SETTER in $PropertySetters)
{
    $v = $SETTER -split "=",2

    $previousValue = $TARGET_NODE."$($v[0])"
    $TARGET_NODE."$($v[0])" = $v[1]
    
    if ($previousValue.Length -eq 0) {
        "Set $($v[0]) to $($v[1])"
    }
    else {
        "Set $($v[0]) to $($v[1]) (Was $previousValue)"
    }
}

$CONTENT.Save("$Path")

"Saved '$Path'"
