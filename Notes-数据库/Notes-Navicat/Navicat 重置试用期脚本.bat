@echo off
for /f %%i in ('"reg query "HKEY_CURRENT_USER\Software\PremiumSoft\NavicatPremium" /s | findstr /l Registration"') do (
    echo %%i
    reg delete %%i /va /f
)

for /f %%i in ('"reg query "HKEY_CURRENT_USER\Software\Classes\CLSID" /s | findstr /e Info"') do (
    echo %%i
    reg delete %%i /va /f
)
pause