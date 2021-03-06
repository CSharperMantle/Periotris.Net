dotnet publish Periotris.Net --no-self-contained --runtime win-x64 -o publish/win-x64-nsc -c Release
dotnet publish Periotris.Net --no-self-contained --runtime osx-x64 -o publish/osx-x64-nsc -c Release
dotnet publish Periotris.Net --no-self-contained --runtime win-x86 -o publish/win-x86-nsc -c Release
dotnet publish Periotris.Net --self-contained --runtime win-x64 -o publish/win-x64-sc -c Release
Compress-Archive -DestinationPath 'publish/win-x64-nsc.zip' -LiteralPath 'publish/win-x64-nsc/'
Compress-Archive -DestinationPath 'publish/osx-x64-nsc.zip' -LiteralPath 'publish/osx-x64-nsc/'
Compress-Archive -DestinationPath 'publish/win-x86-nsc.zip' -LiteralPath 'publish/win-x86-nsc/'
Compress-Archive -DestinationPath 'publish/win-x64-sc.zip' -LiteralPath 'publish/win-x64-sc/'