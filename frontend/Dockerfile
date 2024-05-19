FROM node:lts-alpine

EXPOSE 5173

WORKDIR /app

COPY package*.json ./

RUN npm install

ENV REACT_APP_BASE_URL=http://localhost:8000/api/marsrover/download-images

COPY . .

CMD [ "npm", "run", "dev" ]