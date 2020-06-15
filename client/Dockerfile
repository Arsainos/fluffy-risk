FROM node AS builder
WORKDIR /opt/fluffy-risk-client
COPY ./package.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx
RUN rm /etc/nginx/conf.d/default.conf
COPY ./nginx/default.conf /etc/nginx/conf.d/default.conf
COPY --from=builder /opt/fluffy-risk-client/build/ /usr/share/nginx/html
CMD /bin/bash -c "envsubst '\$PORT' < /etc/nginx/conf.d/default.conf > /etc/nginx/conf.d/default.conf" && nginx -g 'daemon off;'