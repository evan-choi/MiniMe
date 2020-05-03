Set-Location $PSScriptRoot

function Verify-Index {
    Param (
        [string]$Index,
        [int]$Min,
        [int]$Max
    )

    if ($Index -notmatch "^\d+$") {
        return $false
    }

    $Index = [int]$Index

    return $Min -le $Index -and $Index -le $Max
}

function Get-Projects {
    $result = New-Object System.Collections.Generic.List[System.Object]

    foreach ($projectDir in Get-ChildItem ./MiniMe.* -Directory) {
        $projectName = $projectDir.Name.Split(".", 2)[1]
        $dataDir = [IO.Path]::Combine($projectDir, 'Data')
        $contextFile = [IO.Path]::Combine($dataDir, "$($projectName)Context.cs")

        if (!(Test-Path $contextFile)) {
            continue
        }

        $result.Add([ordered]@{
            Name = $projectName
            ProjectDirectory = $projectDir
            MigrationDirectory = [IO.Path]::Combine($dataDir, 'Migrations')
        })
    }

    return $result
}

function Select-Project {
    while ($true) {
        Clear-Host
        Write-Host "================ Select Project ================"

        $projects = Get-Projects
    
        for ($i = 0; $i -lt $projects.Count; $i++) {
            Write-Host "$($i + 1). $($projects[$i].Name)"
        }

        Write-Host "$($projects.Count + 1). Exit"
        Write-Host

        $input = Read-Host "Project"

        if (!(Verify-Index $input -Min 1 -Max ($projects.Count + 1))) {
            continue
        }

        if ($input -eq 3) {
            return
        } else {
            return $projects[$input - 1]
        }

        pause
    }
}

function Delete-All-Migration($project) {
    do {
        $yn = (Read-Host "Delete all $($project.Name) migration data? (Y/N)").ToLower() 
    } while ($yn -notin @('y','n'))
                
    if ($yn -eq 'y') {
        Remove-Item -Recurse -Force -ErrorAction Ignore $project.MigrationDirectory
    }
}

function Initialize-Migration($project) {
    if (Test-Path $project.MigrationDirectory) {
        Delete-All-Migration $project
    }

    dotnet ef migrations add InitialCreate -o $project.MigrationDirectory
}

function Create-Migration($project) {
    $name = Read-Host 'Input migration name'

    if ($name -match '^\w+$') {
        dotnet ef migrations add $Name -o ./Data/Migrations
    }
    else
    {
        Write-Error 'Invalid migration name.'
    }
}

function Run-Migration($project) {
    while ($true) {
        Clear-Host
        Write-Host "================ $($project.Name) EF Migration ================"
        Write-Host "1. Initialize migration"
        Write-Host "2. Creatre migration"
        Write-Host "3. Delete all migrations"
        Write-Host "4. Exit"
        Write-Host

        $input = Read-Host "Project"
        
        if (!(Verify-Index $input -Min 1 -Max 3)) {
            continue
        }

        Write-Host
        Set-Location $project.ProjectDirectory

        switch ($input) {
            1 {
                Initialize-Migration $project
            }
            2 {
                Create-Migration $project
            }
            3 {
                Delete-All-Migration $project
            }
            4 {
                return
            }
        }

        Write-Host
        Write-Host 'Done'

        return
    }
}

$selectedProject = Select-Project

if ($selectedProject -eq $null) {
    return
}

Run-Migration $selectedProject
