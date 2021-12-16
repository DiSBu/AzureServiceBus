# AzureServiceBus

# Introduction #
This repository has two main project for a Windows service that publish messages to Azure Service Bus (project PublisherService) and another Windows service to process those messages (project ConsumerService).

## Description of the Problem ##
There is a recurrent need to be able to integrate with other systems and that integration should be able to retry the operation if anything fails. 
The objective is to create a solution that uses a Queue Messaging system that can be used to integrate with any system whenever needed.

## Technologies Used ##
The target Queue Messaging system will be [Azure Service Bus Integration](https://docs.microsoft.com/es-mx/azure/service-bus-messaging/service-bus-dotnet-get-started-with-queues) and the development environment is Microsoft Visual Studio 2019. The libraries to conect to Azure Service Bus are implemented using the NetStandard 2.0 to be able to implement whenever needed.

# System Architecture #
## General Architecture ##
This is the general architecture for the system.<br>

![image](https://user-images.githubusercontent.com/36702379/146432870-745b7871-b2a4-4a60-90ca-4a5f5051c164.png)

<br>

# Project Structure #
## Common.AzureServiceBus project ##
This is the main project created in NetStandard 2.0 that should be implemented for utilizing Azure Service Bus Queue messaging capabilities.<br>

![0](https://user-images.githubusercontent.com/36702379/146426484-c88ac731-b97c-433a-9ab3-2c042ff3f804.jpg)

![1](https://user-images.githubusercontent.com/36702379/146426038-d20a9b4c-0a89-4a78-a1bf-8ae2eabeaed7.jpg)

![2](https://user-images.githubusercontent.com/36702379/146426087-b0cf4f16-1ba2-45e0-869d-90d4339439cd.jpg)


The project is divided in 2 main folders:<br>
Consumer folder: In consumer folder we have 3 main files <br>
- MessageConsumer: This class should be implemented to have Azure Service Bus message consuming capabilities.<br>
- MessageProcessor: This class should be implemented to have capability to process a message when an Azure Service Bus message is received in the MessageConsumer.<br>
- MessageExceptionHandler: This class should be implemented to have capability to handle any exception occurring during the processing of a message received in the MessageConsumer.<br>

Publisher folder:<br>
- MessagePublisher: This class should be implemented to provide Publishing message capability to Azure Service Bus. This is also can be used to Publish a new message when an exception occurred, and the operation should be for retry.


## PublisherService ##
This service will be responsible to run any Process and send messages to Azure Service Bus Topic.
The process will run at especifics intervals (configured by default each minute).

### Configuring Subscription to the Queue ###
The configurations are inyected in DIConfiguration.cs file as showned in below image <br>
![image](https://user-images.githubusercontent.com/36702379/146434928-c3554e77-6138-46b3-9d2f-704c7b0f1d97.png)

The PublisherService is configured by default to run each 1 minute, when it runs it will call Process method in Common.Services.PublisherService class.<br>
![image](https://user-images.githubusercontent.com/36702379/146434287-c4f55a91-7ed3-44c2-a8ca-4c3c6c6162df.png)

<br>

## ConsumerService ##
This service will be responsible to listen Azure Service Bus Queue for incoming messages, and to call any the existing Api endpoint.

### Configuring MessageConsumer, MessageProcessor and MessageExceptionHandler ###
The below images shows how to configure each implementation for MessageConsumer, MessageProcessor and MessageExceptionHandler<br>
Pay attention to MessageConsumer which is configured as AddHostedService, that means this will add the BackgroundService that will listen for incoming messages from Azure Service Bus.<br>
![image](https://user-images.githubusercontent.com/36702379/146436653-15b0d47d-0059-409f-ab44-dd6361f1de89.png)


### Configuring MessagePublisher ###
The below image shows how to configure the MessagePublisher. This is also used to Publish a new message when an exception occurred, and the operation should be for retry<br>
![image](https://user-images.githubusercontent.com/36702379/146436787-ab69005c-0b17-4a62-ae10-3e9fef01e31b.png)


### Sample implentation of MessageProcessor for ConsumerService ###
Below image shows the implentation of MessageProcessor for the current  ConsumerService<br>
![image](https://user-images.githubusercontent.com/36702379/146436541-7a2b6357-8194-408a-968a-bdbed4024263.png)

### Sample implentation of MessageExceptionHandle ###
Below image shows the implentation of MessageExceptionHandler for the current  ConsumerService<br>
![image](https://user-images.githubusercontent.com/36702379/146437165-2e1877f4-4a7f-4fc7-b69b-ed2728df2a20.png)

# How it works? #
There are two windows services created in .Net Core 3.1.

__PublisherService__: 

This service will be responsible to Process any needed logic and send the messages to Azure Service Bus Topic.
The process will run at especifics intervals (configured by default to run every minute).

__ConsumerService__: 

This service will be responsible to listen Azure Service Bus Queue for incoming messages, and to call any the existing Api endpoint.
 
# Flow diagram #
This is the general flow diagram for both services.

![image](https://user-images.githubusercontent.com/36702379/146437713-c248f344-1c42-4953-beb4-a69348086e4c.png)


