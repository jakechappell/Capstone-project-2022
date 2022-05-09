FROM mcr.microsoft.com/dotnet/sdk:5.0

# install NodeJS
RUN apt-get update -yq
RUN apt-get install curl gnupg -yq
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs

RUN npm install -g @vue/cli


COPY /vue /vue

EXPOSE 8080

WORKDIR /vue

RUN npm install

CMD ["npm", "run", "serve"]