﻿using Atomia.Store.PublicBillingApi.Handlers;
using Atomia.Web.Plugin.OrderServiceReferences.AtomiaBillingPublicService;
using System.Collections.Generic;
using System.Linq;

namespace Atomia.Store.PublicOrderHandlers.CartItemHandlers
{
    public class RemovePostOrderHandler : OrderDataHandler
    {
        public virtual IEnumerable<string> HandledCategories
        {
            get { return new[] { "PostOrder" }; }
        }

        public override PublicOrder AmendOrder(PublicOrder order, PublicOrderContext orderContext)
        {
            var postOrderItems = orderContext.ItemData.Where(i => this.HandledCategories.Contains(i.Category));
            var orderItems = new List<PublicOrderItem>(order.OrderItems);

            foreach (var postOrderItem in postOrderItems)
            {
                var existingItem = ExistingOrderItem(order, postOrderItem);

                if (existingItem != null)
                {
                    orderItems.Remove(existingItem);
                }
            }

            order.OrderItems = orderItems.ToArray();

            return order;
        }
    }
}
