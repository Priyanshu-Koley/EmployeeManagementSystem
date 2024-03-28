import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'EmployeeManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44359/',
    redirectUri: baseUrl,
    clientId: 'EmployeeManagement_App',
    responseType: 'code',
    scope: 'offline_access EmployeeManagement',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44359',
      rootNamespace: 'EmployeeManagement',
    },
  },
} as Environment;