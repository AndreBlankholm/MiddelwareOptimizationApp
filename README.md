# Middleware Optimization Application

.NET 9 ASP.NET Core application demonstrating middleware optimization and security enforcement patterns.

## Overview

Reference implementation for efficient middleware patterns focusing on security validation, input sanitization, and performance optimization.

## Architecture

Two middleware components in optimized pipeline:

### HTTPS Enforcement Middleware
- Validates `secure=true` query parameter to simulate HTTPS
- Blocks non-compliant requests with HTTP 400 response

### Input Validation Middleware  
- Sanitizes request parameters and detects XSS patterns
- Early rejection of invalid requests for performance optimization

## System Configuration

Kestrel server on port 5294 with 50 max connections and optimized timeouts.

## Usage

Start with `dotnet run` on `http://localhost:5294`

Test endpoints:
- `curl http://localhost:5294/` → HTTP 400 (missing secure parameter)
- `curl "http://localhost:5294/?secure=true&input=validdata"` → HTTP 200 (success)

## Technology Stack

- .NET 9 / ASP.NET Core / Kestrel / C# 12

## Pipeline Flow

1. Kestrel receives request
2. HTTPS enforcement validates `secure=true` parameter  
3. Input validation checks for XSS patterns
4. Application processes valid requests

## Key Features

- Optimized middleware pipeline with early request rejection
- Configurable security and performance parameters
- Comprehensive logging and error handling

## Customization

Extend validation in `IsValidInput()` function and adjust Kestrel limits in `appsettings.Development.json`

---

**Built with .NET 9 and ASP.NET Core**