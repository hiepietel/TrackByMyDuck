resource "azurerm_service_plan" "asp" {
  name                = "${var.prefix}-${var.application}-${var.environment}-asp"
  resource_group_name = var.resource_group_name
  location            = var.location
  os_type             = "Linux"
  sku_name            = "B1"

  tags = {
    application = var.application
    environment = var.environment
    owner       = var.owner
  }
}

resource "azurerm_linux_web_app" "webapp" {
  name                = "${var.prefix}-${var.application}-${var.environment}-api"
  resource_group_name = var.resource_group_name
  location            = var.location
  service_plan_id     = azurerm_service_plan.asp.id

  site_config {
    application_stack {
      dotnet_version = "6.0"  
    }   
    cors {
      allowed_origins = ["*"]
    }
  }

#   connection_string {
#   name = "DefaultConnection"
#   type = "SQLServer"
#   //value = "Server=${var.prefix}-${var.application}-${var.environment}-sqlserver-dev-1..database.azure.com;Database=postgres;Port=5432;User Id=postgres@${var.prefix}-${var.application}-${var.environment}-psql-dev-1;Password=Q1w2e3r4t5y6.;Ssl Mode=Require;Trust Server Certificate=true"
#   value = "Server=tcp:${var.prefix}-${var.application}-${var.environment}-mssql-dev-1.database.windows.net,1433;Initial Catalog=testdb;Persist Security Info=False;User ID=mssqluser;Password=Q1w2e3r4t5y6.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
#   }

#   app_settings = {
#     AppSettings__Token     = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"
#   }

  tags = {
    application = var.application
    environment = var.environment
    owner       = var.owner
  }
}