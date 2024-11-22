export interface CheckoutCommand {
    originUrl: string;
    productId: string;
    productType: ProductType;
}

export interface CheckoutResultModel {
    orderId: string;
    urlCheckout: string;
}

export enum ProductType {
    Theme,
    SubcriptionPlan
}