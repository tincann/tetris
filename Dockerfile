FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . ./
RUN dotnet restore Tetris.sln

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out Tetris.sln

# Build runtime image
FROM microsoft/dotnet:runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Tetris.Game.dll"]
