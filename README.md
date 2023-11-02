# ApiGestionCliente

### IDE
```
  - Visual Studio 2022 community 
```
### NuGet - Packages
```
  - Microsoft.EntityFrameworkCore.Sqlite 7.0.12
  - Swashbuckle.AspNetCore 6.5.0
```
### Base de datos
```
  - dbSqlite.db
```
### Marcos de trabajo
```
  - ASP NET Core Web API
  - Framework .NET 6.0
```  
### Postman
```
  - ApiGestionCliente.postman_collection.json
    - Crear (Post)
	  - Body
			{
			  "rut": "kkkkk",
			  "nombre": "kkkk",
			  "apePaterno": "kkk",
			  "apeMaterno": "kkk",
			  "email": "kkkkk@gmail.com",
			  "celular": "+56 9 97035764",
			  "empresa": "Sistemas Orion"
			}
	  - Headers
        - Key: Authorization
	    - Value: autorizado
	- Listar (Get)
	  - Todos
	    - https://localhost:7063/apiGesClient/get
	  - Por ID
		- https://localhost:7063/apiGesClient/get/1
    - Actualizar (PUT)
	  - Body
			{
			  "rut": "3.457.956-k",
			  "nombre": "Jaime",
			  "apePaterno": "Perez",
			  "apeMaterno": "Perez",
			  "email": "Jaime@gmail.com",
			  "celular": "+56 9 97356715",
			  "empresa": "Condominion platon"
			}
	  - Headers
        - Key: Authorization
	    - Value: autorizado
```  

