cd "C:\Program Files\Docker\Docker\resources\bin"

SET @searchTerm=%*

Docker.exe exec -it bc4f49e5cf7c /bin/bash -c "cd root/openface/;demos/compare.py images/examples/%@searchTerm%"