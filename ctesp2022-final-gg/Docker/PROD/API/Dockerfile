# Specify the parent image from which we build
FROM mcr.microsoft.com/dotnet/sdk:5.0 as webapig

# Set the working directory
WORKDIR /app

# Copy files from your host to your current working directory
COPY ctesp2022-final-gg/ctesp2022-final-gg.csproj ./

COPY . ./

RUN dotnet publish -c release -o out

#Restore and build the project
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /app

COPY --from=webapig /app/out ./

ENTRYPOINT [ "dotnet", "ctesp2022-final-gg.dll" ]