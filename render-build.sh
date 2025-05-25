#!/bin/bash

echo "🚀 Starting Render build process..."

# Environment variables check
echo "Checking environment variables..."
echo "DATABASE_URL: ${DATABASE_URL:0:20}..."
echo "PGHOST: $PGHOST"
echo "PGDATABASE: $PGDATABASE"
echo "PGUSER: $PGUSER"

# Build the Docker image
echo "Building Docker image..."
docker build -t agms-backend .

echo "✅ Build completed successfully!" 