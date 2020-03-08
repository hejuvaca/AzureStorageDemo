#Inicie sesión en la suscripción de Azure con el comando Connect-AzAccount y siga las instrucciones que aparecen en pantalla para autenticarse

	Connect-AzAccount

#En primer lugar, cree un grupo de recursos con PowerShell mediante el comando New-AzResourceGroup:

	$resourceGroup = "ypfstorage_rg" 
	$location = "westus" 
	New-AzResourceGroup -Name $resourceGroup -Location $location

#Luego, para crear una cuenta de almacenamiento de uso general v2 con almacenamiento con redundancia local con acceso de lectura (RA-GRS), use el comando New-AzStorageAccount. Recuerde que el nombre de la cuenta de almacenamiento debe ser único en Azure, así que reemplace el valor de marcador de posición entre corchetes por su propio valor único

	#New-AzStorageAccount -ResourceGroupName $resourceGroup ` -Name storageaccountypfdemo ` -Location $location ` -SkuName Standard_RAGRS ` -Kind StorageV2
	#Sin espacios: 
	New-AzStorageAccount -ResourceGroupName $resourceGroup -Name storageaccountypfdemo -Location $location -SkuName Standard_RAGRS -Kind StorageV2

#Para crear una cuenta de almacenamiento de uso general v2 con otra opción de replicación, sustituya el valor deseado de la tabla siguiente por el parámetro SkuName
#Almacenamiento con redundancia local: (LRS) Standard_LRS 
#Almacenamiento con redundancia de zona: (ZRS) Standard_ZRS 
#Almacenamiento con redundancia geográfica: (GRS) Standard_GRS 
#Almacenamiento con redundancia geográfica con acceso de lectura: (GRS) Standard_RAGRS 
#Almacenamiento con redundancia de zona geográfica: (GZRS) (versión preliminar) Standard_GZRS 
#Almacenamiento con redundancia de zona geográfica con acceso de lectura (RA-GZRS) (versión preliminar): Standard_RAGZRS

#Eliminar cuenta de almacenamiento:
	Remove-AzStorageAccount -Name storageaccountypfdemo -ResourceGroupName  $resourceGroup 
