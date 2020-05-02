Set-Location (Get-Item $PSScriptRoot).Parent.Parent.FullName

if ($Env:OS.StartsWith('Windows', 'CurrentCultureIgnoreCase'))
{
    Add-Type -AssemblyName Microsoft.VisualBasic
    [void][Reflection.Assembly]::LoadWithPartialName('Microsoft.VisualBasic')

    $title = 'MiniMe migration tool'
    $msg = 'Input migration name'
    $name = [Microsoft.VisualBasic.Interaction]::InputBox($msg, $title)    
}
else
{
    $name = Read-Host 'Input migration name'
}

if ($name -match '^\w+$')
{
    dotnet ef migrations add $Name -o ./Data/Migrations
}
else
{
    Write-Error 'Invalid migration name.'
}
