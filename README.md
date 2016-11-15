# ArmManagement

This sample code is used for us to create a Azure ARM management project quickly. All AD application setting are existed in ADSettings.json.
We could find all values in AD application "ARMTemplate" in Azure portal. At currently this project support below function:

1. GetToken 
2. Get SQL Database info
3. Get Resource Group info

*Please note** we need to add "Windows Azure Service Management API" in portal "Required permissions" like the following screenshot:



and we need assign "Contributor" for this service principal:

  PS C:\Users\v-jayao> New-AzureRmRoleAssignment -RoleDefinitionName Contributor -ServicePrincipalName 'applicationID'
