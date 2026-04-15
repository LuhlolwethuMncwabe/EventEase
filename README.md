CLDV
PART 1
YouTube Video

Cloud Computing Basics (qD)
1. Cloud deployed regarding security
Cloud providers such as Microsoft Azure and Amazon Web Services (AWS) operate under a Shared Responsibility Model. In this model, the provider secures the physical infrastructure, data centers, networking hardware, and the virtualization layer, while the customer is responsible for securing their data, application configuration, and access controls.

Azure, for example, employs enterprise-grade protections including AES-256 encryption at rest, DDoS (Distributed Denial of Service) mitigation, role-based access control (RBAC), multi-factor authentication (MFA), and continuous threat monitoring through Microsoft Defender for Cloud. These capabilities would be prohibitively expensive for most organizations to replicate internally.

 If EventEase were deployed on Microsoft Azure App Service (PaaS), Microsoft would manage OS-level patches, network firewalls, and physical data centre security. The EventEase development team would only be responsible for securing the application code and the customer data stored in the database. (SentinelOne, 2025)

On premises regarding security
Deployment an application in the cloud differs from deploying it on-premises as On-premises deployments give organizations complete control over their security posture. Every firewall rule, intrusion detection system, and access policy is configured and maintained by the internal IT team. Classified government systems or core banking applications often prefer this model precisely because no third party has any access to the infrastructure.

However, this control comes at significant cost. Security patches must be applied manually, and the organization bears full responsibility for staying ahead of evolving cyber threats. Smaller teams often struggle to maintain current security practices without the automated tooling that cloud providers offer by default. (GeeksforGeeks, 2025)

Aspect	On-premises deployment 	Cloud deployement
Responsibility	There is full responsibility the organization manages every layer.	There is a shared responsibility, the provider secured infrastructure and the customer secures the data.
Patch management 	This is manual, the IT team must apply and test all patches.	Automated by the provider.
Physical security	Organization fund and manage physical access controls	World class data center with biometric access and or guards 24/7
Threat monitoring 	Requires a committed security team and expensive tooling	Ongoing AI driven threat detection included
Example tool/s	On-site firewalls	Azure Security Centre
(Microsoft Build, 2026)


Deployment regarding speed
One of the most compelling advantages of cloud deployment is the speed at which infrastructure can be provisioned. With platforms like Azure App Service, a developer can deploy a fully configured web application complete with a database, load balancer, and SSL certificate in a matter of minutes using a few clicks or a CI/CD pipeline.

Microsoft Azure DevOps and GitHub Actions allow teams to automate the entire deployment pipeline. A code change pushed to the main branch can trigger an automated build, run tests, and deploy to production, all without human intervention. This practice, known as Continuous Integration / Continuous Deployment (CI/CD), is a defining feature of modern cloud development.
In EventEase a developer pushes a bug fix to GitHub. GitHub Actions automatically builds the EventEase application, runs unit tests, and deploys the updated version to Azure App Service, all within 3 to 5 minutes, with zero downtime using deployment slots. 



On premises regarding speed
On-premises deployments are significantly slower. Provisioning a new server requires procurement approval, hardware ordering (which can take a few weeks), physical installation, operating system configuration, security hardening, and application deployment. GeeksforGeeks notes that this process can take two to three months from initial recognition of need to production deployment.

This inflexibility forces organisations to over-provision, purchasing more hardware than is currently needed just in case demand spikes. Resources then sit idle at significant financial cost. (GeeksforGeeks, 2025)


Aspect	On-premises deployment 	Cloud deployement
New server provisioning 	Takes weeks to months to order the hardware and the physical set up	It takes minutes and is automated through cloud portal or API
Application deployment	Manual deployment scripts, downtime is often required 	Automated CI or CD pipelines.
Rollback	Fairly complex, as it requires manual intervention and potential downtime.	Instant rollback.
Geographic expansion	Requires a physical data center setup in the new location.	Deployed to a new region in minutes.
Example 	A Construction company setting up a new branch IT system in 3 months .	Azure App service deploys slot swap with zero downtime release.


Cloud regarding resource management 
Cloud computing operates on an elastic resource model. Resources like the CPU, RAM, storage, network bandwidth, scale automatically in response to demand. This is governed by auto-scaling rules defined by the developer. Azure, for example, uses Azure Monitor and Auto Scale to detect traffic spikes and provision additional instances of an application within seconds, then de-provision them when demand subsides.

The billing model reflects this elasticity: cloud resources follow an Operational Expenditure model. You pay only for what you use when you use it. There is no upfront capital investment required.

