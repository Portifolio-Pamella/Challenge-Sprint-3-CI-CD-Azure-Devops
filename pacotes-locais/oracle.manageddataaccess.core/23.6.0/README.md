![Oracle Logo](https://raw.githubusercontent.com/oracle/dotnet-db-samples/master/images/oracle-nuget.png) 
# Oracle.ManagedDataAccess.Core 23.6.0
Release Notes for Oracle Data Provider for .NET Core NuGet Package

September 2024

Oracle Data Provider for .NET (ODP.NET) Core features optimized ADO.NET data access to the Oracle database for .NET (Core) runtime. ODP.NET allows developers to take advantage of advanced Oracle database functionality, including AI vectors, Real Application Clusters, Application Continuity, JSON Relational Duality, and Fast Connection Failover. 

This document provides information that supplements the [Oracle Data Provider for .NET (ODP.NET) documentation](https://docs.oracle.com/en/database/oracle/oracle-database/23/odpnt/index.html).

## Oracle .NET Links
* [Oracle .NET Home Page](https://www.oracle.com/database/technologies/appdev/dotnet.html)
* [GitHub - Sample Code](https://github.com/oracle/dotnet-db-samples)
* [ODP.NET Discussion Forum](https://forums.oracle.com/ords/apexds/domain/dev-community/category/odp-dot-net)
* [YouTube](https://www.youtube.com/user/OracleDOTNETTeam)
* [X (Twitter)](https://twitter.com/oracledotnet)
* [Email Newsletter Sign Up](https://go.oracle.com/LP=28277?elqCampaignId=124071&nsl=onetdev)

## New Features
* Eliminate exception when using Transparent Application Failover (TAF) SELECT mode (starting with 23.5.1)
* BINARY Vector Support
* IsFloatingPointNumber Schema Table Column Support
* Data Source Allowed Parameters Support
* Allow UNC Paths Support
* OpenTelemetry: ActivitySource.Version Support
* OpenTelemetry: SQL Normalization Support
* OpenTelemetry: db.odp.user.statement Tag Support
* AutoProxy Support
* SSL-related OracleConnection Property Support
* Azure Credentials Support for Service Principal Authentication Flow 
* SQLNET.IGNORE_ANO_ENCRYPTION_FOR_TCPS Support

## Bug Fixes since Oracle.ManagedDataAccess.Core 23.5.0
* Bug 37054477 - KEEPALIVE: TURNING ON KEEPALIVE SUCCEEDED BUT NO KEEPALIVE PACKAGES ON LINUX
* Bug 37013827 - PROVIDER SPECIFIC TYPE OBJECTS' TOSTRING() METHODS ARE NOT SENSITIVE TO SESSION'S NLS FORMAT SETTINGS
* Bug 36937681 - ORA-00917 MISSING COMMA ERROR WHEN USING Ø CHARACTER WITH CHARACTER SET ZHS16GBK 
* Bug 36913251 - EXCEPTION THROWN WHEN ODPM/C 23AI CONFIGURED FOR TAF SELECT FAILOVER 
* Bug 36831777 - LDAP: SPACE BETWEEN DIRECTORY SERVERS IN DIRECTORY_SERVERS CAUSES ORA-12154
* Bug 36736236 - SETTING THE PORT WHEN USING NOTIFICATIONS CAUSES ORA-50050: THE NOTIFICATION LISTENER IS ALREADY STARTED
* Bug 36656255 - STATEMENT CACHING NOT PROPERLY HANDLING UNDERLYING TABLE CHANGES

 Copyright (c) 2024, Oracle and/or its affiliates. 
