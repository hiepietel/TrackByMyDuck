variable "prefix" {
  type        = string
  description = "Team prefix"
}

variable "application" {
  type        = string
  description = "Application name"
}

variable "environment" {
  type        = string
  description = "Environment name"
}

variable "owner" {
  type        = string
  description = "Owner email"
}

variable "resource_group_name" {
  type        = string
  description = "RG Name"
}

variable "location" {
  type        = string
  description = "Azure region"
}

# variable "sql_user" {
#   type        = string
#   description = "Postgres DB username"
# }

# variable "sql_host" {
#   type        = string
#   description = "Postgres hostname"
# }

# variable "sql_password" {
#   type        = string
#   description = "Postgres DB password"
# }