EventEase Example: Suppose EventEase goes live and hosts a popular concert event that sells 50,000 tickets in one hour. Azure App Service would automatically scale the application from 2 instances to 20 instances to handle the traffic spikes, then scale back down to 2 when demand normalizes with no developer intervention required.


On premises regarding resource management 
On-premises resource management is static by nature. Capacity must be planned and purchased in advance. If an organization underestimates demand, the system crashes. If it overestimates, expensive hardware sits idle consuming power and space. Scaler Topics notes that scaling on premises requires purchasing and deploying new hardware, which may result in over-provisioning or delays that directly hinder innovation. (GeeksforGeeks, 2025)

Aspect	On-premises deployment 	Cloud deployement
Scaling Model	Static, it has a fixed capacity determined by purchased hardware	Elastic. automatic scale up or down based on demand
Cost Model	CapEx a large upfront hardware and licensing cost	OpEx. A pay-as-you-go, no upfront investment
Idle resources 	Significant. Hardware runs and consumes power even when idle	None, unused capacity is not billed
Disaster recovery	Manual. Organization must build and test DR infrastructure	A built In, with redundant backups.
Example 	A retailer's server crashes on Black Friday due to fixed capacity	Azure auto scale takes care of black fridge traffic automatically


2. Infrastructure as a Service (IaaS)
Infrastructure as a service (IaaS) is a form of cloud computing that delivers on-demand IT infrastructure resources such as servers, virtual machines (VMs), compute, network and storage to consumers over the internet and on a pay-as-you-go basis. (Susnjara. S, Smalley. I, 2026)

 The provider manages:
1.	Physical servers, storage arrays, and networking hardware.
2.	Data centre facilities for power, cooling, physical security.
3.	Virtualisation layer.
What the Customer Manages:
1.	Operating system installation, configuration, and patching
2.	Middleware, runtime, and application frameworks
3.	Application code and data
4.	Network security groups, firewalls, and access controls

Azure IaaS Examples:
1.	Azure Virtual Machines
2.	Azure Virtual Network
3.	Azure Disk Storage
(GeeksforGeeks, 2026)
EventEase example (IaaS); Deploying EventEase on an Azure Virtual Machine running Windows Server 2022 with IIS. The team would install .NET 10, SQL Server, and IIS manually, configure the firewall, apply security patches, and manage the server. Full control, but full responsibility.



Platform as a Service (PaaS)
Platform as a service (PaaS) is a cloud computing model that provides developers with a platform to build, deploy, and manage applications without worrying about the underlying infrastructure. It allows developers to focus on writing code, while the cloud provider handles the infrastructure, maintenance, and scalability. (Microsoft, 2026)

What the Provider Manages:
1.	Everything IaaS manages, PLUS:
2.	Operating system as installation, patching, and upgrades
3.	Runtime environment (.NET, Node.js, Python, Java)
4.	Middleware like web servers, message queues, caching layers
5.	Automatic scaling, load balancing, and high availability

What the Customer Manages:
1.	Application code and business logic
2.	Data and database schema
3.	Application-level security and access control

Azure PaaS Examples:
1.	Azure App Service 
2.	Azure SQL Database 
3.	Azure Function
4.	Azure Service Bus


Deploying EventEase to Azure App Service. The team pushes code via GitHub Actions. Azure automatically provisions the .NET 10 runtime, configures IIS, scales instances during peak booking periods, applies OS patches, and provides built-in SSL certificates. The team writes code; Azure handles the rest.

Software as a Service (SaaS)
SaaS is a cloud-based software delivery model where individuals or organizations subscribe to applications rather than purchasing and installing them locally. Customers access software over the internet, typically through a web browser, while the cloud service provider manages the underlying infrastructure, security, maintenance, and updates. (Microsoft Azure, 2026)

What the Provider Manages:
1.	Everything IaaS and PaaS manage.
2.	The application itself, its features, updates, bug fixes.
3.	User interface and user experience
4.	All integrations and third-party connections

What the Customer Manages:
1.	User account settings and preferences
2.	Data entered into the application.
3.	Which users have access (basic user management)

SaaS Examples:
1.	Microsoft 365 (Word, Excel, Teams, Outlook).
2.	Salesforce CRM.
3.	Dropbox.
4.	Google Workspace.

EventEase SaaS Context: EventEase itself is not a SaaS product, it is a custom-built application. However, the EventEase team might USE SaaS products as part of their operations, for example, using Microsoft 365 for team communication, or a SaaS email service like SendGrid for booking confirmation emails.

