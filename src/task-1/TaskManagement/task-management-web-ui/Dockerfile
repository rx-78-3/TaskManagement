FROM node:20.17.0 AS build
WORKDIR /app
EXPOSE 80

COPY package*.json ./
RUN npm install

# Copy the source code to the container.
COPY . .

# Install env variables via ARG
ARG REACT_APP_TASKS_API_BASE_URL
ENV REACT_APP_TASKS_API_BASE_URL=${REACT_APP_TASKS_API_BASE_URL}

RUN npm run build

# Use Nginx image to serve the static files.
FROM nginx:alpine
# Copy the build output to replace the default Nginx contents.
COPY --from=build /app/build /usr/share/nginx/html

# Run Nginx server.
CMD ["nginx", "-g", "daemon off;"]