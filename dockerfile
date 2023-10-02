# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ["Presentation.CardGamesGuruMiniApp/Presentation.CardGamesGuruMiniApp.csproj","Presentation.CardGamesGuruMiniApp/"]
RUN dotnet restore "Presentation.CardGamesGuruMiniApp/Presentation.CardGamesGuruMiniApp.csproj"

# Copy the source code and build the application
COPY . .
RUN dotnet build

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80

# Entry point for the application
ENTRYPOINT ["dotnet", "Presentation.CardGamesGuruMiniApp.dll"]
