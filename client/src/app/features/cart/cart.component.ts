import { Component, OnInit, inject } from '@angular/core';
import { CartService } from '../../core/services/cart.service';
import { CartItemComponent } from './cart-item/cart-item.component';
import { OrderSummaryComponent } from '../../shared/components/order-summary/order-summary.component';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CartItemComponent, OrderSummaryComponent],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent { 

  cartService = inject(CartService);

  // ngOnInit(): void { implements OnInit
  //   const id = localStorage.getItem('cart_id');
  //   if (id) {
  //     this.cartService.getCart(id).subscribe();
  //   }
  // }
}
