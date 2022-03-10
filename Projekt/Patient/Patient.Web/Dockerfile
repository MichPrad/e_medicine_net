FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
LABEL stage=patient_build
WORKDIR /src
COPY ["Patient.Web/Patient.Web.csproj","Patient.Web/"]
COPY ["Patient.Tests/Patient.Tests.csproj","Patient.Tests/"]
RUN dotnet restore "Patient.Web/Patient.Web.csproj"
COPY . .
WORKDIR "/src/Patient.Web"
RUN dotnet build "Patient.Web.csproj" -c Release -o /app/build
RUN dotnet publish "Patient.Web.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Patient.Web.dll"]