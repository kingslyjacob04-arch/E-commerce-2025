import { nanoid } from 'nanoid';

export type CartType = {
    id: string;            // ✅ FIXED: string instead of number
    items: CartItem[];
}

export type CartItem = {
    productId: number;
    productName: string;
    price: number;
    quantity: number;
    pictureUrl: string;
    brand: string;
    type: string;
}

export class Cart implements CartType {
    id = nanoid();         // nanoid() is string → ✔ matches interface now
    items: CartItem[] = [];
}
