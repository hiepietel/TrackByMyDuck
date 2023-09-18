module "resource_group" {
  source = "./modules/resource_group"

  application = var.application
  environment = var.environment
  owner       = var.owner
  location    = var.location
  prefix      = var.prefix
}

module "web_app_api_nodb" {
  source = "./modules/web_app_api_nodb"

  prefix      = var.prefix
  application = var.application
  environment = var.environment
  owner       = var.owner

  resource_group_name = module.resource_group.resource_group_name
  location            = var.location

  # sql_user     = module.azurerm_mssql_server.sql_user
  # sql_password = module.azurerm_mssql_server.sql_password
  # sql_host     = module.azurerm_mssql_server.sql_host
}