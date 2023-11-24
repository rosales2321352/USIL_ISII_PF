export const ClientForm = {
  personID: null,
  name: '',
  phoneNumber: '',
  email: '',
  companyID: null,
  clientStatusID: null,
  WhatsappID: null,
}

export const CompanyForm = {
  companyID: null,
  name: '',
  ruc: '',
  address: '',
  email: '',
}

export const ClientInformationForm = {
  ...ClientForm,
  ...CompanyForm
}