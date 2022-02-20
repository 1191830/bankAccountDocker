FROM sonarqube:7.7-community

USER root

ENV SONAR_SCANNER_MSBUILD_VERSION=5.3.2.38712 \
    DOTNETCORE_SDK=5.0.403 \
    DOTNETCORE_RUNTIME=5.0.12 \
    NETAPP_VERSION=net5.0 \
    DOCKER_VERSION=5:20.10.10~3-0~debian-buster \
    CONTAINERD_VERSION=1.4.11-1 \
    OPENJDK_VERSION=11 \
    NODEJS_VERSION=16

# Linux update
RUN apt-get update \
    && apt-get dist-upgrade -y \
    && apt-get install -y \
        apt-transport-https \
        ca-certificates \
        curl \
        gnupg-agent \
        software-properties-common

RUN mkdir -p /usr/share/man/man1mkdir -p /usr/share/man/man1

# Install dependencies
RUN apt-get update \
 && apt-get install wget unzip zip -y
RUN apt-get install wget
RUN wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN rm packages-microsoft-prod.deb

# Install .NET SDK 5.0
RUN apt-get update; 
RUN apt-get install -y apt-transport-https
RUN apt-get update
RUN apt-get install -y dotnet-sdk-5.0
RUN dotnet --version

# Install Sonar Scanner
RUN apt-get install -y unzip \
    && wget https://github.com/SonarSource/sonar-scanner-msbuild/releases/download/5.3.2.38712/sonar-scanner-msbuild-5.3.2.38712-net5.0.zip \
    && unzip sonar-scanner-msbuild-5.3.2.38712-net5.0.zip -d /sonar-scanner \
    && rm sonar-scanner-msbuild-5.3.2.38712-net5.0.zip.zip \
    && chmod +x -R /sonar-scanner

# Cleanup
RUN apt-get -q autoremove \
    && apt-get -q clean -y \
    && rm -rf /var/lib/apt/lists/* /var/cache/apt/*.bin