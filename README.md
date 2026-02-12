# TshirtFormMockup (.NET MAUI Desktop)

Desktop MAUI sample with a File/Edit/View/Help menu bar and placeholder actions.

## Prerequisites
- .NET 7 SDK with MAUI workload (`dotnet workload install maui`)
- Windows 10 19041+ for desktop target

## Build & Run (Windows)
1. `dotnet restore`
2. `dotnet build -t:Run -f net7.0-windows10.0.19041.0`

## Menu Actions
- File: New, Open, Save (alerts), Exit (closes app)
- Edit: Undo, Redo, Copy, Paste (alerts)
- View: Refresh, Toggle Theme (alerts)
- Help: About (alert)
