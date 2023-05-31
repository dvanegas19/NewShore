FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NewShore.Flight.WebApi/NewShore.Flight.WebApi.csproj", "NewShore.Flight.WebApi/"]
COPY ["NewShore.Flight.Controllers/NewShore.Flight.Controllers.csproj", "NewShore.Flight.Controllers/"]
COPY ["NewShore.Flight.ExternalPresenter/NewShore.Flight.ExternalPresenter.csproj", "NewShore.Flight.ExternalPresenter/"]
COPY ["NewShore.Flight.UseCasesExternal/NewShore.Flight.UseCasesExternal.csproj", "NewShore.Flight.UseCasesExternal/"]
COPY ["NewShore.Flight.UseCasesPortsExternal/NewShore.Flight.UseCasesPortsExternal.csproj", "NewShore.Flight.UseCasesPortsExternal/"]
COPY ["NewShore.Flight.UsesCasesExternalDTOs/NewShore.Flight.UsesCasesExternalDTOs.csproj", "NewShore.Flight.UsesCasesExternalDTOs/"]
COPY ["NewShore.Flight.UsesCasesDTOs/NewShore.Flight.UsesCasesDTOs.csproj", "NewShore.Flight.UsesCasesDTOs/"]
COPY ["NewShore.Fliht.UseCases/NewShore.Flight.UseCases.csproj", "NewShore.Fliht.UseCases/"]
COPY ["NewShore.Flight.UseCasesPorts/NewShore.Flight.UseCasesPorts.csproj", "NewShore.Flight.UseCasesPorts/"]
COPY ["NewShore.Fligth.Presenters/NewShore.Fligth.Presenters.csproj", "NewShore.Fligth.Presenters/"]
COPY ["NewShore.Flight.WebExceptionsPresenter/NewShore.Flight.WebExceptionsPresenter.csproj", "NewShore.Flight.WebExceptionsPresenter/"]
COPY ["NowShore.Flight.Entities/NowShore.Flight.Entities.csproj", "NowShore.Flight.Entities/"]
COPY ["NewShore.Fligth.IoC/NewShore.Fligth.IoC.csproj", "NewShore.Fligth.IoC/"]
RUN dotnet restore "NewShore.Flight.WebApi/NewShore.Flight.WebApi.csproj"
COPY . .
WORKDIR "/src/NewShore.Flight.WebApi"
RUN dotnet build "NewShore.Flight.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NewShore.Flight.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewShore.Flight.WebApi.dll"]