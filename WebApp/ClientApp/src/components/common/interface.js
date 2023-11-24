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

export const NoteInformationForm = {
  annotationID: null,
  title: '',
  description: '',
  annotationTypeID: null
}

export const EventInformationForm = {
  eventID: null,
  title: '',
  date: new Date(),
  startTime: new Date(),
  endTime: new Date(),
  description: '',
  clientID: '',
  eventTypeID: ''
}