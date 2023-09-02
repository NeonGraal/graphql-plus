FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine

RUN apk update \
 && apk add git bash \
 && apk upgrade \
 && apk cache clean

ENV PATH="${PATH}:/root/.dotnet/tools"

RUN dotnet tool update -g docfx && \
    docfx --version

WORKDIR /docs
VOLUME [ "/docs" ]

ENTRYPOINT [ "docfx" ]
CMD [ "build" ]
