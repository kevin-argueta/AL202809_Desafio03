FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["AL202809_Desafio03/AL202809_Desafio03.csproj", "AL202809_Desafio03/"]
COPY ["AL208209_Desafio3.BL/AL208209_Desafio3.BL.csproj", "AL208209_Desafio3.BL/"]
COPY ["AL208209_Desafio3.DAL/AL208209_Desafio3.DAL.csproj", "AL208209_Desafio3.DAL/"]
COPY ["AL208209_Desafio3.Entities/AL208209_Desafio3.Entities.csproj", "AL208209_Desafio3.Entities/"]
COPY ["AL208209_Desafio3.Common/AL208209_Desafio3.Common.csproj", "AL208209_Desafio3.Common/"]

RUN dotnet restore "AL202809_Desafio03/AL202809_Desafio03.csproj"

COPY . .

WORKDIR "/src/AL202809_Desafio03"
RUN dotnet build "AL202809_Desafio03.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AL202809_Desafio03.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS final 

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "AL202809_Desafio03.dll"]