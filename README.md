# ConsumoAPI
Información técnica 

Acceso a las WebAPIs 

El acceso a las WebAPIs ser realiza mediante autenticación con usuario y clave, si la autenticación es correcta, la respuesta devuelve un Token JWT de acceso y su fecha de expiración en el caso de ser un usuario autenticado. Este token debe enviarse en la cabecera de cada Api que se consuma.  

 

Autenticación: 

El metodo api/Acceso/Acceso será del tipo POST, y recibirá como parámetro un objeto del tipo CredencialesUsuario (Usuario y Contraseña). La respuesta esperada será del tipo HTTP Status OK 200, devolviendo un objeto anónimo en formato Json con el Token JWT de acceso 

Parametro: 

CredencialesUsuario{ 

email, string 
	password, string 
 

} 

 

api/Acceso/Acceso 

curl -X 'POST' \ 

  'https://dominio/api/Acceso/Acceso' \ 

  -H 'accept: text/plain' \ 

  -H 'Content-Type: application/json-patch+json' \ 

  -d '{ 

"email": "user@example.com", 

"password": "string" 

  }' 

 

Respuesta: 

 

RespuestaAutDTO{ 

token		string 		nullable: true 

expiracion	string($date-time) 

roles	[...]	List(string) 

errorResp	string 		nullable: true 

} 

 

Si la respuesta retorna un HTTP status 200 debemos enviar el Token JWT de acceso al Web API en cada operación HTTP que realicemos. 

  

Para la integración de (… nombre del proyecto de encuestas) hemos expuesto una serie de webapis personalizadas con la información requerida.  

 

 

Stock por catálogo: 

 

api/Encuesta/StockxCatalogo 

curl -X 'POST' \ 
  'https://dominio/api/Encuesta/StockxCatalogo' \ 
  -H 'accept: text/plain' \ 
  -H 'Content-Type: application/json-patch+json' \ 
  -d '{ 
  	"fecha": "2023-08-11T20:43:53.864Z", 
  	"catalogo": "string" 
        }' 

 

Respuesta: 

{ 
  "stock": 0 
} 

 

Unidades vendidas sin accesorios 

 

api/Encuesta/UnidadesVendidasSinAccs 

 

curl -X 'POST' \ 
  	 'https://oliauto.dyndns.org:2088/api/Encuesta/UnidadesVendidasSinAccs' \ 
  	 -H 'accept: text/plain' \ 
  	 -H 'Content-Type: application/json-patch+json' \ 
  	 -d '{ 
  		"fecha": "2023-08-11T18:25:58.258Z" 
	     }' 

 

Respuesta: 

[  

{  

"prefijo": "string",  

"remito": 0,  

"operacion": "string",  

"documento": "string",  

"razonSocial": "string",  

"mail": "string",  

"telefono": "string",  

"provincia": "string",  

"vendedor": "string",  

"modelo": "string",  

"hrEntrega": "string",  

"comprometida": "string",  

"diasHabiles": 0,  

"gestAdm": "string",  

"diasGestAdm": 0,  

"encargado": "string",  

"accesorios": "string"  

}  

] 

 

Unidades vendidas 

 

api/Encuesta/UnidadesVendidas 

 

curl -X 'POST' \ 
  	'https://oliauto.dyndns.org:2088/api/Encuesta/UnidadesVendidas' \ 
  	-H 'accept: text/plain' \ 
  	-H 'Content-Type: application/json-patch+json' \ 
  	-d '{ 
  		"fecha": "2023-08-11T18:25:58.258Z" 
	     }' 

 

 

Respuesta: 

[ 

{ 

"prefijo": "string", 

"remito": 0, 

"operacion": "string", 

"documento": "string", 

"razonSocial": "string", 

"mail": "string", 

"telefono": "string", 

"provincia": "string", 

"vendedor": "string", 

"bocavta": "string", 

"vin": "string", 

"modelo": "string", 

"anioModelo": "string", 

"patente": "string", 

"fechaPatentamiento": "string", 

"fechaEntrega": "string", 

"hrEntrega": "string", 

"comprometida": "string", 

"diasHabiles": 0, 

"gestAdm": "string", 

"diasGestAdm": 0, 

"encargado": "string", 

"accesorios": "string" 

} 

] 

 

Ordenes cerradas 

 

Api/Encuesta/OrdenesCerradas 

 

Curl -X 'POST' \ 
  	'https://oliauto.dyndns.org:2088/api/Encuesta/OrdenesCerradas' \ 
  	-H 'accept: text/plain' \ 
  	-H 'Content-Type: application/json-patch+json' \ 
  	-d '{ 
  	"fecha": "2023-08-08T12:46:05.688Z" 
	}' 

 

Respuesta: 

[ 
  { 
    "codConcesionario": "string", 
    "vin": "string", 
    "modelo": "string", 
    "fechaCierre": "string", 
    "indicator": 0, 
    "apellidoTitular": "string", 
    "nombreTitula": "string", 
    "razonSocialTitular": "string", 
    "domicilio": "string", 
    "calleNro": "string", 
    "codPostal": "string", 
    "ciudad": "string", 
    "codPais": "string", 
    "telLaboral": "string", 
    "telPrivado": "string", 
    "telCelular": "string", 
    "codAsesor": "string", 
    "apellidoAsesor": "string", 
    "nombreAsesor": "string", 
    "fechaPatentamiento": "string", 
    "km": 0, 
    "tipoVisita": "string", 
    "mail": "string", 
    "nroOrdenReparacion": 0, 
    "fechaApertura": "string", 
    "recepcionTablet": "string" 
  } 
] 
