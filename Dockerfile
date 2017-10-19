FROM microsoft/dotnet
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app
COPY . /usr/src/app
EXPOSE 50051
CMD [ "./out/sample-dotnet-grpc" ] 