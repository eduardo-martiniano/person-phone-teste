#stage 1
FROM node:8.9.4 as node
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build 
#stage 2
FROM nginx:alpine
COPY --from=node /app/dist/teste-app /usr/share/nginx/html