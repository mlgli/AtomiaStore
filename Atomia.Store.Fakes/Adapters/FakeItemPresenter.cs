﻿using Atomia.Store.Core;
using System.Linq;

namespace Atomia.Store.Fakes.Adapters
{
    public class FakeItemPresenter: IItemPresenter
    {
        public string GetName(IPresentableItem item)
        {
            if (item.ArticleNumber.StartsWith("DMN-"))
            {
                var domainNameAttr = item.CustomAttributes.FirstOrDefault(ca => ca.Name == "DomainName");
                
                if (domainNameAttr != default(CustomAttribute)) {
                    return domainNameAttr.Value;
                }
            }

            return item.ArticleNumber;
        }

        public string GetDescription(IPresentableItem item)
        {
            return "Description of " + item.ArticleNumber;
        }
    }
}