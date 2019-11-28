# Demo: Connecting App Service to Service Bus using a managed identity

This project is a demonstration of how to connect an App Service (function app) to a Service Bus queue. The connection is authenticated using a managed identity.

## Setup

Deploy the `deploy/template.json` ARM template first. This will provision all of the resources, including the [Service Bus role assignment](https://docs.microsoft.com/en-us/azure/service-bus-messaging/authenticate-application#built-in-rbac-roles-for-azure-service-bus). Note that this includes a role definition ID GUID, which is well-known and [documented here](https://docs.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#azure-service-bus-data-owner).

Once that has deployed, you can build and deploy the function app, then run it to publish a message into the Service Bus queue.

## Related links
 * [Authenticate a managed identity with Azure Active Directory to access Azure Service Bus resources](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-managed-service-identity)
 * [Sample application (not an App Service/Function app)](https://github.com/Azure/azure-service-bus/tree/master/samples/DotNet/Microsoft.ServiceBus.Messaging/RoleBasedAccessControl)
