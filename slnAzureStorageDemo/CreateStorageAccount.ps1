#Inicie sesi�n en la suscripci�n de Azure con el comando Connect-AzAccount y siga las instrucciones que aparecen en pantalla para autenticarse

	Connect-AzAccount

#En primer lugar, cree un grupo de recursos con PowerShell mediante el comando New-AzResourceGroup:

	$resourceGroup = "ypfstorage_rg" 
	$location = "westus" 
	New-AzResourceGroup -Name $resourceGroup -Location $location

#Luego, para crear una cuenta de almacenamiento de uso general v2 con almacenamiento con redundancia local con acceso de lectura (RA-GRS), use el comando New-AzStorageAccount. Recuerde que el nombre de la cuenta de almacenamiento debe ser �nico en Azure, as� que reemplace el valor de marcador de posici�n entre corchetes por su propio valor �nico

	#New-AzStorageAccount -ResourceGroupName $resourceGroup ` -Name storageaccountypfdemo ` -Location $location ` -SkuName Standard_RAGRS ` -Kind StorageV2
	#Sin espacios: 
	New-AzStorageAccount -ResourceGroupName $resourceGroup -Name storageaccountypfdemo -Location $location -SkuName Standard_RAGRS -Kind StorageV2

#Para crear una cuenta de almacenamiento de uso general v2 con otra opci�n de replicaci�n, sustituya el valor deseado de la tabla siguiente por el par�metro SkuName
#Almacenamiento con redundancia local: (LRS) Standard_LRS 
#Almacenamiento con redundancia de zona: (ZRS) Standard_ZRS 
#Almacenamiento con redundancia geogr�fica: (GRS) Standard_GRS 
#Almacenamiento con redundancia geogr�fica con acceso de lectura: (GRS) Standard_RAGRS 
#Almacenamiento con redundancia de zona geogr�fica: (GZRS) (versi�n preliminar) Standard_GZRS 
#Almacenamiento con redundancia de zona geogr�fica con acceso de lectura (RA-GZRS) (versi�n preliminar): Standard_RAGZRS

#Eliminar cuenta de almacenamiento:
	Remove-AzStorageAccount -Name storageaccountypfdemo -ResourceGroupName  $resourceGroup 
