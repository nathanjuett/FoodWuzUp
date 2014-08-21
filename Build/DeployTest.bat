(robocopy.exe L:\Code\Git\FoodWuzUp\FoodWuzUp.Web C:\inetpub\wwwroot\FoodWuzUpTest /E /XF *.cs *.csproj *.sln *.config *.user /XD obj) ^& IF %ERRORLEVEL% LEQ 1 exit 0
