import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'EmployeeManagementSystem',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44320/',
    redirectUri: baseUrl,
    clientId: 'EmployeeManagementSystem_App',
    responseType: 'code',
    scope: 'offline_access EmployeeManagementSystem',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44320',
      rootNamespace: 'EmployeeManagementSystem',
    },
  },
} as Environment;
