FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
LABEL stage=medicalappointments_build
WORKDIR /src
COPY ["MedicalAppointments.Tests/MedicalAppointments.Tests.csproj","MedicalAppointments.Tests/"]
COPY ["MedicalAppointments.Domain/MedicalAppointments.Domain.csproj","MedicalAppointments.Domain/"]
COPY ["MedicalAppointments.Infrastructure/MedicalAppointments.Infrastructure.csproj","MedicalAppointments.Infrastructure/"]
COPY ["MedicalAppointments.Web/MedicalAppointments.Web.csproj","MedicalAppointments.Web/"]
RUN dotnet restore "MedicalAppointments.Web/MedicalAppointments.Web.csproj"
COPY . .
WORKDIR "/src/MedicalAppointments.Web"
RUN dotnet build "MedicalAppointments.Web.csproj" -c Release -o /app/build
RUN dotnet publish "MedicalAppointments.Web.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MedicalAppointments.Web.dll"]