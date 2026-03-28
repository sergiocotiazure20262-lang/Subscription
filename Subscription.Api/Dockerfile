# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Subscription.Api/Subscription.Api.csproj", "Subscription.Api/"]
COPY ["Subscription.Domain/Subscription.Domain.csproj", "Subscription.Domain/"]
COPY ["Subscription.Infra.Data/Subscription.Infra.Data.csproj", "Subscription.Infra.Data/"]
COPY ["Subscription.Infra.Messages/Subscription.Infra.Messages.csproj", "Subscription.Infra.Messages/"]
RUN dotnet restore "./Subscription.Api/Subscription.Api.csproj"
COPY . .
WORKDIR "/src/Subscription.Api"
RUN dotnet build "./Subscription.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Subscription.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Subscription.Api.dll"]