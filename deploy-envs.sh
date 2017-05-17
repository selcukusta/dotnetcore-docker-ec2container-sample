#!/bin/bash
# set environment variables used in deploy.sh and AWS task-definition.json:
export IMAGE_NAME=netcore-sampleapp
export IMAGE_VERSION=latest

export AWS_DEFAULT_REGION=us-west-2
export AWS_ECS_CLUSTER_NAME=default
export AWS_VIRTUAL_HOST=34.210.194.241
