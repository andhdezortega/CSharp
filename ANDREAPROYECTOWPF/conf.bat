@ECHO OFF
cls
chcp 65001 <NUL
SET PATH=C:\dotnet-sdk-8.0.414-win-x64;%PATH%
SET PATH=.;C:\Users\Venta\AppData\Local\Programs\Python\Python313;%PATH%
SET PATH=C:\Users\Venta\AppData\Local\Programs\Python\Python313\Scripts;%PATH%

dotnet --version

@ECHO OFF
CLS
CHCP 65001 > NUL

SET PATH=C:\sqlite3;C:\Program Files\SQLite\bin;%PATH%

python --version
mysql --version
dotnet --version