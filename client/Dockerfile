FROM node AS builder
WORKDIR /opt/fluffy-risk-client
COPY . .
RUN npm install
RUN npm run build:prod

FROM nginx
WORKDIR /var/www/fluffy-risk-client
COPY --from=builder /opt/fluffy-risk-client/dist/ .
COPY nginx.conf /etc/nginx/