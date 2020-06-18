FROM node:latest as angular
WORKDIR /app
COPY package.json /app
RUN npm install --silent
COPY .  .
RUN npm run build

FROM nginx:alpine as copafilmesApp
VOLUME /var/cache/nginx
COPY --from=angular app/dist/y /usr/share/nginx/html
COPY ./config/nginx.conf /etc/ngix/conf.d/default.conf
