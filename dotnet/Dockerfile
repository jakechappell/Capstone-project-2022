FROM mcr.microsoft.com/dotnet/sdk:5.0

COPY . .
# COPY dotnet/buildPortal.sh dotnet/buildPortal.sh
# COPY dotnet/dotnetEntry.sh dotnet/dotnetEntry.sh

# RUN apt-get update && \
    # apt-get install dos2unix && \
    # apt-get clean

# expose whatever port used to run the back-end swagger page
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT Development
EXPOSE 1433

WORKDIR /dotnet/Portal/Portal

# RUN dos2unix ./../../buildPortal.sh

RUN dotnet build "Portal.csproj"

WORKDIR /dotnet/Portal/Portal/bin/Debug/net5.0/

# RUN chmod +x ./../../dotnetEntry.sh

CMD [ "dotnet", "Portal.dll" ]
# CMD /bin/bash ./../../dotnetEntry.sh