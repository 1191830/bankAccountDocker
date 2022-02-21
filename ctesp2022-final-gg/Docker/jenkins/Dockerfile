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
RUN apt-get update
RUN apt-get -y install apt-transport-https ca-certificates curl gnupg2 software-properties-common
RUN curl -fsSL https://download.docker.com/linux/$(. /etc/os-release; echo "$ID")/gpg > /tmp/dkey;apt-key add /tmp/dkey
RUN add-apt-repository  "deb [arch=amd64] https://download.docker.com/linux/$(. /etc/os-release; echo "$ID") $(lsb_release -cs)  stable"
RUN apt-get update
RUN apt-get -y install docker-ce
RUN usermod -a -G docker jenkins

RUN dotnet tool install dotnet-sonarscanner --global || true && export PATH="$PATH:/root/.dotnet/tools"