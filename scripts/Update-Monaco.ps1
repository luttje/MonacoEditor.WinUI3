<#
.SYNOPSIS
    Updates the Monaco Editor assets to the latest version from npm/CDN.

.DESCRIPTION
    This script:
    1. Queries the npm registry for the latest stable monaco-editor version
    2. Downloads the minified distribution from jsDelivr CDN
    3. Extracts the required files into the project's Web/ folder
    4. Updates the version reference in index.html

    Run this from the repository root:
        .\scripts\Update-Monaco.ps1

    Or specify a version:
        .\scripts\Update-Monaco.ps1 -Version "0.55.1"

.PARAMETER Version
    Optional. A specific monaco-editor version to download (e.g. "0.55.1").
    If omitted, the latest stable version from npm is used.

.PARAMETER CdnOnly
    Optional. If set, only updates the CDN URL in index.html without downloading
    files locally. Use this for CDN-only deployments.
#>

[CmdletBinding()]
param(
    [string]$Version,
    [switch]$CdnOnly
)

$ErrorActionPreference = 'Stop'

$RepoRoot   = Split-Path -Parent $PSScriptRoot
$WebDir     = Join-Path $RepoRoot 'src\MonacoEditor.WinUI3\Web'
$HtmlFile   = Join-Path $WebDir 'index.html'
$TempDir    = Join-Path $env:TEMP "monaco-update-$(Get-Random)"

# ── Step 1: Resolve version ──────────────────────────────────────────────

if (-not $Version) {
    Write-Host '  Querying npm for latest monaco-editor version...' -ForegroundColor Cyan
    $npmInfo = Invoke-RestMethod -Uri 'https://registry.npmjs.org/monaco-editor/latest'
    $Version = $npmInfo.version
}

Write-Host "  Target version: monaco-editor@$Version" -ForegroundColor Green

# ── Step 2: Update the CDN fallback URL in index.html ────────────────────

if (Test-Path $HtmlFile) {
    $html = Get-Content $HtmlFile -Raw
    $updatedHtml = $html -replace `
        "monaco-editor@[\d\.]+/min", `
        "monaco-editor@$Version/min"
    Set-Content -Path $HtmlFile -Value $updatedHtml -NoNewline
    Write-Host "  Updated CDN URL in index.html" -ForegroundColor Green
}

if ($CdnOnly) {
    Write-Host '  CDN-only mode: skipping file download.' -ForegroundColor Yellow
    Write-Host "  Done! Monaco Editor updated to $Version (CDN reference only)." -ForegroundColor Green
    exit 0
}

# ── Step 3: Download the npm tarball ─────────────────────────────────────

Write-Host '  Downloading monaco-editor tarball...' -ForegroundColor Cyan

New-Item -ItemType Directory -Path $TempDir -Force | Out-Null

$TarballUrl = "https://registry.npmjs.org/monaco-editor/-/monaco-editor-$Version.tgz"
$TarballPath = Join-Path $TempDir "monaco-editor-$Version.tgz"

Invoke-WebRequest -Uri $TarballUrl -OutFile $TarballPath

# ── Step 4: Extract ──────────────────────────────────────────────────────

Write-Host '  Extracting...' -ForegroundColor Cyan

$ExtractDir = Join-Path $TempDir 'extracted'
New-Item -ItemType Directory -Path $ExtractDir -Force | Out-Null

# Use tar (available on Windows 10+)
tar -xzf $TarballPath -C $ExtractDir

$MonacoSrc = Join-Path $ExtractDir 'package\min'

if (-not (Test-Path $MonacoSrc)) {
    Write-Error "Expected directory '$MonacoSrc' not found after extraction."
    exit 1
}

# ── Step 5: Copy into project ────────────────────────────────────────────

$MonacoDest = Join-Path $WebDir 'monaco'

if (Test-Path $MonacoDest) {
    Write-Host '  Removing old Monaco files...' -ForegroundColor Yellow
    Remove-Item -Recurse -Force $MonacoDest
}

Write-Host '  Copying new Monaco files...' -ForegroundColor Cyan
Copy-Item -Path $MonacoSrc -Destination $MonacoDest -Recurse

# ── Step 6: Update the HTML to use local path ────────────────────────────

if (Test-Path $HtmlFile) {
    # If the user wants bundled local files, they can update __MONACO_BASE_URL__
    # The default in the HTML still points to CDN as a fallback.
    Write-Host "  Local Monaco files placed at: $MonacoDest" -ForegroundColor Green
    Write-Host "  Set MonacoBaseUrl='monaco' on the control to use local files." -ForegroundColor Yellow
}

# ── Step 7: Write version marker ─────────────────────────────────────────

$VersionFile = Join-Path $MonacoDest 'VERSION.txt'
Set-Content -Path $VersionFile -Value $Version

# ── Cleanup ──────────────────────────────────────────────────────────────

Write-Host '  Cleaning up temp files...' -ForegroundColor Cyan
Remove-Item -Recurse -Force $TempDir

Write-Host ''
Write-Host "  Done! Monaco Editor updated to $Version" -ForegroundColor Green
Write-Host "  Files are in: $MonacoDest" -ForegroundColor Green
Write-Host ''
Write-Host '  Next steps:' -ForegroundColor White
Write-Host '    1. Rebuild the project' -ForegroundColor White
Write-Host '    2. Test that the editor loads correctly' -ForegroundColor White
Write-Host '    3. Commit the changes' -ForegroundColor White
