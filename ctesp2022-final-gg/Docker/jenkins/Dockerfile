FROM jenkins/jenkins:lts

ENV JENKINS_USER admin
ENV JENKINS_PASS admin

# Skip initial setup
ENV JAVA_OPTS -Djenkins.install.runSetupWizard=false

COPY plugins.txt /usr/share/jenkins/plugins.txt
RUN /usr/local/bin/install-plugins.sh < usr/share/jenkins/plugins.txt

USER root

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

#dind
RUN curl -L "https://github.com/docker/compose/releases/download/1.29.2/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose
RUN chmod +x /usr/local/bin/docker-compose
RUN ln -s /usr/local/bin/docker-compose /usr/bin/docker-compose
RUN apt install docker.io -y

RUN dotnet tool install dotnet-sonarscanner --global || true && export PATH="$PATH:/root/.dotnet/tools"