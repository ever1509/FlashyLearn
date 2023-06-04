FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/FlashyLearn.API.GraphQL/FlashyLearn.API.GraphQL.csproj", "src/FlashyLearn.API.GraphQL/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
RUN dotnet restore "src/FlashyLearn.API.GraphQL/FlashyLearn.API.GraphQL.csproj"
COPY . .
WORKDIR "/src/src/FlashyLearn.API.GraphQL"
RUN dotnet build "FlashyLearn.API.GraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlashyLearn.API.GraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlashyLearn.API.GraphQL.dll"]
