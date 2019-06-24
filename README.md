# OpenFaceApi
dotnetcore 2.2 Web API for connection to an bamos/openface docker container

## Disclaimer: Ideally the Web API would be moved into the bamos/openface container. This is just a POC implementation that needs further refinement.

## Steps to Run

1. Install Docker for Windows
2. Pull the bamos/openface image

    `docker pull bamos/openface`

3. Run the container image as an instance

    `docker run -p 9000:9000 -p 8000:8000 -t -i bamos/openface /bin/bash`

4. Clone this repo.
5. Change the `@containerId` variable in the run_openface.bat file to the instance that you have just installed on your machine.
6. run `dotnet run` in the project directory
7. Hit the GET endpoint `https://localhost:5000/api/openface?searchterm={lennon*, clapton*}`
