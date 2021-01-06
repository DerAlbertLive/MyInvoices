type CustomerId = number;
type CompanyName = string;

type Customer = {
  id: CustomerId;
  companyName: CompanyName;
  name: Name;
  address: Address;
};

type Address = {
  street: string;
  zipCode: string;
  city: string;
  country: string;
};

type Name = {
  first: string;
  middle: string;
  family: string;
};
