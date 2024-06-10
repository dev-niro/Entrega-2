# Ferremax

## Entregables
Dentro de los entregables para cumplir la entrega tenemos los siguientes:
- API Clientes y Productos -> Hecha en C#
- API Entrega -> Hecha en Python Flask-Restful
- API Ventas -> Hecha en Python Flask-Restful
- Front -> Hecho con html, css, js.
- Documentación de los endpoints de cada una de las APIs.
- Listado de curls para el llenado de la API de clientes y productos, para así poder hacer pruebas.
- Colección de Postman.

# Documentación Endpoints
[Documentation](https://documenter.getpostman.com/view/34415114/2sA3XLEPcy)

# Listado de curls para llenado de API
## Clientes
```
curl --location 'http://localhost:27776/api/cliente' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Id": 1,
    "Rut": "20.900.351-1",
    "FirstName":"Nicolas",
    "LastName":"Moya Escobar",
    "Email":"n.moyae@duocuc.cl",
    "Address": "Manio 6425, La Granja"
}'
```
```
curl --location 'http://localhost:27776/api/cliente' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Id": 2,
    "Rut": "11.111.111-1",
    "FirstName":"Juan",
    "LastName":"Masa",
    "Email":"john.dough@outlook.com",
    "Address": "Los Leones 153, Providencia"
}'
```
```
curl --location 'http://localhost:27776/api/cliente' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Id": 3,
    "Rut": "1-1",
    "FirstName":"Pedro",
    "LastName":"Gomez",
    "Email":"pgomeza@gmail.com",
    "Address": "Lord Cochrane 1400, Santiago"
}'
```
## Productos
```
curl --location 'http://localhost:27776/api/producto' \
--header 'Content-Type: application/json' \
--data '{
    "Id":1,
    "Name":"Martillo",
    "Price":2990,
    "Description":"Martillo mango de goma, alta calidad.",
    "Stock":24
}'
```
```
curl --location 'http://localhost:27776/api/producto' \
--header 'Content-Type: application/json' \
--data '{
    "Id":2,
    "Name":"Destornillador",
    "Price":1790,
    "Description":"Destornillador de cruz.",
    "Stock":100
}'
```
```
curl --location 'http://localhost:27776/api/producto' \
--header 'Content-Type: application/json' \
--data '{
    "Id":3,
    "Name":"Pasta Muro",
    "Price":12990,
    "Description":"Pasta Muro al agua, 1 Kg.",
    "Stock":10
}'
```
