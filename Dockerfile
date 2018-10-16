FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

COPY Fitness.WebApi/Fitness.WebApi.csproj ./Fitness.WebApi/
COPY Fitness.Core/Fitness.Core.csproj ./Fitness.Core/
COPY Fitness.DataModels/Fitness.DataModels.csproj ./Fitness.DataModels/
WORKDIR /app/Fitness.WebApi
RUN dotnet restore

WORKDIR /app/
COPY Fitness.WebApi/. ./Fitness.WebApi/
COPY Fitness.Core/. ./Fitness.Core/
COPY Fitness.DataModels/. ./Fitness.DataModels/
WORKDIR /app/Fitness.WebApi
RUN dotnet publish -c Debug -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/Fitness.WebApi/out ./
ENTRYPOINT ["dotnet", "Fitness.WebApi.dll"]