type Project = {
  id: number;
  description: number;
  customerId: number;
  currency: string;
};

type ProjectRate = {
  projectId: number;
  productId: number;
  description: string;
  vatId: number;
  rate: number;
  active: boolean;
};

type Product = {
  id: number;
  description: string;
  productType: string;
  active: boolean;
  unit: string;
};

export { Product, Project, ProjectRate };
