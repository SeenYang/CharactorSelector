FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
#Copy nuget.config to the root folder.
COPY nuget.config .
#Copy all the content from the root folder to the ./app folder (including folder structure)
COPY . ./app

#Set workdir to the project folder (so all the commands from now on will automatically run inside the workdir folder)
WORKDIR /app/CharactorSelectorApi
RUN dotnet restore --ignore-failed-sources

WORKDIR /app
RUN dotnet test

WORKDIR /app/CharactorSelectorApi
RUN dotnet publish -c Release -o ../out --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
ENV ASPNETCORE_URLS="http://*:80"
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "CharactorSelectorApi.dll"]