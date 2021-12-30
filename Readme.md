**Reverse Proxy Server**

This project demonstrates the use of the NGINX server as a reverse proxy.

Swagger documentation is served from each API behind the proxy.

http://localhost:4200/api1/swagger/index.html

http://localhost:4200/api2/swagger/index.html

**How do I SSH into a running container**

1. Use docker ps to get the name of the existing container.
2. Use the command docker exec -it <container name> /bin/bash to get a bash shell in the container.
3. Generically, use docker exec -it <container name> <command> to execute whatever command you specify in the container.



Useful Linux commands to used when running cli from Container for NGINX.

Get IP address

```
ip a
```

View config file

```
cat /etc/nginx/nginx.conf
```

Check Nginx is running

```
ps aux | grep "[n|N]ginx"
```

Verify Port is open

```
netstat -tulpn | grep :80
```

View log files.

```
grep 'error' /var/log/nginx/error.log
tail -f /var/log/nginx/access.log 
```

> 
> 
> Other Info
> 
> https://www.nginx.com/resources/wiki/start/topics/examples/full/
> 
> https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-6.0