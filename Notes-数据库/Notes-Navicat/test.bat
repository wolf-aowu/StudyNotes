@echo off
for /f %%i in ('"reg query "HKEY_CURRENT_USER\Software\Classes\CLSID" /s | findstr /l Info"') do (
    echo %%i
)
pause