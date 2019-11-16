# cs-project
C# project
The pharmacy online application to automate business processes

There are 7 entities:
1) Doctor
2) Drug
3) Organization
4) Manufacturer
5) Patient
6) Order
7) Prescription

Dependencies:

Doctor has many patients
Patient has a one doctor

Drugs have many manufacturers
Manufacturers have many drugs

Organization has only one doctor
Doctor has only one organization

Doctor has own prescriptions for patients
An pharmacy also has own orders