Why it’s better for EventEase to use PaaS when moving to the cloud?
When EventEase eventually moves from localhost to the cloud, PaaS, specifically Azure App Service is the most appropriate service model for these five reasons:

1. Azure App Service was built with ASP.NET Core in mind. It natively supports .NET 10 (the version EventEase is built on), automatically configures IIS, and integrates directly with GitHub Actions for CI/CD deployment. The development team can deploy EventEase with a single git push no server configuration required. (Microsoft Learn, 2026)
2. With IaaS, the EventEase team would need to install .NET 10, configure IIS, apply Windows Server patches, manage SSL certificates, and monitor server health none of which contributes to building the application. PaaS eliminates this overhead entirely. As Microsoft Azure states, PaaS allows developers to concentrate on writing code and managing data, while the provider handles all the infrastructure and runtime details. (Microsoft Azure, 2026)
3. EventEase currently uses SQL Server LocalDB. Azure SQL Database (a PaaS offering) is the direct cloud equivalent it uses the same T-SQL syntax, supports Entity Framework Core migrations, and requires zero changes to the EventEase application code beyond a connection string update in appsettings.json. It also provides automated backups, point-in-time restore, and 99.99% uptime SLA capabilities that LocalDB cannot offer.
4. EventEase handles event bookings, a workload that is inherently unpredictable. When a popular event goes on sale, thousands of users may simultaneously try to book seats. Azure App Service automatically scales horizontally (adding more application instances) in response to traffic, then scales back down when demand subsides. With IaaS, the team would need to configure and manage this scaling manually. 
5. SaaS would not be suitable for EventEase because EventEase is a custom-built application, SaaS only delivers pre-built software, not a platform for deploying your own application. IaaS would be unnecessarily expensive, and complex given that the team has no need to manage the operating system or server infrastructure. PaaS sits in the optimal position: low operational overhead, full application control, and a pay-as-you-go pricing model that scales affordably as EventEase grows from a student project to a production system.

In conclusion EventEase should adopt PaaS, Azure App Service and Azure SQL Database, when moving to the cloud because it is an ASP.NET Core application that benefits directly from managed .NET hosting, automated scaling, seamless SQL migration, and zero infrastructure management overhead, allowing the team to focus entirely on improving the application rather than maintaining servers. (Wright. N, 2019)


References

GeeksforGeeks, 2025. AWS vs On-Premise Servers: Why Cloud is the Future [online] Available at: AWS vs On-Premise Servers: Why Cloud is the Future - GeeksforGeeks (Accessed 14 April 2026)
 
GeeksforGeeks, 2026. IaaS - Infrastructure as a Service [online] Available at: IaaS - Infrastructure as a Service - GeeksforGeeks (Accessed 14 April 2026)

GeeksforGeeks, 2025. On Premises VS On Cloud [online] Available at: On Premises VS On Cloud - GeeksforGeeks (Accessed 14 April 2026)
Microsoft Azure, 2026. What are IaaS, PaaS, and SaaS? [online] Available at: online] Available at: What is Software as a Service (SaaS)? | Microsoft Azure Accessed 14 April 2026)

Microsoft Azure, 2026. What is platform as a service (PaaS)? [online] Available at: online] Available at: On Premises VS On Cloud - GeeksforGeeks (Accessed 14 April 2026)

Microsoft Azure, 2026. What is software as a service (SaaS)? [online] Available at: online] Available at: What is Software as a Service (SaaS)? | Microsoft Azure Accessed 14 April 2026)

Microsoft Learn, 2026. Microsoft build 2026 [online] Available at: Azure App Service documentation - Azure App Service | Microsoft Learn Accessed 14 April 2026)

Microsoft Build, 2026. Shared responsibility in the cloud [online] Available at: Shared responsibility in the cloud - Microsoft Azure | Microsoft Learn (Accessed 14 April 2026)

SentinelOne, 2025. Cloud vs On-premises Security: 6 Critical Differences [online] Available at: Cloud vs On-premise Security: 6 Critical Differences (Accessed 14 April 2026)

Susnjara. S, Smalley. I, 2026) What is infrastructure as a service (IaaS)? [online] IBM Available at: What Is Infrastructure as a Service? | IBM (Accessed 14 April 2026)
	
Wright. N, 2019.  IaaS vs SaaS vs PaaS: A guide to Azure cloud service types [online] Tenth Revolution Available at: IaaS vs SaaS vs PaaS: A guide to Azure cloud service types | Nigel Frank ( 14 April 2026).

