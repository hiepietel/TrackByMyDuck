FROM node:15.4 as build

WORKDIR /app

COPY package*.json .
RUN npm install
COPY . .
RUN npm run build

FROM nginx:1.19

COPY ./nginx/nginx.conf /etc/nginx/nginx.conf
COPY --from=build /app/build /usr/share/nginx/html

#docker build -t track-by-my-duck-front-con .
#docker run -p :80 track-by-my-duck-front-con

#az login --use-device-code
#az acr login --name jptrackbymyduckdevcr.azurecr.io
#docker tag track-by-my-duck-front-con jptrackbymyduckdevcr.azurecr.io/app
#az acr update -n jptrackbymyduckdevcr --admin-enabled true
#docker push  jptrackbymyduckdevcr.azurecr.io/app